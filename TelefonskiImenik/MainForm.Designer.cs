namespace TelefonskiImenik
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridView dgvContacts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.SuspendLayout();

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.TabIndex = 0;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(330, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Išči";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            // btnDodaj
            this.btnDodaj.Location = new System.Drawing.Point(415, 20);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 2;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.BtnDodaj_Click);

            // dgvContacts
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Location = new System.Drawing.Point(20, 60);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.RowTemplate.Height = 25;
            this.dgvContacts.Size = new System.Drawing.Size(550, 250);
            this.dgvContacts.TabIndex = 3;

            // MainForm
            this.ClientSize = new System.Drawing.Size(600, 330);
            this.Controls.Add(this.dgvContacts);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Name = "MainForm";
            this.Text = "Telefonski imenik";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
