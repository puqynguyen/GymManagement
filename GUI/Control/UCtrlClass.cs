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
        public UCtrlClass()
        {
            InitializeComponent();
            IEnumerable<Class> classes = classService.GetAll();
            BindGridClass(classes);
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

    }
}
