using BUS;
using BUS.Services;
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
    public partial class FormHistoryPur : Form
    {
        
            private readonly CustomerService customerService = new CustomerService();
            private readonly PurchaseInvoiceService purchaseInvoiceService = new PurchaseInvoiceService();

            public FormHistoryPur()
            {
                InitializeComponent();
                LoadCustomerHistory();
            }

            private void LoadCustomerHistory()
            {
                var customersWithPurchases = GetAllCustomersWithPurchases();

                dataGridView1.DataSource = customersWithPurchases;
            }

            private List<CustomerWithPurchases> GetAllCustomersWithPurchases()
            {
                var customerPurchases = from customer in customerService.GetAll()
                                        join invoice in purchaseInvoiceService.GetAll() 
                                        on customer.CustomerID equals invoice.CustomerID
                                        select new CustomerWithPurchases
                                        {
                                            CustomerID = customer.CustomerID,
                                            Name = customer.name,
                                            //PurchaseDate = invoice.date, 
                                            //TotalAmount = invoice.otalAmount 
                                        };

                return customerPurchases.ToList();
            }
        }

        public class CustomerWithPurchases
        {
            public int CustomerID { get; set; }
            public string Name { get; set; }
            public DateTime PurchaseDate { get; set; }
            public decimal TotalAmount { get; set; }
        }


    }

