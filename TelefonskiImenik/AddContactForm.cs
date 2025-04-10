using System;
using System.Windows.Forms;

namespace TelefonskiImenik
{
    public partial class AddContactForm : Form
    {
        public string ContactName { get; set; } = "";
        public string ContactNumber { get; set; } = "";

        public AddContactForm()
        {
            InitializeComponent();
        }

        private void BtnShrani_Click(object sender, EventArgs e)
        {
            ContactName = txtNaziv.Text.Trim();
            ContactNumber = txtStevilka.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
