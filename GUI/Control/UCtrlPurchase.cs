using BUS.services;
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
using BUS;

namespace GUI.Control
{
    public partial class UCtrlPurchase : UserControl
    {
        PurchaseInvoiceService purchaseInvoiceService = new PurchaseInvoiceService();
        SupplementService supplementService = new SupplementService();
        BrandService brandService = new BrandService();
        DataTable invoiceDetails = new DataTable();
        decimal totalAmount = 0;
        public UCtrlPurchase()
        {
            InitializeComponent();
            InitializeInvoiceDetailsTable();
        }

        private void InitializeInvoiceDetailsTable()
        {
            invoiceDetails.Columns.Add("SupplementID", typeof(int));
            invoiceDetails.Columns.Add("Name", typeof(string));
            invoiceDetails.Columns.Add("Quantity", typeof(int));
            invoiceDetails.Columns.Add("UnitPrice", typeof(decimal));
            invoiceDetails.Columns.Add("TotalPrice", typeof(decimal));
        }



        private void UCtrlPurchase_Load(object sender, EventArgs e)
        {
            Cbbfill();
        }

        private void Cbbfill()
        {
            var supplements = supplementService.GetAll();
            cbbSupp.DataSource = supplements;
            cbbSupp.DisplayMember = "Name";
            cbbSupp.ValueMember = "SupplementID";
        }


        private decimal GetPriceById(int supplementId)
        {
            var supplement = supplementService.GetById(supplementId);
            if (supplement != null)
            {
                return supplement.price.Value;
            }
            throw new Exception("Supplement not found");
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TotalPrice"].Value != null)
                {
                    totalAmount += Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                }
            }

            txtTotal.Text = totalAmount.ToString("N0") + " ₫";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            int supplementId = (int)cbbSupp.SelectedValue;
            string supplementName = cbbSupp.Text;
            int quantity = (int)numericUpDown1.Value;
            decimal unitPrice = GetPriceById(supplementId);

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalPrice = quantity * unitPrice;

            foreach (DataRow row in invoiceDetails.Rows)
            {
                if ((int)row["SupplementID"] == supplementId)
                {
                    row["Quantity"] = (int)row["Quantity"] + quantity;
                    row["TotalPrice"] = (int)row["Quantity"] * unitPrice;
                    UpdateTotalAmount();
                    return;
                }
            }
            DataRow newRow = invoiceDetails.NewRow();
            newRow["SupplementID"] = supplementId;
            newRow["Name"] = supplementName;
            newRow["Quantity"] = quantity;
            newRow["UnitPrice"] = unitPrice;
            newRow["TotalPrice"] = totalPrice;
            invoiceDetails.Rows.Add(newRow);

            dataGridView1.DataSource = invoiceDetails;
            UpdateTotalAmount();
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        int supplementId = (int)row.Cells["SupplementID"].Value;
                        DataRow[] rowsToDelete = invoiceDetails.Select("SupplementID = " + supplementId);

                        foreach (DataRow dataRow in rowsToDelete)
                        {
                            invoiceDetails.Rows.Remove(dataRow);
                        }


                        dataGridView1.Rows.Remove(row);
                    }
                }
                UpdateTotalAmount();
            }
            else
            {
                MessageBox.Show("Chosse product to remove", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId = 1; 
                DateTime dateCreated = DateTime.Now;

                PurchaseInvoice invoice = new PurchaseInvoice
                {
                    CustomerID = customerId,
                    date = dateCreated,
                    totalAmount = totalAmount
                };

                purchaseInvoiceService.Add(invoice);

                foreach (DataRow row in invoiceDetails.Rows)
                {
                    PurchaseDetail detail = new PurchaseDetail
                    {
                        InvoiceID = invoice.InvoiceID,
                        ItemID = (int)row["SupplementID"],
                        quantity = (int)row["Quantity"],
                        price = (decimal)row["UnitPrice"]
                    };
                    purchaseInvoiceService.AddPurchaseDetailsToInvoice(invoice.InvoiceID, new List<PurchaseDetail> { detail });
                    FormBill formBill = new FormBill(invoiceDetails, totalAmount);
                    formBill.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

    }
}
