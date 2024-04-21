using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GarageTicketing.Controller;
using GarageTicketing.Entity;

namespace GarageTicketing.Boundary
{
    public partial class AdminMenu : Form
    {
        private bool _programmaticClose;
        private readonly int Id;

        public AdminMenu(int Id)
        {
            InitializeComponent();

            FormClosing += AdminMenu_Closing;
            Id = id;
        }

        public void DisplayParkingSpots(List<ParkingSpot> parkingSpots)
        {
            var spotLabels = new Label[] { spot1Label, spot2Label, spot3Label, spot4Label, spot5Label, spot6Label };

            for (int i = 0; i < Math.Min(parkingSpots.Count, spotLabels.Length); i++)
            {
                spotLabels[i].Text = parkingSpots[i].SpotName;
            }
        }

        private void AdminMenu_Closing(object sender, FormClosingEventArgs e)
        {
            if (_programmaticClose)
            {
                _programmaticClose = false; // Reset the programmatic close and do nothing
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                DBConnector.RecordLogout(_accountID);
                Application.Exit();
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            _programmaticClose = true;
            Close();
            LogoutControl.Logout(_accountID);
        }

        private void EditSpotsButton_Click(object sender, EventArgs e)
        {
            _programmaticClose = true;
            Close(); 
            SpotEditingControl.EditSpots(_accountID); 
        }
    }
}
