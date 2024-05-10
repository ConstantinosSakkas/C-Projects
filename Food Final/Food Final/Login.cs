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
using System.Data.SqlTypes;



namespace Food_Final
{
    public partial class Login : Form
    {
        private SqlConnection SqlConnection;
        private Search searchForm;



        public Login()
        {
            InitializeComponent();
            InitializeSqlConnection();
            searchForm = new Search();
        }


        private void InitializeSqlConnection()
            {
            
            }


        private void Form1_Load(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
  string source = "Data Source = tolmount.abertay.ac.uk; Initial Catalog = mssql2200984; User ID = mssql2200984; Password = s4wTa4RnBR";
   string user = maskedTextBox1.Text;
    string password = textBox1.Text;

    SqlConnection SqlConnection = new SqlConnection(source);
    SqlCommand cmd = new SqlCommand("SELECT UserId FROM RecipesDB.UserProfiles WHERE Username = @Username AND Password = @Password", SqlConnection);

     SqlConnection.Open();

     cmd.Parameters.AddWithValue("@Username", user);
      cmd.Parameters.AddWithValue("@Password", password);

   using (SqlDataReader reader = cmd.ExecuteReader())
                {
 if (reader.Read())
     {
    MessageBox.Show("Great Success User :) ");


    searchForm.Show();
      }
        
     if (user.ToLower() == "admin" && password == "admin123")
     {
      MessageBox.Show("Welcome Admin :) ");
      }
      else
    {
     MessageBox.Show("Sorry, not the right credentials");
   }
 }


      }
       catch (Exception)
      {
      MessageBox.Show("Oof ");
      }

          

     }


        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
