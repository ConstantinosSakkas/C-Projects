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

namespace Food_Final
{
    public partial class UserStocks : Form
    {

        
        SqlCommand cmd;
        private SqlConnection SqlConnection;


        public UserStocks()
        {
            string connString = "Data Source = tolmount.abertay.ac.uk; Initial Catalog = mssql2200984; User ID = mssql2200984; Password = s4wTa4RnBR";
            SqlConnection = new SqlConnection(connString);
            InitializeComponent();

        }



        private void UserStocks_Load(object sender, EventArgs e)
        {
           
       
            this.ingredientsTableAdapter.Fill(this.recipes2200984.Ingredients);

        }





        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection.Open();

                
                int NewR = 0;
                int ID =0;

                string updateQuery = "UPDATE RecipesDB.UserFavorites " +
                                     "SET RecipeID = @NewRecipeID " +
                                     "WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(updateQuery, SqlConnection))
                {
                    command.Parameters.AddWithValue("@NewRecipeID", NewR);
                    command.Parameters.AddWithValue("@UserID", ID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Done");
                    }
                    else
                    {
                        Console.WriteLine("Nothing changed ");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Oops");
            }
            finally
            {
                SqlConnection.Close();
            }
        }



      

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//list box 
        {

        }
        private void button3_Click(object sender, EventArgs e)//stock
        {
            Ingri.Items.Add(textBox1.Text);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.userFavoritesTableAdapter.Fill(this.recipes2200984.UserFavorites);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//stock
        {

        }
    }
}
