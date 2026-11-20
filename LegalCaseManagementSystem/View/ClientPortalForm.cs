using LegalCaseManagementSystem.Controller;
using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.View
{
    public partial class ClientPortalForm : Form
    {
        private readonly ClientPortalController _controller = new ClientPortalController();
        private List<LegalCase> _cases = new List<LegalCase>();
        private static readonly Color Navy = Color.FromArgb(25, 45, 75);
        private static readonly Color Gold = Color.FromArgb(184, 148, 88);
        private static readonly Color Ivory = Color.FromArgb(245, 247, 250);

        public bool LoggedOut { get; private set; }

        public ClientPortalForm()
        {
            InitializeComponent();
            UiStyle.Maximize(this);

            UiStyle.ConfigureGrid(dgvCases);
            UiStyle.ConfigureGrid(dgvHearings);
            UiStyle.ApplyProfessionalControls(this);

            Load += ClientPortalForm_Load;
            btnLogout.Click += btnLogout_Click;
            btnProfile.Click += (s, e) => ShowProfile();
            btnContact.Click += (s, e) => ShowContact();
        }

        private void ClientPortalForm_Load(object? sender, EventArgs e)
        {
            var user = AuthController.CurrentUser;
            lblWelcome.Text = user == null
                ? "Welcome"
                : "Welcome, " + user.FullName;

            try
            {
                LoadCases();
                LoadHearings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load your case information: " + ex.Message,
                    "Client Portal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCases()
        {
            _cases = _controller.GetCases();
            dgvCases.DataSource = _cases;

            if (dgvCases.Columns["CaseId"] != null)
                dgvCases.Columns["CaseId"]!.Visible = false;
            if (dgvCases.Columns["ClientId"] != null)
                dgvCases.Columns["ClientId"]!.Visible = false;
            if (dgvCases.Columns["LawyerId"] != null)
                dgvCases.Columns["LawyerId"]!.Visible = false;

            SetHeader("CaseNumber", "Case number");
            SetHeader("CaseType", "Type");
            SetHeader("LawyerName", "Lawyer");
            SetHeader("DateOpened", "Date opened");
            SetHeader("Status", "Status");
            if (dgvCases.Columns["DateOpened"] != null)
            {
                dgvCases.Columns["DateOpened"]!.HeaderText = "Opened";
                dgvCases.Columns["DateOpened"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void LoadHearings()
        {
            var hearings = _controller.GetHearings()
                .Where(h => h.HearingDate.Date >= DateTime.Today)
                .OrderBy(h => h.HearingDate)
                .ThenBy(h => h.HearingTime)
                .ToList();
            dgvHearings.DataSource = hearings;

            if (dgvHearings.Columns["HearingId"] != null)
                dgvHearings.Columns["HearingId"]!.Visible = false;
            if (dgvHearings.Columns["CaseId"] != null)
                dgvHearings.Columns["CaseId"]!.Visible = false;

            SetHeader(dgvHearings, "CaseNumber", "Case number");
            SetHeader(dgvHearings, "LawyerName", "Lawyer");
            SetHeader(dgvHearings, "HearingDate", "Date");
            SetHeader(dgvHearings, "HearingTime", "Time");
            SetHeader(dgvHearings, "Court", "Court");
        }

        private void SetHeader(string columnName, string headerText)
        {
            SetHeader(dgvCases, columnName, headerText);
        }

        private static void SetHeader(DataGridView grid, string columnName, string headerText)
        {
            if (grid.Columns[columnName] != null)
                grid.Columns[columnName]!.HeaderText = headerText;
        }

        private static void ConfigureGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            AuthController.Logout();
            LoggedOut = true;
            Close();
        }

        private void ShowProfile()
        {
            var user = AuthController.CurrentUser;
            using var profile = new Form
            {
                Text = "My Profile",
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(540, 390),
                BackColor = Ivory,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            var title = CreateTitle("My Client Profile");
            var details = new Label
            {
                Text = "Your secure account information\n\nFull name: " + Model.ProfileDisplay.Text(user?.FullName) +
                    "\nUsername: " + Model.ProfileDisplay.Text(user?.Username) +
                    "\nPhone: " + Model.ProfileDisplay.Text(user?.Phone) +
                    "\nAddress: " + Model.ProfileDisplay.Text(user?.Address) +
                    "\nDate of birth: " + Model.ProfileDisplay.Date(user?.DateOfBirth) +
                    "\nAccount type: Client\n\nYour case information is private and can only be viewed by your account.",
                AutoSize = true,
                Location = new Point(38, 95),
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(55, 66, 82)
            };
            var close = CreateButton("Close", 38, 305, Navy, Color.White);
            close.Click += (s, e) => profile.Close();
            profile.Controls.AddRange(new Control[] { title, details, close });
            profile.ShowDialog(this);
        }

        private void ShowContact()
        {
            using var contact = new Form
            {
                Text = "Contact Legal Support",
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(540, 390),
                BackColor = Ivory,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            var title = CreateTitle("Legal Support Centre");
            var details = new Label
            {
                Text = "Need help with your case or upcoming hearing?\n\nLegal Case Management Office\nEmail: support@legalcasemanagement.local\nPhone: +1 555 010 2000\nOffice hours: Monday - Friday, 08:00 - 17:00",
                AutoSize = true,
                Location = new Point(38, 95),
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(55, 66, 82)
            };
            var close = CreateButton("Close", 38, 305, Navy, Color.White);
            close.Click += (s, e) => contact.Close();
            contact.Controls.AddRange(new Control[] { title, details, close });
            contact.ShowDialog(this);
        }

        private static Label CreateTitle(string text) => new Label
        {
            Text = text,
            AutoSize = true,
            Location = new Point(34, 30),
            Font = new Font("Segoe UI", 20F, FontStyle.Bold),
            ForeColor = Navy
        };

        private static Button CreateButton(string text, int x, int y, Color background, Color foreground) => new Button
        {
            Text = text,
            Location = new Point(x, y),
            Size = new Size(145, 42),
            BackColor = background,
            ForeColor = foreground,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderSize = 0 }
        };
    }
}
