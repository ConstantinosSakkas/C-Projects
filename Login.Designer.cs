namespace Draft_4
{
    partial class Login
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
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.Email1 = new System.Windows.Forms.Label();
            this.Password1 = new System.Windows.Forms.Label();
            this.Login1 = new System.Windows.Forms.Button();
            this.Exit1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(182, 243);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(427, 22);
            this.textEmail.TabIndex = 0;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(182, 308);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(427, 22);
            this.textPassword.TabIndex = 1;
            // 
            // Email1
            // 
            this.Email1.AutoSize = true;
            this.Email1.Location = new System.Drawing.Point(135, 249);
            this.Email1.Name = "Email1";
            this.Email1.Size = new System.Drawing.Size(41, 16);
            this.Email1.TabIndex = 2;
            this.Email1.Text = "Email";
            // 
            // Password1
            // 
            this.Password1.AutoSize = true;
            this.Password1.Location = new System.Drawing.Point(109, 314);
            this.Password1.Name = "Password1";
            this.Password1.Size = new System.Drawing.Size(67, 16);
            this.Password1.TabIndex = 3;
            this.Password1.Text = "Password";
            // 
            // Login1
            // 
            this.Login1.Location = new System.Drawing.Point(254, 357);
            this.Login1.Name = "Login1";
            this.Login1.Size = new System.Drawing.Size(75, 31);
            this.Login1.TabIndex = 4;
            this.Login1.Text = "Login";
            this.Login1.UseVisualStyleBackColor = true;
            // 
            // Exit1
            // 
            this.Exit1.Location = new System.Drawing.Point(405, 357);
            this.Exit1.Name = "Exit1";
            this.Exit1.Size = new System.Drawing.Size(75, 31);
            this.Exit1.TabIndex = 5;
            this.Exit1.Text = "Exit";
            this.Exit1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(796, 499);
            this.Controls.Add(this.Exit1);
            this.Controls.Add(this.Login1);
            this.Controls.Add(this.Password1);
            this.Controls.Add(this.Email1);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textEmail);
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Login_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label Email1;
        private System.Windows.Forms.Label Password1;
        private System.Windows.Forms.Button Login1;
        private System.Windows.Forms.Button Exit1;
    }
}