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
    public partial class UCtrlSupplement : UserControl
    {
        SupplementService supplementService = new SupplementService();
        BrandService brandService = new BrandService();
        public UCtrlSupplement()
        {
            InitializeComponent();
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            Load();
        }
        private void Load()
        {
            IEnumerable<Supplement> supplements = supplementService.GetAll();
            BindGrid(supplements);
            IEnumerable<Brand> brands = brandService.GetAll();
            FillCbb(brands);
        }
        private void FillCbb(IEnumerable<Brand> brands)
        {
            this.cbbBrand.DataSource = brands;
            this.cbbBrand.DisplayMember = "name";
            this.cbbBrand.ValueMember = "BrandID";
            cbbBrand.SelectedIndex = -1;
        }
        private void BindGrid(IEnumerable<Supplement> supplements)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in supplements)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.SupplementID;
                dataGridView1.Rows[index].Cells[1].Value = item.name;
                dataGridView1.Rows[index].Cells[2].Value = item.Brand.name;
                dataGridView1.Rows[index].Cells[3].Value = item.price;
                dataGridView1.Rows[index].Cells[4].Value = item.stock_quantity;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[0].Index >= 0)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbbBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtQuantity.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btnAddUp_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
