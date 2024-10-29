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

namespace GUI
{
    public partial class FormAddToClass : Form
    {
        private ClassService classService = new ClassService();
        public FormAddToClass(bool customer, int classId)
        {
            InitializeComponent();
            if (customer)
            {
                IEnumerable<Customer> customers = classService.GetCustomersNotInClass(classId);
                BindGridCustomer(customers);
            }
            else
            {

            }    
        }
        private void BindGridCustomer(IEnumerable<Customer> customers)
        {
            // Clear any existing columns (optional, if you want to reset columns each time)
            dgvList.Columns.Clear();

            // Check if columns are already added; if not, add them
            if (dgvList.Columns.Count == 0)
            {
                dgvList.Columns.Add("CustomerID", "ID");
                dgvList.Columns.Add("Name", "Name");
                dgvList.Columns.Add("ContactInfo", "Contact Information");
                dgvList.Columns.Add("Age", "Age");
                dgvList.Columns.Add("Gender", "Gender");
            }

            // Clear existing rows before adding new ones
            dgvList.Rows.Clear();

            // Add customer data to the DataGridView
            foreach (Customer customer in customers)
            {
                int index = dgvList.Rows.Add();
                dgvList.Rows[index].Cells["CustomerID"].Value = customer.CustomerID;
                dgvList.Rows[index].Cells["Name"].Value = customer.name;
                dgvList.Rows[index].Cells["ContactInfo"].Value = customer.contact_info;
                dgvList.Rows[index].Cells["Age"].Value = customer.age;
                dgvList.Rows[index].Cells["Gender"].Value = customer.sex;
            }
        }
        private void BindGridInstructor(IEnumerable<Instructor> instructors)
        {
            // Clear any existing columns (optional, if you want to reset columns each time)
            dgvList.Columns.Clear();

            // Check if columns are already added; if not, add them
            if (dgvList.Columns.Count == 0)
            {
                dgvList.Columns.Add("InstructorID", "ID");
                dgvList.Columns.Add("Name", "Name");
                dgvList.Columns.Add("Certifications", "Certifications");
                dgvList.Columns.Add("Gender", "Gender");
            }

            // Clear existing rows before adding new ones
            dgvList.Rows.Clear();

            // Add instructor data to the DataGridView
            foreach (Instructor instructor in instructors)
            {
                int index = dgvList.Rows.Add();
                dgvList.Rows[index].Cells["InstructorID"].Value = instructor.InstructorID;
                dgvList.Rows[index].Cells["Name"].Value = instructor.name;
                dgvList.Rows[index].Cells["Certifications"].Value = instructor.certifications;
                dgvList.Rows[index].Cells["Gender"].Value = instructor.sex;
            }
        }
    }
}
