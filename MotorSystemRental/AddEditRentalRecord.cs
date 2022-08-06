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
    public partial class AddEditRentalRecord : Form
    {
        private readonly MotorRentalEntities _db;
        private bool isEditMode;
        public AddEditRentalRecord()
        {
            InitializeComponent();
            _db = new MotorRentalEntities();
            isEditMode = false;
        }
        public AddEditRentalRecord(MotorRentalRecord motorToEdit)
        {
            InitializeComponent();
            
            lblTitle.Text = "Edit Rental Record";
            this.Text = "Edit Rental Record";
            if(motorToEdit == null)
            {
                MessageBox.Show("Somthing was Wrong!");
            }
            else
            {
                populateFields(motorToEdit);
                _db = new MotorRentalEntities();
                isEditMode = true;

            }
            

        }
        private void populateFields(MotorRentalRecord motorToEdit)
        {
            TxtName.Text = motorToEdit.name;
            txtCost.Text = motorToEdit.cost.ToString();
            dpDateOut.Value = (DateTime)motorToEdit.dateOut;
            dpDateIn.Value = (DateTime)motorToEdit.dateIn;
            cmbModel.SelectedValue = motorToEdit.typeOfMotorId;
            lblId.Text = motorToEdit.id.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = TxtName.Text;
                double cost = double.Parse(txtCost.Text);
                var dateOut = dpDateOut.Value;
                var dateIn = dpDateIn.Value;
                var motor = cmbModel.Text;

                bool isValid = true;
                string ErrorMessage = "";

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(motor))
                {
                    isValid = false;
                    ErrorMessage += "Name Or Motor is Empty. Please Fill The Blank!\t\n";
                }

                if (dateOut > dateIn)
                {
                    isValid = false;
                    ErrorMessage += "Set a Correct day Please!\t\n";
                }
                if (isValid)
                {
                    var rentalRecord = new MotorRentalRecord();
                    if (isEditMode)
                    {
                        var id = int.Parse(lblId.Text);
                        rentalRecord = _db.MotorRentalRecords.FirstOrDefault(q => q.id == id);
                    }
                    
                    rentalRecord.name = name;
                    rentalRecord.cost = (decimal)cost;
                    rentalRecord.dateOut = (DateTime)dateOut;
                    rentalRecord.dateIn = (DateTime)dateIn;
                    rentalRecord.typeOfMotorId = (int)cmbModel.SelectedValue;

                    if (!isEditMode)
                        _db.MotorRentalRecords.Add(rentalRecord);

                    _db.SaveChanges();
                    MessageBox.Show($"Name : {name}\n\r" +
                                    $"Cost : {cost}\n\r" +
                                    $"Date Rented : {dateOut}\n\r" +
                                    $"Date Returned : {dateIn}\n\r" +
                                    $"Motor : {motor}\n\r" +
                                    $"\n\r" +
                                    $"Record Has Been Added Succesfully",
                                    "Add Record", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    Close();
                }
                else
                {
                    MessageBox.Show(ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var motor = _db.TypesOfMotors.Select(q => new
            {
                ID = q.id,
                Name = q.make + " " + q.model
            }).ToList();

            cmbModel.DisplayMember = "Name";
            cmbModel.ValueMember = "Id";
            cmbModel.DataSource = motor;
        }

        
    }
}
