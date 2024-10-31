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
using BUS.Services;
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
            dgvClassEdit.DefaultCellStyle.ForeColor = Color.Black;
            dgvClassEdit.DefaultCellStyle.BackColor = Color.White;
            dgvClassEdit.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvClassEdit.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
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
            txtDescription.Text = "";
            txtDescription1.Text = "";
            txtId.Text = "";
            txtName.Text = "";
            txtName1.Text = "";
            txtSize.Text = "";
            txtSize1.Text = "";
            btnRemoveCustomer.Enabled = false;
            btnRemoveInstructor.Enabled = false;
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
            formAddToClass.FormClosed += (s, args) => Load2();
            formAddToClass.ShowDialog();
        }
        private void Load2()
        {
            IEnumerable<Customer> customers = classService.GetCustomersInClass(_selectedClassId);
            IEnumerable<Instructor> instructors = classService.GetInstructorsInClass(_selectedClassId);
            BindGridCustomer(customers);
            BindGridInstructor(instructors);
            Clear();
        }
        private void btnAddInstructor_Click(object sender, EventArgs e)
        {
            FormAddToClass formAddToClass = new FormAddToClass(false, _selectedClassId);
            formAddToClass.FormClosed += (s, args) => Load2();
            formAddToClass.ShowDialog();
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            if (lblCustomerId.Text != "...")
            {
                int cusId = Convert.ToInt32(lblCustomerId.Text);
                classService.RemoveCustomerFromClass(cusId, _selectedClassId);
                Load2();
            }
        }

        private void btnRemoveInstructor_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblInstructorId.Text != "...")
                {
                    int insId = Convert.ToInt32(lblInstructorId.Text);
                    classService.RemoveInstructorFromClass(insId, _selectedClassId);
                    Load2();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dgvClassEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClassEdit.Columns[0].Index >= 0)
            {
                txtId.Text = dgvClassEdit.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvClassEdit.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDescription.Text = dgvClassEdit.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSize.Text = dgvClassEdit.Rows[e.RowIndex].Cells[3].Value.ToString();
                if(dgvClassEdit.Rows[e.RowIndex].Cells[4].Value.ToString() == "Available")
                    ckbCancel.Checked = false;
                else ckbCancel.Checked = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtId.Text);
                Class @class= classService.GetById(Id);
                if (@class == null)
                {
                    throw new Exception("Membership Id not found!");
                }
                @class.class_size = Convert.ToInt32(txtSize.Text);
                @class.class_type = txtName.Text;
                @class.desciption = txtDescription.Text;
                if (ckbCancel.Checked) @class.closed = 1;
                else @class.closed = 0;
                    
                classService.Update(@class);
                UCtrlClass_Load(sender, e);

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
                Class @class = classService.GetById(Id);
                if (@class == null)
                {
                    throw new Exception("Class Id not found!");
                }
                classService.Delete(Id);
                UCtrlClass_Load(sender , e);
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
                int size = Convert.ToInt32(txtSize1.Text);
                Class @class = new Class() { class_size = size, class_type = txtName1.Text, desciption = txtDescription1.Text};
                classService.Add(@class);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UCtrlClass_Load(sender, e);
        }

        private void ckbClosedClass_CheckedChanged(object sender, EventArgs e)
        {
            IEnumerable<Class> classes = null;
            if (ckbClosedClass.Checked)
            {
                classes = classService.GetAll().Where(c => c.closed == 1);

                dgvClassEdit.Rows.Clear();
                foreach (var item in classes)
                {
                    int index = dgvClassEdit.Rows.Add();
                    dgvClassEdit.Rows[index].Cells[0].Value = item.ClassID;
                    dgvClassEdit.Rows[index].Cells[1].Value = item.class_type;
                    dgvClassEdit.Rows[index].Cells[2].Value = item.desciption;
                    dgvClassEdit.Rows[index].Cells[3].Value = item.class_size;
                    dgvClassEdit.Rows[index].Cells[4].Value = "Closed";
                }
            }
            else
            {
                dgvClassEdit.Rows.Clear();
                classes = classService.GetAll();
                foreach (var item in classes)
                {
                    int index = dgvClassEdit.Rows.Add();
                    dgvClassEdit.Rows[index].Cells[0].Value = item.ClassID;
                    dgvClassEdit.Rows[index].Cells[1].Value = item.class_type;
                    dgvClassEdit.Rows[index].Cells[2].Value = item.desciption;
                    dgvClassEdit.Rows[index].Cells[3].Value = item.class_size;
                    if (item.closed == 1)
                    {
                        dgvClassEdit.Rows[index].Cells[4].Value = "Closed";
                    }
                    else
                    {
                        dgvClassEdit.Rows[index].Cells[4].Value = "Available";
                    }
                }
            }    
        }

        private void UCtrlClass_Load(object sender, EventArgs e)
        {
            dgvCustomer.Rows.Clear();
            dgvInstructor.Rows.Clear();
            btnRemoveCustomer.Enabled = false;
            btnRemoveInstructor.Enabled = false;
            Clear();
            ckbClosedClass_CheckedChanged(sender, e);
            ckFull_CheckedChanged(sender, e);
        }

    }
}
