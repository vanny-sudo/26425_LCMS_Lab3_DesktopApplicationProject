using LegalCaseManagementSystem.Controller;

namespace LegalCaseManagementSystem.View
{
    public partial class MainForm : Form
    {
        private readonly MenuStrip _menu = new MenuStrip();
        private readonly StatusStrip _status = new StatusStrip();
        private readonly ToolStripStatusLabel _lblUser = new ToolStripStatusLabel();
        private readonly Panel _welcomePanel = new Panel();
        private readonly Label _welcomeTitle = new Label();
        private readonly Label _welcomeSubtitle = new Label();
        private readonly Label _welcomeRole = new Label();
        private readonly TableLayoutPanel _summaryCards = new TableLayoutPanel();
        private readonly DataGridView _upcomingHearings = new DataGridView();

        private static readonly Color Navy = Color.FromArgb(25, 45, 75);
        private static readonly Color Gold = Color.FromArgb(184, 148, 88);
        private static readonly Color Ivory = Color.FromArgb(245, 247, 250);

        public bool LoggedOut { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            var user = AuthController.CurrentUser;
            Text = user?.Role == "Admin" ? "LCMS - Administration Workspace" : "LCMS - Lawyer Workspace";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Normal;
            Size = new Size(1100, 720);
            MinimumSize = new Size(900, 600);
            UiStyle.ApplyProfessionalControls(this);

            BuildWelcomeSurface();
            BuildMenu();
            BuildStatusBar();
            Activated += MainForm_Activated;
        }

        private void BuildWelcomeSurface()
        {
            var user = AuthController.CurrentUser;
            _welcomePanel.BackColor = Ivory;
            _welcomePanel.Dock = DockStyle.Fill;
            _welcomePanel.Padding = new Padding(48, 48, 48, 48);

            var banner = UiStyle.CreateLegalBanner(
                user?.Role == "Admin" ? "Administration Workspace" : "Lawyer Workspace",
                user?.Role == "Admin"
                    ? "Cases, clients, users, hearings and reports in one professional workspace."
                    : "Assigned cases, hearings, status updates and legal progress at a glance.");
            banner.Location = new Point(0, 0);
            banner.Width = _welcomePanel.ClientSize.Width;
            banner.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            BuildDashboardContent();

            _welcomePanel.Controls.Add(banner);
            Controls.Add(_welcomePanel);
        }

        private void BuildMenu()
        {
            _menu.BackColor = Navy;
            _menu.ForeColor = Color.White;
            _menu.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            _menu.Dock = DockStyle.Top;
            _menu.Height = 42;
            _menu.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
            _menu.Padding = new Padding(8, 4, 8, 4);

            var isAdmin = AuthController.CurrentUser?.Role == "Admin";
            if (isAdmin)
            {
                AddMenu("Manage Users", (s, e) => { using var form = new UsersForm(); form.ShowDialog(); });
                AddMenu("Clients", (s, e) => { using var form = new ClientsForm(); form.ShowDialog(); });
            }
            AddMenu("Dashboard", (s, e) => RefreshDashboard());
            AddMenu("My Cases", (s, e) =>
            {
                using var form = new CasesForm();
                form.ShowDialog();
                RefreshDashboard();
            });
            if (isAdmin)
            {
                AddMenu("Search", (s, e) => { using var form = new SearchForm(); form.ShowDialog(); });
                AddMenu("Reports", (s, e) => { using var form = new ReportsForm(); form.ShowDialog(); });
            }
            AddMenu("New Case", (s, e) =>
            {
                using var form = new CasesForm();
                form.ShowDialog();
                RefreshDashboard();
            });
            AddMenu("Hearings", (s, e) =>
            {
                using var form = new HearingsForm();
                form.ShowDialog();
            });

            AddMenu("My Profile", (s, e) =>
            {
                using var form = new ProfileForm();
                form.ShowDialog();
            });
            AddMenu("Contact", (s, e) =>
            {
                using var form = new ContactForm();
                form.ShowDialog();
            });
            
            AddMenu("Logout", Logout_Click);
            AddMenu("Exit", (s, e) => Close());

            MainMenuStrip = _menu;
            Controls.Add(_menu);
        }

