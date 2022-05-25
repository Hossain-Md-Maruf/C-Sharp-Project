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
    public partial class DefineProductScreen : Form
    {
        string ProductID = "";
        public DefineProductScreen()
        {
            InitializeComponent();
        }
        
        public bool IsUpdate { get; set; }
        private List<int> SizesCart = new List<int>();

        private void DefineProductScreen_Load(object sender, EventArgs e)
        {
            if(!this.IsUpdate)
            {

            }
            LoadAllSizesinDataGridView();
            
        }

        private void LoadDataIntoComboBoxes()
        {
            CategoryComboBox.DataSource = GetComboBoxData(CategoryComboBox.SelectedIndex);
            SupplierComboBox.DataSource = GetComboBoxData(SupplierComboBox.SelectedIndex);
        }

        private DataTable GetComboBoxData(int listTypeID)
        {
            DataTable dtrecord = new DataTable();
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListTypesData_LoadDataIntoComboBox", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ListTypeID", listTypeID);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dtrecord.Load(sdr);
                }
            }
            return dtrecord;
        }

        private void LoadAllSizesinDataGridView()
        {
            
            try
            {

                using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    con.Open();
                    string query = "SELECT * FROM Products";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    SizesDataGridView.DataSource = dataTable;
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

            SizesDataGridView.Columns[0].Visible = false;
            SizesDataGridView.Columns[1].HeaderText = "Name";
            SizesDataGridView.Columns[2].HeaderText = "Caterory";
            SizesDataGridView.Columns[3].HeaderText = "Supplier";
            SizesDataGridView.Columns[4].HeaderText = "Purchase Price";
            SizesDataGridView.Columns[5].HeaderText = "Quantity";
            SizesDataGridView.Columns[6].HeaderText = "Sales Price";
            SizesDataGridView.Columns[7].HeaderText = "Amount";





        }

        private DataTable GetSizesData()
        {
            DataTable dtsizes = new DataTable();
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using(SqlCommand cmd=new SqlCommand("usp_SizesLoadAllSizes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ListTypeID", 1);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dtsizes.Load(sdr); 
                }
            }
            return dtsizes;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DefineNewButton_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString())) 
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Products SET Name = '" + ProductNameTextBox.Text.Trim() + "', CategoryID = '" + CategoryComboBox.Text.Trim() + "', SupplierID = '" + SupplierComboBox.Text.Trim() + "', PurchasePrice = '" + PurchasePriceTextBox.Text.Trim() + "',Quantity = '" + QuantityTextBox.Text.Trim() + "', SalesPrice= '" + SalesPriceTextBox.Text.Trim() + "', Amount = '" + AmountTextBox.Text.Trim() + "' WHERE ProductID = '" + ProductID + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    
                    ClearControls();
                    LoadAllSizesinDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearControls()
        {
            
            ProductNameTextBox.Text = "";
            SupplierComboBox.Text = "";
            CategoryComboBox.SelectedIndex = -1;
            PurchasePriceTextBox.Text = "";
            SalesPriceTextBox.Text = "";
            
            ProductNameTextBox.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                SizesCart.Clear();
                
                using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    try
                    {
                        con.Open();
                        string query = "INSERT INTO Products (Name, CategoryID, SupplierID, PurchasePrice,Quantity, SalesPrice,Amount) VALUES ('" + ProductNameTextBox.Text.Trim()+ "','" + CategoryComboBox.Text.Trim() + "','" + SupplierComboBox.Text.Trim() + "','" + PurchasePriceTextBox.Text.Trim() + "','" + QuantityTextBox.Text.Trim() + "','" + SalesPriceTextBox.Text.Trim() + "','" + AmountTextBox.Text.Trim() + "')";
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
        }

        private void SaveSizes(int _id)
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                foreach (int sizeID in SizesCart)
                {
                    using (SqlCommand cmd = new SqlCommand("usp_Products_InsertProductSizes", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductID", _id);
                        cmd.Parameters.AddWithValue("@SizeID", sizeID);
                        cmd.ExecuteNonQuery();
                       
                    }
                }

            }
        }

        private void LoadDataIntoSizesCart()
        {
            foreach(DataGridViewRow row in SizesDataGridView.Rows)
            {
                if(row.Cells["Select"].Value!=null && !DBNull.Value.Equals(row.Cells["Select"].Value)&& Convert.ToBoolean(row.Cells["Select"].Value)==true)
                {
                    SizesCart.Add((int)row.Cells["ID"].Value);
                }
            }
        }

        private bool IsValid()
        {
           if(ProductNameTextBox.Text.Trim()==string.Empty)
            {
                MessageBox.Show("Product Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProductNameTextBox.Focus();
                return false;
            }
            if (PurchasePriceTextBox.Text.Trim()==string.Empty)
            {
                MessageBox.Show("Product Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               PurchasePriceTextBox.Focus();
                return false;
            }
            return true;
        }

        private void SupplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SizesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductNameTextBox.DataBindings.Clear();
            CategoryComboBox.DataBindings.Clear();
            SupplierComboBox.DataBindings.Clear();
            PurchasePriceTextBox.DataBindings.Clear();
            QuantityTextBox.DataBindings.Clear();
            SalesPriceTextBox.DataBindings.Clear();
            AmountTextBox.DataBindings.Clear();


            ProductID = SizesDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            ProductNameTextBox.Text = SizesDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            CategoryComboBox.Text = SizesDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            SupplierComboBox.Text = SizesDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            PurchasePriceTextBox.Text = SizesDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
            QuantityTextBox.Text = SizesDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            SalesPriceTextBox.Text = SizesDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
            AmountTextBox.Text = SizesDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                try
            {
                con.Open();
                string query = "DELETE FROM Products WHERE ProductID = '" + ProductID + "'";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.ExecuteNonQuery();
                con.Close();
                LoadAllSizesinDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
