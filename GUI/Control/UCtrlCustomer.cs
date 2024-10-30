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
using BUS.services;
namespace GUI.Control
{
    public partial class UCtrlCustomer : UserControl
    {
        CustomerService customerService = new CustomerService();
        public UCtrlCustomer()
        {
            InitializeComponent();
            dgvAdjust.DefaultCellStyle.ForeColor = Color.Black;
            dgvAdjust.DefaultCellStyle.BackColor = Color.White;
            dgvAdjust.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAdjust.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            Load();
        }
        private void Load()
        {
            IEnumerable<Customer> customers = customerService.GetAll();
            BindGrid(customers);
        }
        private void BindGrid(IEnumerable<Customer> customers)
        {
            dgvAdjust.Rows.Clear();
            foreach (var item in customers)
            {
                int index = dgvAdjust.Rows.Add();
                dgvAdjust.Rows[index].Cells[0].Value = item.CustomerID;
                dgvAdjust.Rows[index].Cells[1].Value = item.name;
                dgvAdjust.Rows[index].Cells[2].Value = item.sex;
                dgvAdjust.Rows[index].Cells[3].Value = item.age;
                dgvAdjust.Rows[index].Cells[4].Value = item.contact_info;
                dgvAdjust.Rows[index].Cells[5].Value = item.address;
                dgvAdjust.Rows[index].Cells[6].Value = item.date_joined;
                var membership = customerService.GetActiveMembershipByCustomerId(item.CustomerID);

                if (membership != null)
                {
                    dgvAdjust.Rows[index].Cells[7].Value = membership.name;
                }
                else
                {
                    dgvAdjust.Rows[index].Cells[7].Value = "No active membership";
                }
            }
        }

        private void dgvAdjust_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && dgvAdjust.Columns[0].Index >= 0)
            //{
            //    txtName = dgvClass.Rows[e.RowIndex].Cells[0].Value;
            //    IEnumerable<Customer> customers = classService.GetCustomersInClass(_selectedClassId);
            //    IEnumerable<Instructor> instructors = classService.GetInstructorsInClass(_selectedClassId);
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
