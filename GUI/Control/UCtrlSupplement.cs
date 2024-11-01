﻿using System;
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
            this.Load += UCtrlSupplement_Load; // Connect the LoadData event to the handler
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
        }

        private void UCtrlSupplement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            IEnumerable<Supplement> supplements = supplementService.GetAll();
            BindGrid(supplements);
            IEnumerable<Brand> brands = brandService.GetAll();
            FillCbb(brands);
            Clear();
        }
        private void Clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtName2.Text = "";
            txtPrice2.Text = "";
            txtQuantity2.Text = "";
        }
        private void FillCbb(IEnumerable<Brand> brands)
        {
            this.cbbBrand.DataSource = brands;
            this.cbbBrand.DisplayMember = "name";
            this.cbbBrand.ValueMember = "BrandID";
            cbbBrand.SelectedIndex = -1;
            this.cbbBrand2.DataSource = brands;
            this.cbbBrand2.DisplayMember = "name";
            this.cbbBrand2.ValueMember = "BrandID";
            cbbBrand2.SelectedIndex = -1;
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtId.Text);
                Supplement supplement = supplementService.GetById(Id);
                if (supplement == null)
                {
                    throw new Exception("Supplement Id not found!");
                }
                supplementService.DeleteSupplement(Id);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtId.Text);
                Supplement supplement = supplementService.GetById(Id);
                if (supplement == null)
                {
                    throw new Exception("Supplement Id not found!");
                }
                supplement.name = txtName.Text;
                supplement.BrandID = Convert.ToInt16(cbbBrand.SelectedValue);
                supplement.name = txtName.Text;
                supplement.price = Convert.ToDecimal(txtPrice.Text);
                supplement.stock_quantity = Convert.ToInt16(txtQuantity.Text);
                supplementService.Update(supplement);
                LoadData();
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
                decimal @price = Convert.ToDecimal(txtPrice2.Text);
                int brandId = (int)cbbBrand2.SelectedValue;
                int quantity = Convert.ToInt32(txtQuantity2.Text);
                Supplement supplement = new Supplement() { name = txtName2.Text, BrandID = brandId, price = @price, stock_quantity = quantity};
                supplementService.Add(supplement);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
