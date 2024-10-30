using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Control
{
    public partial class UCtrlMembership : UserControl
    {
        public UCtrlMembership()
        {
            InitializeComponent();
        }
        FormMembership_Edit membership = new FormMembership_Edit();

        private void membershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            membership.Show();
        }
    }
}
