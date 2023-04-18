using PdfiumViewer;
using System;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace HalloWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label1.Text = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pdfViewer1.Document?.Dispose();
            pdfViewer1.Document = PdfDocument.Load("TEST PDF.pdf");

        }
    }
}
