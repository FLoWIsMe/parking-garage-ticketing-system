using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GarageTicketing.Controller;
using GarageTicketing.Entity;

namespace GarageTicketing.Boundary
{
    public partial class CustomerMenu : Form
    {
        private bool _programmaticClose;
        private int _accountId;
        private List<Spot> _spotList;

        private FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

        public CustomerMenu(int accountId, List<Spot> spotList)
        {
            InitializeComponent();
            _accountId = accountId;
            _spotList = spotList;

            CreateClaimButtons();
        }

        private void CreateClaimButtons()
        {
            flowLayoutPanel.Controls.Clear();

            foreach (var spot in _spotList)
            {
                var claimButton = CreateClaimButton(spot);
                flowLayoutPanel.Controls.Add(claimButton);
            }
        }

        private Button CreateClaimButton(Spot spot)
        {
            var claimButton = new Button
            {
                Text = $"Claim Spot {spot.Index}",
                Width = 200,
                Tag = spot
            };
            claimButton.Click += ClaimButton_Click;
            return claimButton;
        }

        private void ClaimButton_Click(object sender, EventArgs e)
        {
            var claimButton = (Button)sender;
            var spot = (Spot)claimButton.Tag;
            ClaimControl.Select(spot.SpotId, _accountId);
            _programmaticClose = true;
            Close();
        }

        private void CustomerMenu_Closing(object? sender, FormClosingEventArgs e)
        {
            if (_programmaticClose)
            {
                _programmaticClose = false;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                LogoutControl.Logout(_accountId);
                Application.Exit();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _programmaticClose = true;
            Close();
            LogoutControl.logout(_accountId);
        }
    }
}

