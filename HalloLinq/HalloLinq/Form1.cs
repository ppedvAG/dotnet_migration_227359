using System.Runtime.CompilerServices;

namespace HalloLinq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            employees.Add(new Employee() { Id = 1, FirstName = "Fred", LastName = "Feuerstein", BirthDate = new DateTime(1984, 4, 7) });
            employees.Add(new Employee() { Id = 2, FirstName = "Wilma", LastName = "Flintstone", BirthDate = new DateTime(1985, 5, 15) });
            employees.Add(new Employee() { Id = 3, FirstName = "Barney", LastName = "Rubble", BirthDate = new DateTime(1986, 6, 23) });
            employees.Add(new Employee() { Id = 4, FirstName = "Betty", LastName = "Rubble", BirthDate = new DateTime(1987, 7, 31) });
            employees.Add(new Employee() { Id = 5, FirstName = "Bam Bam", LastName = "Rubble", BirthDate = new DateTime(1988, 8, 8) });
            employees.Add(new Employee() { Id = 6, FirstName = "Dino", LastName = "Flintstone", BirthDate = new DateTime(1989, 9, 20) });
            employees.Add(new Employee() { Id = 7, FirstName = "Mr.", LastName = "Slate", BirthDate = new DateTime(1990, 10, 1) });
            employees.Add(new Employee() { Id = 8, FirstName = "Pearl", LastName = "Slaghoople", BirthDate = new DateTime(1991, 11, 3) });
            employees.Add(new Employee() { Id = 9, FirstName = "Joe", LastName = "Rockhead", BirthDate = new DateTime(1992, 12, 5) });
            employees.Add(new Employee() { Id = 10, FirstName = "The Great", LastName = "Gazoo", BirthDate = new DateTime(1993, 1, 7) });
            employees.Add(new Employee() { Id = 11, FirstName = "Samantha", LastName = "Slaghoople", BirthDate = new DateTime(1994, 2, 9) });
            employees.Add(new Employee() { Id = 12, FirstName = "George", LastName = "Slate", BirthDate = new DateTime(1995, 3, 11) });
            employees.Add(new Employee() { Id = 13, FirstName = "Zonk", LastName = "Rubble", BirthDate = new DateTime(1996, 4, 13) });
            employees.Add(new Employee() { Id = 14, FirstName = "Shmoo", LastName = "Slaghoople", BirthDate = new DateTime(1997, 5, 15) });
            employees.Add(new Employee() { Id = 15, FirstName = "Rocky", LastName = "Gravel", BirthDate = new DateTime(1998, 6, 17) });
            employees.Add(new Employee() { Id = 16, FirstName = "Crush", LastName = "Slaghoople", BirthDate = new DateTime(1999, 7, 19) });
            employees.Add(new Employee() { Id = 17, FirstName = "Pebbles", LastName = "Flintstone", BirthDate = new DateTime(2000, 8, 21) });
            employees.Add(new Employee() { Id = 18, FirstName = "Roxy", LastName = "Rockhead", BirthDate = new DateTime(2001, 9, 23) });
            employees.Add(new Employee() { Id = 19, FirstName = "Chip", LastName = "Rockhead", BirthDate = new DateTime(2002, 10, 25) });
        }

        List<Employee> employees = new List<Employee>();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = employees;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = from emp in employees
                        where emp.LastName.StartsWith("R")
                        orderby emp.LastName, emp.FirstName descending
                        select emp;

            dataGridView1.DataSource = query.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = employees.Where(x => x.LastName.StartsWith("R"))
                                                .OrderBy(x => x.LastName)
                                                .ThenByDescending(x => x.FirstName)
                                                .ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{employees.Average(x => x.BirthDate.Month)} ⌀ Monat");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var emp = employees.FirstOrDefault(x => x.BirthDate.Month == 5);

            if (emp != null)
                MessageBox.Show($"{emp.FirstName}");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var query = from emp in employees
                        select new { Name = $"{emp.FirstName} {emp.LastName}", BDate = emp.BirthDate };

            dataGridView1.DataSource = query.ToList();
        }
    }

    static class DateTimeKW
    {
        public static int GetKw(this DateTime dt) //extention Method
        {
            return 16;
        }
    }
}