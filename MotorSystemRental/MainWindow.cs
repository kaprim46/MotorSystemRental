using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorSystemRental
{
    public partial class MainWindow : Form
    {
        private Login _login;
        public user _user;
        public string _roleShortName;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(Login login, user user)
        {
            InitializeComponent();
            _login = login;
            _user = user;
            _roleShortName = user.UserRoles.FirstOrDefault().Role.shortName;
        }


        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "AddEdditRentalRecord";

            if (!Tools.formIsOpen(name))
            {
                var addEditRentalRecord = new AddEditRentalRecord();
                addEditRentalRecord.MdiParent = this;
                addEditRentalRecord.Show();
            }
        }

        private void manageMotorListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Tools.formIsOpen("ManageMotorListing"))
            {
                var manageMotorListing = new ManageMotorListing();
                manageMotorListing.MdiParent = this;
                manageMotorListing.Show();
            }
        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Tools.formIsOpen("ManageRentalRecord"))
            {
                var manageRentalRecord = new ManageRentalRecord();
                manageRentalRecord.MdiParent = this;
                manageRentalRecord.Show();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Tools.formIsOpen("ManageUsers"))
            {
                var manageUser = new ManageUsers();
                manageUser.MdiParent = this;
                manageUser.Show();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (_user.password == Tools.ResetHashedPassword())
            {
                PasswordReset passwordReset = new PasswordReset(_user);
                passwordReset.ShowDialog();
            }
            var userName = _user.username;
            tsLoginText.Text = $"Logged In As:{userName}";
            if(_roleShortName != "admin")
            {
                manageUsersToolStripMenuItem.Visible = false;
            }
            
        }
    }
}
