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
using WholeSaleManagement.General;
using System.IO;

namespace WholeSaleManagement.Screens.CustomerF
{
    public partial class NewCustomerForm : Form
    {
        
        string CustomerId;
        public NewCustomerForm()
        {
            InitializeComponent();
        }
        public int customerID { get; set; }
        public bool IsUpdate { get; set; }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                try
            {
                
                    con.Open();
                string query = "INSERT INTO Customers (Name, Mobile, Address, Picture) VALUES ('" + CustomerNameTextBox.Text.Trim() + "','" + MobileTextBox.Text.Trim() + "','" + AddressTextBox.Text.Trim() + "','"+ PathTextBox.Text.Trim() + "')";
                SqlCommand sqlCommand = new SqlCommand(query, con);
               
                sqlCommand.ExecuteNonQuery();
                con.Close();
                LoadAllSizesinDataGridView();

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
               con.Close();
            }
        }

        private void ClearForNewProduct()
        {
            CustomerNameTextBox.Clear();
            MobileTextBox.Clear();
            AddressTextBox.Clear();
            pictureBoxInput.Image = null;
            PathTextBox.Clear();
            CustomerNameTextBox.Focus();
            this.IsUpdate = false;
            this.customerID = 0;
        }

        private bool IsValid()
        {
            if(CustomerNameTextBox.Text.Trim()==string.Empty)
            {
                MessageBox.Show("Customer Name is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CustomerNameTextBox.Focus();
                return false;
            }
            return true;
        }

        private void DefineNewButton_Click(object sender, EventArgs e)
        {
            ClearForNewProduct();
        }

        private void NewCustomerForm_Load(object sender, EventArgs e)
        {
            if(this.IsUpdate)
            {
                LoadDataAndMapIntoControls();
                
            }
            LoadAllSizesinDataGridView();
        }

        private void LoadDataAndMapIntoControls()
        {
            DataTable dtRecords = GetCustomerData();
            DataRow row;
            row = dtRecords.Rows[0];
            CustomerNameTextBox.Text = row["Name"].ToString();
            MobileTextBox.Text = row["Mobile"].ToString();
            AddressTextBox.Text = row["Address"].ToString();
        }

        private DataTable GetCustomerData()
        {
            DataTable dtdata = new DataTable();
            using (SqlConnection con=new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using(SqlCommand cmd=new SqlCommand("usp_CustomerGetCustomerDataByCustomerID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID ", this.customerID);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dtdata.Load(sdr);
                }
            }

            return dtdata;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JPEG Image (*.JPG)|*.jpg|GIF Image (*.GIF)|*.gif|PNG Image (*.PNG)|*.png|Bitmap Image (*.BMP)|*.bmp";
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Select a Photo";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxInput.ImageLocation = openFileDialog.FileName.ToString();
                
                pictureBoxInput.SizeMode = PictureBoxSizeMode.Zoom;
                PathTextBox.Text = openFileDialog.FileName;
            }
        }
        private void LoadAllSizesinDataGridView()
        {

            try
            {

                using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    con.Open();
                    string query = "SELECT * FROM Customers";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    NewCustomerGridView.DataSource = dataTable;
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

            NewCustomerGridView.Columns[0].Visible = false;
            NewCustomerGridView.Columns[1].HeaderText = "Name";
            NewCustomerGridView.Columns[2].HeaderText = "Mobile";
            NewCustomerGridView.Columns[3].HeaderText = "Address";
            NewCustomerGridView.Columns[4].HeaderText = "Picture";
           

        }
        public void CustomerData(int rowIndex)
        {
            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                try
            {
                    CustomerNameTextBox.DataBindings.Clear();
                    MobileTextBox.DataBindings.Clear();
                    AddressTextBox.DataBindings.Clear();
                
                con.Open();
                string query = "SELECT * FROM Customers where CustomerID='"+ NewCustomerGridView.Rows[rowIndex].Cells[0].Value+"'";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                        CustomerId = sqlDataReader.GetDecimal(0).ToString();
                        CustomerNameTextBox.Text = sqlDataReader.GetString(1);
                        MobileTextBox.Text = sqlDataReader.GetString(2);
                        AddressTextBox.Text = sqlDataReader.GetString(3);
                    
                    byte[] imageByte = ((byte[])sqlDataReader[9]);
                    if (imageByte == null)
                    {
                            pictureBoxInput.Image = null;
                    }
                    else
                    {
                        MemoryStream memoryStream = new MemoryStream(imageByte);
                            pictureBoxInput.Image = Image.FromStream(memoryStream);
                            pictureBoxInput.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                sqlDataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }
        public byte[] getImageByte(string imageLoaction)
        {
            byte[] imageByte = null;
            FileStream fileStream = new FileStream(imageLoaction, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            imageByte = binaryReader.ReadBytes((int)fileStream.Length);
            return imageByte;
        }

        private void NewCustomerGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerNameTextBox.DataBindings.Clear();
            MobileTextBox.DataBindings.Clear();
            AddressTextBox.DataBindings.Clear();
            PathTextBox.DataBindings.Clear();



            CustomerId = NewCustomerGridView.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            CustomerNameTextBox.Text = NewCustomerGridView.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            MobileTextBox.Text = NewCustomerGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            AddressTextBox.Text = NewCustomerGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            PathTextBox.Text = NewCustomerGridView.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
            pictureBoxInput.ImageLocation = NewCustomerGridView.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();

        }
    }
}
