using LegalCaseManagementSystem.Controller;

namespace LegalCaseManagementSystem.View
{
    public partial class UsersForm : Form
    {
        private readonly UserController _controller = new UserController();

        public UsersForm()
        {
            InitializeComponent();
            UiStyle.Maximize(this);
            UiStyle.ConfigureGrid(dgvUsers);
            UiStyle.ApplyProfessionalControls(this);
            Text = "LCMS | Manage Users";
            cboRole.SelectedIndex = 0;
            btnCreate.Click += Create_Click;
            btnUpdate.Click += Update_Click;
            btnDelete.Click += Delete_Click;
            dgvUsers.SelectionChanged += Users_SelectionChanged;
            Load += (s, e) => LoadUsers();
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = _controller.GetAll();
            if (dgvUsers.Columns["UserId"] != null) dgvUsers.Columns["UserId"].Visible = false;
            if (dgvUsers.Columns["ClientId"] != null) dgvUsers.Columns["ClientId"].Visible = false;
            SetHeader("FullName", "Full name");
            SetHeader("Username", "Username");
            SetHeader("Role", "Role");
            HideColumn("Phone");
            HideColumn("Address");
            HideColumn("DateOfBirth");
            if (dgvUsers.Rows.Count > 0) dgvUsers.Rows[0].Selected = false;
        }

        private void SetHeader(string columnName, string header)
        {
            if (dgvUsers.Columns[columnName] != null) dgvUsers.Columns[columnName].HeaderText = header;
        }

        private void HideColumn(string columnName)
        {
            if (dgvUsers.Columns[columnName] != null) dgvUsers.Columns[columnName].Visible = false;
        }

        private void Users_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.DataBoundItem is not Model.User user) return;
            txtFullName.Text = user.FullName;
            txtUsername.Text = user.Username;
            cboRole.SelectedItem = user.Role;
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private int SelectedUserId => dgvUsers.CurrentRow?.DataBoundItem is Model.User user ? user.UserId : 0;

        private void Create_Click(object? sender, EventArgs e)
        {
            if (_controller.Create(txtFullName.Text, txtUsername.Text, txtPassword.Text,
                txtConfirmPassword.Text, cboRole.Text, out string message))
            {
                MessageBox.Show(message, "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFullName.Clear(); txtUsername.Clear(); txtPassword.Clear(); txtConfirmPassword.Clear(); LoadUsers();
            }
            else
            {
                MessageBox.Show(message, "Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Update_Click(object? sender, EventArgs e)
        {
            if (SelectedUserId == 0)
            {
                MessageBox.Show("Select a user from the table first.", "Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_controller.Update(SelectedUserId, txtFullName.Text, txtUsername.Text, txtPassword.Text,
                txtConfirmPassword.Text, cboRole.Text, out string message))
            {
                MessageBox.Show(message, "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            else MessageBox.Show(message, "Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Delete_Click(object? sender, EventArgs e)
        {
            if (SelectedUserId == 0)
            {
                MessageBox.Show("Select a user from the table first.", "Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Delete the selected user account? This action cannot be undone.", "Confirm deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (_controller.Delete(SelectedUserId, out string message))
            {
                MessageBox.Show(message, "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFullName.Clear(); txtUsername.Clear(); txtPassword.Clear(); txtConfirmPassword.Clear();
                LoadUsers();
            }
            else
            {
                MessageBox.Show(message, "Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
