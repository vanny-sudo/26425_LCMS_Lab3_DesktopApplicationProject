namespace LegalCaseManagementSystem.View
{
    partial class ContactForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactForm));
            lblTitle = new Label();
            lblDetails = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(25, 45, 75);
            lblTitle.Location = new Point(36, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(476, 54);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Contact the Legal Office";
            // 
            // lblDetails
            // 
            lblDetails.AutoSize = true;
            lblDetails.Font = new Font("Segoe UI", 11F);
            lblDetails.ForeColor = Color.FromArgb(55, 66, 82);
            lblDetails.Location = new Point(40, 92);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(597, 180);
            lblDetails.TabIndex = 1;
            lblDetails.Text = resources.GetString("lblDetails.Text");
            lblDetails.Click += lblDetails_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(25, 45, 75);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(36, 320);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 42);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // ContactForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(865, 439);
            Controls.Add(btnClose);
            Controls.Add(lblDetails);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            Name = "ContactForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Contact Support";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblDetails;
        private Button btnClose;
    }
}
