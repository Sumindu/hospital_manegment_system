using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hospital_manegment_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.hospitalConnectionString);

        string ShowPswdBtnSts = "hide";

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (ShowPswdBtnSts == "show")
            {
                guna2CircleButton1.Image = Properties.Resources.hide;
                ShowPswdBtnSts = "hide";
                guna2TextBox2.PasswordChar = '●';
                guna2TextBox2.UseSystemPasswordChar = true;

            }
            else if (ShowPswdBtnSts == "hide")
            {
                guna2CircleButton1.Image = Properties.Resources.show;
                ShowPswdBtnSts = "show";
                guna2TextBox2.PasswordChar = '\0';
                guna2TextBox2.UseSystemPasswordChar = false;
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox1.Focus();
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.ActiveControl = guna2TextBox2;
            }
        }

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.ActiveControl = guna2Button2;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string username = guna2TextBox1.Text;
                string q = "SELECT * FROM users WHERE email = '" + guna2TextBox1.Text + "'AND pswd = '" + guna2TextBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string type = dt.Rows[0]["type"].ToString();
                    ulog.type = type;
                    ulog.userid = username;

                    this.Hide();
                    home f = new home();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid login credentials,please check Username and Password and try again.", "Invalid Login Details.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox1.Focus();
                }
            }
            catch (Exception r)
            {
                MessageBox.Show("Sql Connection Error" + r, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
