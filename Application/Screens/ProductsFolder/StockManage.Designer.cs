namespace WholeSaleManagement.Screens.ProductsFolder
{
    partial class StockManage
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
            this.ShowButton = new System.Windows.Forms.Button();
            this.StockManageDataGridview = new System.Windows.Forms.DataGridView();
            this.ProductComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StockManageDataGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowButton
            // 
            this.ShowButton.Location = new System.Drawing.Point(414, 10);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(118, 23);
            this.ShowButton.TabIndex = 7;
            this.ShowButton.Text = "Show";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // StockManageDataGridview
            // 
            this.StockManageDataGridview.AllowUserToAddRows = false;
            this.StockManageDataGridview.AllowUserToDeleteRows = false;
            this.StockManageDataGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StockManageDataGridview.Location = new System.Drawing.Point(12, 71);
            this.StockManageDataGridview.Name = "StockManageDataGridview";
            this.StockManageDataGridview.ReadOnly = true;
            this.StockManageDataGridview.Size = new System.Drawing.Size(762, 344);
            this.StockManageDataGridview.TabIndex = 13;
            // 
            // ProductComboBox
            // 
            this.ProductComboBox.FormattingEnabled = true;
            this.ProductComboBox.Location = new System.Drawing.Point(253, 12);
            this.ProductComboBox.Name = "ProductComboBox";
            this.ProductComboBox.Size = new System.Drawing.Size(121, 21);
            this.ProductComboBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Product List";
            // 
            // StockManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductComboBox);
            this.Controls.Add(this.StockManageDataGridview);
            this.Controls.Add(this.ShowButton);
            this.Name = "StockManage";
            this.Text = "StockManage";
            this.Load += new System.EventHandler(this.StockManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockManageDataGridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.DataGridView StockManageDataGridview;
        private System.Windows.Forms.ComboBox ProductComboBox;
        private System.Windows.Forms.Label label1;
    }
}