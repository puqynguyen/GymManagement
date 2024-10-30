using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Entities;
using BUS.Services;
namespace GUI.Control
{
    public partial class UCtrlCustomer : UserControl
    {
        CustomerService customerService = new CustomerService();
        public UCtrlCustomer()
        {
            InitializeComponent();
        }
        private void Load()
        {
            
        }
        private void BindGrid(IEnumerable<Customer> customers)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
