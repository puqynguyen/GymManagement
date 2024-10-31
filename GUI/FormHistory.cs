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
        private int customerId;
        public FormHistory(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
