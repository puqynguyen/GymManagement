using BUS.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DTO.Entities;
using BUS;

namespace GUI.Control
{
    public partial class UCtrlPurchase : UserControl
    {
        private readonly PurchaseInvoiceService purchaseInvoiceService = new PurchaseInvoiceService();
        private readonly SupplementService supplementService = new SupplementService();
        private readonly DataTable invoiceDetails = new DataTable();
        private decimal totalAmount = 0;
        private DataGridViewRow selectedRow;

        public UCtrlPurchase()
        {
            InitializeComponent();
            InitializeInvoiceDetailsTable();
            CustomizeDataGridView();
        }

        private void InitializeInvoiceDetailsTable()
        {
            invoiceDetails.Columns.Add("SupplementID", typeof(int));
            invoiceDetails.Columns.Add("Name", typeof(string));
            invoiceDetails.Columns.Add("Quantity", typeof(int));
            invoiceDetails.Columns.Add("UnitPrice", typeof(decimal));
            invoiceDetails.Columns.Add("TotalPrice", typeof(decimal));

            dataGridView1.DataSource = invoiceDetails;
        }

        private void CustomizeDataGridView()
        {
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
        }

        private void UCtrlPurchase_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void FillComboBox()
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
                return supplement.price.HasValue ? supplement.price.Value : 0;
            }
            throw new Exception("Supplement not found");
        }

        private void UpdateTotalAmount()
        {
            totalAmount = 0;

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
            try
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

                UpdateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRow != null)
                {
                    int quantityToRemove = (int)numericUpDown1.Value;
                    if (quantityToRemove <= 0)
                    {
                        MessageBox.Show("Số lượng cần xóa phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int supplementId = (int)selectedRow.Cells["SupplementID"].Value;
                    DataRow[] rowsToUpdate = invoiceDetails.Select("SupplementID = " + supplementId);

                    foreach (DataRow dataRow in rowsToUpdate)
                    {
                        int currentQuantity = (int)dataRow["Quantity"];

                        if (quantityToRemove >= currentQuantity)
                        {
                            invoiceDetails.Rows.Remove(dataRow);
                        }
                        else
                        {
                            dataRow["Quantity"] = currentQuantity - quantityToRemove;
                            dataRow["TotalPrice"] = (int)dataRow["Quantity"] * (decimal)dataRow["UnitPrice"];
                        }
                    }

                    UpdateTotalAmount();
                    selectedRow = null;
                }
                else
                {
                    MessageBox.Show("Hãy chọn một sản phẩm để xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }

                FormBill formBill = new FormBill(invoiceDetails, totalAmount);
                formBill.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow  = dataGridView1.Rows[e.RowIndex];
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
            }
        }
    }
}
