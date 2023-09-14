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
    public partial class add_staff : Form
    {
        public add_staff()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.hospitalConnectionString);

        private void add_staff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalStaff.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.hospitalStaff.users);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            home f = new home();
            f.ShowDialog();
            this.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string v1 = "2";
            if (guna2ComboBox2.Text == "Admin")
            {
                v1 = "1";
            }
            else if(guna2ComboBox2.Text == "Staff")
            {
                v1 = "2";
            }
            try
            {
                string cmdString = @"INSERT INTO [dbo].[users] ([Id], [f_name], [l_name], [address], [position], [t_no], [gen], [b_salary], [email], [pswd], [type]) VALUES (@Id, @f_name, @l_name, @address, @position, @t_no, @gen, @b_salary, @email, @pswd, @type);";

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.Parameters.AddWithValue("@id", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@l_name", guna2TextBox13.Text);
                cmd.Parameters.AddWithValue("@t_no", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@email", guna2TextBox4.Text);
                cmd.Parameters.AddWithValue("@pswd", guna2TextBox11.Text);
                cmd.Parameters.AddWithValue("@type", v1);
                cmd.Parameters.AddWithValue("@address", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@f_name", guna2TextBox9.Text);
                cmd.Parameters.AddWithValue("@position", guna2TextBox8.Text);
                cmd.Parameters.AddWithValue("@b_salary", guna2TextBox10.Text);
                cmd.Parameters.AddWithValue("@gen", guna2ComboBox1.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Added Succesfully.", "Register Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.usersTableAdapter.Fill(this.hospitalStaff.users);
                //table_fill();
                //this.clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string v1 = "2";
            if (guna2ComboBox2.Text == "Admin")
            {
                v1 = "1";
            }
            else if (guna2ComboBox2.Text == "Staff")
            {
                v1 = "2";
            }

            try
            {
                string cmdString = @"UPDATE [dbo].[users] SET [Id] = @Id, [f_name] = @f_name, [l_name] = @l_name, [address] = @address, [position] = @position, [t_no] = @t_no, [gen] = @gen, [b_salary] = @b_salary, [email] = @email, [pswd] = @pswd, [type] = @type WHERE Id = @Id;";

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.Parameters.AddWithValue("@id", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@l_name", guna2TextBox13.Text);
                cmd.Parameters.AddWithValue("@t_no", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@email", guna2TextBox4.Text);
                cmd.Parameters.AddWithValue("@pswd", guna2TextBox11.Text);
                cmd.Parameters.AddWithValue("@type", v1);
                cmd.Parameters.AddWithValue("@address", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@f_name", guna2TextBox9.Text);
                cmd.Parameters.AddWithValue("@position", guna2TextBox8.Text);
                cmd.Parameters.AddWithValue("@b_salary", guna2TextBox10.Text);
                cmd.Parameters.AddWithValue("@gen", guna2ComboBox1.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Succesfully.", "Register Doctor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.usersTableAdapter.Fill(this.hospitalStaff.users);
                //table_fill();
                //this.clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You sure, Do you really want to Delete this record..?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string cmdstring = @"DELETE FROM users Where id=@id";
                SqlCommand cmd = new SqlCommand(cmdstring, con);

                cmd.Parameters.AddWithValue(@"id", (guna2TextBox1.Text));
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                this.usersTableAdapter.Fill(this.hospitalStaff.users);
                //table_fill();
                //this.clear();
            }
            else
            {
                this.Show();
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            staff_info f = new staff_info();
            f.ShowDialog();
            this.Close();
        }
    }
}
