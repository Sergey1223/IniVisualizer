using IniClient.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IniClient
{
    public partial class MainForm : Form
    {
        private const string CONNECT_BUTTON_TEXT = "Connect";
        private const string CONNECTED_LABEL_TEXT = "Connected";
        private const string DISCONNECT_BUTTON_TEXT = "Disconnect";
        private const string DISCONNECTED_LABEL_TEXT = "Disconnected";
        private const string SERVER_UNAVAILABLE_LABEL_TEXT = "Server is unavailable, try again.";
        private const string SERVER_UNABLE_TO_DISCONNECT_LABEL_TEXT = "Unable to disconnect, try again.";
        private const int ROWS_COUNT = 15;
        private const int DEFAULT_SORT_COLUMN_INDEX = 1;

        private Client client;
        private int sortColumnIndex;
        private bool isConnected;

        public MainForm()
        {
            InitializeComponent();

            Initialize();
        }

        private void OnClientSwitchingButtonClick(object sender, EventArgs e)
        {
            clientSwithingButton.Enabled = false;

            if (client == null)
            {
                client = new Client();

                client.Connected += OnClientConnected;
                client.Disconnected += OnClientDisconnected;
                client.Updated += OnClientUpdated;
            }

            if (!isConnected)
            {
                client.Connect();
            }
            else
            {
                client.Disconnect();
            }
        }

        private void OnTableScrollBarValueChanged(object sender, EventArgs e)
        {
            client.Update(GetState());
        }

        private void OnDataTableColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Excluding first column (row number)
            if (e.ColumnIndex > 0)
            {
                sortColumnIndex = e.ColumnIndex;

                client.Update(GetState());
            }
        }

        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                client.Disconnect();

                client.Connected -= OnClientConnected;
                client.Disconnected -= OnClientDisconnected;
                client.Updated -= OnClientUpdated;
            }
        }

        private void Initialize()
        {
            isConnected = false;

            // Column "Number"
            sortColumnIndex = DEFAULT_SORT_COLUMN_INDEX;

            for (int i = 0; i < ROWS_COUNT; i++)
            {
                dataTable.Rows.Add();
            }
        }

        private void OnClientConnected(ClientConnectionEventArgs e)
        {
            string labelText;
            Color color;
            
            if (e.IsSuccessful)
            {
                labelText = CONNECTED_LABEL_TEXT;
                color = Color.Green;

                clientSwithingButton.Invoke(new Action(() => clientSwithingButton.Text = DISCONNECT_BUTTON_TEXT));
                dataTableScrollBar.Invoke(new Action(() => dataTableScrollBar.Enabled = true));

                client.StartUpdating(GetState());

                isConnected = true;
            }
            else
            {
                labelText = SERVER_UNAVAILABLE_LABEL_TEXT;
                color = Color.Red;
            }

            statusValueLabel.Invoke(new Action(() =>
            {
                statusValueLabel.Text = labelText;
                statusValueLabel.ForeColor = color;
            }));

            clientSwithingButton.Invoke(new Action(() => clientSwithingButton.Enabled = true));
        }

        private void OnClientDisconnected(ClientConnectionEventArgs e)
        {
            string labelText;
            Color color;

            if (e.IsSuccessful)
            {
                labelText = DISCONNECTED_LABEL_TEXT;
                color = Color.Black;

                clientSwithingButton.Invoke(new Action(() => clientSwithingButton.Text = CONNECT_BUTTON_TEXT));
            }
            else
            {
                labelText = SERVER_UNABLE_TO_DISCONNECT_LABEL_TEXT;
                color = Color.Red;
            }

            statusValueLabel.Invoke(new Action(() =>
            {
                statusValueLabel.Text = labelText;
                statusValueLabel.ForeColor = color;
            }));

            clientSwithingButton.Invoke(new Action(() => clientSwithingButton.Enabled = true));

            isConnected = false;
        }

        private void OnClientUpdated(ClientUpdatedEventArgs e)
        {
            if (e.IsSuccessful)
            {
                if (errorLabel.Visible)
                {
                    errorLabel.Invoke(new Action(() => errorLabel.Visible = false));
                }

                CarEntityModelList modelList = (CarEntityModelList)e.Model;

                dataTableScrollBar.Invoke(new Action(() => dataTableScrollBar.Maximum = ((CarEntityModelList)e.Model).TotalCount - ROWS_COUNT));

                dataTable.Invoke(new Action(() => UpdateTable(e)));
            }
            else
            {
                errorLabel.Invoke(new Action(() => {
                    errorLabel.Text = ((ExceptionEntityModel)e.Model).Message;
                    errorLabel.Visible = true;
                }));
            }
        }

        private void UpdateTable(ClientUpdatedEventArgs e)
        {
            CarEntityModelList modelList = (CarEntityModelList)e.Model;

            for (int i = 0; i < modelList.Data.Count; i++)// CarEntityModel model in modelList.Data)
            {
                CarEntityModel model = modelList.Data[i];

                dataTable.Rows[i].SetValues(
                        dataTableScrollBar.Value + i + 1,
                        model.Number,
                        model.XPosition,
                        model.YPosition,
                        model.FuelAmount,
                        model.TyresWear,
                        model.IsActive);
            }
        }

        private State GetState()
        {
            return new State(
                    dataTableScrollBar.Value,
                    ROWS_COUNT,
                    sortColumnIndex,
                    dataTable.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection);
        }
    }
}
