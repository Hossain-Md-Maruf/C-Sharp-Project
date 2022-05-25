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
    public partial class StockManage : Form
    {
        public StockManage()
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
                    string query = "select * from Stock_View where ProductID='" + ProductComboBox.SelectedValue + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    StockManageDataGridview.DataSource = dataTable;
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

            StockManageDataGridview.Columns[0].Visible = false;
            StockManageDataGridview.Columns[1].HeaderText = "Name";
            StockManageDataGridview.Columns[2].HeaderText = "Caterory";
            StockManageDataGridview.Columns[3].HeaderText = "Supplier";
            StockManageDataGridview.Columns[4].HeaderText = "Purchase Price";
            StockManageDataGridview.Columns[5].HeaderText = "Quantity";
            StockManageDataGridview.Columns[6].HeaderText = "Sales Price";
            StockManageDataGridview.Columns[7].HeaderText = "Amount";





        }
        public void ProductNameLoad()
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                try
                {
                    con.Open();
                    string query = "select ProductID,Name from Products";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("ProductID");
                    dataTable.Columns.Add("Name");
                    DataRow data = dataTable.NewRow();
                    data["ProductID"] = "0";
                    data["Name"] = "Select a Product";
                    dataTable.Rows.Add(data);
                    sqlDataAdapter.Fill(dataTable);
                    ProductComboBox.DataSource = dataTable;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["ProductID"].ToString().Trim() != "" && dataRow["Name"].ToString().Trim() != "")
                        {
                            ProductComboBox.DisplayMember = "Name";
                            ProductComboBox.ValueMember = "ProductID";
                        }
                    }
                    con.Close();
                    ProductComboBox.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
        }

        private void StockManage_Load(object sender, EventArgs e)
        {
            ProductNameLoad();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            LoadAllSizesinDataGridView();
        }
    }
}
