using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 3/2/2020
    /// Approver:
    /// 
    /// Interation logic for treatmentrecordcontrols.xaml.
    /// </summary>
    public partial class TreatmentRecordControls : Page
    {
        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Constructor for treatment record controls.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public TreatmentRecordControls()
        {
            InitializeComponent();
            _treatmentRecordManager = new TreatmentRecordManager();
        }

        private ITreatmentRecordManager _treatmentRecordManager;

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Method that calls manager method to get the data for the treatment records.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        private void refreshTreatmentRecordData()
        {
            dgTreatmentRecords.ItemsSource = _treatmentRecordManager.RetrieveTreatmentRecords();
            dgTreatmentRecords.Columns.Remove(dgTreatmentRecords.Columns[0]);
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Makes sure the data grid is loaded with data when the window is loaded.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        private void dgTreatmentRecords_Loaded(object sender, RoutedEventArgs e)
        {
            refreshTreatmentRecordData();
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Allows to fill out treatment record to be added to the data.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        private void btnAddTreatmentRecord_Click(object sender, RoutedEventArgs e)
        {
            canAddTreatmentRecord.Visibility = Visibility.Visible;
            btnAddTreatmentRecord.Visibility = Visibility.Hidden;
            btnEditTreatmentRecord.Visibility = Visibility.Hidden;
            dgTreatmentRecords.Visibility = Visibility.Hidden;
            btnCancelTreatmentRecordAdd.Visibility = Visibility.Visible;
            BtnSubmitTreatmentRecordAdd.Visibility = Visibility.Visible;
            btnSaveTreatmentRecord.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Makes sure the data is submited when clicked.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        private void BtnSubmitTreatmentRecordAdd_Click(object sender, RoutedEventArgs e)
        {
            string treatmentDate = cndTreatmentDate.SelectedDate.ToString();
            if (String.IsNullOrEmpty(txtFormName.Text))
            {
                MessageBox.Show("Please enter the form name");
                return;
            }
            if (String.IsNullOrEmpty(txtTreatmentDescription.Text))
            {
                MessageBox.Show("Please enter the treatment description");
                return;
            }
            if (String.IsNullOrEmpty(txtReason.Text))
            {
                MessageBox.Show("Please enter the reason for the animal's treatment");
                return;
            }
            if (String.IsNullOrEmpty(txtUrgency.Text))
            {
                MessageBox.Show("Please enter the urgency for the animal's treatment");
                return;
            }

            TreatmentRecord newTreatmentRecord = new TreatmentRecord();

            newTreatmentRecord.VetID = txtVetID.Text;
            newTreatmentRecord.FormName = txtFormName.Text;
            newTreatmentRecord.TreatmentDescription = txtTreatmentDescription.Text;
            newTreatmentRecord.Notes = txtNotes.Text;
            newTreatmentRecord.Reason = txtReason.Text;
            newTreatmentRecord.TreatmentDate = cndTreatmentDate.DisplayDate;

            try
            {
                if (_treatmentRecordManager.AddNewTreatmentRecord(newTreatmentRecord))
                {
                    WPFErrorHandler.SuccessMessage("Animal Successfully Added");

                    canViewTreatmentRecords.Visibility = Visibility.Visible;
                    canAddTreatmentRecord.Visibility = Visibility.Hidden;
                    dgTreatmentRecords.Visibility = Visibility.Visible;
                    refreshTreatmentRecordData();
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                canViewTreatmentRecords.Visibility = Visibility.Visible;
                canAddTreatmentRecord.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Makes sure the data is deleted when clicked.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        private void btnCancelTreatmentRecordAdd_Click(object sender, RoutedEventArgs e)
        {
            canViewTreatmentRecords.Visibility = Visibility.Visible;
            canAddTreatmentRecord.Visibility = Visibility.Hidden;
            btnAddTreatmentRecord.Visibility = Visibility.Visible;
            dgTreatmentRecords.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Makes sure the data is deleted when clicked.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        private void btnRemoveTreatmentRecord_Click(object sender, RoutedEventArgs e)
        {
            TreatmentRecordVM selectedTreatmentRecordVM = (TreatmentRecordVM)dgTreatmentRecords.SelectedItem;
            TreatmentRecord selectedTreatmentRecord = _treatmentRecordManager.GetTreatmentRecordByName(selectedTreatmentRecordVM.FormName.ToString());

            dgTreatmentRecords.ItemsSource = null;
            dgTreatmentRecords.ItemsSource = _treatmentRecordManager.RetrieveTreatmentRecords();
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Makes sure the data can be edited when clicked.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        private void btnEditTreatmentRecord_Click(object sender, RoutedEventArgs e)
        {
            TreatmentRecord selectedTreatmentRecordVM = (TreatmentRecord)dgTreatmentRecords.SelectedItem;
            TreatmentRecord selectedTreatmentRecord = _treatmentRecordManager.GetTreatmentRecordByName(selectedTreatmentRecordVM.FormName.ToString());

            canAddTreatmentRecord.Visibility = Visibility.Visible;
            txtVetID.Text = selectedTreatmentRecord.VetID.ToString();
            txtAnimalID.Text = selectedTreatmentRecord.AnimalID.ToString();
            txtFormName.Text = selectedTreatmentRecord.FormName.ToString();
            cndTreatmentDate.DisplayDate = selectedTreatmentRecord.TreatmentDate;
            txtTreatmentDescription.Text = selectedTreatmentRecord.TreatmentDescription.ToString();
            txtNotes.Text = selectedTreatmentRecord.Notes.ToString();
            txtReason.Text = selectedTreatmentRecord.Reason.ToString();
            txtUrgency.Text = selectedTreatmentRecord.Urgency.ToString();

            BtnSubmitTreatmentRecordAdd.Visibility = Visibility.Hidden;
            btnAddTreatmentRecord.Visibility = Visibility.Hidden;
            dgTreatmentRecords.Visibility = Visibility.Hidden;
            btnRemoveTreatmentRecord.Visibility = Visibility.Hidden;
            btnEditTreatmentRecord.Visibility = Visibility.Hidden;

        }

        private void btnSaveTreatmentRecord_Click(object sender, RoutedEventArgs e)
        {
            //int update = _treatmentRecordManager.EditTreatmentRecord(oldTreatmentRecord, newTreatmentRecord);

            canAddTreatmentRecord.Visibility = Visibility.Hidden;
            dgTreatmentRecords.Visibility = Visibility.Visible;
            canViewTreatmentRecords.Visibility = Visibility.Visible;
            btnAddTreatmentRecord.Visibility = Visibility.Visible;
            btnEditTreatmentRecord.Visibility = Visibility.Visible;
            btnRemoveTreatmentRecord.Visibility = Visibility.Visible;
        }
    }
}

//private void btnSave_Click(object sender, RoutedEventArgs e)
//{
//    string taskName = txtTaskName.Text.ToString();
//    string taskType = comboTaskType.Text.ToString();
//    string assignmentGroup = comboAssignmentGroup.Text.ToString();
//    DateTime dueDate = DateTime.Parse(txtVolunteerTaskDate.Text.ToString());
//    string taskDescription = txtVolunteerTaskDescription.Text.ToString();

//    int update = _volunteerTaskManager.UpdateVolunteerTask(taskName, taskType, assignmentGroup, dueDate, taskDescription);

//    //this.Close();

//    canCreateTask.Visibility = Visibility.Hidden;
//    dgVolTaskList.ItemsSource = null;
//    dgVolTaskList.ItemsSource = _volunteerTaskManager.GetAllVolunteerTasks();
//    canViewTasks.Visibility = Visibility.Visible;

//}
