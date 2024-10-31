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
        public FormInvoice(DataTable invoiceDetails, string customerId, string customerName, decimal totalAmount, DateTime dateCreated)
        {
            InitializeComponent();

            dataGridView1.DataSource = invoiceDetails;
            lblId.Text = customerId;
            lblName.Text = customerName;
            lblTotal.Text = totalAmount.ToString("N0") + " ₫";
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
