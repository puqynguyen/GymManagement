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
        private readonly ClassService service = new ClassService();
        public UCtrlClass()
        {
            InitializeComponent();
            
            IEnumerable<Class> classes = service.GetAll();
            BindGridClass(classes);
        }
        private void BindGridClass(IEnumerable<Class> classes)
        {
            dgvClass.Rows.Clear();
            foreach (var cls in classes)
            {
                int index = dgvClass.Rows.Add();
                dgvClass.Rows[index].Cells["Id"].Value = cls.ClassID;
                dgvClass.Rows[index].Cells["ClassName"].Value = cls.class_type;
                int CusInClass = Convert.ToInt16(service.GetCustomersInClass(cls.ClassID).Count());
                dgvClass.Rows[index].Cells["Enrollment"].Value = $"{CusInClass}/{cls.class_size}";
                if(cls.closed == 1)
                {
                    dgvClass.Rows[index].Cells["Status"].Value = "Closed";
                }
                else if(CusInClass == cls.class_size)
                {
                    dgvClass.Rows[index].Cells["Status"].Value = "Full";
                }
                else
                {
                    dgvClass.Rows[index].Cells["Status"].Value = "Available";
                }
                dgvClass.Rows[index].Cells["Description"].Value = cls.desciption;
            }
        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("xxx");
            if (e.RowIndex >= 0 && dgvClass.Columns["Id"].Index >= 0)
            {
                int classId = Convert.ToInt32(dgvClass.Rows[e.RowIndex].Cells["Id"].Value);
                IEnumerable<Customer> customers = service.GetCustomersInClass(classId);
                BindGridCustomer(customers);
            }
        }
        private void BindGridCustomer(IEnumerable<Customer> customers)
        {
            dgvCustomer.Rows.Clear();
            foreach (var customer in customers)
            {
                int index = dgvCustomer.Rows.Add();
                dgvCustomer.Rows[index].Cells["CustomerId"].Value = customer.CustomerID;
                dgvCustomer.Rows[index].Cells["CustomerName"].Value = customer.name;
                dgvCustomer.Rows[index].Cells["ContactInfo"].Value = customer.contact_info;
                dgvCustomer.Rows[index].Cells["Age"].Value = customer.age;
                if(customer.sex == "F")
                {
                    dgvCustomer.Rows[index].Cells["Gender"].Value = "Female";
                }
                else
                {
                    dgvCustomer.Rows[index].Cells["Gender"].Value = "Male"; 
                }
            }
        }


    }
}
