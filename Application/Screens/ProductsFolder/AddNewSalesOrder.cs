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
    
    public partial class AddNewSalesOrder : Form
    {
        string invoiceNumber;
        public AddNewSalesOrder()
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
                    string query = "SELECT * FROM SalesOrders WHERE CustomerID='" + CustomerComboBox.SelectedValue + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    SalesOrderGridview.DataSource = dataTable;
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

            SalesOrderGridview.Columns[0].Visible = false;
            SalesOrderGridview.Columns[1].HeaderText = "Date";
            SalesOrderGridview.Columns[2].HeaderText = "Product ID";
            SalesOrderGridview.Columns[3].HeaderText = "Customer ID";
            SalesOrderGridview.Columns[4].HeaderText = "Quantity";
            SalesOrderGridview.Columns[5].HeaderText = "Amount";
            SalesOrderGridview.Columns[5].HeaderText = "Discount";
            SalesOrderGridview.Columns[5].HeaderText = "Balance";

        }
        public void generateInvoiceNo()
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                try
            {
                con.Open();
                string query = "SELECT * FROM SalesOrders";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                con.Close();
                if (dataTable.Rows.Count == 0)
                {
                        invoiceNumber = "1";
                        InvoiceNumberTextBox.Text =  invoiceNumber;
                }
                else
                {
                   con.Open();
                    query = "SELECT MAX(InvoiceNumber)+1 AS MaxCode FROM SalesOrders";
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    SqlDataReader sqlDataReader = null;
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                            invoiceNumber = sqlDataReader["MaxCode"].ToString().Trim();
                    }
                    sqlDataReader.Close();
                    con.Close();
                        InvoiceNumberTextBox.Text =  invoiceNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void AddNewSalesOrder_Load(object sender, EventArgs e)
        {
            generateInvoiceNo();
            CustomerNameLoad();
            ProductNameLoad();
            DiscountTextBox.Text = "0";
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO SalesOrders (InvoiceDate, ProductID, CustomerID, Quantity, Amount,Discount,Balance) VALUES ('" + dateTimePicker.Value + "','" + ProductComboBox.SelectedValue + "','" + CustomerComboBox.SelectedValue + "','" + QuantityTextBox.Text.Trim() + "','" + AmountTextBox.Text.Trim() + "','" + DiscountTextBox.Text.Trim() + "','" + BalanceTextBox.Text.Trim() + "')";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    LoadAllSizesinDataGridView();
                    CustomerComboBox.Enabled = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void CustomerNameLoad()
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                try
                {
                    con.Open();
                    string query = "select CustomerID,Name from Customers";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("CustomerID");
                    dataTable.Columns.Add("Name");
                    DataRow data = dataTable.NewRow();
                    data["CustomerID"] = "0";
                    data["Name"] = "Select a Customer";
                    dataTable.Rows.Add(data);
                    sqlDataAdapter.Fill(dataTable);
                    CustomerComboBox.DataSource = dataTable;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["CustomerID"].ToString().Trim() != "" && dataRow["Name"].ToString().Trim() != "")
                        {
                            CustomerComboBox.DisplayMember = "Name";
                            CustomerComboBox.ValueMember = "CustomerID";
                        }
                    }
                    con.Close();
                    CustomerComboBox.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   con.Close();
                }
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

        private void NewTextButton_Click(object sender, EventArgs e)
        {
            CustomerComboBox.Enabled = true;
        }

        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(AmountTextBox.Text, out int a) && int.TryParse(QuantityTextBox.Text, out int b) && int.TryParse(DiscountTextBox.Text, out int c) && int.TryParse(BalanceTextBox.Text, out int d))
            {
                BalanceTextBox.Text = ((Convert.ToDouble(QuantityTextBox.Text) * Convert.ToDouble(AmountTextBox.Text)) - Convert.ToDouble(DiscountTextBox.Text)).ToString();
                
            }
            else
                BalanceTextBox.Text = "0";
        }

        private void DiscountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(AmountTextBox.Text, out int a) && int.TryParse(QuantityTextBox.Text, out int b) && int.TryParse(DiscountTextBox.Text, out int c) && int.TryParse(BalanceTextBox.Text, out int d))
            {
                BalanceTextBox.Text = ((Convert.ToDouble(QuantityTextBox.Text) * Convert.ToDouble(AmountTextBox.Text)) - Convert.ToDouble(DiscountTextBox.Text)).ToString();
                
            }
            else
                BalanceTextBox.Text = "0";
        }

        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(AmountTextBox.Text, out int a) && int.TryParse(QuantityTextBox.Text, out int b) && int.TryParse(DiscountTextBox.Text, out int c) && int.TryParse(BalanceTextBox.Text, out int d))
            {
                BalanceTextBox.Text = ((Convert.ToDouble(QuantityTextBox.Text) * Convert.ToDouble(AmountTextBox.Text)) - Convert.ToDouble(DiscountTextBox.Text)).ToString();
               
            }
            else
                BalanceTextBox.Text = "0";
        }

        private void SalesOrderGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
    
}
