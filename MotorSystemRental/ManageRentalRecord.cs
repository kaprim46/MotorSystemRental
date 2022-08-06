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
    public partial class ManageRentalRecord : Form
    {
        private readonly MotorRentalEntities _db;
        public ManageRentalRecord()
        {
            InitializeComponent();
            _db = new MotorRentalEntities();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            if (!Tools.formIsOpen("AddEditRentalRecord"))
            {
                var addEditRentalRecord = new AddEditRentalRecord();
                addEditRentalRecord.MdiParent = this.MdiParent;
                addEditRentalRecord.Show();
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvManageRentalRecord.SelectedRows[0].Cells["Id"].Value;
                var record = _db.MotorRentalRecords.FirstOrDefault(q => q.id == id);
                if (!Tools.formIsOpen("AddEditRentalRecord"))
                {
                    var addEditRentalRecord = new AddEditRentalRecord(record);
                    addEditRentalRecord.MdiParent = this.MdiParent;
                    addEditRentalRecord.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void populaGrid()
        {
            var rentalRecord = _db.MotorRentalRecords.Select(q => new
            {
                Name = q.name,
                DateOut = q.dateOut,
                DateIn = q.dateIn,
                q.cost,
                Motor = q.TypesOfMotor.make + " " + q.TypesOfMotor.model,
                Id = q.id
            }).ToList();

            gvManageRentalRecord.DataSource = rentalRecord;
            gvManageRentalRecord.Columns["DateOut"].HeaderText = "Date Rented";
            gvManageRentalRecord.Columns["DateIn"].HeaderText = "Date Returned";
            gvManageRentalRecord.Columns["Id"].Visible = false;
        }

        private void ManageRentalRecord_Load(object sender, EventArgs e)
        {
            populaGrid();
            gvManageRentalRecord.Refresh();
            
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvManageRentalRecord.SelectedRows[0].Cells["Id"].Value;
                var record = _db.MotorRentalRecords.FirstOrDefault(q => q.id == id);
                DialogResult dg = MessageBox.Show("Do you Want Really Delete This Record", "Delete Record", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    _db.MotorRentalRecords.Remove(record);
                    _db.SaveChanges();
                    MessageBox.Show("Record Deleted Succesfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnRefreshRecord_Click(object sender, EventArgs e)
        {
            populaGrid();
            gvManageRentalRecord.Refresh();
        }
    }
}
