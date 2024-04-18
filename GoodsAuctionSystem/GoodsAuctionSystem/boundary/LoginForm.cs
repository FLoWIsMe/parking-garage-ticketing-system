using GoodsAuctionSystem.Controller;
using GoodsAuctionSystem.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GoodsAuctionSystem.Boundary
{
    public partial class LoginForm : Form
    {
        bool _programmaticClose; 
        public LoginForm()
        {
            InitializeComponent();
            loginError.Visible = false;
            this.FormClosing += LoginForm_FormClosing;
            //loginError.Text = "";
        }

        private void LoginForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_programmaticClose == true)
            {
                // Reset the programmatic close and do nothing
                _programmaticClose = false;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                // User hit the red X button
                Application.Exit();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void passText_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginError_Click(object sender, EventArgs e)
        {

        }

        private void loginButt_Click(object sender, EventArgs e)
        {
            string username = userText.Text;
            string password = passText.Text;

            bool loggedIn = LoginControl.login(username, password);

            if (loggedIn)
            {
                _programmaticClose = true;
                this.Hide();
            }
            else
            {
                this.loginError.Visible = true;
            }
        }

        private void userText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
