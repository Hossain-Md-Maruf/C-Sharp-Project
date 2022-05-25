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
using WholeSaleManagement.General;

namespace WholeSaleManagement.Screens.ProductsFolder
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                try
                {
                    con.Open();
                    String query = "select Password from LoginUsers where UserName='" + UserNameTextBox.Text.Trim() + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    
                    if (sqlDataReader.Read())
                    {
                        string oldPassword = sqlDataReader["Password"].ToString().Trim();
                        if (textBox2.Text.Trim() == oldPassword.Trim())
                        {
                            con.Close();
                            try
                            {
                                con.Open();
                                string query1 = "UPDATE LoginUsers SET Password = '" + NewPassword.Text.Trim() + "' WHERE UserName = '" + UserNameTextBox.Text.Trim() + "'";
                                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(query1, con);
                                DataTable dataTable1 = new DataTable();
                                sqlDataAdapter1.Fill(dataTable1);
                                con.Close();
                                MessageBox.Show("Password change successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            con.Close();
                            MessageBox.Show("Incorrect ID or Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void UserNameLoad()
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                try
            {
                    UserNameTextBox.Items.Clear();
                con.Open();
                string query = "select UserName from LoginUsers";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (dataRow["UserName"].ToString().Trim() != "")
                    {
                            UserNameTextBox.Items.Insert(0, dataRow["UserName"].ToString().Trim());
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            UserNameLoad();
           
        }
    }
}
