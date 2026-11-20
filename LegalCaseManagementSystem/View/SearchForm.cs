using LegalCaseManagementSystem.Controller;

namespace LegalCaseManagementSystem.View
{
    public partial class SearchForm : Form
    {
        private readonly SearchController _controller = new SearchController();

        public SearchForm()
        {
            InitializeComponent();
            UiStyle.Maximize(this);

            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new object[] { "All", "Open", "In Progress", "Closed" });
            cboStatus.SelectedIndex = 0;

            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.MultiSelect = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UiStyle.ConfigureGrid(dgvResults);

            AcceptButton = btnSearch;   

            Load += (s, e) => RunSearch();   
            btnSearch.Click += (s, e) => RunSearch();
            btnClear.Click += (s, e) =>
            {
                txtCaseNumber.Clear();
                txtClientName.Clear();
                cboStatus.SelectedIndex = 0;
                RunSearch();
            };
        }

        private void RunSearch()
        {
            try
            {
                var results = _controller.Search(
                    txtCaseNumber.Text, txtClientName.Text, cboStatus.Text);

                dgvResults.DataSource = results;

                dgvResults.Columns["CaseId"]!.Visible = false;
                dgvResults.Columns["ClientId"]!.Visible = false;
                dgvResults.Columns["LawyerId"]!.Visible = false;

                dgvResults.Columns["CaseNumber"]!.HeaderText = "Case number";
                dgvResults.Columns["Title"]!.HeaderText = "Title";
                dgvResults.Columns["CaseType"]!.HeaderText = "Type";
                dgvResults.Columns["ClientName"]!.HeaderText = "Client";
                dgvResults.Columns["LawyerName"]!.HeaderText = "Lawyer";
                dgvResults.Columns["DateOpened"]!.HeaderText = "Date opened";
                dgvResults.Columns["DateOpened"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvResults.Columns["Status"]!.HeaderText = "Status";

                lblResult.Text = results.Count == 0
                    ? "No case found."
                    : results.Count + " case(s) found.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}