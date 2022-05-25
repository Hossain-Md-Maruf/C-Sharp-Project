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

namespace WholeSaleManagement.Screens.User
{
    public partial class UserIndentity : Form
    {
        public UserIndentity()
        {
            InitializeComponent();
        }
        private void LoadAllSizesinDataGridView()
        {
            
            try
            {

                using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    con.Open();
                    string query = "select * from LoginUsers";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    UserdataGridView.DataSource = dataTable;
                    gridStyle();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void gridStyle()
        {

            UserdataGridView.Columns[0].HeaderText = "Name";
            UserdataGridView.Columns[1].HeaderText = "Mobile";
            UserdataGridView.Columns[2].HeaderText = "User ID";
            UserdataGridView.Columns[3].Visible=false;
            
            





        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO LoginUsers (Name, Mobile,UserName,Password) VALUES ('" + NameTextBox.Text.Trim() + "','" + MobileTextBox.Text.Trim() + "','" + UserNameTextBox.Text.Trim() + "','" + PasswordTextBox.Text.Trim() + "')";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    LoadAllSizesinDataGridView();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UserIndentity_Load(object sender, EventArgs e)
        {
            LoadAllSizesinDataGridView();
        }
    }
}
