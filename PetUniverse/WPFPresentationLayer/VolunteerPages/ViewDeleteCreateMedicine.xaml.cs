using DataTransferObjects;
using LogicLayer;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-03-13
    ///     CHECKED BY: Ethan Holmes
    ///     Class for showing medicine on the screen
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public partial class ViewDeleteCreateMedicine : Page
    {
        private MedicineManager manager = new MedicineManager();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-13
        ///     CHECKED BY: Ethan Holmes
        ///     Main constructor for the class
        /// </summary>
        public ViewDeleteCreateMedicine()
        {
            InitializeComponent();

            try
            {
                dgMedicineList.ItemsSource = manager.ReturnAllMedicine();
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading data");
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-13
        ///     CHECKED BY: Ethan Holmes
        ///     Event handler for the new medicine button
        /// </summary>
        private void BtnNewMed_Click(object sender, RoutedEventArgs e)
        {
            frmAddMedicine window = new frmAddMedicine();
            window.ShowDialog();
            try
            {
                dgMedicineList.ItemsSource = manager.ReturnAllMedicine();
            }
            catch (Exception)
            {
                MessageBox.Show("Error refreshing the list");
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-13
        ///     CHECKED BY: Ethan Holmes
        ///     Event handler for the delete button
        /// </summary>
        private void BtnDeleteMed_Click(object sender, RoutedEventArgs e)
        {
            if (null == dgMedicineList.SelectedItem)
            {
                MessageBox.Show("Please Select an item");
            }
            else
            {
                try
                {
                    Medicine med = (Medicine)dgMedicineList.SelectedItem;
                    manager.CheckMedicineOut(med.MedicineID);
                    dgMedicineList.ItemsSource = manager.ReturnAllMedicine();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
