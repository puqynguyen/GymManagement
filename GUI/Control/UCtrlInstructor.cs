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
    public partial class UCtrlInstructor : UserControl
    {
        InstructorService instructorService = new InstructorService();
        public UCtrlInstructor()
        {
            InitializeComponent();
            dgvInstructor.DefaultCellStyle.ForeColor = Color.Black;
            dgvInstructor.DefaultCellStyle.BackColor = Color.White;
            dgvInstructor.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvInstructor.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
        }

        private void UCtrlInstructor_Load(object sender, EventArgs e)
        {
            dtpBirthdate.Value = DateTime.Now.AddYears(-18);
            IEnumerable<Instructor> instructors = instructorService.GetAll();
            BindGrid(instructors);
        }
        public void BindGrid(IEnumerable<Instructor> instructors)
        {
            dgvInstructor.Rows.Clear();
            foreach (var item in instructors)
            {
                int index = dgvInstructor.Rows.Add();
                dgvInstructor.Rows[index].Cells[0].Value = item.InstructorID;
                dgvInstructor.Rows[index].Cells[1].Value = item.name;
                dgvInstructor.Rows[index].Cells[2].Value = item.sex;
                dgvInstructor.Rows[index].Cells[3].Value = item.date_of_birth.HasValue
    ? item.date_of_birth.Value.ToString("dd/MM/yyyy") : "";
                dgvInstructor.Rows[index].Cells[4].Value = item.age;
                dgvInstructor.Rows[index].Cells[5].Value = item.certifications;

            }
        }

        private void dgvInstructor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvInstructor.Columns[0].Index >= 0)
            {
                txtId.Text = dgvInstructor.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvInstructor.Rows[e.RowIndex].Cells[1].Value.ToString();
                rdbMale.Checked = true;
                if(dgvInstructor.Rows[e.RowIndex].Cells[2].Value.ToString() == "F")
                {
                    rdbFemale.Checked = true;
                }
                if (dgvInstructor.Rows[e.RowIndex].Cells[3].Value != null && DateTime.TryParseExact(dgvInstructor.Rows[e.RowIndex].Cells[3].Value.ToString().Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                {
                    dtpBirth.Value = dateValue;
                }
                else
                {
                    MessageBox.Show("Invalid date format in the selected cell. Please ensure the date is in 'dd/MM/yyyy' format.");
                }
                txtCertification.Text = dgvInstructor.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);
            Instructor instructor = instructorService.GetById(Id);
            if (instructor != null)
            {
                instructor.name = txtName.Text;
                instructor.certifications = txtCertification.Text;
                string sex = "M";
                if(rdbFemale.Checked)
                {
                    sex = "F";
                }
                instructor.sex = sex;
                instructor.date_of_birth = dtpBirth.Value;
                instructorService.Update(instructor);
                UCtrlInstructor_Load(sender, e);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);
            Instructor instructor = instructorService.GetById(Id);
            if (instructor != null)
            {
                instructorService.Delete(Id);
                UCtrlInstructor_Load(sender, e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string gender = "M";
            if (rdbFemale2.Checked)
            {
                gender = "F";
            }
            Instructor instructor = new Instructor() { name = txtName2.Text, sex = gender, certifications = txtCertifications2.Text, date_of_birth = dtpBirthdate.Value};
            instructorService.Add(instructor);
            UCtrlInstructor_Load(sender, e);

        }
    }
}
