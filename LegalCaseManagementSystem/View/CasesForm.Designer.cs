namespace LegalCaseManagementSystem.View
{
    partial class CasesForm
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
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblType = new Label();
            cboCaseType = new ComboBox();
            lblClient = new Label();
            cboClient = new ComboBox();
            lblLawyer = new Label();
            cboLawyer = new ComboBox();
            lblDate = new Label();
            dtpDateOpened = new DateTimePicker();
            btnOpenCase = new Button();
            btnAssign = new Button();
            btnClear = new Button();
            btnSetOpen = new Button();
            btnSetInProgress = new Button();
            btnSetClosed = new Button();
            dgvCases = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCases).BeginInit();
            SuspendLayout();
            // 
            // lblCaseNumber
            // 
            lblCaseNumber.AutoSize = true;
            lblCaseNumber.ForeColor = Color.FromArgb(25, 45, 75);
            lblCaseNumber.Location = new Point(73, 55);
            lblCaseNumber.Name = "lblCaseNumber";
            lblCaseNumber.Size = new Size(125, 28);
            lblCaseNumber.TabIndex = 0;
            lblCaseNumber.Text = "Case number";
            // 
            // txtCaseNumber
            // 
            txtCaseNumber.Location = new Point(278, 49);
            txtCaseNumber.Name = "txtCaseNumber";
            txtCaseNumber.ReadOnly = true;
            txtCaseNumber.Size = new Size(289, 34);
            txtCaseNumber.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.FromArgb(25, 45, 75);
            lblTitle.Location = new Point(73, 123);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(49, 28);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(278, 117);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(289, 34);
            txtTitle.TabIndex = 3;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.ForeColor = Color.FromArgb(25, 45, 75);
            lblType.Location = new Point(73, 196);
            lblType.Name = "lblType";
            lblType.Size = new Size(96, 28);
            lblType.TabIndex = 4;
            lblType.Text = "Case type";
            // 
            // cboCaseType
            // 
            cboCaseType.FormattingEnabled = true;
            cboCaseType.Location = new Point(278, 193);
            cboCaseType.Name = "cboCaseType";
            cboCaseType.Size = new Size(289, 36);
            cboCaseType.TabIndex = 5;
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.ForeColor = Color.FromArgb(25, 45, 75);
            lblClient.Location = new Point(73, 277);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(62, 28);
            lblClient.TabIndex = 6;
            lblClient.Text = "Client";
            // 
            // cboClient
            // 
            cboClient.FormattingEnabled = true;
            cboClient.Location = new Point(278, 269);
            cboClient.Name = "cboClient";
            cboClient.Size = new Size(289, 36);
            cboClient.TabIndex = 7;
            // 
            // lblLawyer
            // 
            lblLawyer.AutoSize = true;
            lblLawyer.ForeColor = Color.FromArgb(25, 45, 75);
            lblLawyer.Location = new Point(73, 349);
            lblLawyer.Name = "lblLawyer";
            lblLawyer.Size = new Size(157, 28);
            lblLawyer.TabIndex = 8;
            lblLawyer.Text = "Lawyer in charge";
            // 
            // cboLawyer
            // 
            cboLawyer.FormattingEnabled = true;
            cboLawyer.Location = new Point(278, 345);
            cboLawyer.Name = "cboLawyer";
            cboLawyer.Size = new Size(289, 36);
            cboLawyer.TabIndex = 9;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.ForeColor = Color.FromArgb(25, 45, 75);
            lblDate.Location = new Point(73, 430);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(125, 28);
            lblDate.TabIndex = 10;
            lblDate.Text = "Date opened";
            // 
            // dtpDateOpened
            // 
            dtpDateOpened.Location = new Point(278, 424);
            dtpDateOpened.Name = "dtpDateOpened";
            dtpDateOpened.Size = new Size(289, 34);
            dtpDateOpened.TabIndex = 11;
            // 
            // btnOpenCase
            // 
            btnOpenCase.BackColor = Color.FromArgb(184, 148, 88);
            btnOpenCase.FlatAppearance.BorderSize = 0;
            btnOpenCase.FlatStyle = FlatStyle.Flat;
            btnOpenCase.ForeColor = Color.FromArgb(25, 45, 75);
            btnOpenCase.Location = new Point(41, 489);
            btnOpenCase.Name = "btnOpenCase";
            btnOpenCase.Size = new Size(203, 63);
            btnOpenCase.TabIndex = 12;
            btnOpenCase.Text = "Open Case";
            btnOpenCase.UseVisualStyleBackColor = false;
            // 
            // btnAssign
            // 
            btnAssign.BackColor = Color.FromArgb(25, 45, 75);
            btnAssign.FlatAppearance.BorderSize = 0;
            btnAssign.FlatStyle = FlatStyle.Flat;
            btnAssign.ForeColor = Color.White;
            btnAssign.Location = new Point(709, 489);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(195, 63);
            btnAssign.TabIndex = 13;
            btnAssign.Text = "Assign Lawyer";
            btnAssign.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(220, 224, 230);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.FromArgb(25, 45, 75);
            btnClear.Location = new Point(1172, 489);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(199, 63);
            btnClear.TabIndex = 14;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSetOpen
            // 
            btnSetOpen.BackColor = Color.FromArgb(184, 148, 88);
            btnSetOpen.FlatAppearance.BorderSize = 0;
            btnSetOpen.FlatStyle = FlatStyle.Flat;
            btnSetOpen.ForeColor = Color.FromArgb(25, 45, 75);
            btnSetOpen.Location = new Point(278, 489);
            btnSetOpen.Name = "btnSetOpen";
            btnSetOpen.Size = new Size(160, 63);
            btnSetOpen.TabIndex = 16;
            btnSetOpen.Text = "Set Open";
            btnSetOpen.UseVisualStyleBackColor = false;
            // 
            // btnSetInProgress
            // 
            btnSetInProgress.BackColor = Color.FromArgb(25, 45, 75);
            btnSetInProgress.FlatAppearance.BorderSize = 0;
            btnSetInProgress.FlatStyle = FlatStyle.Flat;
            btnSetInProgress.ForeColor = Color.White;
            btnSetInProgress.Location = new Point(492, 489);
            btnSetInProgress.Name = "btnSetInProgress";
            btnSetInProgress.Size = new Size(160, 63);
            btnSetInProgress.TabIndex = 17;
            btnSetInProgress.Text = "Set In Progress";
            btnSetInProgress.UseVisualStyleBackColor = false;
            // 
            // btnSetClosed
            // 
            btnSetClosed.BackColor = Color.FromArgb(150, 70, 70);
            btnSetClosed.FlatAppearance.BorderSize = 0;
            btnSetClosed.FlatStyle = FlatStyle.Flat;
            btnSetClosed.ForeColor = Color.White;
            btnSetClosed.Location = new Point(979, 489);
            btnSetClosed.Name = "btnSetClosed";
            btnSetClosed.Size = new Size(160, 63);
            btnSetClosed.TabIndex = 18;
            btnSetClosed.Text = "Set Closed";
            btnSetClosed.UseVisualStyleBackColor = false;
            // 
            // dgvCases
            // 
            dgvCases.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCases.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(25, 45, 75);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(184, 148, 88);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(25, 45, 75);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCases.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCases.EnableHeadersVisualStyles = false;
            dgvCases.Location = new Point(650, 49);
            dgvCases.Name = "dgvCases";
            dgvCases.RowHeadersWidth = 62;
            dgvCases.Size = new Size(911, 400);
            dgvCases.TabIndex = 15;
            // 
            // CasesForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1591, 620);
            Controls.Add(dgvCases);
            Controls.Add(btnClear);
            Controls.Add(btnAssign);
            Controls.Add(btnOpenCase);
            Controls.Add(btnSetClosed);
            Controls.Add(btnSetInProgress);
            Controls.Add(btnSetOpen);
            Controls.Add(dtpDateOpened);
            Controls.Add(lblDate);
            Controls.Add(cboLawyer);
            Controls.Add(lblLawyer);
            Controls.Add(cboClient);
            Controls.Add(lblClient);
            Controls.Add(cboCaseType);
            Controls.Add(lblType);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Controls.Add(txtCaseNumber);
            Controls.Add(lblCaseNumber);
            Font = new Font("Segoe UI", 10F);
            Name = "CasesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cases";
            Load += CasesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCaseNumber;
        private TextBox txtCaseNumber;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblType;
        private ComboBox cboCaseType;
        private Label lblClient;
        private ComboBox cboClient;
        private Label lblLawyer;
        private ComboBox cboLawyer;
        private Label lblDate;
        private DateTimePicker dtpDateOpened;
        private Button btnOpenCase;
        private Button btnAssign;
        private Button btnClear;
        private Button btnSetOpen;
        private Button btnSetInProgress;
        private Button btnSetClosed;
        private DataGridView dgvCases;
    }
}