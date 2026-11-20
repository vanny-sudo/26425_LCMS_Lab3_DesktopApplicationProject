namespace LegalCaseManagementSystem.View
{
    partial class UpdateCaseForm
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
            lblCase = new Label();
            cboCase = new ComboBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            btnSaveStatus = new Button();
            lblNote = new Label();
            txtNote = new TextBox();
            btnAddNote = new Button();
            dgvNotes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).BeginInit();
            SuspendLayout();
            // 
            // lblCase
            // 
            lblCase.AutoSize = true;
            lblCase.ForeColor = Color.FromArgb(25, 45, 75);
            lblCase.Location = new Point(75, 33);
            lblCase.Name = "lblCase";
            lblCase.Size = new Size(52, 28);
            lblCase.TabIndex = 0;
            lblCase.Text = "Case";
            // 
            // cboCase
            // 
            cboCase.FormattingEnabled = true;
            cboCase.Location = new Point(193, 41);
            cboCase.Name = "cboCase";
            cboCase.Size = new Size(353, 36);
            cboCase.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.FromArgb(25, 45, 75);
            lblStatus.Location = new Point(75, 110);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 28);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status";
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(193, 117);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(353, 36);
            cboStatus.TabIndex = 3;
            // 
            // btnSaveStatus
            // 
            btnSaveStatus.BackColor = Color.FromArgb(184, 148, 88);
            btnSaveStatus.FlatAppearance.BorderSize = 0;
            btnSaveStatus.FlatStyle = FlatStyle.Flat;
            btnSaveStatus.ForeColor = Color.FromArgb(25, 45, 75);
            btnSaveStatus.Location = new Point(304, 192);
            btnSaveStatus.Name = "btnSaveStatus";
            btnSaveStatus.Size = new Size(142, 58);
            btnSaveStatus.TabIndex = 4;
            btnSaveStatus.Text = "Save Status";
            btnSaveStatus.UseVisualStyleBackColor = false;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.ForeColor = Color.FromArgb(25, 45, 75);
            lblNote.Location = new Point(75, 285);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(96, 28);
            lblNote.TabIndex = 5;
            lblNote.Text = "New note";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(193, 292);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(353, 34);
            txtNote.TabIndex = 6;
            // 
            // btnAddNote
            // 
            btnAddNote.BackColor = Color.FromArgb(25, 45, 75);
            btnAddNote.FlatAppearance.BorderSize = 0;
            btnAddNote.FlatStyle = FlatStyle.Flat;
            btnAddNote.ForeColor = Color.White;
            btnAddNote.Location = new Point(304, 361);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(142, 60);
            btnAddNote.TabIndex = 7;
            btnAddNote.Text = "Add Note";
            btnAddNote.UseVisualStyleBackColor = false;
            // 
            // dgvNotes
            // 
            dgvNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNotes.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(25, 45, 75);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(184, 148, 88);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(25, 45, 75);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvNotes.DefaultCellStyle = dataGridViewCellStyle2;
            dgvNotes.EnableHeadersVisualStyles = false;
            dgvNotes.Location = new Point(646, 33);
            dgvNotes.Name = "dgvNotes";
            dgvNotes.RowHeadersWidth = 62;
            dgvNotes.Size = new Size(705, 381);
            dgvNotes.TabIndex = 8;
            // 
            // UpdateCaseForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1375, 643);
            Controls.Add(dgvNotes);
            Controls.Add(btnAddNote);
            Controls.Add(txtNote);
            Controls.Add(lblNote);
            Controls.Add(btnSaveStatus);
            Controls.Add(cboStatus);
            Controls.Add(lblStatus);
            Controls.Add(cboCase);
            Controls.Add(lblCase);
            Font = new Font("Segoe UI", 10F);
            Name = "UpdateCaseForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update Case";
            Load += UpdateCaseForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCase;
        private ComboBox cboCase;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Button btnSaveStatus;
        private Label lblNote;
        private TextBox txtNote;
        private Button btnAddNote;
        private DataGridView dgvNotes;
    }
}