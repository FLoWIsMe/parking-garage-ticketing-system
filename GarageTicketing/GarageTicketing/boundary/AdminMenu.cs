using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GarageTicketing.Entity;
using GarageTicketing.Controller;

namespace GarageTicketing.Boundary
{
    public partial class AdminMenu : Form
    {
        private bool _programmaticClose;
        private int accountID;
        private List<Spot> anSpots;

        public AdminMenu(List<Spot> someSpots, int anAccountID)
        {
            InitializeComponent();
            this.anSpots = someSpots;
            this.accountID = anAccountID;
            this.FormClosing += ClaimSpotMenu_FormClosing;

            // Hook up the click event for each button
            foreach(var spot in anSpots)
            {
                var button = new Button();
                button.Text = spot.ToString();
                button.Click += SpotButton_Click;
                spotPanel.Controls.Add(button);
            }
        }

        private void ClaimSpotMenu_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_programmaticClose == true)
            {
                _programmaticClose = false;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                UserLogService.RecordLogout(accountID);
                Application.Exit();
            }
        }

        private void SpotButton_Click(object sender, EventArgs e)
        {   
            var button = (Button)sender;
            var index = this.anSpots.FindIndex(s => s.Equals(button.Text));
            SpotControl.submit(accountID, anSpots[index].Time, anSpots[index].Index);
            _programmaticClose = true;
            this.Close(); 
        }
    }
}
