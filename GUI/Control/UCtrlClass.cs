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
        }
        private void BindGrid(List<Class> classes)
        {
            dgvClass.Rows.Clear();
            foreach (var cls in classes)
            {
                int index = dgvClass.Rows.Add();
                dgvClass.Rows[index].Cells["ClassId"].Value = cls.ClassID;
                dgvClass.Rows[index].Cells["ClassType"].Value = cls.class_type;
                int CusInClass = Convert.ToInt16(service.GetCustomersInClass(cls.ClassID));
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
                dgvClass.Rows[index].Cells["Discription"].Value = cls.desciption;
            }
        }
    }
}
