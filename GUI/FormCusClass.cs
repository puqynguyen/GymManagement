using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Entities;
using BUS.Services;
using BUS.services;
namespace GUI
{
    public partial class FormCusClass : Form
    {
        ClassService classService = new ClassService();
        CustomerService customerService = new CustomerService();
        int cusId;
        public FormCusClass(int cusId)
        {
            InitializeComponent();
            this.cusId = cusId;

            // Thêm các cột vào DataGridView nếu chưa có
            dgvListClass.Columns.Clear(); // Xóa các cột cũ (nếu có)
            dgvListClass.Columns.Add("ClassID", "Class ID");
            dgvListClass.Columns.Add("ClassType", "Class Type");
            dgvListClass.Columns.Add("Description", "Description");
            dgvListClass.Columns.Add("ClassSize", "Class Size");
            dgvListClass.Columns.Add("Status", "Status");
        }
        public void BindGrid(IEnumerable<Class> classes)
        {
            dgvListClass.Rows.Clear();
            foreach (var item in classes)
            {
                int index = dgvListClass.Rows.Add();
                dgvListClass.Rows[index].Cells[0].Value = item.ClassID;
                dgvListClass.Rows[index].Cells[1].Value = item.class_type;
                dgvListClass.Rows[index].Cells[2].Value = item.desciption;
                dgvListClass.Rows[index].Cells[3].Value = item.class_size;
                dgvListClass.Rows[index].Cells[4].Value = item.closed == 1 ? "Closed" : "Available";
            }
            lblId.Text = "...";
            lblName.Text = "...";
        }

        private void dgvListClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblId.Text = dgvListClass.Rows[e.RowIndex].Cells[0].Value?.ToString();
                lblName.Text = dgvListClass.Rows[e.RowIndex].Cells[1].Value?.ToString();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem lblId có giá trị không (đảm bảo rằng đã chọn một lớp)
            if (!string.IsNullOrEmpty(lblId.Text) && int.TryParse(lblId.Text, out int classId))
            {
                // Thêm khách hàng vào lớp
                try
                {
                    // Tạo một đối tượng dịch vụ để thêm khách hàng vào lớp
                    classService.RegisterCustomerToClass(cusId, classId);

                    // Thông báo thành công
                    MessageBox.Show("Customer added to class successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormCusClass_Load(sender, e);
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                    MessageBox.Show("Error adding customer to class: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a class before adding the customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormCusClass_Load(object sender, EventArgs e)
        {
            IEnumerable<Class> unregisteredClasses = customerService.GetClassesNotRegisteredByCustomer(cusId);
            BindGrid(unregisteredClasses);

        }
    }
}
