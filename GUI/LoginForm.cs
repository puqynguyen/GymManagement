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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            String username = txbUserName.Text;
            String password = txbPass.Text;

            try
            {
                bool isVali = accountService.Login(username, password);
                if (isVali)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    HomebaseForm f = new HomebaseForm();
                    f.ShowDialog();
                }
                else
                {
                    errorProvider1.SetError(txbPass, "Invalid username or password.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            

        }
    }
}
