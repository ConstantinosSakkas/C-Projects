namespace Draft_4
{
    partial class IT_Department
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
            this.components = new System.ComponentModel.Container();
            this.Itassets = new System.Windows.Forms.DataGridView();
            this.Add_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.Edit_button = new System.Windows.Forms.Button();
            this.softassets = new System.Windows.Forms.DataGridView();
            this.mssql2200984DataSet11 = new Draft_4.mssql2200984DataSet1();
            this.softAssetsTableAdapter1 = new Draft_4.mssql2200984DataSet1TableAdapters.SoftAssetsTableAdapter();
            this.Enter_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.note_text = new System.Windows.Forms.TextBox();
            this.open_employee = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mssql2200984DataSet21 = new Draft_4.mssql2200984DataSet2();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.assetsTableAdapter2 = new Draft_4.mssql2200984DataSet2TableAdapters.AssetsTableAdapter();
            this.mssql2200984DataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mssql2200984DataSet2 = new Draft_4.mssql2200984DataSet();
            this.assetsTableAdapter1 = new Draft_4.mssql2200984DataSetTableAdapters.AssetsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Itassets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softassets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2200984DataSet11)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2200984DataSet21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2200984DataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2200984DataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // Itassets
            // 
            this.Itassets.AllowUserToOrderColumns = true;
            this.Itassets.AutoGenerateColumns = false;
            this.Itassets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Itassets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Itassets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Itassets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Itassets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.Itassets.DataSource = this.bindingSource2;
            this.Itassets.Location = new System.Drawing.Point(55, 12);
            this.Itassets.Name = "Itassets";
            this.Itassets.RowHeadersWidth = 51;
            this.Itassets.RowTemplate.Height = 24;
            this.Itassets.Size = new System.Drawing.Size(548, 150);
            this.Itassets.TabIndex = 0;
            this.Itassets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(296, 64);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(75, 23);
            this.Add_button.TabIndex = 1;
            this.Add_button.Text = "Add";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Location = new System.Drawing.Point(408, 64);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(75, 23);
            this.Delete_button.TabIndex = 2;
            this.Delete_button.Text = "Delete";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // Edit_button
            // 
            this.Edit_button.Location = new System.Drawing.Point(355, 107);
            this.Edit_button.Name = "Edit_button";
            this.Edit_button.Size = new System.Drawing.Size(75, 23);
            this.Edit_button.TabIndex = 3;
            this.Edit_button.Text = "Edit";
            this.Edit_button.UseVisualStyleBackColor = true;
            this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
            // 
            // softassets
            // 
            this.softassets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.softassets.Location = new System.Drawing.Point(707, 12);
            this.softassets.Name = "softassets";
            this.softassets.RowHeadersWidth = 51;
            this.softassets.RowTemplate.Height = 24;
            this.softassets.Size = new System.Drawing.Size(678, 182);
            this.softassets.TabIndex = 4;
            // 
            // mssql2200984DataSet11
            // 
            this.mssql2200984DataSet11.DataSetName = "mssql2200984DataSet1";
            this.mssql2200984DataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // softAssetsTableAdapter1
            // 
            this.softAssetsTableAdapter1.ClearBeforeFill = true;
            // 
            // Enter_button
            // 
            this.Enter_button.Location = new System.Drawing.Point(994, 224);
            this.Enter_button.Name = "Enter_button";
            this.Enter_button.Size = new System.Drawing.Size(75, 40);
            this.Enter_button.TabIndex = 5;
            this.Enter_button.Text = "Enter";
            this.Enter_button.UseVisualStyleBackColor = true;
            this.Enter_button.Click += new System.EventHandler(this.Enter_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(689, 426);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 23);
            this.exit_button.TabIndex = 6;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.note_text);
            this.groupBox1.Controls.Add(this.Add_button);
            this.groupBox1.Controls.Add(this.Edit_button);
            this.groupBox1.Controls.Add(this.Delete_button);
            this.groupBox1.Location = new System.Drawing.Point(55, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 268);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controlls";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Notes";
            // 
            // note_text
            // 
            this.note_text.Location = new System.Drawing.Point(71, 138);
            this.note_text.Name = "note_text";
            this.note_text.Size = new System.Drawing.Size(100, 22);
            this.note_text.TabIndex = 4;
            this.note_text.TextChanged += new System.EventHandler(this.note_text_TextChanged);
            // 
            // open_employee
            // 
            this.open_employee.Location = new System.Drawing.Point(851, 426);
            this.open_employee.Name = "open_employee";
            this.open_employee.Size = new System.Drawing.Size(149, 23);
            this.open_employee.TabIndex = 8;
            this.open_employee.Text = "Employee Form";
            this.open_employee.UseVisualStyleBackColor = true;
            this.open_employee.Click += new System.EventHandler(this.open_employee_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Assets";
            this.bindingSource1.DataSource = this.mssql2200984DataSet2BindingSource;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AssetID";
            this.dataGridViewTextBoxColumn3.HeaderText = "AssetID";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "IPAddress";
            this.dataGridViewTextBoxColumn4.HeaderText = "IPAddress";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Notes";
            this.dataGridViewTextBoxColumn5.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "EmpID";
            this.dataGridViewTextBoxColumn6.HeaderText = "EmpID";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // mssql2200984DataSet21
            // 
            this.mssql2200984DataSet21.DataSetName = "mssql2200984DataSet2";
            this.mssql2200984DataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "Assets";
            this.bindingSource2.DataSource = this.mssql2200984DataSet21;
            // 
            // assetsTableAdapter2
            // 
            this.assetsTableAdapter2.ClearBeforeFill = true;
            // 
            // mssql2200984DataSet2BindingSource
            // 
            this.mssql2200984DataSet2BindingSource.DataSource = this.mssql2200984DataSet2;
            this.mssql2200984DataSet2BindingSource.Position = 0;
            // 
            // mssql2200984DataSet2
            // 
            this.mssql2200984DataSet2.DataSetName = "mssql2200984DataSet";
            this.mssql2200984DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // assetsTableAdapter1
            // 
            this.assetsTableAdapter1.ClearBeforeFill = true;
            // 
            // IT_Department
            // 
            this.ClientSize = new System.Drawing.Size(1415, 510);
            this.Controls.Add(this.open_employee);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.Enter_button);
            this.Controls.Add(this.softassets);
            this.Controls.Add(this.Itassets);
            this.Controls.Add(this.groupBox1);
            this.Name = "IT_Department";
            this.Text = "IT Department";
            this.Load += new System.EventHandler(this.Assets_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.Itassets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softassets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2200984DataSet11)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2200984DataSet21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2200984DataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2200984DataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private mssql2200984DataSet mssql2200984DataSet;
        private System.Windows.Forms.BindingSource assetsBindingSource;
        private mssql2200984DataSetTableAdapters.AssetsTableAdapter assetsTableAdapter;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
        public System.Windows.Forms.DataGridView AssetGrid;
        private System.Windows.Forms.BindingSource mssql2200984DataSetBindingSource;
        private System.Windows.Forms.DataGridView softasset;
        private mssql2200984DataSet1 mssql2200984DataSet1;
        private System.Windows.Forms.BindingSource softAssetsBindingSource;
        private mssql2200984DataSet1TableAdapters.SoftAssetsTableAdapter softAssetsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn softIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button exit2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Employeeform;
        private System.Windows.Forms.DataGridView Itassets;
        private mssql2200984DataSet mssql2200984DataSet2;
        private mssql2200984DataSetTableAdapters.AssetsTableAdapter assetsTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn empIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.Button Edit_button;
        private System.Windows.Forms.DataGridView softassets;
        private mssql2200984DataSet1 mssql2200984DataSet11;
        private mssql2200984DataSet1TableAdapters.SoftAssetsTableAdapter softAssetsTableAdapter1;
        private System.Windows.Forms.Button Enter_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.BindingSource mssql2200984DataSet2BindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox note_text;
        private System.Windows.Forms.Button open_employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource bindingSource1;
        private mssql2200984DataSet2 mssql2200984DataSet21;
        private System.Windows.Forms.BindingSource bindingSource2;
        private mssql2200984DataSet2TableAdapters.AssetsTableAdapter assetsTableAdapter2;
    }
}