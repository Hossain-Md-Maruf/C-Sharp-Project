using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WholeSaleManagement.Screens.CustomerF;
using WholeSaleManagement.Screens.ProductsFolder;
using WholeSaleManagement.Screens.User;

namespace WholeSaleManagement.Screens
{
    public partial class DashBoardForm : Form
    {
        public DashBoardForm()
        {
            InitializeComponent();
        }

        private void ExitApplicationButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


       

        private void DefineProductsButton_Click(object sender, EventArgs e)
        {
            DefineProductScreen dps = new DefineProductScreen();
            dps.Show();
        }

        private void ManageProductsButton_Click(object sender, EventArgs e)
        {
            ProductsRecordForm prd = new ProductsRecordForm();
            prd.Show();
        }

       

        private void CustomerManagementButton_Click(object sender, EventArgs e)
        {
            NewCustomerForm ncf = new NewCustomerForm();
            ncf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddNewSalesOrder ano = new AddNewSalesOrder();
            ano.Show();
        }

        private void StockManagementButton_Click(object sender, EventArgs e)
        {
            StockManage sm = new StockManage();
            sm.Show();
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            UserIndentity ui = new UserIndentity();
            ui.Show();
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.Show();
        }
    }
}
