using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace last_na_talaga_toh_pramis
{
  
    public partial class admin : Form
    {
private const string ConnectionString = "Data Source=JAMZ;Initial Catalog=aubrey;Integrated Security=True";
        public admin()
        {
            InitializeComponent();
        }


        private void admin_Load(object sender, EventArgs e)
        {
            LoadPendingRegistrations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewPendingRegistrations.SelectedRows.Count > 0)
            {
                int selectedUserID = Convert.ToInt32(dataGridViewPendingRegistrations.SelectedRows[0].Cells["UserID"].Value);

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Delete the user record from the Users table
                    string deleteQuery = "DELETE FROM [aubreyy] WHERE UserID = @UserID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@UserID", selectedUserID);
                    deleteCommand.ExecuteNonQuery();

                    // Delete the associated record from the AdminApproval table
                    string deleteAdminApprovalQuery = "DELETE FROM Adminn WHERE UserID = @UserID";
                    SqlCommand deleteAdminApprovalCommand = new SqlCommand(deleteAdminApprovalQuery, connection);
                    deleteAdminApprovalCommand.Parameters.AddWithValue("@UserID", selectedUserID);
                    deleteAdminApprovalCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Account Successfully Rejected.");

                LoadPendingRegistrations();
            }
            else
            {

                MessageBox.Show("Please select a user to Reject.");

            }

        }



        private void LoadPendingRegistrations()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string selectPendingUsersQuery = @"
SELECT U.UserID, U.Username, U.Email
FROM aubreyy AS U
LEFT JOIN Adminn AS A ON A.UserID = U.UserID
WHERE U.isApprove = 0 OR U.UserID IS NULL";
                SqlDataAdapter adapter = new SqlDataAdapter(selectPendingUsersQuery, connection);
                DataTable pendingUsersTable = new DataTable();
                adapter.Fill(pendingUsersTable);
                dataGridViewPendingRegistrations.DataSource = pendingUsersTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aub3 frm = new aub3();
            this.Hide();
            frm.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewPendingRegistrations.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewPendingRegistrations.SelectedRows[0].Index;
                int selectedUserID = Convert.ToInt32(dataGridViewPendingRegistrations.SelectedRows[0].Cells["UserID"].Value);

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string updateApprovalQuery = "UPDATE [aubreyy] SET isApprove = 1 WHERE UserID = @UserID";
                    SqlCommand updateApprovalCommand = new SqlCommand(updateApprovalQuery, connection);
                    updateApprovalCommand.Parameters.AddWithValue("@UserID", selectedUserID);
                    updateApprovalCommand.ExecuteNonQuery();
                }
                dataGridViewPendingRegistrations.Rows.RemoveAt(dataGridViewPendingRegistrations.SelectedRows[0].Index);


                MessageBox.Show("Account Successfuly Approved.");
                // Refresh the pending registrations list
                LoadPendingRegistrations();
            }

            else
            {
                 
                MessageBox.Show("Please select a user to Approve.");

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (dataGridViewPendingRegistrations.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewPendingRegistrations.SelectedRows[0].Index;
                int selectedUserID = Convert.ToInt32(dataGridViewPendingRegistrations.SelectedRows[0].Cells["UserID"].Value);

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string updateApprovalQuery = "UPDATE [aubreyy] SET isApprove = 1 WHERE UserID = @UserID";
                    SqlCommand updateApprovalCommand = new SqlCommand(updateApprovalQuery, connection);
                    updateApprovalCommand.Parameters.AddWithValue("@UserID", selectedUserID);
                    updateApprovalCommand.ExecuteNonQuery();
                }
                dataGridViewPendingRegistrations.Rows.RemoveAt(dataGridViewPendingRegistrations.SelectedRows[0].Index);


                MessageBox.Show("Account Successfuly Approved.");
                // Refresh the pending registrations list
                LoadPendingRegistrations();
            }

            else
            {

                MessageBox.Show("Please select a user to Approve.");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewPendingRegistrations.SelectedRows.Count > 0)
            {
                int selectedUserID = Convert.ToInt32(dataGridViewPendingRegistrations.SelectedRows[0].Cells["UserID"].Value);

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Delete the user record from the Users table
                    string deleteQuery = "DELETE FROM [aubreyy] WHERE UserID = @UserID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@UserID", selectedUserID);
                    deleteCommand.ExecuteNonQuery();

                    // Delete the associated record from the AdminApproval table
                    string deleteAdminApprovalQuery = "DELETE FROM Adminn WHERE UserID = @UserID";
                    SqlCommand deleteAdminApprovalCommand = new SqlCommand(deleteAdminApprovalQuery, connection);
                    deleteAdminApprovalCommand.Parameters.AddWithValue("@UserID", selectedUserID);
                    deleteAdminApprovalCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Account Successfully Rejected.");

                LoadPendingRegistrations();
            }
            else
            {

                MessageBox.Show("Please select a user to Reject.");

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            aub3 frm = new aub3();
            this.Hide();
            frm.Show();
        }

        private void dataGridViewPendingRegistrations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void staff_Click(object sender, EventArgs e)
        {
            dataGridViewPendingRegistrations.Show();
            panelmenu.Hide();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            
            panelmenu.Show();
            dataGridViewPendingRegistrations.Hide();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

            aub3 frm = new aub3();
            this.Hide();
            frm.Show();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewPendingRegistrations.SelectedRows[0].Index;
                int selectedUserID = Convert.ToInt32(dataGridViewPendingRegistrations.SelectedRows[0].Cells["UserID"].Value);

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string updateApprovalQuery = "UPDATE [aubreyy] SET isApprove = 1 WHERE UserID = @UserID";
                    SqlCommand updateApprovalCommand = new SqlCommand(updateApprovalQuery, connection);
                    updateApprovalCommand.Parameters.AddWithValue("@UserID", selectedUserID);
                    updateApprovalCommand.ExecuteNonQuery();
                }
                dataGridViewPendingRegistrations.Rows.RemoveAt(dataGridViewPendingRegistrations.SelectedRows[0].Index);


                MessageBox.Show("Account Successfuly Approved.");
                // Refresh the pending registrations list
                LoadPendingRegistrations();
            }

            else
            {

                MessageBox.Show("Please select a user to Approve.");

            }
        }
    }
}

       

