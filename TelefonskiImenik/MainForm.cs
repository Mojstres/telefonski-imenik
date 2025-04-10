using System;
using System.Configuration;
using System.Windows.Forms;
using TelefonskiImenik.DataAccess;
using TelefonskiImenik.Logic;

namespace TelefonskiImenik
{
    public partial class MainForm : Form
    {
        private readonly ContactService _contactService;

        public MainForm()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            var repository = new ContactRepository(connectionString);
            _contactService = new ContactService(repository);

            LoadContacts();
        }

        private void LoadContacts()
        {
            var contacts = _contactService.GetAllContacts();
            dgvContacts.DataSource = contacts;

            if (dgvContacts.Columns["Id"] != null)
                dgvContacts.Columns["Id"].Visible = false;

            dgvContacts.Columns["Naziv"].HeaderText = "Ime in Priimek";
            dgvContacts.Columns["Stevilka"].HeaderText = "Telefonska številka";
            dgvContacts.RowHeadersVisible = false;
            dgvContacts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            var results = _contactService.SearchContacts(query);
            dgvContacts.DataSource = results;
        }

        private void BtnDodaj_Click(object sender, EventArgs e)
        {
            var form = new AddContactForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newContact = new Contact(0, form.ContactName, form.ContactNumber);
                _contactService.AddContact(newContact);
                LoadContacts();
            }
        }
    }
}
