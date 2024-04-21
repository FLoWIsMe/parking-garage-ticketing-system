using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GarageTicketing.Controller;
using GarageTicketing.Entity;

namespace GarageTicketing.Boundary
{
    public partial class AdminMenu : Form
    {
        private bool _programmaticClose;
        private int accountID;
        public AdminMenu(int anAccountID)
        {
            InitializeComponent();

            this.FormClosing += AdminMenu_Closing;
            accountID = anAccountID;
        }

        public void formatAuctions(List<Auction> anAuctionList)
        {
            Label[] itemNameLabels = new Label[] { itemName1, itemName2, itemName3, itemName4, itemName5, itemName6 };
            Label[] itemValueLabels = new Label[] { itemVal1, itemVal2, itemVal3, itemVal4, itemVal5, itemVal6 };

            for (int i = 0; i < anAuctionList.Count; i++)
            {
                itemNameLabels[i].Text = anAuctionList[i].name;
                itemValueLabels[i].Text = anAuctionList[i].hightestBid.ToString();
            }
        }
        private void AdminMenu_Closing(object sender, FormClosingEventArgs e)
        {
            // Needed for clean exit
            if (_programmaticClose == true)
            {
                // Reset the programmatic close and do nothing
                _programmaticClose = false;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                // User hit the red X button
                DBConnector.RecordLogout(accountID);
                Application.Exit();
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _programmaticClose = true;
            this.Close();
            LogoutControl.logout(accountID);
        }

        private void listAuctButton_Click(object sender, EventArgs e)
        {
            _programmaticClose = true;
            this.Close(); 
            AuctionControl.auctionMenu(accountID); 
        }
    }
}
