using LegalCaseManagementSystem.Controller;

namespace LegalCaseManagementSystem.View
{
    public partial class RegisterForm : Form
    {
        private readonly AuthController _auth = new AuthController();

        public RegisterForm()
        {
            InitializeComponent();
            UiStyle.ApplyAuthenticationTheme(this);
            Text = "LCMS | Create Account";

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Items.AddRange(new object[] { "Client", "Lawyer" });
            cboRole.SelectedIndex = 0;
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;
            AcceptButton = btnRegister;
            CancelButton = btnCancel;

            btnRegister.Click += btnRegister_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Registration",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            if (_auth.RegisterUser(
                txtFullName.Text,
                txtPhone.Text,
                txtUsername.Text,
                txtPassword.Text,
                cboRole.Text,
                out string message))
            {
                MessageBox.Show(message, "Registration",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show(message, "Registration",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void cboRole_SelectedIndexChanged(object? sender, EventArgs e)
        {
            bool isClient = cboRole.Text == "Client";
            lblPhone.Visible = isClient;
            txtPhone.Visible = isClient;

            if (!isClient)
                txtPhone.Clear();
        }
    }
}
