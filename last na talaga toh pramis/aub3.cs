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
using System.Linq.Expressions;

namespace last_na_talaga_toh_pramis
{
    public partial class aub3 : Form
    {
        public aub3()
        {
            InitializeComponent();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpass.Text = "";
            txtuser.Focus();
        }

     

      

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                MessageBox.Show("Enter Username", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtpass.Text == "")
            {
                MessageBox.Show("Enter Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtuser.Text == "admin" && txtpass.Text == "admin123")
            {
                MessageBox.Show("Login Success", "Successful Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                admin frm = new admin();
                this.Hide();
                frm.Show();
            }
            else
            {


                string username = txtuser.Text;

                string password = txtpass.Text;



                string validuser = "admin";
                string validpass = "password";


                SqlConnection con = new SqlConnection("Data Source=JAMZ;Initial Catalog=aubrey;Integrated Security=True");
                try
                {
                    con.Open();
                    string selectUserQuery = "SELECT UserID,PasswordHash FROM [aubreyy] WHERE Username = @Username AND PasswordHash = @PasswordHash  AND isApprove = 1 ";


                    SqlCommand cmd = new SqlCommand(selectUserQuery, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", encrypt.hashstring(password));


                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("Login Success", "Successful Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form3 frm = new Form3();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password, pls Check if need Admin Approval ", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

                finally
                {
                    con.Close();
                }
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpass.Text = "";
            txtuser.Focus();
           
        }
        

        private void txtpass_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lblfor_Click(object sender, EventArgs e)
        {

        }

        private void lblregi_Click_1(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            this.Hide();
            fr.Show();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxpass.Checked)
            {
                txtpass.PasswordChar = '\0';
            }
            else
            {
                txtpass.PasswordChar = '•';
            }
        }

        private void lbl_remember_Click(object sender, EventArgs e)
        {

        }

        private void txtpass_MouseClick(object sender, MouseEventArgs e)
        {
            txtpass.Clear();
        }
    }
}
