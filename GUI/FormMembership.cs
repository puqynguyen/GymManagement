using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BUS.Services;
using DTO.Entities;
namespace GUI
{
    public partial class FormMembership : Form
    {
        MembershipService membershipService = new MembershipService();
        public FormMembership()
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Now;
            txtDateCreate2.Text = dateTime.ToString();
        }
        public void BindGrid(IEnumerable<Membership> memberships)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in memberships)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.MembershipID;
                dataGridView1.Rows[index].Cells[1].Value = item.name;
                dataGridView1.Rows[index].Cells[2].Value = item.membership_length;
                dataGridView1.Rows[index].Cells[3].Value = item.price;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[0].Index >= 0)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLength.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
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


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            try
            {
                int Id = Convert.ToInt32(txtId.Text);
                Membership membership = membershipService.GetById(Id);
                if (membership == null)
                {
                    throw new Exception("Membership Id not found!");
                }
                membership.price = Convert.ToInt32(txtPrice.Text);
                membership.membership_length = Convert.ToInt32(txtLength.Text);
                membership.name = txtName.Text;
                membershipService.Update(membership);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtId.Text);
                Membership membership = membershipService.GetById(Id);
                if (membership == null)
                {
                    throw new Exception("Membership Id not found!");
                }
                membershipService.Delete(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int length = Convert.ToInt32(txtLength.Text);
                DateTime dateTime = dtpCreateDate.Value.ToUniversalTime();
                Membership membership = new Membership() { membership_length = length , date_created = dtpCreateDate.Value.ToUniversalTime() };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
