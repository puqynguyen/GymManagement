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
        private int classId;
        bool customer;
        public FormAddToClass(bool customer, int classId)
        {
            this.classId = classId;
            this.customer = customer;
            InitializeComponent();
            btnAdd.Enabled = false;

            if (customer)
            {
                LABEL.Text = "ADD CUSTOMER INTO CLASS";
                IEnumerable<Customer> customers = classService.GetCustomersNotInClass(classId);
                BindGridCustomer(customers);
            }
            else
            {
                LABEL.Text = "ADD INSTRUCTOR INTO CLASS"; 
                IEnumerable<Instructor> instructors = classService.GetInstructorsNotInClass(classId);
                BindGridInstructor(instructors);
            }    
        }
        private void BindGridCustomer(IEnumerable<Customer> customers)
        {
            dgvList.Columns.Clear();
            if (dgvList.Columns.Count == 0)
            {
                dgvList.Columns.Add("CustomerID", "ID");
                dgvList.Columns.Add("Name", "Name");
                dgvList.Columns.Add("ContactInfo", "Contact Information");
                dgvList.Columns.Add("Age", "Age");
                dgvList.Columns.Add("Gender", "Gender");
            }
            dgvList.Rows.Clear();
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
            dgvList.Columns.Clear();
            if (dgvList.Columns.Count == 0)
            {
                dgvList.Columns.Add("InstructorID", "ID");
                dgvList.Columns.Add("Name", "Name");
                dgvList.Columns.Add("Certifications", "Certifications");
                dgvList.Columns.Add("Gender", "Gender");
            }
            dgvList.Rows.Clear();
            foreach (Instructor instructor in instructors)
            {
                int index = dgvList.Rows.Add();
                dgvList.Rows[index].Cells["InstructorID"].Value = instructor.InstructorID;
                dgvList.Rows[index].Cells["Name"].Value = instructor.name;
                dgvList.Rows[index].Cells["Certifications"].Value = instructor.certifications;
                dgvList.Rows[index].Cells["Gender"].Value = instructor.sex;
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && dgvList.Columns[0].Index >= 0)
            {
                btnAdd.Enabled = true;
                lblId.Text = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblName.Text = dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(lblId.Text);
            if(customer)
            {
                classService.RegisterCustomerToClass(Id, classId);
            }
            else
            {
                classService.AssignInstructorToClass(Id, classId);
            }
        }
    }
}
