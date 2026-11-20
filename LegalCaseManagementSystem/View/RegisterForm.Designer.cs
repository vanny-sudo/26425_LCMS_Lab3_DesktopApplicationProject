namespace LegalCaseManagementSystem.View
{
    partial class RegisterForm
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
            lblTitle = new Label();
            lblIntro = new Label();
            lblRole = new Label();
            cboRole = new ComboBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(184, 148, 88);
            lblTitle.Location = new Point(205, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(202, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Registration";
            // 
            // lblIntro
            // 
            lblIntro.AutoSize = true;
            lblIntro.ForeColor = Color.White;
            lblIntro.Location = new Point(44, 84);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(491, 28);
            lblIntro.TabIndex = 1;
            lblIntro.Text = "Create a secure account to access the legal case system.";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.ForeColor = Color.White;
            lblRole.Location = new Point(68, 140);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(50, 28);
            lblRole.TabIndex = 2;
            lblRole.Text = "Role";
            // 
            // cboRole
            // 
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(250, 134);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(285, 36);
            cboRole.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.ForeColor = Color.White;
            lblFullName.Location = new Point(68, 195);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(96, 28);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Full name";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(250, 189);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(285, 34);
            txtFullName.TabIndex = 5;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.ForeColor = Color.White;
            lblPhone.Location = new Point(68, 250);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(67, 28);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(250, 244);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(285, 34);
            txtPhone.TabIndex = 7;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(68, 305);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(99, 28);
            lblUsername.TabIndex = 8;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(250, 299);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(285, 34);
            txtUsername.TabIndex = 9;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(68, 360);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(93, 28);
            lblPassword.TabIndex = 10;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(250, 354);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(285, 34);
            txtPassword.TabIndex = 11;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.ForeColor = Color.White;
            lblConfirmPassword.Location = new Point(68, 415);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(170, 28);
            lblConfirmPassword.TabIndex = 12;
            lblConfirmPassword.Text = "Confirm password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(250, 409);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(285, 34);
            txtConfirmPassword.TabIndex = 13;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(184, 148, 88);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.FromArgb(25, 45, 75);
            btnRegister.Location = new Point(68, 480);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(220, 55);
            btnRegister.TabIndex = 14;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(220, 224, 230);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.FromArgb(25, 45, 75);
            btnCancel.Location = new Point(315, 480);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(220, 55);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 45, 75);
            ClientSize = new Size(873, 667);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(cboRole);
            Controls.Add(lblRole);
            Controls.Add(lblIntro);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Registration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblIntro;
        private Label lblRole;
        private ComboBox cboRole;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Button btnCancel;
    }
}
