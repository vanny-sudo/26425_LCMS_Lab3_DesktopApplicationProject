namespace LegalCaseManagementSystem.View
{
    partial class ClientPortalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblWelcome = new Label();
            lblCases = new Label();
            dgvCases = new DataGridView();
            lblHearings = new Label();
            dgvHearings = new DataGridView();
            btnLogout = new Button();
            btnProfile = new Button();
            btnContact = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHearings).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(25, 45, 75);
            lblWelcome.Location = new Point(45, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(158, 45);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // lblCases
            // 
            lblCases.AutoSize = true;
            lblCases.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCases.ForeColor = Color.FromArgb(25, 45, 75);
            lblCases.Location = new Point(45, 159);
            lblCases.Name = "lblCases";
            lblCases.Size = new Size(205, 30);
            lblCases.TabIndex = 1;
            lblCases.Text = "My Case Overview";
            // 
            // dgvCases
            // 
            dgvCases.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvCases.Location = new Point(45, 214);
            dgvCases.Name = "dgvCases";
            dgvCases.RowHeadersWidth = 62;
            dgvCases.Size = new Size(1050, 210);
            dgvCases.TabIndex = 2;
            // 
            // lblHearings
            // 
            lblHearings.AutoSize = true;
            lblHearings.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHearings.ForeColor = Color.FromArgb(25, 45, 75);
            lblHearings.Location = new Point(45, 475);
            lblHearings.Name = "lblHearings";
            lblHearings.Size = new Size(205, 30);
            lblHearings.TabIndex = 3;
            lblHearings.Text = "Schedule Hearings";
            // 
            // dgvHearings
            // 
            dgvHearings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHearings.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(25, 45, 75);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvHearings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvHearings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(184, 148, 88);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(25, 45, 75);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvHearings.DefaultCellStyle = dataGridViewCellStyle4;
            dgvHearings.EnableHeadersVisualStyles = false;
            dgvHearings.Location = new Point(45, 510);
            dgvHearings.Name = "dgvHearings";
            dgvHearings.RowHeadersWidth = 62;
            dgvHearings.Size = new Size(1050, 292);
            dgvHearings.TabIndex = 4;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(170, 68, 68);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(945, 30);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 45);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.FromArgb(25, 45, 75);
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(527, 30);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(226, 45);
            btnProfile.TabIndex = 7;
            btnProfile.Text = "My Profile";
            btnProfile.UseVisualStyleBackColor = false;
            // 
            // btnContact
            // 
            btnContact.BackColor = Color.FromArgb(184, 148, 88);
            btnContact.FlatAppearance.BorderSize = 0;
            btnContact.FlatStyle = FlatStyle.Flat;
            btnContact.ForeColor = Color.FromArgb(25, 45, 75);
            btnContact.Location = new Point(786, 30);
            btnContact.Name = "btnContact";
            btnContact.Size = new Size(140, 45);
            btnContact.TabIndex = 6;
            btnContact.Text = "Contact";
            btnContact.UseVisualStyleBackColor = false;
            // 
            // ClientPortalForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1140, 772);
            Controls.Add(btnLogout);
            Controls.Add(btnContact);
            Controls.Add(btnProfile);
            Controls.Add(dgvHearings);
            Controls.Add(lblHearings);
            Controls.Add(dgvCases);
            Controls.Add(lblCases);
            Controls.Add(lblWelcome);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(900, 600);
            Name = "ClientPortalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LCMS - Welcome";
            ((System.ComponentModel.ISupportInitialize)dgvCases).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHearings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblCases;
        private DataGridView dgvCases;
        private Label lblHearings;
        private DataGridView dgvHearings;
        private Button btnLogout;
        private Button btnProfile;
        private Button btnContact;

        private static void ConfigureSummaryLabel(Label label, Point location, Color color)
        {
            label.AutoSize = true;
            label.Location = location;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label.ForeColor = color;
        }

        private static void ConfigureSummaryValue(Label label, Point location, Color color)
        {
            label.AutoSize = true;
            label.Location = location;
            label.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label.ForeColor = color;
        }
    }
}
