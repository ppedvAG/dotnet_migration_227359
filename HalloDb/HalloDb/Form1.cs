using Microsoft.Data.SqlClient;

namespace HalloDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = "Server=.;Database=Northwind;Trusted_Connection=true;";
            conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true;TrustServerCertificate=true;";

            try
            {
                using var con = new SqlConnection(conString);
                con.Open();

                using var cmd = new SqlCommand("SELECT * FROM Empl11oyees", con);
                using var reader = cmd.ExecuteReader();

                var employees = new List<Employee>();

                while (reader.Read())
                {
                    employees.Add(new Employee()
                    {
                        Id = reader.GetInt32(0), //doof, weil per index 
                        FirstName = reader["FirstName"].ToString(), //doof, weil selbst convertieren
                        LastName = reader.GetString(reader.GetOrdinal("LastName")), //fein
                        BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")), //fein
                    });
                }

                dataGridView1.DataSource = employees;


            }//con.Dispose(); ->    //con.Close();
            catch (Exception ex)
            {
                MessageBox.Show($"Ein Fehler ist aufgetreten:\n {ex.Message}");
            }

        }
    }
}