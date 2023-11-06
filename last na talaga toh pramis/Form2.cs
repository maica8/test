using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace last_na_talaga_toh_pramis
{
    public partial class Form2 : Form
    {

      private  SqlConnection con = new SqlConnection("Data Source=LAPTOP-JLTIBPM6\\SQLEXPRESS;Initial Catalog=\"last na toh\";Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            this.Hide();
            fr.Show();
        }

        private void chbxpass2_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxpass2.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtemail.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
                txtemail.PasswordChar = '•';
            }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Username and Password are Empty", "Registrationm Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtpassword.Text == txtpassword.Text)
            {
                if (!txtemail.Text.ToLower().Contains("@gmail.com"))
                {
                    MessageBox.Show("Invalid email address. Only Gmail addresses are allowed.");
                }
                else if (IsUserAlreadyRegistered(txtusername.Text, txtemail.Text))
                {
                    MessageBox.Show("Username or Email are already exist");

                }

                try
                {


                    string username = txtusername.Text;
                    string password = txtpassword.Text;
                    string age = txtage.Text;
                    string email = txtemail.Text;


                    string fixedSalt = "whosanna";



                    string hashedPassword = HashPassword(password);

                    string hashedPassword2 = ComputeHash(password + fixedSalt);

                    string randomSalt = GenerateRandomSalt();
                    string hashedPassword3 = ComputeHash(password + randomSalt);


                    string randomSalt2 = GenerateRandomSalt();
                    string hashedPassword4 = ComputeHash(randomSalt + hashedPassword3);


                    con.Open();

                    string query = "INSERT INTO alexiss (Username, PasswordHash, Passfixsalthash,Rrandpasssalthash,Rrandomsalthash,Email,Birthday,Age) VALUES (@Username, @PasswordHash, @PasswordHash,@Passfixsalthash,@Rrandomsalthash,@Email,@bdy,@age)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@bdy", date.Value);
                    cmd.Parameters.AddWithValue("@PasswordHash", encrypt.hashstring(password));
                    cmd.Parameters.AddWithValue("@Passfixsalthash", hashedPassword2);
                    cmd.Parameters.AddWithValue("@Rrandpasssalthash", hashedPassword3);
                    cmd.Parameters.AddWithValue("@Rrandomsalthash", randomSalt2);

                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Registered Successfully");

                    }

                    else
                    {
                        MessageBox.Show("Password Not Match, Re- Enter Your Password");

                        txtusername.Text = "";
                        txtpassword.Text = "";
                        txtemail.Text = "";
                        txtpassword.Focus();
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

            private void btnclear_Click(object sender, EventArgs e)
        {

        }

        private void btnclear2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtemail.Text = "";
            txtage.Text = "";
          
            txtusername.Focus();
        }

        private bool IsUserAlreadyRegistered(string username, string email)
        {


            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-JLTIBPM6\\SQLEXPRESS;Initial Catalog=\"last na toh\";Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [dbo].[alexiss] WHERE Username = @Username OR Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

            private string GenerateRandomSalt()
            {

                byte[] saltBytes = new byte[32];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(saltBytes);
                }


                string salt = BitConverter.ToString(saltBytes).Replace("-", "").ToLower();

                return salt;
            }

            private string HashPassword(string password)
            {

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                    return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }
            private string ComputeHash(string input)
            {

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(input);
                    byte[] hash = sha256.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
                }
            }

        private void lblusername_Click(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
