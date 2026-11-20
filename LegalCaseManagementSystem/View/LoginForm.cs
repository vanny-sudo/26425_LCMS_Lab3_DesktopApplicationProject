using LegalCaseManagementSystem.Controller;

namespace LegalCaseManagementSystem.View
{
    public partial class LoginForm : Form
    {
        private readonly AuthController _auth = new AuthController();

        public LoginForm()
        {
            InitializeComponent();
            UiStyle.ApplyAuthenticationTheme(this);
            Text = "LCMS | Secure Sign In";

            btnLogin.Click += btnLogin_Click;
            btnExit.Click += btnExit_Click;
            btnRegister.Click += btnRegister_Click;
            AcceptButton = btnLogin;   
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            if (_auth.Login(txtUsername.Text, txtPassword.Text, out string message))
            {
                DialogResult = DialogResult.OK;  
            }
            else
            {
                MessageBox.Show(message, "Login failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            using var register = new RegisterForm();
            register.ShowDialog(this);
        }
    }
}