namespace LegalCaseManagementSystem.View
{
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
            UiStyle.ApplyProfessionalControls(this);
            Text = "LCMS | Legal Support";
            btnClose.Click += (s, e) => Close();
        }

        private void lblDetails_Click(object sender, EventArgs e)
        {

        }
    }
}
