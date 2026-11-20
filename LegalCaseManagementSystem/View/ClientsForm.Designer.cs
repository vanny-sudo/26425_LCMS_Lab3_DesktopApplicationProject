namespace LegalCaseManagementSystem.View
{
    partial class ClientsForm
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
            lblName = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvClients = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            var navy = Color.FromArgb(25, 45, 75);
            var gold = Color.FromArgb(184, 148, 88);
            var ivory = Color.FromArgb(245, 247, 250);
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(117, 60);
            lblName.Name = "lblName";
            lblName.Size = new Size(88, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Full name";
            lblName.ForeColor = navy;
            // 
            // txtName
            // 
            txtName.Location = new Point(271, 57);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 31);
            txtName.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(117, 145);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(62, 25);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone";
            lblPhone.ForeColor = navy;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(271, 139);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(150, 31);
            txtPhone.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(45, 237);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(104, 46);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.BackColor = gold;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = navy;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(191, 237);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(122, 46);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.BackColor = navy;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(347, 237);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(134, 46);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.BackColor = Color.FromArgb(170, 68, 68);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(524, 231);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(125, 52);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.BackColor = Color.FromArgb(220, 224, 230);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = navy;
            // 
            // dgvClients
            // 
            dgvClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(723, 28);
            dgvClients.Name = "dgvClients";
            dgvClients.RowHeadersWidth = 62;
            dgvClients.Size = new Size(360, 255);
            dgvClients.TabIndex = 8;
            dgvClients.BackgroundColor = Color.White;
            dgvClients.BorderStyle = BorderStyle.FixedSingle;
            dgvClients.EnableHeadersVisualStyles = false;
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClients.DefaultCellStyle.SelectionBackColor = gold;
            dgvClients.DefaultCellStyle.SelectionForeColor = navy;
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ivory;
            ClientSize = new Size(1192, 390);
            Controls.Add(dgvClients);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Name = "ClientsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Clients";
            Font = new Font("Segoe UI", 10F);
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvClients;
    }
}