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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Food_Final
{
    public partial class Search : Form
    {

        private UserStocks userstocksForm;
        private SqlConnection SqlConnection;
        private object selectedAllergies;
        private readonly object selectectDietaryPreference;
        private int userId;

        public Search()
        {
    InitializeComponent();
    InitializeSqlConnection();
    userstocksForm = new  UserStocks();
        }


        private void InitializeSqlConnection()
        {
   string connString = "Data Source = tolmount.abertay.ac.uk; Initial Catalog = mssql2200984; User ID = mssql2200984; Password = s4wTa4RnBR";
    SqlConnection = new SqlConnection(connString);
     Dietary();
     Allergies();
        }


        private void Dietary()//list of options dietery options 
        {
    comboBox1.Items.Add("Vegetarian");
    comboBox1.Items.Add("Vegan");
    comboBox1.Items.Add("Paleo");
    comboBox1.Items.Add("Omnivore");
    comboBox1.Items.Add("Pescatarian");
        }

        private void Allergies()// list of allergies options  
        {
   comboBox2.Items.Add("Gluten");
   comboBox2.Items.Add("Dairy");
   comboBox2.Items.Add("Nuts");
   comboBox2.Items.Add("Shellfish");
   comboBox2.Items.Add("Lactose");
   comboBox2.Items.Add("Soy");
   comboBox2.Items.Add("Eggs");
        }

        private object DietaryPreference()
        {
      return selectectDietaryPreference;
        }

        private void UserPreference(object selectectDietaryPreference) // save button functions 
        {
  selectectDietaryPreference = comboBox1.SelectedItem?.ToString();
 selectedAllergies = comboBox2.SelectedItem?.ToString();

  if (selectectDietaryPreference != null && selectedAllergies != null)
            {
        try
                {
  string query = "UPDATE RecipesDB.UserProfiles " +
                  "SET DietaryPreferences = @DietaryPreferences, Allergies = @Allergies " +
                "WHERE UserId = @UserId";

  using (SqlCommand command = new SqlCommand(query, SqlConnection))
                    {
 command.Parameters.AddWithValue("@DietaryPreferences", selectectDietaryPreference);
 command.Parameters.AddWithValue("@Allergies", selectedAllergies);
   command.Parameters.AddWithValue("@UserId", userId);

   SqlConnection.Open();
   command.ExecuteNonQuery();
  SqlConnection.Close();

     MessageBox.Show("User preferences saved.");
                    }
     }
 catch (Exception)
   {
     MessageBox.Show("An error :(");
                }
            }
 else
            {
   MessageBox.Show("Please select dietary preferences and allergies.");
            }
        }





      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dietary();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Allergies();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            UserPreference(DietaryPreference()); 
            userstocksForm.Show();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {
           
            this.recipesTableAdapter1.Fill(this.mssql2200984DataSet.Recipes);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
     string searchText = "%" + textBox1.Text.Trim() + "%";
      string query = "SELECT RecipeID, Name, Cuisine, PreparationTime, AverageRating " +
       "FROM RecipesDB.Recipes " +
       "WHERE (Name LIKE @SearchText OR Cuisine LIKE @SearchText OR @SearchText IS NULL)";


    using (SqlCommand command = new SqlCommand(query, SqlConnection))
                {
   command.Parameters.AddWithValue("@SearchText", searchText);

    SqlConnection.Open();

    SqlDataAdapter adapter = new SqlDataAdapter(command);
    DataTable DataTable = new DataTable();
    adapter.Fill(DataTable);

  dataGridView1.DataSource = DataTable;



   SqlConnection.Close();


         
                }  
                
               
            }
   catch (Exception )
            {
   MessageBox.Show("Something is not right :(");
            }
        }

private void textBox1_TextChanged_1(object sender, EventArgs ex)
        {

        }

  private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
