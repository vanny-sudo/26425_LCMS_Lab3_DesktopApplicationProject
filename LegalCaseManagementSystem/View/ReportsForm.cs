using LegalCaseManagementSystem.Controller;

namespace LegalCaseManagementSystem.View
{
    public partial class ReportsForm : Form
    {
        private readonly ReportController _controller = new ReportController();

        public ReportsForm()
        {
            InitializeComponent();
            UiStyle.Maximize(this);

            UiStyle.ConfigureGrid(dgvHearings);
            UiStyle.ConfigureGrid(dgvClosed);

            lblSummary.Font = new Font(lblSummary.Font, FontStyle.Bold);
            lblHearingsTitle.Font = new Font(lblHearingsTitle.Font, FontStyle.Bold);
            lblClosedTitle.Font = new Font(lblClosedTitle.Font, FontStyle.Bold);
            lblSummary.AutoSize = true;
            lblHearingsTitle.AutoSize = true;
            lblClosedTitle.AutoSize = true;

            Load += ReportsForm_Load;
        }

        private static void SetupGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ReportsForm_Load(object? sender, EventArgs e)
        {
            try
            {
                LoadSummary();
                LoadHearings();
                LoadClosedCases();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load reports: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSummary()
        {
            var counts = _controller.GetCaseCountsByStatus();
            int total = counts.Values.Sum();

            lblSummary.Text =
                "Cases by status:   Open = " + counts["Open"] +
                "   |   In Progress = " + counts["In Progress"] +
                "   |   Closed = " + counts["Closed"] +
                "   |   Total = " + total;
        }

        private void LoadHearings()
        {
            var hearings = _controller.GetHearingsThisWeek(out DateTime from, out DateTime to);

            lblHearingsTitle.Text =
                "Hearings coming up this week (" + from.ToString("dd/MM/yyyy") +
                " to " + to.ToString("dd/MM/yyyy") + "): " + hearings.Count;

            dgvHearings.DataSource = hearings;

            dgvHearings.Columns["HearingId"]!.Visible = false;
            dgvHearings.Columns["CaseId"]!.Visible = false;
            dgvHearings.Columns["CaseNumber"]!.HeaderText = "Case number";
            dgvHearings.Columns["LawyerName"]!.HeaderText = "Lawyer";
            dgvHearings.Columns["HearingDate"]!.HeaderText = "Date";
            dgvHearings.Columns["HearingDate"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHearings.Columns["HearingTime"]!.HeaderText = "Time";
            dgvHearings.Columns["HearingTime"]!.DefaultCellStyle.Format = @"hh\:mm";
            dgvHearings.Columns["Court"]!.HeaderText = "Court";
        }

        private void LoadClosedCases()
        {
            var closed = _controller.GetClosedCases();

            lblClosedTitle.Text = "Closed cases: " + closed.Count;

            dgvClosed.DataSource = closed;

            dgvClosed.Columns["CaseId"]!.Visible = false;
            dgvClosed.Columns["ClientId"]!.Visible = false;
            dgvClosed.Columns["LawyerId"]!.Visible = false;
            dgvClosed.Columns["CaseNumber"]!.HeaderText = "Case number";
            dgvClosed.Columns["Title"]!.HeaderText = "Title";
            dgvClosed.Columns["CaseType"]!.HeaderText = "Type";
            dgvClosed.Columns["ClientName"]!.HeaderText = "Client";
            dgvClosed.Columns["LawyerName"]!.HeaderText = "Lawyer";
            dgvClosed.Columns["DateOpened"]!.HeaderText = "Date opened";
            dgvClosed.Columns["DateOpened"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvClosed.Columns["Status"]!.HeaderText = "Status";
        }
    }
}