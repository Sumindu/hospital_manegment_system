using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospital_manegment_system
{
    public partial class p_chechout : Form
    {
        public p_chechout()
        {
            InitializeComponent();
        }

        private void p_chechout_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalBill.billing' table. You can move, or remove it, as needed.
            this.billingTableAdapter.Fill(this.hospitalBill.billing);

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (ulog.type == "1")
            {
                this.Hide();
                add_doctors f = new add_doctors();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                home f = new home();
                f.ShowDialog();
                this.Close();
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
