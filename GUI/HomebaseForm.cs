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
        UCtrlCustomer customer = new UCtrlCustomer();
        UCtrlMembership membership = new UCtrlMembership();   
        UCtrlSupplement supplement = new UCtrlSupplement();
        UCtrlPurchase purchase = new UCtrlPurchase();
        UCtrlInstructor instructor = new UCtrlInstructor();
        UCtrlClass Class = new UCtrlClass();

        private Button currentButton;
        public HomebaseForm()
        {
            InitializeComponent();
        }

        private void ActivateButton(Button button)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(184, 134, 11); 
            }
            button.BackColor = Color.DarkOrange; 
            currentButton = button;
        }

        private void btnCus_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            panel2.Controls.Clear();
            panel2.Controls.Add(customer);
            customer.Dock = DockStyle.Fill;
        }

        private void btnMem_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            panel2.Controls.Clear();
            panel2.Controls.Add(membership);
            membership.Dock = DockStyle.Fill;
        }

        private void btnSupp_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            panel2.Controls.Clear();
            panel2.Controls.Add(supplement);
            supplement.Dock = DockStyle.Fill;
        }

        private void btnInstructor_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            panel2.Controls.Clear();
            panel2.Controls.Add(instructor);
            instructor.Dock = DockStyle.Fill;
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            panel2.Controls.Clear();
            panel2.Controls.Add(purchase);
            purchase.Dock = DockStyle.Fill;
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            panel2.Controls.Clear();
            panel2.Controls.Add(Class);
            Class.Dock = DockStyle.Fill;
        }
    }
}
