namespace IniServer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverSwitchingButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataSourceOperationsIntervalnput = new System.Windows.Forms.NumericUpDown();
            this.dataSourceOperationsIntervalLabel = new System.Windows.Forms.Label();
            this.dataSourceOperationsCountInput = new System.Windows.Forms.NumericUpDown();
            this.dataSourceOperationsCountLabel = new System.Windows.Forms.Label();
            this.dataSourceCapacityDeltaInput = new System.Windows.Forms.NumericUpDown();
            this.dataSourceCapacityDeltaLabel = new System.Windows.Forms.Label();
            this.dataSourceCapacityLabel = new System.Windows.Forms.Label();
            this.simulationStatusLabel = new System.Windows.Forms.Label();
            this.statusValueLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.simulationStatusValuelabel = new System.Windows.Forms.Label();
            this.dataSourceCapacityInput = new System.Windows.Forms.NumericUpDown();
            this.simulationSwithingButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceOperationsIntervalnput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceOperationsCountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceCapacityDeltaInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceCapacityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // serverSwitchingButton
            // 
            this.serverSwitchingButton.Location = new System.Drawing.Point(12, 200);
            this.serverSwitchingButton.Name = "serverSwitchingButton";
            this.serverSwitchingButton.Size = new System.Drawing.Size(101, 23);
            this.serverSwitchingButton.TabIndex = 0;
            this.serverSwitchingButton.Text = "Start server";
            this.serverSwitchingButton.UseVisualStyleBackColor = true;
            this.serverSwitchingButton.Click += new System.EventHandler(this.OnServerSwitchingButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataSourceOperationsIntervalnput, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.dataSourceOperationsIntervalLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.dataSourceOperationsCountInput, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataSourceOperationsCountLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataSourceCapacityDeltaInput, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataSourceCapacityDeltaLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataSourceCapacityLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.simulationStatusLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusValueLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.simulationStatusValuelabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataSourceCapacityInput, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 170);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataSourceOperationsIntervalnput
            // 
            this.dataSourceOperationsIntervalnput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataSourceOperationsIntervalnput.Location = new System.Drawing.Point(178, 145);
            this.dataSourceOperationsIntervalnput.Maximum = new decimal(new int[] {
            216000000,
            0,
            0,
            0});
            this.dataSourceOperationsIntervalnput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.dataSourceOperationsIntervalnput.Name = "dataSourceOperationsIntervalnput";
            this.dataSourceOperationsIntervalnput.Size = new System.Drawing.Size(120, 20);
            this.dataSourceOperationsIntervalnput.TabIndex = 10;
            this.dataSourceOperationsIntervalnput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // dataSourceOperationsIntervalLabel
            // 
            this.dataSourceOperationsIntervalLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataSourceOperationsIntervalLabel.AutoSize = true;
            this.dataSourceOperationsIntervalLabel.Location = new System.Drawing.Point(3, 148);
            this.dataSourceOperationsIntervalLabel.Name = "dataSourceOperationsIntervalLabel";
            this.dataSourceOperationsIntervalLabel.Size = new System.Drawing.Size(157, 13);
            this.dataSourceOperationsIntervalLabel.TabIndex = 6;
            this.dataSourceOperationsIntervalLabel.Text = "Data source operations interval:";
            // 
            // dataSourceOperationsCountInput
            // 
            this.dataSourceOperationsCountInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataSourceOperationsCountInput.Location = new System.Drawing.Point(178, 115);
            this.dataSourceOperationsCountInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.dataSourceOperationsCountInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.dataSourceOperationsCountInput.Name = "dataSourceOperationsCountInput";
            this.dataSourceOperationsCountInput.Size = new System.Drawing.Size(120, 20);
            this.dataSourceOperationsCountInput.TabIndex = 9;
            this.dataSourceOperationsCountInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // dataSourceOperationsCountLabel
            // 
            this.dataSourceOperationsCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataSourceOperationsCountLabel.AutoSize = true;
            this.dataSourceOperationsCountLabel.Location = new System.Drawing.Point(3, 118);
            this.dataSourceOperationsCountLabel.Name = "dataSourceOperationsCountLabel";
            this.dataSourceOperationsCountLabel.Size = new System.Drawing.Size(150, 13);
            this.dataSourceOperationsCountLabel.TabIndex = 5;
            this.dataSourceOperationsCountLabel.Text = "Data source operations count:";
            // 
            // dataSourceCapacityDeltaInput
            // 
            this.dataSourceCapacityDeltaInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataSourceCapacityDeltaInput.Location = new System.Drawing.Point(178, 85);
            this.dataSourceCapacityDeltaInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.dataSourceCapacityDeltaInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.dataSourceCapacityDeltaInput.Name = "dataSourceCapacityDeltaInput";
            this.dataSourceCapacityDeltaInput.Size = new System.Drawing.Size(120, 20);
            this.dataSourceCapacityDeltaInput.TabIndex = 8;
            this.dataSourceCapacityDeltaInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // dataSourceCapacityDeltaLabel
            // 
            this.dataSourceCapacityDeltaLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataSourceCapacityDeltaLabel.AutoSize = true;
            this.dataSourceCapacityDeltaLabel.Location = new System.Drawing.Point(3, 88);
            this.dataSourceCapacityDeltaLabel.Name = "dataSourceCapacityDeltaLabel";
            this.dataSourceCapacityDeltaLabel.Size = new System.Drawing.Size(137, 13);
            this.dataSourceCapacityDeltaLabel.TabIndex = 4;
            this.dataSourceCapacityDeltaLabel.Text = "Data source capacity delta:";
            // 
            // dataSourceCapacityLabel
            // 
            this.dataSourceCapacityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataSourceCapacityLabel.AutoSize = true;
            this.dataSourceCapacityLabel.Location = new System.Drawing.Point(3, 58);
            this.dataSourceCapacityLabel.Name = "dataSourceCapacityLabel";
            this.dataSourceCapacityLabel.Size = new System.Drawing.Size(111, 13);
            this.dataSourceCapacityLabel.TabIndex = 3;
            this.dataSourceCapacityLabel.Text = "Data source capacity:";
            this.dataSourceCapacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simulationStatusLabel
            // 
            this.simulationStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.simulationStatusLabel.AutoSize = true;
            this.simulationStatusLabel.Location = new System.Drawing.Point(3, 31);
            this.simulationStatusLabel.Name = "simulationStatusLabel";
            this.simulationStatusLabel.Size = new System.Drawing.Size(89, 13);
            this.simulationStatusLabel.TabIndex = 3;
            this.simulationStatusLabel.Text = "Simulation status:";
            this.simulationStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusValueLabel
            // 
            this.statusValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.statusValueLabel.AutoSize = true;
            this.statusValueLabel.ForeColor = System.Drawing.Color.Red;
            this.statusValueLabel.Location = new System.Drawing.Point(178, 6);
            this.statusValueLabel.Name = "statusValueLabel";
            this.statusValueLabel.Size = new System.Drawing.Size(48, 13);
            this.statusValueLabel.TabIndex = 3;
            this.statusValueLabel.Text = "Disabled";
            this.statusValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(3, 6);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Status:";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simulationStatusValuelabel
            // 
            this.simulationStatusValuelabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.simulationStatusValuelabel.AutoSize = true;
            this.simulationStatusValuelabel.ForeColor = System.Drawing.Color.Red;
            this.simulationStatusValuelabel.Location = new System.Drawing.Point(178, 31);
            this.simulationStatusValuelabel.Name = "simulationStatusValuelabel";
            this.simulationStatusValuelabel.Size = new System.Drawing.Size(48, 13);
            this.simulationStatusValuelabel.TabIndex = 4;
            this.simulationStatusValuelabel.Text = "Disabled";
            this.simulationStatusValuelabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataSourceCapacityInput
            // 
            this.dataSourceCapacityInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataSourceCapacityInput.Location = new System.Drawing.Point(178, 55);
            this.dataSourceCapacityInput.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.dataSourceCapacityInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.dataSourceCapacityInput.Name = "dataSourceCapacityInput";
            this.dataSourceCapacityInput.Size = new System.Drawing.Size(120, 20);
            this.dataSourceCapacityInput.TabIndex = 7;
            this.dataSourceCapacityInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // simulationSwithingButton
            // 
            this.simulationSwithingButton.Enabled = false;
            this.simulationSwithingButton.Location = new System.Drawing.Point(12, 230);
            this.simulationSwithingButton.Name = "simulationSwithingButton";
            this.simulationSwithingButton.Size = new System.Drawing.Size(101, 23);
            this.simulationSwithingButton.TabIndex = 2;
            this.simulationSwithingButton.Text = "Start emulation";
            this.simulationSwithingButton.UseVisualStyleBackColor = true;
            this.simulationSwithingButton.Click += new System.EventHandler(this.OnSimulationSwitchingButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.simulationSwithingButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.serverSwitchingButton);
            this.Name = "MainForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceOperationsIntervalnput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceOperationsCountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceCapacityDeltaInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceCapacityInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button serverSwitchingButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label statusValueLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button simulationSwithingButton;
        private System.Windows.Forms.Label simulationStatusLabel;
        private System.Windows.Forms.Label simulationStatusValuelabel;
        private System.Windows.Forms.Label dataSourceCapacityLabel;
        private System.Windows.Forms.Label dataSourceCapacityDeltaLabel;
        private System.Windows.Forms.Label dataSourceOperationsIntervalLabel;
        private System.Windows.Forms.Label dataSourceOperationsCountLabel;
        private System.Windows.Forms.NumericUpDown dataSourceCapacityInput;
        private System.Windows.Forms.NumericUpDown dataSourceOperationsIntervalnput;
        private System.Windows.Forms.NumericUpDown dataSourceOperationsCountInput;
        private System.Windows.Forms.NumericUpDown dataSourceCapacityDeltaInput;
    }
}

