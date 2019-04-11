using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Application
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                errorProvider1.SetError(txtName, "Ad Boş Buraxıla Bilməz");
            }
            if (txtName.Text == string.Empty)
            {
                errorProvider1.SetError(txtSurName, "Soyad Boş Buraxıla Bilməz");
            }
            if (txtSurName.Text != string.Empty && txtName.Text != string.Empty)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
