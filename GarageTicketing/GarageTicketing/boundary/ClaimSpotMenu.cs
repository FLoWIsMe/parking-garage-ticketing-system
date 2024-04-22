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
    public partial class ClaimSpotMenu : Form
    {
        private bool _programmaticClose;
        private int accountID;
        private Spot anSpot;
        public ClaimSpotMenu(Spot someSpot, int anAccountID)
        {
            InitializeComponent();
            numericUpDown1.Maximum = 1000000;
            this.anSpot = someSpot;
            this.FormClosing += ClaimSpotMenu_FormClosing;

            this.descripLabel.Text = anSpot.description;

            if (anSpot.condition == true)
            {
                this.condNewUsedLabel.Text = "Used";
            }
            else
            {
                this.condNewUsedLabel.Text = "New";
            }

            this.highBidValLabel.Text = anSpot.hightestBid.ToString();
            this.itemNameLabel.Text = anSpot.name;
            this.numericUpDown1.Minimum = (decimal)anSpot.hightestBid + 1;
            this.accountID = anAccountID;
            this.numericUpDown1.Maximum = 1000000;

        }

        private void ClaimSpotMenu_FormClosing(object? sender, FormClosingEventArgs e)
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

        private void ClaimSpotButton_Click(object sender, EventArgs e)
        {
            float newHighestBid = (float)numericUpDown1.Value;
            BidController.submit(accountID, anSpot.SpotId, newHighestBid);
            _programmaticClose = true;
            this.Close(); 
        }
    }
}
