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
    public partial class patient_appoinment : Form
    {
        public patient_appoinment()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.hospitalConnectionString);


        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            home f = new home();
            f.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void patient_appoinment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalAppoinment.appoinment' table. You can move, or remove it, as needed.
            this.appoinmentTableAdapter.Fill(this.hospitalAppoinment.appoinment);
            

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.usersTableAdapter.Fill(this.doctorsNames.users);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

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
                string cmdString = @"INSERT INTO [dbo].[appoinment] ([Id], [p_name], [t_no], [email], [date], [doc], [comment]) VALUES (@Id, @p_name, @t_no, @email, @date, @doc, @comment);";

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.Parameters.AddWithValue("@id", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@p_name", guna2TextBox9.Text);
                cmd.Parameters.AddWithValue("@t_no", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@email", guna2TextBox4.Text);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(guna2DateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@doc", guna2ComboBox1.Text);
                cmd.Parameters.AddWithValue("@comment", guna2TextBox10.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Added Succesfully.", "Register Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.appoinmentTableAdapter.Fill(this.hospitalAppoinment.appoinment);
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
            try
            {
                string cmdString = @"UPDATE [dbo].[appoinment] SET [Id] = @Id, [p_name] = @p_name, [t_no] = @t_no, [email] = @email, [date] = @date, [doc] = @doc, [comment] = @comment WHERE Id = @Id;";

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.Parameters.AddWithValue("@id", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@p_name", guna2TextBox9.Text);
                cmd.Parameters.AddWithValue("@t_no", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@email", guna2TextBox4.Text);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(guna2DateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@doc", guna2ComboBox1.Text);
                cmd.Parameters.AddWithValue("@comment", guna2TextBox10.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Succesfully.", "Register Doctor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.appoinmentTableAdapter.Fill(this.hospitalAppoinment.appoinment);
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
                string cmdstring = @"DELETE FROM appoinment Where id=@id";
                SqlCommand cmd = new SqlCommand(cmdstring, con);

                cmd.Parameters.AddWithValue(@"id", (guna2TextBox1.Text));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.appoinmentTableAdapter.Fill(this.hospitalAppoinment.appoinment);
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

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.usersTableAdapter.Fill(this.doctorsNames.users);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
