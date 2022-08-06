using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorSystemRental
{
    public partial class Login : Form
    {
        private readonly MotorRentalEntities _db;
        public Login()
        {
            InitializeComponent();
            _db = new MotorRentalEntities();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim();
                string password = txtPassword.Text;
                string hashedPassword = Tools.HashedPassword(password);

                var user = _db.users.FirstOrDefault(q => q.username == userName && q.password == hashedPassword && q.isActive == true);
                if(user == null)
                {
                    MessageBox.Show("Please Provide a Valid Credentials");
                }
                else
                {
                    var mainWindow = new MainWindow(this, user);
                    mainWindow.Show();
                    Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something was wrong!. Please try again");
            }
            
            
        }
    }
}
