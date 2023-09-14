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
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home f = new home();
            f.ShowDialog();
            this.Close();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
