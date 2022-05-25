namespace WholeSaleManagement.Screens.ProductsFolder
{
    partial class ChangePassword
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.NewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentPasswordTextBox = new System.Windows.Forms.Label();
            this.ChangePasswordTextBox = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.UserNameTextBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(370, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 1;
            // 
            // NewPassword
            // 
            this.NewPassword.Location = new System.Drawing.Point(370, 151);
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.Size = new System.Drawing.Size(121, 20);
            this.NewPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Name";
            // 
            // CurrentPasswordTextBox
            // 
            this.CurrentPasswordTextBox.AutoSize = true;
            this.CurrentPasswordTextBox.Location = new System.Drawing.Point(252, 122);
            this.CurrentPasswordTextBox.Name = "CurrentPasswordTextBox";
            this.CurrentPasswordTextBox.Size = new System.Drawing.Size(90, 13);
            this.CurrentPasswordTextBox.TabIndex = 4;
            this.CurrentPasswordTextBox.Text = "Current Password";
            // 
            // ChangePasswordTextBox
            // 
            this.ChangePasswordTextBox.AutoSize = true;
            this.ChangePasswordTextBox.Location = new System.Drawing.Point(252, 154);
            this.ChangePasswordTextBox.Name = "ChangePasswordTextBox";
            this.ChangePasswordTextBox.Size = new System.Drawing.Size(78, 13);
            this.ChangePasswordTextBox.TabIndex = 5;
            this.ChangePasswordTextBox.Text = "New Password";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(370, 201);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(121, 52);
            this.ConfirmButton.TabIndex = 6;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserNameTextBox.FormattingEnabled = true;
            this.UserNameTextBox.Location = new System.Drawing.Point(370, 80);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(121, 21);
            this.UserNameTextBox.TabIndex = 7;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ChangePasswordTextBox);
            this.Controls.Add(this.CurrentPasswordTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewPassword);
            this.Controls.Add(this.textBox2);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox NewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CurrentPasswordTextBox;
        private System.Windows.Forms.Label ChangePasswordTextBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.ComboBox UserNameTextBox;
    }
}