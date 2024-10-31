using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO.Entities;
using BUS.Services;
using BUS.services;
using BUS;

namespace GUI.Control
{
    public partial class UCtrlPurchase : UserControl
    {
        private readonly PurchaseInvoiceService purchaseInvoiceService = new PurchaseInvoiceService();
        private readonly SupplementService supplementService = new SupplementService();
        private readonly CustomerService customerService = new CustomerService();
        private readonly DataTable invoiceDetails = new DataTable();
        private decimal totalAmount = 0;
        private DataGridViewRow selectedRow;

        public UCtrlPurchase()
        {
            InitializeComponent();
            InitializeInvoiceDetailsTable();
            CustomizeDataGridViews();
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

        private void CustomizeDataGridViews()
        {

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;


            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.DefaultCellStyle.BackColor = Color.White;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
        }

        private void UCtrlPurchase_Load(object sender, EventArgs e)
        {
            FillComboBox();
            LoadAllCustomers();
        }

        private void FillComboBox()
        {
            var supplements = supplementService.GetAll();
            cbbSupp.DataSource = supplements;
            cbbSupp.DisplayMember = "Name";
            cbbSupp.ValueMember = "SupplementID";
        }

        private void LoadAllCustomers()
        {
            var customers = customerService.GetAll();
            dataGridView2.DataSource = customers;
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
                        MessageBox.Show("Quantity need to higher 0", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Select a procduct to remove","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim();

            var customers = customerService.GetAll()
                .Where(c => c.name.ToLower().Contains(searchName.ToLower()))
                .ToList();

            dataGridView2.DataSource = customers;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dataGridView1.Rows[e.RowIndex];
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedCustomerRow = dataGridView2.Rows[e.RowIndex];
                txtNameCus.Text = selectedCustomerRow.Cells["name"].Value.ToString();
                txtIdCus.Text = selectedCustomerRow.Cells["CustomerId"].Value.ToString();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = txtIdCus.Text;
                string customerName = txtNameCus.Text;

                if (string.IsNullOrWhiteSpace(customerId) || string.IsNullOrWhiteSpace(customerName))
                {
                    MessageBox.Show("Select customer before.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (invoiceDetails.Rows.Count == 0)
                {
                    MessageBox.Show("No product in purchase", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mở form hóa đơn và truyền dữ liệu vào
                FormInvoice formInvoice = new FormInvoice(invoiceDetails, customerId, customerName, totalAmount);
                formInvoice.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
