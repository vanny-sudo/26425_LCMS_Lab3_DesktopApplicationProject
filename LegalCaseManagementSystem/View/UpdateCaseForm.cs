using LegalCaseManagementSystem.Controller;
using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.View
{
    public partial class UpdateCaseForm : Form
    {
        private readonly CaseUpdateController _controller = new CaseUpdateController();
        private List<LegalCase> _cases = new List<LegalCase>();

        public UpdateCaseForm()
        {
            InitializeComponent();

            cboCase.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new object[] { "Open", "In Progress", "Closed" });

            txtNote.Multiline = true;
            txtNote.MaxLength = 500;

            dgvNotes.ReadOnly = true;
            dgvNotes.AllowUserToAddRows = false;
            dgvNotes.AllowUserToDeleteRows = false;
            dgvNotes.MultiSelect = false;
            dgvNotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Load += UpdateCaseForm_Load;
            cboCase.SelectionChangeCommitted += (s, e) => ShowSelectedCase();
            btnSaveStatus.Click += btnSaveStatus_Click;
            btnAddNote.Click += btnAddNote_Click;
        }

        private void UpdateCaseForm_Load(object? sender, EventArgs e)
        {
            try
            {
                LoadCases(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load cases: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int SelectedCaseId()
        {
            return cboCase.SelectedIndex >= 0 ? (int)cboCase.SelectedValue! : 0;
        }

        private void LoadCases(int? selectCaseId)
        {
            _cases = _controller.GetCases();

            var items = _cases
                .Select(c => new { c.CaseId, Text = c.CaseNumber + " - " + c.Title })
                .ToList();

            cboCase.DisplayMember = "Text";
            cboCase.ValueMember = "CaseId";
            cboCase.DataSource = items;
            cboCase.SelectedIndex = -1;

            if (selectCaseId != null)
                cboCase.SelectedValue = selectCaseId.Value;

            ShowSelectedCase();
        }

        private void ShowSelectedCase()
        {
            int id = SelectedCaseId();
            var current = _cases.FirstOrDefault(c => c.CaseId == id);

            cboStatus.SelectedItem = current?.Status;
            txtNote.Clear();
            LoadNotes(id);
        }

        private void LoadNotes(int caseId)
        {
            if (caseId == 0)
            {
                dgvNotes.DataSource = null;
                return;
            }

            dgvNotes.DataSource = _controller.GetNotes(caseId);

            dgvNotes.Columns["NoteId"]!.Visible = false;
            dgvNotes.Columns["CaseId"]!.Visible = false;
            dgvNotes.Columns["NoteDate"]!.HeaderText = "Date";
            dgvNotes.Columns["NoteDate"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvNotes.Columns["NoteDate"]!.FillWeight = 25;
            dgvNotes.Columns["NoteText"]!.HeaderText = "Note";
            dgvNotes.Columns["NoteText"]!.FillWeight = 75;
        }

        private void btnSaveStatus_Click(object? sender, EventArgs e)
        {
            int id = SelectedCaseId();

            if (_controller.UpdateStatus(id, cboStatus.Text, out string message))
            {
                MessageBox.Show(message, "Update Case",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCases(id);
            }
            else
            {
                MessageBox.Show(message, "Update Case",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddNote_Click(object? sender, EventArgs e)
        {
            int id = SelectedCaseId();

            if (_controller.AddNote(id, txtNote.Text, out string message))
            {
                txtNote.Clear();
                LoadNotes(id);
                MessageBox.Show(message, "Update Case",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Update Case",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}