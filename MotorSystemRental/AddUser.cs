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
    public partial class AddUser : Form
    {
        private readonly MotorRentalEntities _db;
        private ManageUsers _manageUser;
        public AddUser(ManageUsers manageUser)
        {
            InitializeComponent();
            _db = new MotorRentalEntities();
            _manageUser = manageUser;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var roles = _db.Roles.ToList();

            cmbRoles.DisplayMember = "Name";
            cmbRoles.ValueMember = "Id";
            cmbRoles.DataSource = roles;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new user();
                string username = txtUserName.Text;
                var role = (int)cmbRoles.SelectedValue;

                user.username = username;
                user.isActive = true;
                user.password = Tools.ResetHashedPassword();

                _db.users.Add(user);
                _db.SaveChanges();
                var userId = user.id;
                var userRole = new UserRole
                {
                    roleid = role,
                    userid = userId
                };
                _db.UserRoles.Add(userRole);
                _db.SaveChanges();
                MessageBox.Show("User Added SuccesFully");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
