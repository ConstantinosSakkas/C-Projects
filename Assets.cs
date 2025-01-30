using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json.Linq;
namespace Draft_4
{
    public partial class IT_Department : Form
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["Draft_4.Properties.Settings.GLEN1"].ConnectionString;// Arthur:CodingByAdnanQurban (https://youtu.be/hgARKgpg2uE?si=NyQv7fxtcEHVFc4a) (accessed 19th of December) idea of storing the database credetials for better security 
        private readonly int _empId; 
        private static readonly string url = @"https://services.nvd.nist.gov/rest/json/cves/2.0?cpeName=cpe:2.3:o:microsoft:window_11:10.0.22631&cvssV3Severity=CRITICAL";//adapted url to currect version of windows application is running on
        private static readonly string Key = ConfigurationManager.AppSettings["Key"];// Arthur:CodingByAdnanQurban (https://youtu.be/hgARKgpg2uE?si=NyQv7fxtcEHVFc4a) (accessed 19th of December) idea adapted from database string  and  store api key  for better security 
        public IT_Department(int empId)
        {
            InitializeComponent();
            _empId = empId;
            _ = Load_Assets(); // load assets grid
            _ = Load_SoftAssets(); // load softassets grid
        }

        private async Task Load_Assets()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM GLEN.Assets";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    Itassets.DataSource = dataTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private async Task Load_SoftAssets()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM GLEN.SoftAssets";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    softassets.DataSource = dataTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private string SystemInfo(string propertyName)// Microsoft, DataGrid Class,  (https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.datagrid?view=windowsdesktop-8.0 ) (Accesed 25 th October)    system info class adapted to project in order to work
        {
            string result = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject os in searcher.Get())
                {
                    result = os[propertyName]?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        private async void Enter_button_Click(object sender, EventArgs e)
        {
           
            string output = await getapi();
            showapi(output);
        }

        private async Task<string> getapi()//Microsoft learn chanllenge (https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client) (accessed 22th of December 2024) and from workign api sheet code
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("apiKey", Key);//get the api key 

                try
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        return responseData;
                    }
                    else
                    {
                        return $"Request error: {response.StatusCode}";
                    }
                }
                catch (HttpRequestException e)
                {
                    return $"Request error: {e.Message}";
                }
            }
        }

        private void showapi(string apiResponse)//show api 
        {
            try
            {
                var json = JObject.Parse(apiResponse);
                var formattedJson = json.ToString();
                MessageBox.Show(formattedJson, "API Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }



        private async void Add_button_Click(object sender, EventArgs e) // adapted from 205 project
        {
            using (var dbassets = new Asset1(connString))
            {
                try
                {
                    int softId = GetSoftID();

                    var newAsset = new Asset
                    {
                        IPAddress = GetDeviceIP(),
                        Notes = note_text.Text, // write notes
                        SoftID = softId, // set the SoftID
                        EmpID = _empId // set the EmpID
                    };

                    dbassets.Assets.InsertOnSubmit(newAsset);
                    dbassets.SubmitChanges(); // save changes



                 
                    await Load_Assets();//reload asset 
                    await Load_SoftAssets(); // reload soft assets 
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private int GetSoftID()
        {
            string connString = ConfigurationManager.ConnectionStrings["Draft_4.Properties.Settings.GLEN1"].ConnectionString; // connection string
            int softId = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    //display the system name, os . and manufacturer
                    string name = SystemInfo("Caption");
                    string version = SystemInfo("Version");
                    string manufacturer = SystemInfo("Manufacturer");

                    // check if the SoftAsset already exists
                    string query = "SELECT SoftID FROM GLEN.SoftAssets WHERE OS = @OS AND Version = @Version AND Manufacturer = @Manufacturer";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OS", name);
                        cmd.Parameters.AddWithValue("@Version", version);
                        cmd.Parameters.AddWithValue("@Manufacturer", manufacturer);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            softId = (int)result;
                        }
                        else
                        {
                            // insert new SoftAsset and get the SoftID
                            string insertQuery = "INSERT INTO GLEN.SoftAssets (OS, Version, Manufacturer, Date) " +
                                "OUTPUT INSERTED.SoftID VALUES (@OS, @Version, @Manufacturer, GETDATE())";
                            using (SqlCommand adding = new SqlCommand(insertQuery, conn))
                            {
                                adding.Parameters.AddWithValue("@OS", name);
                                adding.Parameters.AddWithValue("@Version", version);
                                adding.Parameters.AddWithValue("@Manufacturer", manufacturer);
                                softId = (int)adding.ExecuteScalar();
                            }
                        }
                    }


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return softId;
        }

        private async void Edit_button_Click(object sender, EventArgs e) // edit button
        {
            if (Itassets.SelectedRows.Count > 0) // sees if row has been selected
            {
                var selectedRow = Itassets.SelectedRows[0];
                int assetId = Convert.ToInt32(selectedRow.Cells["AssetID"].Value); // assetid of that row is selected

                using (var dbassets = new Asset1(connString))
                {
                    try
                    {
                        var edit = dbassets.Assets.FirstOrDefault(a => a.AssetID == assetId);

                        if (edit != null) // edit assets
                        {
                            // update the selected asset row with the new values

                            edit.Notes = selectedRow.Cells["Notes"].Value.ToString();

                            dbassets.SubmitChanges(); // save changes
                            MessageBox.Show("Asset edited successfully!");

                            // Reload assets to reflect the changes
                            await Load_Assets();
                            await Load_SoftAssets();
                        }
                        else
                        {
                            MessageBox.Show("Sorry, asset not found.");
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose an asset.");
            }
        }

        private async void Delete_button_Click(object sender, EventArgs e)
        {
            if (Itassets.SelectedRows.Count > 0) // sees if row has been selected
            {
                try
                {
                    var selectedRow = Itassets.SelectedRows[0]; // check row
                    int assetId = Convert.ToInt32(selectedRow.Cells["AssetID"].Value);

                    using (var dbassets = new Asset1(connString))
                    {
                        var delete = dbassets.Assets.FirstOrDefault(a => a.AssetID == assetId);

                        if (delete != null)
                        {
                            dbassets.Assets.DeleteOnSubmit(delete); // request to delete the row selected
                            dbassets.SubmitChanges(); // save changes

                            MessageBox.Show("Asset deleted successfully!");

                            // reload assets after deletion
                            await Load_Assets();
                            await Load_SoftAssets();
                        }
                        else
                        {
                            MessageBox.Show("Asset not found.");
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("Please choose an asset.");
            }
        }

        private string GetDeviceIP() // Arthur: Ameer Hamza, C# | Find IP Address using Windows Form Application (https://www.youtube.com/watch?v=izpntJlcs8o) (Accessed 27th October 2024) adapted code from video
        {
            string deviceIP = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    deviceIP = ip.ToString();
                    break;
                }
            }
            return deviceIP;
        }

    
        private void Assets_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mssql2200984DataSet21.Assets' table. You can move, or remove it, as needed.
            this.assetsTableAdapter2.Fill(this.mssql2200984DataSet21.Assets);


        }

        private void exit_button_Click(object sender, EventArgs e)
        {
 Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void note_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void open_employee_Click(object sender, EventArgs e)
        {
  Other_Employee_Assets employeeForm = new Other_Employee_Assets(_empId);
            employeeForm.Show();
        }
    }
}

