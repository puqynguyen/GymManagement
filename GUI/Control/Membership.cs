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
    public partial class Membership : UserControl
    {
        public Membership()
        {
            InitializeComponent();
        }
        Membership_Edit membership = new Membership_Edit();

        private void membershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            membership.Show();

        }
    }
}
