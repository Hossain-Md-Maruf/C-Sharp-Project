namespace WholeSaleManagement.Screens
{
    partial class DashBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.StockManagementButton = new System.Windows.Forms.Button();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.CustomerManagementButton = new System.Windows.Forms.Button();
            this.ExitApplicationButton = new System.Windows.Forms.Button();
            this.DefineProductsButton = new System.Windows.Forms.Button();
            this.CreateUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(25, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "Add New Sales Order";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // StockManagementButton
            // 
            this.StockManagementButton.Location = new System.Drawing.Point(25, 195);
            this.StockManagementButton.Name = "StockManagementButton";
            this.StockManagementButton.Size = new System.Drawing.Size(178, 41);
            this.StockManagementButton.TabIndex = 3;
            this.StockManagementButton.Text = "Stock Management";
            this.StockManagementButton.UseVisualStyleBackColor = true;
            this.StockManagementButton.Click += new System.EventHandler(this.StockManagementButton_Click);
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.Location = new System.Drawing.Point(25, 242);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(178, 43);
            this.ChangePasswordButton.TabIndex = 6;
            this.ChangePasswordButton.Text = "Change Password";
            this.ChangePasswordButton.UseVisualStyleBackColor = true;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // CustomerManagementButton
            // 
            this.CustomerManagementButton.Location = new System.Drawing.Point(25, 113);
            this.CustomerManagementButton.Name = "CustomerManagementButton";
            this.CustomerManagementButton.Size = new System.Drawing.Size(178, 34);
            this.CustomerManagementButton.TabIndex = 7;
            this.CustomerManagementButton.Text = "New Customer";
            this.CustomerManagementButton.UseVisualStyleBackColor = true;
            this.CustomerManagementButton.Click += new System.EventHandler(this.CustomerManagementButton_Click);
            // 
            // ExitApplicationButton
            // 
            this.ExitApplicationButton.Location = new System.Drawing.Point(25, 348);
            this.ExitApplicationButton.Name = "ExitApplicationButton";
            this.ExitApplicationButton.Size = new System.Drawing.Size(178, 41);
            this.ExitApplicationButton.TabIndex = 9;
            this.ExitApplicationButton.Text = "Exit Application";
            this.ExitApplicationButton.UseVisualStyleBackColor = true;
            this.ExitApplicationButton.Click += new System.EventHandler(this.ExitApplicationButton_Click);
            // 
            // DefineProductsButton
            // 
            this.DefineProductsButton.Location = new System.Drawing.Point(25, 69);
            this.DefineProductsButton.Name = "DefineProductsButton";
            this.DefineProductsButton.Size = new System.Drawing.Size(178, 38);
            this.DefineProductsButton.TabIndex = 10;
            this.DefineProductsButton.Text = "Define Products";
            this.DefineProductsButton.UseVisualStyleBackColor = true;
            this.DefineProductsButton.Click += new System.EventHandler(this.DefineProductsButton_Click);
            // 
            // CreateUserButton
            // 
            this.CreateUserButton.Location = new System.Drawing.Point(25, 291);
            this.CreateUserButton.Name = "CreateUserButton";
            this.CreateUserButton.Size = new System.Drawing.Size(178, 39);
            this.CreateUserButton.TabIndex = 11;
            this.CreateUserButton.Text = "Create User";
            this.CreateUserButton.UseVisualStyleBackColor = true;
            this.CreateUserButton.Click += new System.EventHandler(this.CreateUserButton_Click);
            // 
            // DashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreateUserButton);
            this.Controls.Add(this.DefineProductsButton);
            this.Controls.Add(this.ExitApplicationButton);
            this.Controls.Add(this.CustomerManagementButton);
            this.Controls.Add(this.ChangePasswordButton);
            this.Controls.Add(this.StockManagementButton);
            this.Controls.Add(this.button3);
            this.Name = "DashBoardForm";
            this.Text = "DashBoardForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button StockManagementButton;
        private System.Windows.Forms.Button ChangePasswordButton;
        private System.Windows.Forms.Button CustomerManagementButton;
        private System.Windows.Forms.Button ExitApplicationButton;
        private System.Windows.Forms.Button DefineProductsButton;
        private System.Windows.Forms.Button CreateUserButton;
    }
}