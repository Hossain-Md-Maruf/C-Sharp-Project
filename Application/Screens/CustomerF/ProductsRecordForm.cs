using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WholeSaleManagement.General;
using System.Data.SqlClient;

namespace WholeSaleManagement.Screens.ProductsFolder
{
    public partial class ProductsRecordForm : Form
    {
        public ProductsRecordForm()
        {
            InitializeComponent();
        }

        private void ProductsRecordForm_Load(object sender, EventArgs e)
        {
            LoadAllProductsIntoDataGridView();
        }

        private void LoadAllProductsIntoDataGridView()
        {
            if(ProductsDataGridView.Columns.Contains("Delete"))
            {
                ProductsDataGridView.Columns.Remove("Delete");
            }
            ProductsDataGridView.DataSource = GetData();
           // ProductsDataGridView.Columns[0].Visible = false;
            DataGridViewButtonColumn dv = new DataGridViewButtonColumn();
            dv.HeaderText = "Delete";
            dv.Name = "Delete";
            ProductsDataGridView.Columns.Add(dv);

            
        }

        private DataTable GetData()
        {
            DataTable dtrecord = new DataTable();
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("ups_Products_LoadAllProductsForDataGridView", con))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dtrecord.Load(sdr);
                }
            }
            return dtrecord;
        }
        

        private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if(ProductNameTextBox.Text.Trim()==string.Empty)
            {
                LoadAllProductsIntoDataGridView();
            }
            else
            {
                ProductsDataGridView.DataSource = GetProductByProductID();
            }
        }

        private DataTable GetProductByProductID()
        {
            DataTable dtrecord = new DataTable();
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("ups_Products_LoadAllProductsByProductName", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", ProductNameTextBox.Text.Trim());
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dtrecord.Load(sdr);
                }
            }
            return dtrecord;
        }

        private void ProductsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(ProductsDataGridView.CurrentCell.ColumnIndex==7)
            {
                //MessageBox.Show("Button is Clicked");
                int _id = Convert.ToInt32(ProductsDataGridView.SelectedRows[0].Cells[0].Value);
                if(_id>0)
                {
                    using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_Products_DeleteProducandSizes", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProductID", _id);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            
                            MessageBox.Show("Product No." + _id.ToString() + " is deleted from the system", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllProductsIntoDataGridView();
                        }
                    }
                }
                
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
