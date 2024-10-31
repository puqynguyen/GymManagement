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
    public partial class FormHistory : Form
    {
        private readonly int _customerId;
        private readonly CustomerService _membershipService;
        public FormHistory(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            _membershipService = new CustomerService();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            LoadMembershipHistory();
        }
        private void LoadMembershipHistory()
        {
            var memberships = _membershipService.GetActiveMembershipByCustomerId(_customerId);
            dvgHistory.DataSource = memberships;
        }
    }
}
