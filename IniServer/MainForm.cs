using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IniServer
{
    public partial class MainForm : Form
    {
        private const string START_SERVER_LABEL_TEXT = "Start server";
        private const string ENABLED_LABEL_TEXT = "Enabled";
        private const string SHUTDOWN_SERVER_LABEL_TEXT = "Shutdown server";
        private const string DISABLED_LABEL_TEXT = "Disabled";
        private const string START_SIMULATION_LABEL_TEXT = "Start simulation";
        private const string STOP_SIMULATION_LABEL_TEXT = "Stop simulation";
        private const string GENERATING_LABEL_TEXT = "Generating...";
        
        private Server server;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void OnServerSwitchingButtonClick(object sender, EventArgs e)
        {
            serverSwitchingButton.Enabled = false;

            if (server == null)
            {
                server = new Server();

                await Task.Run(server.Start);

                serverSwitchingButton.Text = SHUTDOWN_SERVER_LABEL_TEXT;

                statusValueLabel.Text = ENABLED_LABEL_TEXT;
                statusValueLabel.ForeColor = Color.Green;

                simulationSwithingButton.Enabled = true;
            }
            else
            {
                await Task.Run(server.Stop);

                server = null;

                serverSwitchingButton.Text = START_SERVER_LABEL_TEXT;

                statusValueLabel.Text = DISABLED_LABEL_TEXT;
                statusValueLabel.ForeColor = Color.Red;

                simulationSwithingButton.Enabled = false;
            }

            serverSwitchingButton.Enabled = true;
        }

        private async void OnSimulationSwitchingButtonClick(object sender, EventArgs e)
        {
            simulationSwithingButton.Text = GENERATING_LABEL_TEXT;
            simulationSwithingButton.Enabled = false;

            if (server != null && !server.SimulationIsActive)
            {
                dataSourceCapacityInput.Enabled = false;
                dataSourceCapacityDeltaInput.Enabled = false;
                dataSourceOperationsCountInput.Enabled = false;
                dataSourceOperationsIntervalnput.Enabled = false;

                await Task.Run(() => server.StartSimulation(
                    (int?)dataSourceCapacityInput.Value,
                    (int?)dataSourceCapacityDeltaInput.Value,
                    (int?)dataSourceOperationsCountInput.Value,
                    (int?)dataSourceOperationsIntervalnput.Value));

                simulationSwithingButton.Text = STOP_SIMULATION_LABEL_TEXT;

                simulationStatusValuelabel.Text = ENABLED_LABEL_TEXT;
                simulationStatusValuelabel.ForeColor = Color.Green;
            }
            else
            {
                server.StopSimulation();

                simulationSwithingButton.Text = START_SIMULATION_LABEL_TEXT;

                simulationStatusValuelabel.Text = DISABLED_LABEL_TEXT;
                simulationStatusValuelabel.ForeColor = Color.Red;
            }

            simulationSwithingButton.Enabled = true;
        }

        private void OnMainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
            {
                server.StopSimulation();
                server.Stop();
                server = null;
            }
        }
    }
}
