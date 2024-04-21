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
    public partial class CustomerMenu : Form
    {
        private bool _programmaticClose;
        private int accountID;
        private static List<Auction> auctionList;
        public CustomerMenu(int anAccountID, List<Auction> anAuctionList)
        {
            InitializeComponent();
            this.FormClosing += CustomerMenu_Closing;
            accountID = anAccountID;
            auctionList = anAuctionList;
            formatAuctions();

        }
        private void formatAuctions()
        {
            Label[] itemNameLabels = new Label[] { itemName1, itemName2, itemName3, itemName4, itemName5, itemName6 };
            Label[] itemValueLabels = new Label[] { itemVal1, itemVal2, itemVal3, itemVal4, itemVal5, itemVal6 };

            for (int i = 0; i < auctionList.Count; i++)
            {
                itemNameLabels[i].Text = auctionList[i].name;
                itemValueLabels[i].Text = auctionList[i].hightestBid.ToString();
            }
        }

        private void CustomerMenu_Closing(object? sender, FormClosingEventArgs e)
        {
            if (_programmaticClose == true)
            {
                // Do Nothing
                _programmaticClose = false;
            }
            else if (e.CloseReason == CloseReason.CustomerClosing)
            {
                DBConnector.RecordLogout(accountID);
                Application.Exit();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _programmaticClose = true;
            this.Close();
            LogoutControl.logout(accountID);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bidButton1_Click(object sender, EventArgs e)
        {
            BidController.select(auctionList[0].auctionId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton2_Click(object sender, EventArgs e)
        {
            BidController.select(auctionList[1].auctionId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton3_Click(object sender, EventArgs e)
        {
            BidController.select(auctionList[2].auctionId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton4_Click(object sender, EventArgs e)
        {
            BidController.select(auctionList[3].auctionId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton5_Click(object sender, EventArgs e)
        {
            BidController.select(auctionList[4].auctionId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton6_Click(object sender, EventArgs e)
        {
            BidController.select(auctionList[5].auctionId, accountID);
            _programmaticClose = true;
            this.Close();
        }
    }
}
