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
    public partial class FormInvoice : Form
    {
        public FormInvoice(DataTable invoiceDetails, string customerId, string customerName, decimal totalAmount)
        {
            InitializeComponent();

            dataGridView1.DataSource = invoiceDetails;
            label5.Text = customerId;
            label6.Text = customerName;
            label3.Text = totalAmount.ToString("N0") + " ₫";
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {

        }
    }
}
