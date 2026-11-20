namespace LegalCaseManagementSystem.View
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblDateOfBirth = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblRole = new Label();
            txtRole = new TextBox();
            btnSave = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(25, 45, 75);
            lblTitle.Location = new Point(40, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(217, 54);
            lblTitle.TabIndex = 14;
            lblTitle.Text = "My Profile";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(40, 72);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(96, 28);
            lblFullName.TabIndex = 13;
            lblFullName.Text = "Full name";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(55, 103);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(398, 34);
            txtFullName.TabIndex = 12;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(40, 151);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(153, 28);
            lblPhone.TabIndex = 11;
            lblPhone.Text = "Contact number";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(40, 182);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(413, 34);
            txtPhone.TabIndex = 10;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(33, 229);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(82, 28);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(33, 260);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(420, 34);
            txtAddress.TabIndex = 8;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Location = new Point(33, 309);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(123, 28);
            lblDateOfBirth.TabIndex = 7;
            lblDateOfBirth.Text = "Date of birth";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(33, 340);
            dtpDateOfBirth.MaxDate = new DateTime(2026, 11, 20, 0, 0, 0, 0);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(200, 34);
            dtpDateOfBirth.TabIndex = 6;
            dtpDateOfBirth.Value = new DateTime(2026, 11, 20, 0, 0, 0, 0);
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(40, 388);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(202, 28);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Username (protected)";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(33, 433);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(200, 34);
            txtUsername.TabIndex = 4;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(285, 388);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(153, 28);
            lblRole.TabIndex = 3;
            lblRole.Text = "Role (protected)";
            // 
            // txtRole
            // 
            txtRole.Location = new Point(270, 433);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(190, 34);
            txtRole.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(184, 148, 88);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.FromArgb(25, 45, 75);
            btnSave.Location = new Point(33, 496);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 42);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save changes";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(25, 45, 75);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(228, 496);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 42);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(724, 600);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(txtRole);
            Controls.Add(lblRole);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(lblDateOfBirth);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimumSize = new Size(520, 510);
            Name = "ProfileForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "My Profile";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblDateOfBirth;
        private DateTimePicker dtpDateOfBirth;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblRole;
        private TextBox txtRole;
        private Button btnSave;
        private Button btnClose;
    }
}
