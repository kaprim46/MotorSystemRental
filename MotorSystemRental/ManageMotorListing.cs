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
    public partial class ManageMotorListing : Form
    {
        private readonly MotorRentalEntities _db;
        public ManageMotorListing()
        {
            InitializeComponent();
            _db = new MotorRentalEntities();
        }

        private void ManageMotorListing_Load(object sender, EventArgs e)
        {
            try
            {
                populateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populateGrid()
        {
            var manageMotorListing = _db.TypesOfMotors.Select(q => new
            {
                Name = q.make,
                Model = q.model,
                Vin = q.vin,
                Year = q.year,
                q.id
            }).ToList();
            gvMotorListing.DataSource = manageMotorListing;
            //gvMotorListing.Columns[1].HeaderText = "Date Rented";
            //gvMotorListing.Columns[2].HeaderText = "Date Returned";
            gvMotorListing.Columns[4].Visible = false;
            
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            var addMotor = new AddEditMotor();
            addMotor.ShowDialog();
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvMotorListing.SelectedRows[0].Cells["Id"].Value;
                var motor = _db.TypesOfMotors.FirstOrDefault(q => q.id == id);
                var motorToEdit = new AddEditMotor(motor);
                motorToEdit.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvMotorListing.SelectedRows[0].Cells["Id"].Value;
                var motor = _db.TypesOfMotors.FirstOrDefault(q => q.id == id);
                DialogResult dg = MessageBox.Show("Do you Want Really Delete This Motor", "Delete Motor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    _db.TypesOfMotors.Remove(motor);
                    _db.SaveChanges();
                    MessageBox.Show("Motor Deleted Succesfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void btnRfresh_Click(object sender, EventArgs e)
        {
            populateGrid();
            gvMotorListing.Refresh();
        }
    }
}
