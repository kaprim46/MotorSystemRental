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
    public partial class PasswordReset : Form
    {
        private readonly MotorRentalEntities _db;
        private user _user;
        public PasswordReset(user user)
        {
            InitializeComponent();
            _db = new MotorRentalEntities();
            _user = user;
        }

        private void btnSubmitPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string NewPass = txtNewPassword.Text;
                string ConfirmPass = txtConfirmPassword.Text;
                var user = _db.users.FirstOrDefault(q => q.id == _user.id);

                if (NewPass != ConfirmPass)
                {
                    MessageBox.Show("Password do not match. Please try again");
                }

                user.password = Tools.HashedPassword(NewPass);
                _db.SaveChanges();
                MessageBox.Show("Password has been changed");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured");
            }
            

        }
    }
}
