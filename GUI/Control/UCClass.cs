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
    public partial class UCClass : UserControl
    {
        private readonly ClassService _classService = new ClassService();

        public UCClass()
        {
            InitializeComponent();
            IEnumerable<Class> classes = _classService.GetAll(); 
            BindGrid(classes);
        }
        private void BindGrid(IEnumerable<Class> classes)
        {
            dgvClass.Rows.Clear();
            foreach (Class cls in classes)
            {
                int index = dgvClass.Rows.Add();
                dgvClass.Rows[index].Cells["IdClass"].Value = cls.ClassID;
                dgvClass.Rows[index].Cells["ClassType"].Value = cls.class_type;
                //dgvClass.Rows[index].Cells["Enrollment"].Value = cls.;
                if (cls.closed == 0)
                {
                    dgvClass.Rows[index].Cells["Status"].Value = "Closed";
                }
                else if(cls.class_size == _classService.GetCustomersInClass(cls.ClassID).Count())
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

    }
}
