using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormBill : Form
    {
        private DataTable invoiceDetails;
        private decimal totalAmount;
        public FormBill(DataTable invoiceDetails, decimal totalAmount)
        {
            InitializeComponent();
            this.invoiceDetails = invoiceDetails;
            this.totalAmount = totalAmount;
        }

        private void Bill_Load(object sender, EventArgs e)
        {


        }
    }
}
