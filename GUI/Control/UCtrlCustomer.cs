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
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            Load();
        }
        private void Load()
        {
            IEnumerable<Customer> customers = customerService.GetAll();
            BindGrid(customers);

        }
        private void BindGrid(IEnumerable<Customer> customers)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in customers)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.CustomerID;
                dataGridView1.Rows[index].Cells[1].Value = item.name;
                dataGridView1.Rows[index].Cells[2].Value = item.sex;
                dataGridView1.Rows[index].Cells[3].Value = item.age;
                dataGridView1.Rows[index].Cells[4].Value = item.contact_info;
                dataGridView1.Rows[index].Cells[5].Value = item.address;
                dataGridView1.Rows[index].Cells[6].Value = item.date_joined;
                var membership = customerService.GetActiveMembershipByCustomerId(item.CustomerID);

                if (membership != null)
                {
                    dataGridView1.Rows[index].Cells[7].Value = membership.name;
                }
                else
                {
                    dataGridView1.Rows[index].Cells[7].Value = "No active membership";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[0].Index >= 0)
            {
                txtIdV.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameV.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                // Parse the date string to DateTime and assign it to dtpCreateDate.Value
                DateTime dateValue;
                if (DateTime.TryParse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), out dateValue))
                {
                    dtpCreateDate.Value = dateValue;
                }
                else
                {
                    MessageBox.Show("Invalid date format in the selected row.");
                }
            }
        }
    }
}
