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
    public partial class AddEditMotor : Form
    {
        private readonly MotorRentalEntities _db;
        bool isEditMode;
        public AddEditMotor()
        {
            InitializeComponent();
            _db = new MotorRentalEntities();
            this.Text = "Add New Motor";
            isEditMode = false;
            lblId.Visible = false;
        }
        public AddEditMotor(TypesOfMotor motorToEdit)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Motor";
            this.Text = "Edit Motor";
            if(motorToEdit == null)
            {
                MessageBox.Show("Something was Wrong");
            }
            else
            {
                _db = new MotorRentalEntities();
                populateFields(motorToEdit);
                lblId.Visible = false;
                isEditMode = true;
            }
        }
        private void populateFields(TypesOfMotor motor)
        {
            txtMotorName.Text = motor.make;
            txtModel.Text = motor.model;
            txtVin.Text = motor.vin;
            txtYear.Text = motor.year.ToString();
            lblId.Text = motor.id.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string motorName = txtMotorName.Text;
                string model = txtModel.Text;
                string vin = txtVin.Text;
                int year = Convert.ToInt32(txtYear.Text);
                bool isValid = true;
                string ErrorMessage = "";

                if (string.IsNullOrWhiteSpace(motorName) || string.IsNullOrWhiteSpace(model))
                {
                    ErrorMessage += "ERROR : Motor Name or Motor Model is Empty!\r\n";
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(vin) || string.IsNullOrWhiteSpace(txtYear.Text))
                {
                    ErrorMessage += "ERROR : Vin or Year is Empty!\r\n";
                    isValid = false;
                }
                if (isValid)
                {
                    var motor = new TypesOfMotor();
                    if (isEditMode)
                    {
                        var id = int.Parse(lblId.Text);
                        motor = _db.TypesOfMotors.FirstOrDefault(q => q.id == id);
                        motor.make = motorName;
                        motor.model = model;
                        motor.vin = vin;
                        motor.year = year;

                        MessageBox.Show($"Motor Name: {motorName}\r\n" +
                                    $"Model: {model}\r\n" +
                                    $"Vin: {vin}\r\n" +
                                    $"Year: {year}\r\n" +
                                    $"\n" +
                                    $"Motor Edited Succesfully");
                        _db.SaveChanges();
                        Close();
                    }


                    else if (!isEditMode) 
                    { 
                      _db.TypesOfMotors.Add(motor);
                      _db.SaveChanges();

                    MessageBox.Show($"Motor Name: {motorName}\r\n" +
                                    $"Model: {model}\r\n" +
                                    $"Vin: {vin}\r\n" +
                                    $"Year: {year}\r\n" +
                                    $"\n" +
                                    $"Motor Added Succesfully");
                    Close();
                    }
                }
                else
                {
                    MessageBox.Show(ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }
    }
}
