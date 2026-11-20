namespace LegalCaseManagementSystem.View
{
    partial class SearchForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblCaseNumber = new Label();
            txtCaseNumber = new TextBox();
            lblClientName = new Label();
            txtClientName = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            btnSearch = new Button();
            btnClear = new Button();
            lblResult = new Label();
            dgvResults = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // lblCaseNumber
            // 
            lblCaseNumber.AutoSize = true;
            lblCaseNumber.ForeColor = Color.FromArgb(25, 45, 75);
            lblCaseNumber.Location = new Point(61, 40);
            lblCaseNumber.Name = "lblCaseNumber";
            lblCaseNumber.Size = new Size(125, 28);
            lblCaseNumber.TabIndex = 0;
            lblCaseNumber.Text = "Case number";
            // 
            // txtCaseNumber
            // 
            txtCaseNumber.Location = new Point(250, 34);
            txtCaseNumber.Name = "txtCaseNumber";
            txtCaseNumber.Size = new Size(256, 34);
            txtCaseNumber.TabIndex = 1;
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.ForeColor = Color.FromArgb(25, 45, 75);
            lblClientName.Location = new Point(61, 102);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(115, 28);
            lblClientName.TabIndex = 2;
            lblClientName.Text = "Client name";
            // 
            // txtClientName
            // 
            txtClientName.Location = new Point(250, 102);
            txtClientName.Name = "txtClientName";
            txtClientName.Size = new Size(256, 34);
            txtClientName.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.FromArgb(25, 45, 75);
            lblStatus.Location = new Point(61, 172);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 28);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status";
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(250, 167);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(256, 36);
            cboStatus.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(184, 148, 88);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.FromArgb(25, 45, 75);
            btnSearch.Location = new Point(105, 258);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(138, 56);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(220, 224, 230);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.FromArgb(25, 45, 75);
            btnClear.Location = new Point(323, 258);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(155, 48);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResult.ForeColor = Color.FromArgb(25, 45, 75);
            lblResult.Location = new Point(250, 360);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(70, 28);
            lblResult.TabIndex = 8;
            lblResult.Text = "label1";
            // 
            // dgvResults
            // 
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(25, 45, 75);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(184, 148, 88);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(25, 45, 75);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvResults.DefaultCellStyle = dataGridViewCellStyle2;
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.Location = new Point(608, 56);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 62;
            dgvResults.Size = new Size(660, 383);
            dgvResults.TabIndex = 9;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1309, 649);
            Controls.Add(dgvResults);
            Controls.Add(lblResult);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(cboStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtClientName);
            Controls.Add(lblClientName);
            Controls.Add(txtCaseNumber);
            Controls.Add(lblCaseNumber);
            Font = new Font("Segoe UI", 10F);
            Name = "SearchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Search Cases";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCaseNumber;
        private TextBox txtCaseNumber;
        private Label lblClientName;
        private TextBox txtClientName;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Button btnSearch;
        private Button btnClear;
        private Label lblResult;
        private DataGridView dgvResults;
    }
}