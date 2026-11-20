using LegalCaseManagementSystem.Controller;
using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.View
{
    public partial class HearingsForm : Form
    {
        private readonly HearingController _controller = new HearingController();
        private int _selectedHearingId = 0;   

        public HearingsForm()
        {
            InitializeComponent();
            UiStyle.Maximize(this);

            dgvHearings.ReadOnly = true;
            dgvHearings.AllowUserToAddRows = false;
            dgvHearings.AllowUserToDeleteRows = false;
            dgvHearings.MultiSelect = false;
            dgvHearings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UiStyle.ConfigureGrid(dgvHearings);

            cboCase.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpDate.MinDate = DateTime.Today;
            dtpDate.Format = DateTimePickerFormat.Short;

            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.CustomFormat = "HH:mm";
            dtpTime.ShowUpDown = true;

            Load += HearingsForm_Load;
            dgvHearings.CellClick += dgvHearings_CellClick;
            btnSchedule.Click += btnSchedule_Click;
            btnCancelHearing.Click += btnCancelHearing_Click;
            btnClear.Click += (s, e) => ClearForm();
        }

        private void HearingsForm_Load(object? sender, EventArgs e)
        {
            try
            {
                var cases = _controller.GetSchedulableCases()
                    .Select(c => new { c.CaseId, Text = c.CaseNumber + " - " + c.Title })
                    .ToList();

                cboCase.DisplayMember = "Text";
                cboCase.ValueMember = "CaseId";
                cboCase.DataSource = cases;

                LoadHearings();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHearings()
        {
            dgvHearings.DataSource = _controller.GetHearings();

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

        private void ClearForm()
        {
            _selectedHearingId = 0;
            cboCase.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Today.AddHours(9);   
            txtCourt.Clear();
            dgvHearings.ClearSelection();
        }

        private void dgvHearings_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvHearings.Rows[e.RowIndex].DataBoundItem is Hearing h)
                _selectedHearingId = h.HearingId;
        }

        private void btnSchedule_Click(object? sender, EventArgs e)
        {
            var time = dtpTime.Value.TimeOfDay;

            var hearing = new Hearing
            {
                CaseId = cboCase.SelectedIndex >= 0 ? (int)cboCase.SelectedValue! : 0,
                HearingDate = dtpDate.Value.Date,
                HearingTime = new TimeSpan(time.Hours, time.Minutes, 0),
                Court = txtCourt.Text.Trim()
            };

            if (_controller.Schedule(hearing, out string message))
            {
                MessageBox.Show(message, "Hearings",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHearings();
                ClearForm();
            }
            else
            {
                MessageBox.Show(message, "Hearings",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelHearing_Click(object? sender, EventArgs e)
        {
            if (_selectedHearingId == 0)
            {
                MessageBox.Show("Please click a hearing in the list first.", "Cancel",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var answer = MessageBox.Show("Do you really want to cancel this hearing?",
                "Cancel hearing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            if (_controller.Cancel(_selectedHearingId, out string message))
            {
                MessageBox.Show(message, "Hearings",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHearings();
                ClearForm();
            }
            else
            {
                MessageBox.Show(message, "Hearings",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}