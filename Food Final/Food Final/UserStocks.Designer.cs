namespace Food_Final
{
    partial class UserStocks
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
            this.button1 = new System.Windows.Forms.Button();
            this.userFavoritesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recipes2200984 = new Food_Final.Recipes2200984();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Ingri = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.userFavoritesTableAdapter = new Food_Final.Recipes2200984TableAdapters.UserFavoritesTableAdapter();
            this.ingredientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientsTableAdapter = new Food_Final.Recipes2200984TableAdapters.IngredientsTableAdapter();
            this.fKUserStockIngredientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userStockTableAdapter = new Food_Final.Recipes2200984TableAdapters.UserStockTableAdapter();
            this.ingredientsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.userFavoritesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipes2200984)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKUserStockIngredientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkCyan;
            this.button1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userFavoritesBindingSource, "UserID", true));
            this.button1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button1.Location = new System.Drawing.Point(286, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Insert Data";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userFavoritesBindingSource
            // 
            this.userFavoritesBindingSource.DataMember = "UserFavorites";
            this.userFavoritesBindingSource.DataSource = this.recipes2200984;
            // 
            // recipes2200984
            // 
            this.recipes2200984.DataSetName = "Recipes2200984";
            this.recipes2200984.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 295);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Favourites";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.recipeIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.userFavoritesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(410, 183);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // recipeIDDataGridViewTextBoxColumn
            // 
            this.recipeIDDataGridViewTextBoxColumn.DataPropertyName = "RecipeID";
            this.recipeIDDataGridViewTextBoxColumn.HeaderText = "RecipeID";
            this.recipeIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.recipeIDDataGridViewTextBoxColumn.Name = "recipeIDDataGridViewTextBoxColumn";
            this.recipeIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.Ingri);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(445, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 403);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Stock";
            // 
            // Ingri
            // 
            this.Ingri.BackColor = System.Drawing.Color.YellowGreen;
            this.Ingri.FormattingEnabled = true;
            this.Ingri.ItemHeight = 16;
            this.Ingri.Location = new System.Drawing.Point(18, 85);
            this.Ingri.Name = "Ingri";
            this.Ingri.Size = new System.Drawing.Size(309, 244);
            this.Ingri.TabIndex = 4;
            this.Ingri.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(141, 351);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // userFavoritesTableAdapter
            // 
            this.userFavoritesTableAdapter.ClearBeforeFill = true;
            // 
            // ingredientsBindingSource
            // 
            this.ingredientsBindingSource.DataMember = "Ingredients";
            this.ingredientsBindingSource.DataSource = this.recipes2200984;
            // 
            // ingredientsTableAdapter
            // 
            this.ingredientsTableAdapter.ClearBeforeFill = true;
            // 
            // fKUserStockIngredientsBindingSource
            // 
            this.fKUserStockIngredientsBindingSource.DataMember = "FK_UserStock_Ingredients";
            this.fKUserStockIngredientsBindingSource.DataSource = this.ingredientsBindingSource;
            // 
            // userStockTableAdapter
            // 
            this.userStockTableAdapter.ClearBeforeFill = true;
            // 
            // ingredientsBindingSource1
            // 
            this.ingredientsBindingSource1.DataMember = "Ingredients";
            this.ingredientsBindingSource1.DataSource = this.recipes2200984;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // UserStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Name = "UserStocks";
            this.Text = "UserStocks";
            this.Load += new System.EventHandler(this.UserStocks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userFavoritesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipes2200984)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKUserStockIngredientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private Recipes2200984 recipes2200984;
        private System.Windows.Forms.BindingSource userFavoritesBindingSource;
        private Recipes2200984TableAdapters.UserFavoritesTableAdapter userFavoritesTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ingredientsBindingSource;
        private Recipes2200984TableAdapters.IngredientsTableAdapter ingredientsTableAdapter;
        public System.Windows.Forms.ListBox Ingri;
        private System.Windows.Forms.BindingSource fKUserStockIngredientsBindingSource;
        private Recipes2200984TableAdapters.UserStockTableAdapter userStockTableAdapter;
        private System.Windows.Forms.BindingSource ingredientsBindingSource1;
        private System.Windows.Forms.TextBox textBox1;
    }
}