using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageTicketing.Boundary
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void loginButt_Click(object sender, EventArgs e)
        {

        }

       
    }
}
