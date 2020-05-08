using DataTransferObjects;
using LogicLayer;
using System;
using System.Windows;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-03-13
    ///     CHECKED BY: Ethan Holmes
    ///     Class for adding medicine
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public partial class frmAddMedicine : Window
    {
        MedicineManager _manager = new MedicineManager();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-13
        ///     CHECKED BY: Ethan Holmes
        ///     Main constructor for the class
        /// </summary>
        public frmAddMedicine()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-13
        ///     CHECKED BY: Ethan Holmes
        ///     Event handler for the submit button
        /// </summary>
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescription.Text == "")
            {
                MessageBox.Show("Please enter a description");
            }
            else if (txtDosage.Text == "")
            {
                MessageBox.Show("Please enter a dosage");
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a name");
            }
            else
            {
                Medicine medicine = new Medicine()
                {
                    MedicineDescription = txtDescription.Text,
                    MedicineDosage = txtDosage.Text,
                    MedicineName = txtName.Text
                };
                try
                {
                    _manager.CheckMedicineIn(medicine);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("There was an error checking in the medicine");
                }
            }
        }
    }
}
