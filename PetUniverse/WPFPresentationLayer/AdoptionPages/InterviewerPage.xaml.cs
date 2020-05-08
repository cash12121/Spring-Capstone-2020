using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace WPFPresentationLayer.AdoptionPages
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/04
    /// Approver : Mohamed Elamin
    /// This class represent the tracking methode for the Interviewer Xaml
    /// </summary>
    public partial class InterviewerPage : Page
    {
        private IAdoptionManager adoptionManager;
        private List<AdoptionApplication> adoptionApplications;
        List<AdoptionApplication> applicationsReviewed;

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// Default construct create an object for reviewer manager(Logic Layer)
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>     
        public InterviewerPage()
        {
            InitializeComponent();
            adoptionManager = new ReviewerManager();
            adoptionApplications = new List<AdoptionApplication>();
            applicationsReviewed = new List<AdoptionApplication>();
            btnInterviewerDecission.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// When load the page, data grid view must show all the adoption applications
        /// that Approved by Interviewer
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>     
        /// <param name="e"></param>
        /// <param name="sender"></param>

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            updateAdoptionList();

        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>         
        private void updateAdoptionList()
        {
            try
            {
                adoptionApplications = adoptionManager.retrieveCustomersFilledQuestionnair();
                applicationsReviewed.Clear();
                foreach (AdoptionApplication item in adoptionApplications)
                {
                    if (item.Status == "Interviewer")
                    {
                        applicationsReviewed.Add(item);
                    }

                }
                if (applicationsReviewed.Count == 0)
                {
                    lblInterviewerErrorMessage.Content = "There are no adoption applications need Interview";
                    DGInterviewerData.ItemsSource = null;
                    GridInterviewerDecission.Visibility = Visibility.Hidden;
                }
                else
                {
                    DGInterviewerData.ItemsSource = applicationsReviewed;
                    lblInterviewerErrorMessage.Content = "Please select one of above records";
                    GridInterviewerDecission.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {

                lblInterviewerErrorMessage.Content = "We do not have adoption applications";
                GridInterviewerDecission.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void DGInterviewerData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AdoptionApplication application = new AdoptionApplication();
                application = (AdoptionApplication)DGInterviewerData.SelectedItem;
                txtAdoptionApplicationID.Text = application.AdoptionApplicationID.ToString();
                lblInterviewerErrorMessage.Content = "";
                btnInterviewerDecission.Visibility = Visibility.Visible;
                GridInterviewerDecission.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                btnInterviewerDecission.Visibility = Visibility.Hidden;
                GridInterviewerDecission.Visibility = Visibility.Hidden;

                txtAdoptionApplicationID.Text = "Please select one of the adoption application list";
            }

        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnInterviewerDecission_Click(object sender, RoutedEventArgs e)
        {
            if (InHomeInspection.IsSelected)
            {
                if (adoptionManager.SubmitReviewerDecision(Convert.ToInt32(txtAdoptionApplicationID.Text), InHomeInspection.Content.ToString()))
                {
                    lblInterviewerErrorMessage.Content = InHomeInspection.Content;
                    updateAdoptionList();
                    DGInterviewerData.ItemsSource = applicationsReviewed;
                    GridInterviewerDecission.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblInterviewerErrorMessage.Content = "Please choose a decision";
                    GridInterviewerDecission.Visibility = Visibility.Visible;
                }

            }
            else if (Deny.IsSelected)
            {
                if (adoptionManager.SubmitReviewerDecision(Convert.ToInt32(txtAdoptionApplicationID.Text), Deny.Content.ToString()))
                {
                    lblInterviewerErrorMessage.Content = Deny.Content;
                    DGInterviewerData.ItemsSource = adoptionManager.retrieveCustomersFilledQuestionnair();
                    GridInterviewerDecission.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblInterviewerErrorMessage.Content = "Please choose a decision";
                    GridInterviewerDecission.Visibility = Visibility.Visible;
                }
            }
            else
            {
                lblInterviewerErrorMessage.Content = "Please choose a decission";
            }

        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void InterviewerControl_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                adoptionApplications = adoptionManager.retrieveCustomersFilledQuestionnair();
                applicationsReviewed.Clear();
                foreach (AdoptionApplication item in adoptionApplications)
                {
                    if (item.Status == "Interviewer")
                    {
                        applicationsReviewed.Add(item);
                    }

                }

            }
            catch (Exception)
            {

                lblInterviewerErrorMessage.Content = "We do not have adoption applications";
                GridInterviewerDecission.Visibility = Visibility.Hidden;
            }
        }
    }
}
