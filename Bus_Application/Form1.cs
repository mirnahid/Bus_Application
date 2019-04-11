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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmbBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbBus.Text)
            {
                case "Travego":
                    Seat(8, false);
                    break;
                case "Setra":
                    Seat(12, true);
                    break;

                case "Neoplan":
                    Seat(10, false);
                    break;
                default:
                    break;
            }
        }
        void Seat(int sira, bool five)
        {
        slow:
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = ctrl as Button;
                    if (btn.Text == "Yadda Saxla")
                    {
                        continue;
                    }
                    else
                    {
                        this.Controls.Remove(ctrl);
                        goto slow;
                    }
                }

            }
            int SeatNo = 1;
            for (int i = 0; i < sira; i++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (i == sira / 2 && c > 2)
                    {
                        continue;
                    }
                    if (five == true)
                    {
                        if (i != sira - 1 && c == 2)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (c == 2)
                        {
                            continue;
                        }
                    }



                    Button Seat = new Button();
                    Seat.Height = Seat.Width = 40;
                    Seat.Top = 30 + (i * 45);
                    Seat.Left = 5 + (c * 45);
                    Seat.Text = SeatNo.ToString();
                    Seat.ContextMenuStrip = contextMenuStrip1;
                    Seat.MouseDown += Seat_MouseDown;
                    SeatNo++;
                    this.Controls.Add(Seat);
                }
            }
        }
        Button clicked;
        private void Seat_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = sender as Button;
        }

        private void rezervEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbBus.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbBus, "Avtobusu Seçin");
            }
            if (cmbWhere.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbWhere, "Boş Buraxılmamalıdır");
            }
            if (cmbHere.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbHere, "Boş Buraxılmamalıdır");
            }
            if (cmbBus.SelectedIndex == -1 || cmbWhere.SelectedIndex == -1 || cmbHere.SelectedIndex == -1)
            {
                MessageBox.Show("Lazımi Sahələri Doldurun!");

            }
            else
            {
                RegisterForm reg = new RegisterForm();
               DialogResult dr = reg.ShowDialog();
                if (dr==DialogResult.OK)
                {
                    ListViewItem lvii = new ListViewItem();
                    lvii.Text = string.Format("{0}{1}", reg.txtName.Text, reg.txtSurName.Text);
                    lvii.SubItems.Add(reg.txtNumber.Text);
                    if (reg.rdbMale.Checked)
                    {
                        lvii.SubItems.Add("Kişi");
                        clicked.BackColor = Color.Blue;
                    }
                    if (reg.rdbFemale.Checked)
                    {
                        lvii.SubItems.Add("Qadın");
                        clicked.BackColor = Color.Pink;
                    }
                    lvii.SubItems.Add(cmbWhere.Text);
                    lvii.SubItems.Add(cmbHere.Text);
                    lvii.SubItems.Add(clicked.Text);
                    lvii.SubItems.Add(dtpDate.Text);
                    lvii.SubItems.Add(nudPrice.Value.ToString());
                    listView1.Items.Add(lvii);
                }
            }

        }
    }
}
