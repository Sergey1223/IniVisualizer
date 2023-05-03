using IniClient.Model;
using IniVisualizer.Shared.Packages;
using Shared.Packages.Exeption;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace IniClient
{
    internal class Client
    {
        private const int UPDATING_INTERVAL = 1000;
        private const int BUFFER_SIZE = 2048;

        private readonly byte[] buffer;
        
        private TcpClient socket;
        private NetworkStream stream;
        private Task updatingTask;
        private CancellationTokenSource updatingCancellationSource;
        private bool needNotifyUpdate;
        private bool updatingIsActive;

        internal delegate void ClientConnectedEventHandler(ClientConnectionEventArgs eventArgs);
        internal event ClientConnectedEventHandler Connected;

        internal delegate void ClientDisconnectedEventHandler(ClientConnectionEventArgs eventArgs);
        internal event ClientDisconnectedEventHandler Disconnected;

        internal delegate void ClientUpdatedEventHandler(ClientUpdatedEventArgs eventArgs);
        internal event ClientUpdatedEventHandler Updated;

        private State State { get; set; }

        internal Client()
        {
            buffer = new byte[BUFFER_SIZE];
            needNotifyUpdate = true;
        }

        internal void Connect()
        {
            if (socket == null)
            {
                socket = new TcpClient();

                updatingCancellationSource = new CancellationTokenSource();
            }

            updatingCancellationSource = new CancellationTokenSource();

            socket.BeginConnect(
                IPAddress.Parse(Properties.Settings.Default.ServerIp),
                Properties.Settings.Default.ServerPort,
                OnConnected,
                null);
        }

        internal void Disconnect()
        {
            // Client already disconnected
            if (socket == null)
            {
                return;
            }

            bool isSuccessful = false;
            string errorMessage = null;

            try
            {
                StopUpdating();

                stream.Close();
                
                socket.Close();
                socket = null;

                isSuccessful = true;
            }
            catch (SocketException e)
            {
                isSuccessful = false;

                Debug.WriteLine(e.Message);

                errorMessage = e.Message;
            }
            finally {
                Disconnected?.Invoke(new ClientConnectionEventArgs(isSuccessful, errorMessage));
            }
        }

        internal void Update(State state)
        {
            if (!updatingTask.IsCompleted)
            {
                needNotifyUpdate = false;
            }

            updatingTask.Wait();

            needNotifyUpdate = true;

            State = state;

            updatingTask = Task.Run(() => UpdateInternal());
        }

        internal void StartUpdating(State state)
        {
            updatingCancellationSource = new CancellationTokenSource();

            updatingIsActive = true;

            Task.Run(() => StartUpdatingInternal(state));
        }

        internal void StopUpdating()
        {
            updatingCancellationSource.Cancel();

            updatingIsActive = false;
        }

        private void OnConnected(IAsyncResult result)
        {
            bool isSuccessful = false;
            string message = null;

            try
            {
                socket.EndConnect(result);

                isSuccessful = true;

                stream = socket.GetStream();

            }
            catch (SocketException e)
            {
                Debug.WriteLine(e.Message);

                message = e.Message;
            }

            Connected?.Invoke(new ClientConnectionEventArgs(isSuccessful, message));
        }

        private void StartUpdatingInternal(State state)
        {
            State = state;

            while (updatingIsActive)
            {
                if (updatingTask != null && !updatingTask.IsCompleted)
                {
                    updatingTask.Wait();
                }

                updatingTask = Task.Run(() => UpdateInternal());

                updatingTask.Wait();

                Thread.Sleep(UPDATING_INTERVAL);
            }
        }

        private void UpdateInternal()
        {
            // Update is cancelled.
            if (updatingCancellationSource.IsCancellationRequested)
            {
                return;
            }

            // Writing request

            DataTableRequestBody body = new DataTableRequestBody(State.Offset, State.Count, State.SortColumnIndex, State.SortOrder);
            DataTableRequestPackage requestPackage = new DataTableRequestPackage(body);
            byte[] sequence = requestPackage.ToBytes();

            stream.BeginWrite(sequence, 0, sequence.Length, OnWrited, null);
        }

        private void OnWrited(IAsyncResult result)
        {
            // Update is cancelled.
            if (updatingCancellationSource.IsCancellationRequested)
            {
                return;
            }

            stream.EndWrite(result);

            // Reading response
            stream.BeginRead(buffer, 0, buffer.Length, OnRead, null);
        }

        private void OnRead(IAsyncResult result)
        {
            // Update is cancelled.
            if (updatingCancellationSource.IsCancellationRequested)
            {
                return;
            }

            int count = stream.EndRead(result);
            byte[] rawSequence = new byte[count];

            Array.Copy(buffer, 0, rawSequence, 0, count);
            Array.Clear(buffer, 0, count);

            if (Utils.TryReadPackage(rawSequence, out byte[] packageSequence))
            {
                byte? type = Utils.GetPackageType(packageSequence);

                switch (type)
                {
                    case DataTableResponsePackage.TYPE:
                        DataTableResponsePackage response = new DataTableResponsePackage(packageSequence);
                        CarEntityModelList entity = new CarEntityModelList(response.Body.TotalCount, response.Body.Frame);

                        if (needNotifyUpdate && Updated != null)
                        {
                            Updated.Invoke(new ClientUpdatedEventArgs(true, entity));
                        }

                        return;
                    case ExceptionResponsePackage.TYPE:
                        ExceptionResponsePackage exception = new ExceptionResponsePackage(packageSequence);
                        ExceptionEntityModel exceptionModel = new ExceptionEntityModel(exception.Body.Message);

                        if (needNotifyUpdate && Updated != null)
                        {
                            Updated.Invoke(new ClientUpdatedEventArgs(false, exceptionModel));
                        }

                        return;
                    default:
                        break;
                }
            }
        }
    }
}
