using LegalCaseManagementSystem.Controller;

namespace LegalCaseManagementSystem.View
{
    public partial class ProfileForm : Form
    {
        private readonly UserController _controller = new UserController();

        public ProfileForm()
        {
            InitializeComponent();
            UiStyle.ApplyProfessionalControls(this);
            Text = "My Profile";
            dtpDateOfBirth.MaxDate = DateTime.Today;
            Load += ProfileForm_Load;
            btnSave.Click += btnSave_Click;
            btnClose.Click += (s, e) => Close();
        }

        private void ProfileForm_Load(object? sender, EventArgs e)
        {
            var profile = _controller.GetOwnProfile(out string message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "My Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFullName.Text = profile.FullName;
            txtPhone.Text = profile.Phone == Model.ProfileDisplay.Missing ? "" : profile.Phone;
            txtAddress.Text = profile.Address == Model.ProfileDisplay.Missing ? "" : profile.Address;
            dtpDateOfBirth.Value = profile.DateOfBirth ?? DateTime.Today.AddYears(-25);
            txtUsername.Text = profile.Username;
            txtRole.Text = profile.Role;
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            var current = AuthController.CurrentUser;
            if (current == null) return;

            var profile = new Model.User
            {
                UserId = current.UserId,
                FullName = txtFullName.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                DateOfBirth = dtpDateOfBirth.Value.Date,
                Username = current.Username,
                Role = current.Role
            };

            if (_controller.UpdateOwnProfile(profile, out string message))
            {
                MessageBox.Show(message, "My Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show(message, "My Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
