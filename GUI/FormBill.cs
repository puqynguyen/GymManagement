using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormBill : Form
    {
        private DataTable invoiceDetails;
        private decimal totalAmount;
        public FormBill(DataTable invoiceDetails, decimal totalAmount)
        {
            InitializeComponent();
            this.invoiceDetails = invoiceDetails;
            this.totalAmount = totalAmount;
        }

        private void Bill_Load(object sender, EventArgs e)
        {

            ReportDataSource rds = new ReportDataSource("InvoiceDataSet", invoiceDetails);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Thiết lập tham số tổng tiền
            ReportParameter paramTotalAmount = new ReportParameter("TotalAmount", totalAmount.ToString("C"));
            reportViewer1.LocalReport.SetParameters(paramTotalAmount);

            reportViewer1.RefreshReport();
        }
    }
}