        private void AddMenu(string text, EventHandler onClick)
        {
            var item = new ToolStripMenuItem(text);
            item.BackColor = Navy;
            item.ForeColor = Color.White;
            item.Padding = new Padding(12, 5, 12, 5);
            item.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            item.Click += onClick;
            _menu.Items.Add(item);
        }

        private void BuildStatusBar()
        {
            var user = AuthController.CurrentUser;
            _lblUser.Text = user == null
                ? "Not logged in"
                : "Signed in: " + user.FullName + "  |  " + user.Role + " workspace";

            _status.BackColor = Navy;
            _status.ForeColor = Gold;
            _status.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _status.Dock = DockStyle.Bottom;
            _status.SizingGrip = false;
            _status.Height = 30;
            _status.Items.Add(_lblUser);
            Controls.Add(_status);
        }

        private void Logout_Click(object? sender, EventArgs e)
        {
            var answer = MessageBox.Show("Do you want to log out?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                AuthController.Logout();
                LoggedOut = true;
                Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void MainForm_Activated(object? sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void BuildDashboardContent()
        {
            _summaryCards.Location = new Point(52, 235);
            _summaryCards.Size = new Size(920, 105);
            _summaryCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _summaryCards.ColumnCount = 4;
            _summaryCards.RowCount = 1;
            _summaryCards.ColumnStyles.Clear();
            for (int i = 0; i < 4; i++)
                _summaryCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            _upcomingHearings.Location = new Point(52, 375);
            _upcomingHearings.Size = new Size(920, 230);
            _upcomingHearings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _upcomingHearings.ReadOnly = true;
            _upcomingHearings.AllowUserToAddRows = false;
            _upcomingHearings.AllowUserToDeleteRows = false;
            _upcomingHearings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _upcomingHearings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _upcomingHearings.BackgroundColor = Color.White;
            _upcomingHearings.EnableHeadersVisualStyles = false;
            _upcomingHearings.ColumnHeadersDefaultCellStyle.BackColor = Navy;
            _upcomingHearings.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            _upcomingHearings.DefaultCellStyle.SelectionBackColor = Gold;
            _upcomingHearings.DefaultCellStyle.SelectionForeColor = Navy;

            _welcomePanel.Controls.Add(_summaryCards);
            _welcomePanel.Controls.Add(_upcomingHearings);
        }

        private void RefreshDashboard()
        {
            try
            {
                var report = new ReportController();
                var counts = report.GetCaseCountsByStatus();
                _summaryCards.Controls.Clear();
                AddSummaryCard("TOTAL CASES", counts.Values.Sum(), Navy, 0);
                AddSummaryCard("OPEN", counts["Open"], Gold, 1);
                AddSummaryCard("IN PROGRESS", counts["In Progress"], Color.FromArgb(70, 105, 145), 2);
                AddSummaryCard("CLOSED", counts["Closed"], Color.FromArgb(105, 115, 125), 3);

                var hearings = new HearingController().GetHearings()
                    .Where(h => h.HearingDate.Date >= DateTime.Today)
                    .OrderBy(h => h.HearingDate).ThenBy(h => h.HearingTime).Take(10).ToList();
                _upcomingHearings.DataSource = hearings;
                if (_upcomingHearings.Columns.Count > 0)
                {
                    _upcomingHearings.Columns["HearingId"].Visible = false;
                    _upcomingHearings.Columns["CaseId"].Visible = false;
                    _upcomingHearings.Columns["CaseNumber"].HeaderText = "Case number";
                    _upcomingHearings.Columns["HearingDate"].HeaderText = "Date";
                    _upcomingHearings.Columns["HearingDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    _upcomingHearings.Columns["HearingTime"].HeaderText = "Time";
                    _upcomingHearings.Columns["HearingTime"].DefaultCellStyle.Format = @"hh\:mm";
                }
            }
            catch
            {
                _summaryCards.Controls.Clear();
                _upcomingHearings.DataSource = null;
            }
        }

        private void AddSummaryCard(string title, int value, Color color, int column)
        {
            var card = new Panel { Dock = DockStyle.Fill, BackColor = color, Margin = new Padding(6) };
            card.Controls.Add(new Label
            {
                Text = title + "\n" + value,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold)
            });
            _summaryCards.Controls.Add(card, column, 0);
        }
    }
}