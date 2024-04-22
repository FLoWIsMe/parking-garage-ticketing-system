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
            conditionDrop.Text = "New";
            startingPrice.Maximum = 1000000;
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
            string text = conditionDrop.Text;
            bool condition;
            if (text == "New")
            {
                condition = true;
            }
            else if (text == "Used")
            {
                condition = false;
            }
            else
            {
                condition = false;
            }


            Spot newSpot =
                new Spot(
                    itemNameTxt.Text,
                    descripTxt.Text,
                    condition,
                    1,
                    (float)startingPrice.Value,
                    accountID
                );
            bool isValid = SpotControl.submit(newSpot);
            if (isValid)
            {
                _programaticClose = true;
                this.Close();
            }
            else
            {
                // Label here for error 
            }
        }
    }
}
