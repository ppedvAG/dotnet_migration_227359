﻿using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
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

        private void button1_Click(object sender, EventArgs e)
        {
            pdfViewer1.Document?.Dispose();

            pdfViewer1.Document = PdfDocument.Load("TEST PDF.pdf");

            var lala= System.Data.Entity.TransactionalBehavior.EnsureTransaction.ToString();
        }
    }
}
