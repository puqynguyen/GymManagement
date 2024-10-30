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
using DTO.Entities;
namespace GUI
{
    public partial class FormBrand : Form
    {
        BrandService brandService = new BrandService();
        public FormBrand()
        {
            InitializeComponent();
            IEnumerable<Brand> brands = brandService.GetAll();
            BindGrid(brands);
        }
        public void BindGrid(IEnumerable<Brand> brands)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in brands)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.BrandID;
                dataGridView1.Rows[index].Cells[1].Value = item.name;
                dataGridView1.Rows[index].Cells[2].Value = item.contact_info;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[0].Index >= 0)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtContact.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnAddUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                {
                    throw new Exception("Please enter all the information");
                }
                if (txtId.Text == "")
                {
                    Brand brand = new Brand() { name = txtName.Text, contact_info = txtContact.Text };
                    brandService.Add(brand);
                }
                else
                {
                    int brandId = Convert.ToInt32(txtId.Text);
                    Brand brand = brandService.GetById(brandId);
                    if (brand != null)
                    {
                        brand.name = txtName.Text;
                        brand.contact_info = txtContact.Text;
                    }
                    else
                    {
                        throw new Exception("Brand Id not found!");
                    }
                }
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
                if(!ValidateInput())
                {
                    throw new Exception("Please enter all the information");
                }
                int brandId = Convert.ToInt32(txtId.Text);
                Brand brand = brandService.GetById(brandId);
                if (brand != null)
                {
                    brandService.Delete(brandId);
                }
                else
                {
                    throw new Exception("Brand Id not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool ValidateInput()
        {
            if (txtId.Text != "" && txtContact.Text != "" && txtName.Text != "")
                return true;
            return false;
        }
    }
}