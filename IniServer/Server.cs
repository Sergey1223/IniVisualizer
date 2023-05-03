using IniServer.Repository;
using IniVisualizer.Shared.Packages;
using Shared.Packages.Exeption;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace IniServer
{
    internal class Server
    {
        private const int BUFFER_SIZE = 2048;

        private readonly IPEndPoint endPoint = new IPEndPoint(
            IPAddress.Parse(Properties.Settings.Default.ServerIp),
            Properties.Settings.Default.ServerPort);

        private TcpListener socket;
        private TcpClient client;
        private NetworkStream clientStream;
        private CancellationTokenSource listeningCancellationSource;
        private GenerableDataSource<CarEntityModel> dataSource;
        private readonly byte[] buffer;
        private bool isActive;

        internal bool SimulationIsActive
        {
            get
            {
                return dataSource != null && dataSource.SimulationIsActive;
            }
        }

        internal Server()
        {
            buffer = new byte[BUFFER_SIZE];
            isActive = false;
        }

        internal void Start()
        {
            if (socket != null)
            {
                throw new ServerException("Server is already running.", null);
            }

            Array.Clear(buffer, 0, buffer.Length);

            isActive = true;

            socket = new TcpListener(endPoint);
            socket.Start();

            BeginClientAccept();
        }

        internal void Stop()
        {
            // Server already stopped
            if (socket == null)
            {
                return;
            }

            listeningCancellationSource.Cancel();

            dataSource.StopSimulation();

            if (clientStream != null)
            {
                clientStream.Close();
            }

            isActive = false;

            socket.Stop();
            socket = null;
        }

        private void BeginClientAccept()
        {
            if (socket == null)
            {
                throw new ServerException("Socket is unavailable.", null);
            }

            socket.BeginAcceptTcpClient(OnClientAccepted, socket);
        }

        private void OnClientAccepted(IAsyncResult result)
        {
            // Server disabled or client disconeccted
            if (!isActive || !socket.Server.IsBound)
            {
                return;
            }

            TcpClient tcpClient = socket.EndAcceptTcpClient(result);
            clientStream = tcpClient.GetStream();
            listeningCancellationSource = new CancellationTokenSource();

            Listen(client, listeningCancellationSource.Token);
        }

        private void Listen(TcpClient client, CancellationToken cancellationToken)
        {
            byte[] buffer = new byte[BUFFER_SIZE];

            // Reading request
            clientStream.BeginRead(buffer, 0, buffer.Length, OnRead, null);
        }

        private void OnRead(IAsyncResult result)
        {
            if (!isActive)
            {
                return;
            }

            // Reading request

            int count = clientStream.EndRead(result);
            byte[] rawSequence = new byte[count];

            Array.Copy(buffer, 0, rawSequence, 0, count);
            Array.Clear(buffer, 0, count);

            // Client disconnected
            if (count == 0)
            {
                // Starting new connection establishing
                socket.BeginAcceptTcpClient(OnClientAccepted, socket);

                return;
            }

            byte[] responseSequence = null;

            if (!SimulationIsActive)
            {
                ExceptionResponsePackage response = new ExceptionResponsePackage(
                    new ExceptionResponseBody("Simulation is not active."));

                responseSequence = response.ToBytes();
            }
            else if (Utils.TryReadPackage(rawSequence, out byte[] packageSequence))
            {
                byte? type = Utils.GetPackageType(packageSequence);

                if (type == DataTableRequestPackage.TYPE)
                {
                    DataTableRequestPackage request = new DataTableRequestPackage(packageSequence);

                    dataSource.ApplySort(request.Body.SortColumnIndex, request.Body.SortOrder);

                    List<List<string>> frame = new List<List<string>>(request.Body.Count);
                    IEnumerable<CarEntityModel> data = dataSource.GetRange(request.Body.Offset, request.Body.Count);

                    foreach (CarEntityModel car in data)
                    {
                        List<string> row = new List<string>
                        {
                            car.Id.ToString(),
                            car.Number.Value.ToString(),
                            car.XPosition.Value.ToString(),
                            car.YPosition.Value.ToString(),
                            car.FuelAmount.Value.ToString(),
                            car.TyresWear.Value.ToString(),
                            car.IsActive.Value.ToString()
                        };

                        frame.Add(row);
                    }

                    DataTableResponsePackage response = new DataTableResponsePackage(new DataTableResponseBody(dataSource.Count, frame));

                    responseSequence = response.ToBytes();
                }
            }

            else
            {
                ExceptionResponsePackage response = new ExceptionResponsePackage(
                    new ExceptionResponseBody("Unable to read request package."));

                responseSequence = response.ToBytes();
            }

            // Writing response
            clientStream.BeginWrite(responseSequence, 0, responseSequence.Length, OnWrited, null);
        }

        private void OnWrited(IAsyncResult result)
        {
            clientStream.EndWrite(result);

            // Reading request
            clientStream.BeginRead(buffer, 0, buffer.Length, OnRead, null);
        }

        internal void StartSimulation(int? capacity = null, int? capacityDelta = null, int? operationsCount = null, int? interval = null)
        {
            if (dataSource == null)
            {
                dataSource = new GenerableDataSource<CarEntityModel>(capacity, capacityDelta, operationsCount, interval);

                dataSource.GenerateData();
            }

            dataSource.StartSimulation();
        }

        internal void StopSimulation(int? capacity = null, int? capacityDelta = null, int? operationsCount = null, int? interval = null)
        {
            dataSource.StopSimulation();
        }
    }
}
