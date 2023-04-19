using Microsoft.Data.SqlClient;

namespace HalloDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true;TrustServerCertificate=true;";

        private void button1_Click(object sender, EventArgs e)
        {
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


            } //con.Dispose(); --> con.Close();
            catch (Exception ex)
            {
                MessageBox.Show($"Ein Fehler ist aufgetreten:\n {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using var con = new SqlConnection(conString);
                con.Open();

                using var cmd = new SqlCommand("SELECT COUNT(*) FROM Employees", con);
                object resultAsObject = cmd.ExecuteScalar();
                int resultAlsIntCasting = (int)resultAsObject; //casting = doof

                if (resultAsObject is int resultAsInt) //pattern matching = fein
                {
                    MessageBox.Show($"{resultAsInt:000} Employees in DB");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ein Fehler ist aufgetreten:\n {ex.Message}");
            }
        }
    }
}