using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GarageTicketing.Entity;
using GarageTicketing.Controller;

namespace GarageTicketing.Boundary
{
    public partial class EditClaimMenu : Form
    {
        private int accountID;
        private bool _programaticClose;
        public EditClaimMenu(int anAccountID)
        {
            InitializeComponent();
            accountID = anAccountID;
            this.FormClosing += EditClaimMenu_FormClosing;
        }

        private void EditClaimMenu_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_programaticClose == true)
            {
                // Do Nothing
                _programaticClose = false;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _programaticClose = true;
            this.Close();
            LogoutControl.logout(accountID);
        }

        private void createAuctButton_Click(object sender, EventArgs e)
        {
            
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
