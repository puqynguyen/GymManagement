using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.services;
using DTO.Entities;

namespace GUI.Control
{
    public partial class UCtrlClass : UserControl
    {
        ClassService classService = new ClassService();
        private int _selectedClassId;
        public UCtrlClass()
        {
            InitializeComponent();
            dgvClass.DefaultCellStyle.ForeColor = Color.Black;
            dgvClass.DefaultCellStyle.BackColor = Color.White;
            dgvClass.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvClass.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dgvInstructor.DefaultCellStyle.ForeColor = Color.Black;
            dgvInstructor.DefaultCellStyle.BackColor = Color.White;
            dgvInstructor.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvInstructor.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dgvCustomer.DefaultCellStyle.ForeColor = Color.Black;
            dgvCustomer.DefaultCellStyle.BackColor = Color.White;
            dgvCustomer.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCustomer.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            IEnumerable<Class> classes = classService.GetAll();
            BindGridClass(classes);
            btnRemoveCustomer.Enabled = false;
            btnRemoveInstructor.Enabled = false;
        }
        private void BindGridClass(IEnumerable<Class> classes)
        {
            dgvClass.Rows.Clear();
            foreach (var item in classes)
            {
                int index = dgvClass.Rows.Add();
                dgvClass.Rows[index].Cells[0].Value = item.ClassID;
                dgvClass.Rows[index].Cells[1].Value = item.class_type;
                dgvClass.Rows[index].Cells[2].Value = item.desciption;
                int enrollment = classService.GetCustomersInClass(item.ClassID).Count();
                dgvClass.Rows[index].Cells[3].Value = $"{enrollment}/{item.class_size}";
                if(item.closed == 1)
                {
                    dgvClass.Rows[index].Cells[4].Value = "Closed";
                }
                else if(enrollment == item.class_size)
                {
                    dgvClass.Rows[index].Cells[4].Value = "Full";
                }
                else
                {
                    dgvClass.Rows[index].Cells[4].Value = "Available";
                }
            }
        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClass.Columns[0].Index >= 0)
            {
                btnAddCustomer.Enabled = true;
                btnRemoveCustomer.Enabled = false;
                btnAddInstructor.Enabled = true;
                btnRemoveInstructor.Enabled = false;
                Clear();
                _selectedClassId = Convert.ToInt32(dgvClass.Rows[e.RowIndex].Cells[0].Value);
                IEnumerable<Customer> customers = classService.GetCustomersInClass(_selectedClassId);
                IEnumerable<Instructor> instructors = classService.GetInstructorsInClass(_selectedClassId);
                BindGridCustomer(customers);
                BindGridInstructor(instructors);
            }
        }
        private void BindGridCustomer(IEnumerable<Customer> customers)
        {
            dgvCustomer.Rows.Clear();
            foreach (Customer customer in customers)
            {
                int index = dgvCustomer.Rows.Add();
                dgvCustomer.Rows[index].Cells[0].Value = customer.CustomerID;
                dgvCustomer.Rows[index].Cells[1].Value = customer.name;
                dgvCustomer.Rows[index].Cells[2].Value = customer.contact_info;
                dgvCustomer.Rows[index].Cells[3].Value = customer.age;
                dgvCustomer.Rows[index].Cells[4].Value = customer.sex;
            }
        }
        private void BindGridInstructor(IEnumerable<Instructor> instructors)
        {
            dgvInstructor.Rows.Clear();
            foreach (Instructor instructor in instructors)
            {
                int index = dgvInstructor.Rows.Add();
                dgvInstructor.Rows[index].Cells[0].Value = instructor.InstructorID;
                dgvInstructor.Rows[index].Cells[1].Value = instructor.name;
                dgvInstructor.Rows[index].Cells[2].Value = instructor.certifications;
                dgvInstructor.Rows[index].Cells[3].Value = instructor.sex;
            }
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomer.Columns[0].Index >= 0)
            {
                lblCustomerId.Text = dgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblCustomerName.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblContact.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                btnRemoveCustomer.Enabled = true;
            }
        }

        private void dgvInstructor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvInstructor.Columns[0].Index >= 0)
            {
                lblInstructorId.Text = dgvInstructor.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblInstructorName.Text = dgvInstructor.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblCertifications.Text = dgvInstructor.Rows[e.RowIndex].Cells[2].Value.ToString();
                btnRemoveInstructor.Enabled = true;
            }
        }
        private void Clear()
        {
            lblCertifications.Text = "...";
            lblContact.Text = "...";
            lblCustomerId.Text = "...";
            lblCustomerName.Text = "...";
            lblInstructorId.Text = "...";
            lblInstructorName.Text = "...";

        }

        private void ckFull_CheckedChanged(object sender, EventArgs e)
        {
            if (ckFull.Checked)
            {
                IEnumerable<Class> classes = classService.GetAllAvailableClass();
                BindGridClass(classes);
            }
            else
            {
                IEnumerable<Class> classes = classService.GetAll();
                BindGridClass(classes);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            FormAddToClass formAddToClass = new FormAddToClass(true, _selectedClassId);
            formAddToClass.ShowDialog();
        }

        private void btnAddInstructor_Click(object sender, EventArgs e)
        {
            FormAddToClass formAddToClass = new FormAddToClass(false, _selectedClassId);
            formAddToClass.ShowDialog();
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            int cusId = Convert.ToInt32(lblCustomerId.Text);
            classService.RemoveCustomerFromClass(cusId, _selectedClassId);
        }

        private void btnRemoveInstructor_Click(object sender, EventArgs e)
        {
            int insId = Convert.ToInt32(lblInstructorId.Text);
            classService.RemoveInstructorFromClass(insId, _selectedClassId);
        }
    }
}
