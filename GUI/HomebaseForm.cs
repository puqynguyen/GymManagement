using GUI.Control;
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
    public partial class HomebaseForm : Form
    {
        Customer customer = new Customer();
        Membership membership = new Membership();   
        Supplement supplement = new Supplement();
        Purchase purchase = new Purchase();
        public HomebaseForm()
        {
            InitializeComponent();
        }

        private void btnCus_Click(object sender, EventArgs e)
        {
           
            panel2.Controls.Clear();
            panel2.Controls.Add(customer);
            customer.Dock = DockStyle.Fill;
        }

        private void btnMem_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(membership);
            membership.Dock = DockStyle.Fill;
        }

        private void btnSupp_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(supplement);
            supplement.Dock = DockStyle.Fill;
        }

        private void btnInstructor_Click(object sender, EventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(purchase);
            purchase.Dock = DockStyle.Fill;
        }
    }
}
