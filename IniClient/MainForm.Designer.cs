namespace IniClient
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
            this.clientSwithingButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusValueLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyresWear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataTableScrollBar = new System.Windows.Forms.VScrollBar();
            this.errorLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // clientSwithingButton
            // 
            this.clientSwithingButton.Location = new System.Drawing.Point(12, 138);
            this.clientSwithingButton.Name = "clientSwithingButton";
            this.clientSwithingButton.Size = new System.Drawing.Size(75, 23);
            this.clientSwithingButton.TabIndex = 0;
            this.clientSwithingButton.Text = "Connect";
            this.clientSwithingButton.UseVisualStyleBackColor = true;
            this.clientSwithingButton.Click += new System.EventHandler(this.OnClientSwitchingButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusValueLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(865, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // statusValueLabel
            // 
            this.statusValueLabel.AutoSize = true;
            this.statusValueLabel.ForeColor = System.Drawing.Color.Black;
            this.statusValueLabel.Location = new System.Drawing.Point(153, 0);
            this.statusValueLabel.Name = "statusValueLabel";
            this.statusValueLabel.Size = new System.Drawing.Size(73, 13);
            this.statusValueLabel.TabIndex = 3;
            this.statusValueLabel.Text = "Disconnected";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(3, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Status:";
            // 
            // dataTable
            // 
            this.dataTable.AllowUserToAddRows = false;
            this.dataTable.AllowUserToDeleteRows = false;
            this.dataTable.AllowUserToResizeRows = false;
            this.dataTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.Number,
            this.XPosition,
            this.YPosition,
            this.FuelAmount,
            this.TyresWear,
            this.IsActive});
            this.dataTable.Location = new System.Drawing.Point(27, 178);
            this.dataTable.MultiSelect = false;
            this.dataTable.Name = "dataTable";
            this.dataTable.ReadOnly = true;
            this.dataTable.RowHeadersVisible = false;
            this.dataTable.RowTemplate.ReadOnly = true;
            this.dataTable.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataTable.Size = new System.Drawing.Size(829, 352);
            this.dataTable.TabIndex = 4;
            this.dataTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnDataTableColumnHeaderMouseClick);
            // 
            // RowNumber
            // 
            this.RowNumber.HeaderText = "№";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Number
            // 
            this.Number.HeaderText = "Number";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // XPosition
            // 
            this.XPosition.HeaderText = "Position (X)";
            this.XPosition.Name = "XPosition";
            this.XPosition.ReadOnly = true;
            // 
            // YPosition
            // 
            this.YPosition.HeaderText = "Position (Y)";
            this.YPosition.Name = "YPosition";
            this.YPosition.ReadOnly = true;
            // 
            // FuelAmount
            // 
            this.FuelAmount.HeaderText = "Fuel amount";
            this.FuelAmount.Name = "FuelAmount";
            this.FuelAmount.ReadOnly = true;
            // 
            // TyresWear
            // 
            this.TyresWear.HeaderText = "Tyres wear";
            this.TyresWear.Name = "TyresWear";
            this.TyresWear.ReadOnly = true;
            // 
            // IsActive
            // 
            this.IsActive.HeaderText = "Is active";
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            // 
            // dataTableScrollBar
            // 
            this.dataTableScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTableScrollBar.Enabled = false;
            this.dataTableScrollBar.Location = new System.Drawing.Point(859, 178);
            this.dataTableScrollBar.Name = "dataTableScrollBar";
            this.dataTableScrollBar.Size = new System.Drawing.Size(21, 361);
            this.dataTableScrollBar.TabIndex = 5;
            this.dataTableScrollBar.ValueChanged += new System.EventHandler(this.OnTableScrollBarValueChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(93, 143);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(50, 13);
            this.errorLabel.TabIndex = 6;
            this.errorLabel.Text = "No errors";
            this.errorLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 551);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.dataTableScrollBar);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.clientSwithingButton);
            this.MinimumSize = new System.Drawing.Size(650, 590);
            this.Name = "MainForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clientSwithingButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label statusValueLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowNewDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowEditDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowRemoveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn supportsChangeNotificationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn supportsSearchingDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn supportsSortingDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSortedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortPropertyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDirectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadOnlyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isFixedSizeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn syncRootDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSynchronizedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.VScrollBar dataTableScrollBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn XPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn YPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyresWear;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.Label errorLabel;
    }
}

