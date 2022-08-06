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
    public partial class ManageUsers : Form
    {
        private readonly MotorRentalEntities _db;
        public ManageUsers()
        {
            InitializeComponent();
            _db = new MotorRentalEntities();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {

            populate();
        }

        public void populate()
        {
            var user = _db.users.Select(q => new
            {
                Id = q.id,
                Username = q.username,
                Role = q.UserRoles.FirstOrDefault().Role.shortName,
                IsActive = q.isActive
            }).ToList();

            gvUserListing.DataSource = user;
            gvUserListing.Columns["Id"].Visible = false;
            gvUserListing.Columns["IsActive"].HeaderText = "Active";
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!Tools.formIsOpen("AddUser"))
            {
                var addUser = new AddUser(this);
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvUserListing.SelectedRows[0].Cells["id"].Value;
                var user = _db.users.FirstOrDefault(q => q.id == id);

                user.password = Tools.ResetHashedPassword();
                _db.SaveChanges();
                MessageBox.Show($"{user.username}'s Password has been reset!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnActivateDeActivate_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvUserListing.SelectedRows[0].Cells["id"].Value;
                var user = _db.users.FirstOrDefault(q => q.id == id);

                user.isActive = user.isActive == true ? false : true;

                _db.SaveChanges();
                MessageBox.Show($"{user.username}'Active status has changed!");
                populate();
                gvUserListing.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRfresh_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
