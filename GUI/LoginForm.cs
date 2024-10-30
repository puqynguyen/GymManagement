using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.services;

namespace GUI
{

    public partial class LoginForm : Form
    {
        private readonly AccountService accountService;
        public LoginForm()
        {
            InitializeComponent();
            accountService = new AccountService();
            lblError.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            String username = txbUserName.Text;
            String password = txbPass.Text;

            //try
            //{
            //    bool isVali = accountService.Login(username, password);
            //    if (isVali)
            //    {
            //        lblError.Visible = false;
            //        this.Hide();
            //        HomebaseForm f = new HomebaseForm();
            //        f.ShowDialog();
            //    }
            //    else
            //    {
            //        lblError.Visible = true;
            //    }


            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            HomebaseForm f = new HomebaseForm();
            f.ShowDialog();

        }

        private void CBShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CBShowPass.Checked == true)
            {
                txbPass.UseSystemPasswordChar = false;
            }
            else
                txbPass.UseSystemPasswordChar = true;
        
        }
    }
}
