using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using WholeSaleManagement.General;
using WholeSaleManagement.Screens;

namespace WholeSaleManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
               using(SqlConnection con=new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    using(SqlCommand cmd=new SqlCommand("usp_Login_VerifyLoginDetails",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", PasswordTextBox.Text.Trim());
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        if(sdr.Read())
                        {
                            this.Hide();
                            DashBoardForm df = new DashBoardForm();
                            df.Show();
                        }
                        else
                        {
                            MessageBox.Show("User name or password is incorrect", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }
        private bool IsValid()
        {
            if(UserNameTextBox.Text.Trim()==string.Empty)
            {
                MessageBox.Show("User Name is required!!","Form Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserNameTextBox.Focus();
                return false;
            }
            if (PasswordTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password is required!!", "Form Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextBox.Focus();
                return false;
            }
            return true;
        }
    }
}
