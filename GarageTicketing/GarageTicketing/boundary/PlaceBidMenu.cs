using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoodsAuctionSystem.Entity;
using GoodsAuctionSystem.Controller;

namespace GoodsAuctionSystem.Boundary
{
    public partial class PlaceBidMenu : Form
    {
        private bool _programmaticClose;
        private int accountID;
        private Auction anAuction;
        public PlaceBidMenu(Auction someAuction, int anAccountID)
        {
            InitializeComponent();
            numericUpDown1.Maximum = 1000000;
            this.anAuction = someAuction;
            this.FormClosing += PlaceBidMenu_FormClosing;

            this.descripLabel.Text = anAuction.description;

            if (anAuction.condition == true)
            {
                this.condNewUsedLabel.Text = "Used";
            }
            else
            {
                this.condNewUsedLabel.Text = "New";
            }

            this.highBidValLabel.Text = anAuction.hightestBid.ToString();
            this.itemNameLabel.Text = anAuction.name;
            this.numericUpDown1.Minimum = (decimal)anAuction.hightestBid + 1;
            this.accountID = anAccountID;
            this.numericUpDown1.Maximum = 1000000;

        }

        private void PlaceBidMenu_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_programmaticClose == true)
            {
                _programmaticClose = false;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                DBConnector.RecordLogout(accountID);
                Application.Exit();
            }
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void placeBidButton_Click(object sender, EventArgs e)
        {
            float newHighestBid = (float)numericUpDown1.Value;
            BidController.submit(accountID, anAuction.auctionId, newHighestBid);
            _programmaticClose = true;
            this.Close(); 
        }
    }
}
