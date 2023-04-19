using HalloEfCore.Models;

namespace HalloEfCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthWindContext context = new NorthWindContext();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Employees.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Products.Where(x => x.Category.CategoryName.Length > 5).OrderBy(x => x.UnitPrice).ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }
}