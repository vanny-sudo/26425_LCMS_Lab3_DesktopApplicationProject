namespace LegalCaseManagementSystem.View
{
    partial class ReportsForm
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
            lblSummary = new Label();
            lblHearingsTitle = new Label();
            dgvHearings = new DataGridView();
            lblClosedTitle = new Label();
            dgvClosed = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHearings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClosed).BeginInit();
            SuspendLayout();
            var navy = Color.FromArgb(25, 45, 75);
            var gold = Color.FromArgb(184, 148, 88);
            var ivory = Color.FromArgb(245, 247, 250);
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(428, 36);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(59, 25);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "label1";
            lblSummary.ForeColor = navy;
            // 
            // lblHearingsTitle
            // 
            lblHearingsTitle.AutoSize = true;
            lblHearingsTitle.Location = new Point(428, 109);
            lblHearingsTitle.Name = "lblHearingsTitle";
            lblHearingsTitle.Size = new Size(59, 25);
            lblHearingsTitle.TabIndex = 1;
            lblHearingsTitle.Text = "label1";
            lblHearingsTitle.ForeColor = navy;
            // 
            // dgvHearings
            // 
            dgvHearings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvHearings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHearings.Location = new Point(295, 160);
            dgvHearings.Name = "dgvHearings";
            dgvHearings.RowHeadersWidth = 62;
            dgvHearings.Size = new Size(350, 200);
            dgvHearings.TabIndex = 2;
            dgvHearings.BackgroundColor = Color.White;
            dgvHearings.BorderStyle = BorderStyle.FixedSingle;
            dgvHearings.EnableHeadersVisualStyles = false;
            dgvHearings.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvHearings.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHearings.DefaultCellStyle.SelectionBackColor = gold;
            dgvHearings.DefaultCellStyle.SelectionForeColor = navy;
            // 
            // lblClosedTitle
            // 
            lblClosedTitle.AutoSize = true;
            lblClosedTitle.Location = new Point(439, 390);
            lblClosedTitle.Name = "lblClosedTitle";
            lblClosedTitle.Size = new Size(59, 25);
            lblClosedTitle.TabIndex = 3;
            lblClosedTitle.Text = "label1";
            lblClosedTitle.ForeColor = navy;
            // 
            // dgvClosed
            // 
            dgvClosed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClosed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClosed.Location = new Point(295, 443);
            dgvClosed.Name = "dgvClosed";
            dgvClosed.RowHeadersWidth = 62;
            dgvClosed.Size = new Size(360, 225);
            dgvClosed.TabIndex = 4;
            dgvClosed.BackgroundColor = Color.White;
            dgvClosed.BorderStyle = BorderStyle.FixedSingle;
            dgvClosed.EnableHeadersVisualStyles = false;
            dgvClosed.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvClosed.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClosed.DefaultCellStyle.SelectionBackColor = gold;
            dgvClosed.DefaultCellStyle.SelectionForeColor = navy;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ivory;
            ClientSize = new Size(928, 751);
            Controls.Add(dgvClosed);
            Controls.Add(lblClosedTitle);
            Controls.Add(dgvHearings);
            Controls.Add(lblHearingsTitle);
            Controls.Add(lblSummary);
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reports";
            Font = new Font("Segoe UI", 10F);
            Load += ReportsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHearings).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClosed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSummary;
        private Label lblHearingsTitle;
        private DataGridView dgvHearings;
        private Label lblClosedTitle;
        private DataGridView dgvClosed;
    }
}