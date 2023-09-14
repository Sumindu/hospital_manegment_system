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
    public partial class staff_info : Form
    {
        public staff_info()
        {
            InitializeComponent();
        }

        private void staff_info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalStaff.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.hospitalStaff.users);

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
                add_staff f = new add_staff();
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
