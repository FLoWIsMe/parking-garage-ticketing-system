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
            this.anSpot = someSpot;
            this.FormClosing += ClaimSpotMenu_FormClosing;

            this.userLabel.Text = anSpot.User;
            this.timeLabel.Text = anSpot.Time.ToString();
            this.indexLabel.Text = anSpot.Index;

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
            // Add functionality here if needed
        }

        private void ClaimSpotButton_Click(object sender, EventArgs e)
        {
            SpotControl.submit(accountID, anSpot.Time, anSpot.Index);
            _programmaticClose = true;
            this.Close(); 
        }
    }
}