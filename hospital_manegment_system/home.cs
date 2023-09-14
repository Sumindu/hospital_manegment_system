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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            add_doctors f = new add_doctors();
            f.ShowDialog();
            this.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            add_staff f = new add_staff();
            f.ShowDialog();
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            patient_appoinment f = new patient_appoinment();
            f.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void home_Load(object sender, EventArgs e)
        {
            if (ulog.type == "1") // full access admin 
            {

            }
            else if (ulog.type == "2") // staff access
            {
                guna2Button4.Hide();
                guna2Button5.Hide();
            }
            else if (ulog.type == "3") // Docter access
            {
                guna2Button4.Hide();
                guna2Button5.Hide();
                guna2Button5.Hide();
            }
            else // value 0 or other
            {

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            docs_info f = new docs_info();
            f.ShowDialog();
            this.Close();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            p_chechout f = new p_chechout();
            f.ShowDialog();
            this.Close();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            about f = new about();
            f.ShowDialog();
            this.Close();
        }
    }
}
