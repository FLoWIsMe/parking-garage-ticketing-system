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
        private static List<Spot> SpotList;
        public CustomerMenu(int anAccountID, List<Spot> anSpotList)
        {
            InitializeComponent();
            this.FormClosing += CustomerMenu_Closing;
            accountID = anAccountID;
            SpotList = anSpotList;
            formatSpots();

        }
        private void formatSpots()
        {
            Label[] itemNameLabels = new Label[] { itemName1, itemName2, itemName3, itemName4, itemName5, itemName6 };
            Label[] itemValueLabels = new Label[] { itemVal1, itemVal2, itemVal3, itemVal4, itemVal5, itemVal6 };

            for (int i = 0; i < SpotList.Count; i++)
            {
                itemNameLabels[i].Text = SpotList[i].name;
                itemValueLabels[i].Text = SpotList[i].hightestBid.ToString();
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
            BidController.select(SpotList[0].SpotId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton2_Click(object sender, EventArgs e)
        {
            BidController.select(SpotList[1].SpotId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton3_Click(object sender, EventArgs e)
        {
            BidController.select(SpotList[2].SpotId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton4_Click(object sender, EventArgs e)
        {
            BidController.select(SpotList[3].SpotId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton5_Click(object sender, EventArgs e)
        {
            BidController.select(SpotList[4].SpotId, accountID);
            _programmaticClose = true;
            this.Close();
        }

        private void bidButton6_Click(object sender, EventArgs e)
        {
            BidController.select(SpotList[5].SpotId, accountID);
            _programmaticClose = true;
            this.Close();
        }
    }
}
