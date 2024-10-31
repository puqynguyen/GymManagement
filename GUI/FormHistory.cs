using BUS.services;
using BUS.Services;
using DTO.Entities;
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
    public partial class FormHistory : Form
    {
        private int _customerId;
        private CustomerMembershipService customerMembershipService = new CustomerMembershipService();
        public FormHistory(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            LoadMembershipHistory();
        }
        private void LoadMembershipHistory()
        {
            var customerMembershipHistory = customerMembershipService.GetAll()
                .Where(p => p.CustomerID == _customerId)
                .Select(p => new
                {
                    MembershipName = p.Membership.name,
                    StartDate = p.start_date,
                    EndDate = p.end_date,
                    Price = p.price,
                    Status = p.end_date >= DateTime.Now ? "Active" : "Expired"
                }).ToList();

            dvgHistory.DataSource = customerMembershipHistory;
        }

    }
}
