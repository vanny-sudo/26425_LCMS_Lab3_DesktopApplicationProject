using LegalCaseManagementSystem.Controller;
using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.View
{
    public partial class CasesForm : Form
    {
        private readonly CaseController _controller = new CaseController();
        private readonly bool _isAdmin;
        private int _selectedCaseId = 0;   

        public CasesForm()
        {
            InitializeComponent();
            UiStyle.Maximize(this);
            UiStyle.ApplyProfessionalControls(this);

            Text = "My Cases and New Case";
            foreach (Control control in new Control[]
            {
                lblCaseNumber, txtCaseNumber, lblTitle, txtTitle, lblType, cboCaseType,
                lblClient, cboClient, lblLawyer, cboLawyer, lblDate, dtpDateOpened,
                btnOpenCase, btnAssign, btnClear
            })
            {
                control.Visible = control != lblLawyer && control != cboLawyer && control != btnAssign;
            }

            lblLawyer.Visible = false;
            cboLawyer.Visible = false;
            btnAssign.Visible = false;
            btnSetOpen.Visible = false;
            btnSetInProgress.Visible = false;
            btnSetClosed.Visible = false;

            dgvCases.ReadOnly = true;
            dgvCases.AllowUserToAddRows = false;
            dgvCases.AllowUserToDeleteRows = false;
            dgvCases.MultiSelect = false;
            dgvCases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UiStyle.ConfigureGrid(dgvCases);
            dgvCases.CellContentClick += dgvCases_CellContentClick;

            cboCaseType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCaseType.Items.AddRange(new object[]
            {
                "Civil", "Criminal", "Land Dispute", "Family", "Commercial", "Labour", "Other"
            });

            Load += CasesForm_Load;
            dgvCases.CellClick += dgvCases_CellClick;
            btnOpenCase.Click += btnOpenCase_Click;
            btnSetOpen.Click += (s, e) => ChangeStatus("Open");
            btnSetInProgress.Click += (s, e) => ChangeStatus("In Progress");
            btnSetClosed.Click += (s, e) => ChangeStatus("Closed");
            btnClear.Click += (s, e) => ClearForm();
        }

        private void CasesForm_Load(object? sender, EventArgs e)
        {
            try
            {
                cboClient.DisplayMember = "FullName";
                cboClient.ValueMember = "ClientId";
                cboClient.DataSource = _controller.GetClients();

                LoadCases();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCases()
        {
            dgvCases.DataSource = _controller.GetCases();

            dgvCases.Columns["CaseId"]!.Visible = false;
            dgvCases.Columns["ClientId"]!.Visible = false;
            dgvCases.Columns["LawyerId"]!.Visible = false;

            dgvCases.Columns["CaseNumber"]!.HeaderText = "Case number";
            dgvCases.Columns["Title"]!.HeaderText = "Title";
            dgvCases.Columns["CaseType"]!.HeaderText = "Type";
            dgvCases.Columns["ClientName"]!.HeaderText = "Client";
            dgvCases.Columns["LawyerName"]!.HeaderText = "Lawyer";
            dgvCases.Columns["DateOpened"]!.HeaderText = "Date opened";
            dgvCases.Columns["DateOpened"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCases.Columns["DateOpened"]!.Visible = false;
            dgvCases.Columns["Status"]!.HeaderText = "Status";
            dgvCases.Columns["NextHearing"]!.HeaderText = "Next hearing";
            dgvCases.Columns["LawyerName"]!.Visible = false;

            if (!dgvCases.Columns.Contains("Action"))
            {
                dgvCases.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Action",
                    HeaderText = "Action",
                    Text = "Change status",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 18
                });
            }
        }

        private void dgvCases_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                dgvCases.Columns[e.ColumnIndex].Name != "Action") return;

            if (dgvCases.Rows[e.RowIndex].DataBoundItem is LegalCase c)
            {
                _selectedCaseId = c.CaseId;
                ShowStatusDialog(c);
            }
        }

        private void ShowStatusDialog(LegalCase legalCase)
        {
            using var dialog = new Form
            {
                Text = "Change case status",
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(360, 185),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(245, 247, 250)
            };

            var prompt = new Label
            {
                Text = legalCase.CaseNumber + "\nCurrent status: " + legalCase.Status + "\nChoose the new status:",
                AutoSize = true,
                Location = new Point(20, 18),
                ForeColor = Color.FromArgb(25, 45, 75),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            var statuses = new ComboBox
            {
                Location = new Point(20, 88),
                Size = new Size(320, 32),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            statuses.Items.AddRange(new object[] { "Open", "In Progress", "Closed" });
            statuses.SelectedItem = legalCase.Status;
            var save = new Button
            {
                Text = "Save status",
                Location = new Point(20, 132),
                Size = new Size(145, 36),
                BackColor = Color.FromArgb(184, 148, 88),
                ForeColor = Color.FromArgb(25, 45, 75),
                FlatStyle = FlatStyle.Flat
            };
            var cancel = new Button
            {
                Text = "Cancel",
                Location = new Point(195, 132),
                Size = new Size(145, 36),
                DialogResult = DialogResult.Cancel,
                FlatStyle = FlatStyle.Flat
            };
            save.Click += (s, e) =>
            {
                ChangeStatus(statuses.Text);
                dialog.DialogResult = DialogResult.OK;
                dialog.Close();
            };
            dialog.Controls.AddRange(new Control[] { prompt, statuses, save, cancel });
            dialog.AcceptButton = save;
            dialog.CancelButton = cancel;
            dialog.ShowDialog(this);
        }

        private void ClearForm()
        {
            _selectedCaseId = 0;
            dgvCases.ClearSelection();

            txtCaseNumber.Text = _controller.GetNextCaseNumber();
            txtTitle.Clear();
            cboCaseType.SelectedIndex = -1;
            cboClient.SelectedIndex = -1;
            dtpDateOpened.Value = DateTime.Today;
            txtTitle.Focus();
        }

        private void dgvCases_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCases.Rows[e.RowIndex].DataBoundItem is LegalCase c)
            {
                _selectedCaseId = c.CaseId;
            }
        }

        private void btnOpenCase_Click(object? sender, EventArgs e)
        {
            var newCase = new LegalCase
            {
                CaseNumber = txtCaseNumber.Text,
                Title = txtTitle.Text.Trim(),
                CaseType = cboCaseType.Text,
                ClientId = cboClient.SelectedIndex >= 0 ? (int)cboClient.SelectedValue! : 0,
                LawyerId = 0,
                DateOpened = dtpDateOpened.Value.Date
            };

            if (_controller.OpenCase(newCase, out string message))
            {
                MessageBox.Show(message, "Cases",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCases();
                ClearForm();
            }
            else
            {
                MessageBox.Show(message, "Case status",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ChangeStatus(string status)
        {
            if (_selectedCaseId == 0)
            {
                MessageBox.Show("Please click a case in the table first.", "Case status",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var controller = new CaseUpdateController();
            if (controller.UpdateStatus(_selectedCaseId, status, out string message))
            {
                MessageBox.Show(message, "Case status",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCases();
            }
            else
            {
                MessageBox.Show(message, "Case status",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}