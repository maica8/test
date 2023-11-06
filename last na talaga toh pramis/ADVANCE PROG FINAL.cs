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

      private  SqlConnection con = new SqlConnection("Data Source=JAMZ;Initial Catalog=aubrey;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

       
   
        private bool IsUserAlreadyRegistered(string username, string email)
        {


            using (SqlConnection connection = new SqlConnection("Data Source=JAMZ;Initial Catalog=aubrey;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM aubreyy WHERE Username = @Username OR Email = @Email";
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

        private void lblback_Click(object sender, EventArgs e)
        {
          
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void chbxpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxpass.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
            }
        }

        private void lbl_remember_Click(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
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

                    string email = txtemail.Text;


                    string fixedSalt = "whosanna";



                    string hashedPassword = HashPassword(password);

                    string hashedPassword2 = ComputeHash(password + fixedSalt);

                    string randomSalt = GenerateRandomSalt();
                    string hashedPassword3 = ComputeHash(password + randomSalt);


                    string randomSalt2 = GenerateRandomSalt();
                    string hashedPassword4 = ComputeHash(randomSalt + hashedPassword3);
                    string app = "0";


                    con.Open();

                    string query = "INSERT INTO aubreyy (Username, Passwordhash, Passwordfixsalthash, Randompasssalthash, Email, IsApprove) VALUES (@Username,@PasswordHash, @Passfixsalthash, @Randompasssalthash, @Email, @IsApprove)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);


                    cmd.Parameters.AddWithValue("@PasswordHash", encrypt.hashstring(password));
                    cmd.Parameters.AddWithValue("@Passfixsalthash", hashedPassword2);
                    cmd.Parameters.AddWithValue("@Randompasssalthash", hashedPassword3);
                    cmd.Parameters.AddWithValue("@IsApprove", app);

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

        private void btn_REGback_Click(object sender, EventArgs e)
        {
            aub3 frm1 = new aub3();
            this.Close();
            frm1.Show();
        }

      
        private void btn_REGcancel_Click(object sender, EventArgs e)
        {
            aub3 fr = new aub3();
            this.Hide();
            fr.Show();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtemail.Text = "";


            txtusername.Focus();
        }
    }
}
