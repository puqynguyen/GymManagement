using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BUS;
using BUS.services;
using BUS.Services;
using DTO.Entities;
namespace GUI.Control
{
    public partial class UCtrlChart : UserControl
    {
        MembershipService membershipService = new MembershipService();
        CustomerService customerService = new CustomerService();
        PurchaseInvoiceService purchaseInvoiceService = new PurchaseInvoiceService();
        CustomerMembershipService customerMembershipService = new CustomerMembershipService();
        public UCtrlChart()
        {
            InitializeComponent();
            dgvM.DefaultCellStyle.ForeColor = Color.Black;
            dgvM.DefaultCellStyle.BackColor = Color.White;
            dgvM.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvM.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;

            dgvS.DefaultCellStyle.ForeColor = Color.Black;
            dgvS.DefaultCellStyle.BackColor = Color.White;
            dgvS.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvS.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;

        }
        private void BindGrid(IEnumerable<PurchaseInvoice> invoices, IEnumerable<CustomerMembership> customerMemberships)
        {
            dgvS.Rows.Clear();
            dgvM.Rows.Clear();
            int sumS = 0;
            int sumM = 0;

            // Loop through invoices and add rows to dgvS
            foreach (var item in invoices)
            {
                int index = dgvS.Rows.Add(); // Add row to dgvS, not dgvM
                if (item.CustomerID.HasValue)
                {
                    int idCus = item.CustomerID.Value;
                    Customer customer = customerService.GetById(idCus);
                    if (customer != null)
                    {
                        dgvS.Rows[index].Cells[0].Value = customer.name;
                        dgvS.Rows[index].Cells[1].Value = customer.contact_info;
                    }
                    else
                    {
                        dgvS.Rows[index].Cells[0].Value = "Unknown Customer";
                        dgvS.Rows[index].Cells[1].Value = "N/A";
                    }
                }
                else
                {
                    dgvS.Rows[index].Cells[0].Value = "Unknown Customer";
                    dgvS.Rows[index].Cells[1].Value = "N/A";
                }

                dgvS.Rows[index].Cells[2].Value = item.date;
                dgvS.Rows[index].Cells[3].Value = item.totalAmount;
                sumS += (int)(item.totalAmount ?? 0);
            }

            // Loop through customerMemberships and add rows to dgvM
            foreach (var item in customerMemberships)
            {
                int index = dgvM.Rows.Add(); // Add row to dgvM, not dgvS
                int idCus = Convert.ToInt32(item.CustomerID);
                Customer customer = customerService.GetById(idCus);
                if (customer != null)
                {
                    dgvM.Rows[index].Cells[0].Value = customer.name;
                    dgvM.Rows[index].Cells[1].Value = customer.contact_info;
                }
                else
                {
                    dgvM.Rows[index].Cells[0].Value = "Unknown Customer";
                    dgvM.Rows[index].Cells[1].Value = "N/A";
                }

                dgvM.Rows[index].Cells[2].Value = item.start_date;
                dgvM.Rows[index].Cells[3].Value = item.end_date;
                dgvM.Rows[index].Cells[4].Value = item.cancel == 1 || item.end_date < DateTime.Now ? "Outdated" : "Active";
                dgvM.Rows[index].Cells[5].Value = item.price;
                sumM += (int)item.price;
            }

            txtS.Text = sumS.ToString();
            txtM.Text = sumM.ToString();
            txtTotal.Text = $"{sumM + sumS}";
        }


        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            IEnumerable<CustomerMembership> customerMemberships = null;
            IEnumerable<PurchaseInvoice> purchaseInvoices = null;

            if (rdb30.Checked)
            {
                DateTime targetDate = DateTime.Now.AddDays(-30);
                customerMemberships = customerMembershipService.GetAll().Where(cm => cm.start_date == targetDate);
                purchaseInvoices = purchaseInvoiceService.GetAll().Where(pi => pi.date == targetDate);
            }
            else if (rdbTM.Checked)
            {
                DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDate = DateTime.Now;

                customerMemberships = customerMembershipService.GetAll()
                    .Where(cm => cm.start_date >= startOfMonth && cm.start_date <= endDate);
                purchaseInvoices = purchaseInvoiceService.GetAll()
                    .Where(pi => pi.date >= startOfMonth && pi.date <= endDate);
            }
            else if (rdbAT.Checked)
            {
                customerMemberships = customerMembershipService.GetAll();
                purchaseInvoices = purchaseInvoiceService.GetAll();
            }
            BindGrid(purchaseInvoices, customerMemberships);
        }

        private void UCtrlChart_Load(object sender, EventArgs e)
        {
            rdb_CheckedChanged(sender, e);
        }
    }
}
