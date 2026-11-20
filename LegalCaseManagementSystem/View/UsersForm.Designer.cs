namespace LegalCaseManagementSystem.View
{
    partial class UsersForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblTitle = new Label();
            lblFullName = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            lblRole = new Label();
            txtFullName = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            cboRole = new ComboBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvUsers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(25, 45, 75);
            lblTitle.Location = new Point(32, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(402, 54);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "User Administration";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(42, 105);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(100, 23);
            lblFullName.TabIndex = 9;
            lblFullName.Text = "Full name";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(42, 185);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 8;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(42, 265);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(42, 425);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(100, 23);
            lblRole.TabIndex = 6;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(42, 133);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(100, 34);
            txtFullName.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(42, 213);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 34);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(42, 293);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 34);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(42, 345);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(170, 28);
            lblConfirmPassword.TabIndex = 11;
            lblConfirmPassword.Text = "Confirm password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(42, 373);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(310, 34);
            txtConfirmPassword.TabIndex = 12;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Items.AddRange(new object[] { "Client", "Lawyer" });
            cboRole.Location = new Point(42, 453);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(220, 36);
            cboRole.TabIndex = 2;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(184, 148, 88);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.ForeColor = Color.FromArgb(25, 45, 75);
            btnCreate.Location = new Point(42, 505);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(310, 48);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Create User";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(25, 45, 75);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(42, 565);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(148, 44);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update selected";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(150, 45, 45);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(204, 565);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(148, 44);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete selected";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(25, 45, 75);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.ColumnHeadersHeight = 34;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.Location = new Point(400, 95);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(650, 540);
            dgvUsers.TabIndex = 0;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1180, 720);
            Controls.Add(dgvUsers);
            Controls.Add(btnCreate);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(cboRole);
            Controls.Add(txtPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtFullName);
            Controls.Add(lblRole);
            Controls.Add(lblPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblFullName);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            Name = "UsersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Users";
            MinimumSize = new Size(1000, 650);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private static void ConfigureLabel(Label label, string text, int x, int y)
        {
            label.AutoSize = true;
            label.Location = new Point(x, y + 4);
            label.Text = text;
            label.ForeColor = Color.FromArgb(25, 45, 75);
        }

        private static void ConfigureTextBox(TextBox textBox, int x, int y)
        {
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(220, 31);
        }

        private Label lblTitle;
        private Label lblFullName;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private Label lblRole;
        private TextBox txtFullName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private ComboBox cboRole;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvUsers;
    }
}
