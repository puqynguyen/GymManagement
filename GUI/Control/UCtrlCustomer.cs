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
using System.Xml.Linq;
namespace GUI.Control
{
    public partial class UCtrlCustomer : UserControl
    {
        CustomerService customerService = new CustomerService();
        MembershipService membershipService = new MembershipService();
        public UCtrlCustomer()
        {
            InitializeComponent();
            dgvAdjust.DefaultCellStyle.ForeColor = Color.Black;
            dgvAdjust.DefaultCellStyle.BackColor = Color.White;
            dgvAdjust.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAdjust.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
        }
        private void BindGrid(IEnumerable<Customer> customers)
        {
            IEnumerable<Membership> memberships = membershipService.GetAll();
            cbbMembership.DataSource = memberships;
            this.cbbMembership.DisplayMember = "name"; 
            this.cbbMembership.ValueMember = "MembershipId";
            cbbMembership.Text = "";
            dgvAdjust.Rows.Clear();
            foreach (var item in customers)
            {
                int index = dgvAdjust.Rows.Add();
                dgvAdjust.Rows[index].Cells[0].Value = item.CustomerID;
                dgvAdjust.Rows[index].Cells[1].Value = item.name;
                dgvAdjust.Rows[index].Cells[2].Value = item.sex;
                dgvAdjust.Rows[index].Cells[3].Value = item.date_of_birth.HasValue
    ? item.date_of_birth.Value.ToString("dd/MM/yyyy") : "";
                dgvAdjust.Rows[index].Cells[4].Value = item.contact_info;
                dgvAdjust.Rows[index].Cells[5].Value = item.address;
                dgvAdjust.Rows[index].Cells[6].Value = item.date_joined.HasValue
    ? item.date_joined.Value.ToString("dd/MM/yyyy") : "";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void UCtrlCustomer_Load(object sender, EventArgs e)
        {
            IEnumerable<Customer> customers = customerService.GetAll();
            BindGrid(customers);
            
        }

        private void dgvAdjust_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAdjust.Columns[0].Index >= 0)
            {
                txtId.Text = dgvAdjust.Rows[e.RowIndex].Cells[0].Value.ToString();
                int Id = Convert.ToInt32(txtId.Text);
                txtName.Text = dgvAdjust.Rows[e.RowIndex].Cells[1].Value.ToString();
                if(dgvAdjust.Rows[e.RowIndex].Cells[2].Value.ToString() == "F")
                {
                    rdbFemale.Checked = true;
                }
                else
                {
                    rdbMale.Checked = true;
                }
                
                if (dgvAdjust.Rows[e.RowIndex].Cells[3].Value != null && DateTime.TryParseExact(dgvAdjust.Rows[e.RowIndex].Cells[3].Value.ToString().Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                {
                    dtpBirthdate.Value = dateValue;
                }
                else
                {
                    MessageBox.Show("Invalid date format in the selected cell. Please ensure the date is in 'dd/MM/yyyy' format.");
                }
                txtContact.Text = dgvAdjust.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAddress.Text = dgvAdjust.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (dgvAdjust.Rows[e.RowIndex].Cells[6].Value != null && DateTime.TryParseExact(dgvAdjust.Rows[e.RowIndex].Cells[6].Value.ToString().Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValue))
                {
                    dtpDateJoin.Value = dateValue;
                }
                else
                {
                    MessageBox.Show("Invalid date format in the selected cell. Please ensure the date is in 'dd/MM/yyyy' format.");
                }
                if(customerService.GetActiveMembershipByCustomerId(Id) != null)
                {
                    cbbMembership.SelectedValue = customerService.GetActiveMembershipByCustomerId(Id).MembershipID;
                    cbbMembership.Enabled = false;
                }
                else
                {
                    cbbMembership.Text = "x";
                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (dgvAdjust.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvAdjust.SelectedRows[0].Cells["Id"].Value);

                FormHistory historyForm = new FormHistory(customerId);
                historyForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a customer to view history.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
