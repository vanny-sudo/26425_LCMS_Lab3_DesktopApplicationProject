using LegalCaseManagementSystem.Controller;
using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.View
{
    public partial class ClientsForm : Form
    {
        private readonly ClientController _controller = new ClientController();
        private int _selectedId = 0;   

        public ClientsForm()
        {
            InitializeComponent();
            UiStyle.Maximize(this);

            dgvClients.ReadOnly = true;
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.MultiSelect = false;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UiStyle.ConfigureGrid(dgvClients);

            Load += (s, e) => LoadClients();
            dgvClients.CellClick += dgvClients_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += (s, e) => ClearForm();
        }

        private void LoadClients()
        {
            try
            {
                dgvClients.DataSource = _controller.GetAll();

                dgvClients.Columns["ClientId"]!.HeaderText = "ID";
                dgvClients.Columns["FullName"]!.HeaderText = "Full name";
                dgvClients.Columns["Phone"]!.HeaderText = "Phone";
                HideColumn("Address");
                HideColumn("DateOfBirth");

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load clients: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideColumn(string columnName)
        {
            if (dgvClients.Columns[columnName] != null)
                dgvClients.Columns[columnName].Visible = false;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            txtName.Clear();
            txtPhone.Clear();
            dgvClients.ClearSelection();
            txtName.Focus();
        }

        private void dgvClients_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvClients.Rows[e.RowIndex].DataBoundItem is Client c)
            {
                _selectedId = c.ClientId;
                txtName.Text = c.FullName;
                txtPhone.Text = c.Phone;
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            var client = new Client
            {
                ClientId = 0,
                FullName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };
            SaveClient(client);
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Please click a client in the list first.", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var client = new Client
            {
                ClientId = _selectedId,
                FullName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };
            SaveClient(client);
        }

        private void SaveClient(Client client)
        {
            if (_controller.Save(client, out string message))
            {
                MessageBox.Show(message, "Clients",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClients();
            }
            else
            {
                MessageBox.Show(message, "Clients",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Please click a client in the list first.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var answer = MessageBox.Show("Do you really want to delete this client?",
                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            if (_controller.Delete(_selectedId, out string message))
            {
                MessageBox.Show(message, "Clients",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClients();
            }
            else
            {
                MessageBox.Show(message, "Clients",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}