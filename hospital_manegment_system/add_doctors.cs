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
    public partial class add_doctors : Form
    {
        public add_doctors()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.hospitalConnectionString);

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            docs_info f = new docs_info();
            f.ShowDialog();
            this.Close();
        }

        private void add_doctors_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDocs.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.hospitalDocs.users);

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            home f = new home();
            f.ShowDialog();
            this.Close();
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
             try
            {
                string cmdString = @"INSERT INTO[users] ([Id], [l_name], [t_no], [email], [pswd], [type], [d_exp], [f_name], [d_location], [d_spec], [d_quli]) VALUES(@Id, @l_name, @t_no, @email, @pswd, @type, @d_exp, @f_name, @d_location, @d_spec, @d_quli);";

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.Parameters.AddWithValue("@id", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@l_name", guna2TextBox13.Text);
                cmd.Parameters.AddWithValue("@t_no", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@email", guna2TextBox4.Text);
                cmd.Parameters.AddWithValue("@pswd", guna2TextBox11.Text);
                cmd.Parameters.AddWithValue("@type", "3");
                cmd.Parameters.AddWithValue("@d_exp", guna2TextBox5.Text);
                cmd.Parameters.AddWithValue("@f_name", guna2TextBox9.Text);
                cmd.Parameters.AddWithValue("@d_location", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@d_spec", guna2TextBox8.Text);
                cmd.Parameters.AddWithValue("@d_quli", guna2TextBox10.Text);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Added Succesfully.", "Register Doctor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.usersTableAdapter.Fill(this.hospitalDocs.users);
                //table_fill();
                this.clear();

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

        private void clear()
        {
            guna2TextBox1.Clear();
            guna2TextBox13.Clear();
            guna2TextBox4.Clear();
            guna2TextBox11.Clear();
            guna2TextBox5.Clear();
            guna2TextBox9.Clear();
            guna2TextBox2.Clear();
            guna2TextBox8.Clear();
            guna2TextBox10.Clear();
            guna2TextBox6.Clear();
            guna2TextBox3.Clear();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdString = @"UPDATE [users] SET [Id] = @Id, [l_name] = @l_name, [t_no] = @t_no, [email] = @email, [pswd] = @pswd, [type] = @type, [d_exp] = @d_exp, [f_name] = @f_name, [d_location] = @d_location, [d_spec] = @d_spec, [d_quli] = @d_quli WHERE Id = @Id;";

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.Parameters.AddWithValue("@id", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@l_name", guna2TextBox13.Text);
                cmd.Parameters.AddWithValue("@t_no", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@email", guna2TextBox4.Text);
                cmd.Parameters.AddWithValue("@pswd", guna2TextBox11.Text);
                cmd.Parameters.AddWithValue("@type", "3");
                cmd.Parameters.AddWithValue("@d_exp", guna2TextBox5.Text);
                cmd.Parameters.AddWithValue("@f_name", guna2TextBox9.Text);
                cmd.Parameters.AddWithValue("@d_location", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@d_spec", guna2TextBox8.Text);
                cmd.Parameters.AddWithValue("@d_quli", guna2TextBox10.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Succesfully.", "Register Doctor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.usersTableAdapter.Fill(this.hospitalDocs.users);
                //table_fill();
                this.clear();

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
        private void search_btn()
        {
            con.Open();
            if (guna2TextBox12.Text != "")
            {
                try
                {
                    string getCust = "SELECT Id, l_name, t_no, email, pswd, type, d_exp, f_name, d_location, d_spec, d_quli FROM users WHERE id=" + Convert.ToInt32(guna2TextBox12.Text) + " ;";

                    SqlCommand cmd = new SqlCommand(getCust, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        guna2TextBox13.Text = dr.GetValue(1).ToString();
                        guna2Panel3.Text = dr.GetValue(2).ToString();
                        guna2TextBox4.Text = dr.GetValue(3).ToString();
                        guna2TextBox11.Text = dr.GetValue(4).ToString();
                        guna2TextBox5.Text = dr.GetValue(5).ToString();
                        guna2TextBox9.Text = dr.GetValue(7).ToString();
                        guna2TextBox2.Text = dr.GetValue(8).ToString();
                        guna2TextBox8.Text = dr.GetValue(9).ToString();
                        guna2TextBox10.Text = dr.GetValue(10).ToString();
                        //guna2TextBox10.Text = dr.GetValue(11).ToString();

                    }
                    else
                    {
                        MessageBox.Show(" Sorry, This ID, " + guna2TextBox12.Text + " Staff is not Available.   ");
                        guna2TextBox12.Text = "";
                    }
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
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
                this.usersTableAdapter.Fill(this.hospitalDocs.users);
                //table_fill();
                this.clear();
            }
            else
            {
                this.Show();
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            search_btn();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
