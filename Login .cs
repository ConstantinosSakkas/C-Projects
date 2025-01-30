using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Draft_4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            InitializeMyControl();
        }

        private void Login1_Load(object sender, EventArgs e)
        {
        }

        private void Login1_Click_1(object sender, EventArgs e)// Portion s adapted from 205 module project 
        {
            string connString = ConfigurationManager.ConnectionStrings["Draft_4.Properties.Settings.GLEN1"].ConnectionString;// Arthur:CodingByAdnanQurban (https://youtu.be/hgARKgpg2uE?si=NyQv7fxtcEHVFc4a) (accessed 19th of December) idea of storing the database credetials for better security 

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string email = textBox1.Text;
                    string password = textBox2.Text;

                    string query = "SELECT EmpID, Password FROM GLEN.Employees WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            var storedHash = reader["Password"].ToString();
                            int empId = (int)reader["EmpID"];

                            if (BCrypt.Net.BCrypt.Verify(password, storedHash))// adapted and design from Password-based Authentication sheet
                            {
                                MessageBox.Show("You have logged in, great!");

                                if (email.Equals("bob.ross@something.com", StringComparison.OrdinalIgnoreCase))
                                {
                                //open IT form for It user
                                    IT_Department ITForm = new IT_Department(empId);
                                    ITForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                   //open the other employee form for non it users
                                    Other_Employee_Assets employeeForm = new Other_Employee_Assets(empId);
                                    employeeForm.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect password!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email not found");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void InitializeMyControl()
        {
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 15;
        }

        private void Exit1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
