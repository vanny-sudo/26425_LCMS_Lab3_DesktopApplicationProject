namespace LegalCaseManagementSystem.View
{
    partial class HearingsForm
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
            lblCase = new Label();
            cboCase = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblTime = new Label();
            dtpTime = new DateTimePicker();
            lblCourt = new Label();
            txtCourt = new TextBox();
            btnSchedule = new Button();
            btnCancelHearing = new Button();
            btnClear = new Button();
            dgvHearings = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHearings).BeginInit();
            SuspendLayout();
            var navy = Color.FromArgb(25, 45, 75);
            var gold = Color.FromArgb(184, 148, 88);
            var ivory = Color.FromArgb(245, 247, 250);
            // 
            // lblCase
            // 
            lblCase.AutoSize = true;
            lblCase.Location = new Point(88, 48);
            lblCase.Name = "lblCase";
            lblCase.Size = new Size(49, 25);
            lblCase.TabIndex = 0;
            lblCase.Text = "Case";
            lblCase.ForeColor = navy;
            // 
            // cboCase
            // 
            cboCase.FormattingEnabled = true;
            cboCase.Location = new Point(232, 45);
            cboCase.Name = "cboCase";
            cboCase.Size = new Size(300, 33);
            cboCase.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(88, 109);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(114, 25);
            lblDate.TabIndex = 2;
            lblDate.Text = "Hearing date";
            lblDate.ForeColor = navy;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(232, 109);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(300, 31);
            dtpDate.TabIndex = 3;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(88, 190);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(50, 25);
            lblTime.TabIndex = 4;
            lblTime.Text = "Time";
            lblTime.ForeColor = navy;
            // 
            // dtpTime
            // 
            dtpTime.Location = new Point(232, 190);
            dtpTime.Name = "dtpTime";
            dtpTime.Size = new Size(300, 31);
            dtpTime.TabIndex = 5;
            // 
            // lblCourt
            // 
            lblCourt.AutoSize = true;
            lblCourt.Location = new Point(88, 265);
            lblCourt.Name = "lblCourt";
            lblCourt.Size = new Size(56, 25);
            lblCourt.TabIndex = 6;
            lblCourt.Text = "Court";
            lblCourt.ForeColor = navy;
            // 
            // txtCourt
            // 
            txtCourt.Location = new Point(232, 272);
            txtCourt.Name = "txtCourt";
            txtCourt.Size = new Size(300, 31);
            txtCourt.TabIndex = 7;
            // 
            // btnSchedule
            // 
            btnSchedule.Location = new Point(33, 361);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(225, 51);
            btnSchedule.TabIndex = 8;
            btnSchedule.Text = "Schedule Hearing";
            btnSchedule.BackColor = gold;
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.ForeColor = navy;
            // 
            // btnCancelHearing
            // 
            btnCancelHearing.Location = new Point(338, 361);
            btnCancelHearing.Name = "btnCancelHearing";
            btnCancelHearing.Size = new Size(222, 51);
            btnCancelHearing.TabIndex = 9;
            btnCancelHearing.Text = "Cancel Hearing";
            btnCancelHearing.BackColor = Color.FromArgb(170, 68, 68);
            btnCancelHearing.FlatAppearance.BorderSize = 0;
            btnCancelHearing.FlatStyle = FlatStyle.Flat;
            btnCancelHearing.ForeColor = Color.White;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(652, 361);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(205, 51);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.BackColor = Color.FromArgb(220, 224, 230);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = navy;
            // 
            // dgvHearings
            // 
            dgvHearings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHearings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHearings.Location = new Point(687, 45);
            dgvHearings.Name = "dgvHearings";
            dgvHearings.RowHeadersWidth = 62;
            dgvHearings.Size = new Size(409, 258);
            dgvHearings.TabIndex = 11;
            dgvHearings.BackgroundColor = Color.White;
            dgvHearings.BorderStyle = BorderStyle.FixedSingle;
            dgvHearings.EnableHeadersVisualStyles = false;
            dgvHearings.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvHearings.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHearings.DefaultCellStyle.SelectionBackColor = gold;
            dgvHearings.DefaultCellStyle.SelectionForeColor = navy;
            // 
            // HearingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ivory;
            ClientSize = new Size(1252, 544);
            Controls.Add(dgvHearings);
            Controls.Add(btnClear);
            Controls.Add(btnCancelHearing);
            Controls.Add(btnSchedule);
            Controls.Add(txtCourt);
            Controls.Add(lblCourt);
            Controls.Add(dtpTime);
            Controls.Add(lblTime);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(cboCase);
            Controls.Add(lblCase);
            ForeColor = Color.Black;
            Name = "HearingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Hearings";
            Font = new Font("Segoe UI", 10F);
            Load += HearingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHearings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCase;
        private ComboBox cboCase;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblTime;
        private DateTimePicker dtpTime;
        private Label lblCourt;
        private TextBox txtCourt;
        private Button btnSchedule;
        private Button btnCancelHearing;
        private Button btnClear;
        private DataGridView dgvHearings;
    }
}