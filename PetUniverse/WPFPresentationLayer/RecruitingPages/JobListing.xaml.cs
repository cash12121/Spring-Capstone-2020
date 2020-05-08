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
using LogicLayerInterfaces;
using LogicLayer;


namespace WPFPresentationLayer.RecruitingPages
{
    /// 
    /// Creator: Hassan Karar.
    /// Created:  2020/3/10
    /// Approver: Steve Coonrod. 
    ///<summary>
    /// This class Interaction logic for SubmitResponse.xaml
    ///
    /// </summary>


    public partial class JobListing : Page
    {
        private  DataTransferObjects.JobListing oldJobListing = new DataTransferObjects.JobListing();
        private IJobListingManager _jobListingManager;

        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY: Steve Coonrod.
        /// <summary>
        /// This method is submiting a list of job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="requestID"></param>
        /// </remarks>
        /// 
        public JobListing()
        {
            _jobListingManager = new JobListingManager();
            InitializeComponent();
        }

        /// NAME: Hassan Karar
        /// DATE:  3/10/2020
        /// CHECKED BY: Steve Coonrod.
        /// <summary>
        /// Thies methods is to retreieve the sample data from the database.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        /// </remarks>
        /// 
        private void canViewJobListing_Loaded(object sender, RoutedEventArgs e)
        {
            DGViewDatat.ItemsSource = _jobListingManager.RetrieveJobListing();
            DGViewDatat.Columns[1].Visibility = Visibility.Hidden;
            populatedgAdoptionApplicationsList();
        }


        /// NAME: Hassan Karar
        /// DATE:  2020/3/10
        /// CHECKED BY: Steve Coonrod.
        /// <summary>
        /// Thies methods is to do GoFucus on all the field of the create job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// </remarks>
        /// 


        private void lblDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            txtDescription.Text = "";
        }


        private void lblBenifits_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBenefits.Text = "";
        }

        private void lblRequirements_GotFocus(object sender, RoutedEventArgs e)
        {
            txtRequirements.Text = "";
        }

        private void lblStartingWage_GotFocus(object sender, RoutedEventArgs e)
        {
            txtStartingWage.Text = "";
        }


        /// NAME: Hassan Karar
        /// DATE:  2020/3/10
        /// CHECKED BY: Steve Coonrod.
        /// <summary>
        /// Thies methods is clothing the create joblisting after we added and open the view page.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        /// </remarks>
        /// 

        private void btnCreateJobListing_Click(object sender, RoutedEventArgs e)
        {
            canCreateJobListing.Visibility = Visibility.Visible;
            canViewJobListing.Visibility = Visibility.Hidden;
 
        }
        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY:
        /// <summary>
        /// This method is to add new job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        /// </remarks>
        /// 

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;
            DataTransferObjects.JobListing jobListing = new DataTransferObjects.JobListing();

            jobListing.Responsibilities = txtDescription.Text;
            jobListing.Benefits = txtBenefits.Text;
            jobListing.Requirements = txtRequirements.Text;
            
            try
            {
                jobListing.StartingWage = Convert.ToDecimal(txtStartingWage.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Starting Wage should be a number");
                return;
            }

            if (admin.IsSelected)
            {
                jobListing.RoleID = admin.Content.ToString();

            }
            else if (customer.IsSelected)
            {
                jobListing.RoleID = customer.Content.ToString();
            }
            else if (employee.IsSelected)
            {
                jobListing.RoleID = employee.Content.ToString();
            }
            else if (volunteer.IsSelected)
            {

                jobListing.RoleID = volunteer.Content.ToString();

            }

            jobListing.Position = jobListing.RoleID;
            result =  _jobListingManager.addJobListing(jobListing);
            

            if (result)
            {
                MessageBox.Show("done");
                canCreateJobListing.Visibility = Visibility.Hidden;
                canViewJobListing.Visibility = Visibility.Visible;
                DGViewDatat.Columns[1].Visibility = Visibility.Hidden;
                populatedgAdoptionApplicationsList();

            }
            else
            {
                MessageBox.Show("Not done yet");
            }

            cboDefaultPosition.SelectedItem = null;
            txtBenefits.Clear();
            txtDescription.Clear();
            txtRequirements.Clear();
            txtStartingWage.Clear();

          
            
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY: 
        /// <summary>
        /// This method is to edit a job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        /// </remarks>
        /// 
        private void btnEditJobListing_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (DGViewDatat.SelectedItem == null)
                {
                    MessageBox.Show("You have to select a field");
                    return;
                }
                else
                {
                    
                    oldJobListing = (DataTransferObjects.JobListing)DGViewDatat.SelectedItem;
                    if (oldJobListing.RoleID == "Admin")
                    {
                        cboEditDefaultPosition.SelectedIndex = 0;
                        
                    }
                    else if (oldJobListing.RoleID == "Customer")

                    {
                        cboEditDefaultPosition.SelectedIndex = 1;
                    }
                    else if (oldJobListing.RoleID == "Employee")

                    {
                        cboEditDefaultPosition.SelectedIndex = 2;
                    }
                    else if (oldJobListing.RoleID == "Volunteer")

                    {
                        cboEditDefaultPosition.SelectedIndex = 3;
                    }
                    txtEditDescription.Text = oldJobListing.Responsibilities;
                    txtEditBenefits.Text = oldJobListing.Benefits;
                    txtEditRequirements.Text = oldJobListing.Requirements;
                    try
                    {  
                        txtEditStartingWage.Text = Convert.ToString(oldJobListing.StartingWage);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Starting Wage should be a number");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

           
            canViewJobListing.Visibility = Visibility.Hidden;
            canEditJobListing.Visibility = Visibility.Visible;
            populatedgAdoptionApplicationsList();

        }

        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY: 
        /// <summary>
        /// This method is letting you to go back to the list of job listing after we edited.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        /// </remarks>
        /// 

        private void btnBackJobListing_Click(object sender, RoutedEventArgs e)
        {
            canViewJobListing.Visibility = Visibility.Visible;
            canEditJobListing.Visibility = Visibility.Hidden;

        }



        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY: 
        /// <summary>
        /// This method is letting you to cancle creating joblisting and taking you back to the view page.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        /// </remarks>
        /// 


        private void btnCancelJobListing_Click(object sender, RoutedEventArgs e)
        {
            canViewJobListing.Visibility = Visibility.Visible;
            canCreateJobListing.Visibility = Visibility.Hidden;
        }


        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY:  Steve Coonrod.
        /// <summary>
        /// This method is deleting a field from the job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        /// </remarks>
        /// 
        private void btnDeleteJobListing_Click(object sender, RoutedEventArgs e)
        {

            if ((DGViewDatat.SelectedItem == null))
            {
                MessageBox.Show("You have to select a field");
            }
            if (DGViewDatat.SelectedItem != null)
            {
                DataTransferObjects.JobListing Job = new DataTransferObjects.JobListing();
                Job = (DataTransferObjects.JobListing)DGViewDatat.SelectedItem;

                var deletetJobListing = MessageBox.Show(" Are you sure want to delete ?", "Delete A list ", MessageBoxButton.YesNo);
                if (deletetJobListing == MessageBoxResult.Yes)
                {
                    try
                    {
                          _jobListingManager.DeletetJobListing(Job.JobListingID);
                         
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);

                    }

                    MessageBox.Show("Job Listing Deleted");

                }
                populatedgAdoptionApplicationsList();
            }
           


        }

        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY: 
        /// <summary>
        /// This method is saving the edited job Listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        /// </remarks>
        /// 
        private void btnEditSave_Click_1(object sender, RoutedEventArgs e)
        {
            bool result = false;

            DataTransferObjects.JobListing newJobListing = new DataTransferObjects.JobListing();
 
            newJobListing.Responsibilities = txtEditDescription.Text;
            newJobListing.Benefits = txtEditBenefits.Text;
            newJobListing.Requirements = txtEditRequirements.Text;
            try
            {
                newJobListing.StartingWage = Convert.ToDecimal(txtEditStartingWage.Text);
            }
            catch (Exception)
            { 
                MessageBox.Show("Starting Wage should be a number");
                return;
            }

            if (EditAdmin.IsSelected)
            {
                newJobListing.RoleID = EditAdmin.Content.ToString();

            }
            else if (EditCustomer.IsSelected)
            {
                newJobListing.RoleID = EditCustomer.Content.ToString();
            }
            else if (EditEmployee.IsSelected)
            {
                newJobListing.RoleID = EditEmployee.Content.ToString();
            }
            else if (EditVolunteer.IsSelected)
            {

                newJobListing.RoleID = EditVolunteer.Content.ToString();

            }

            result = _jobListingManager.EditJobListing(newJobListing, oldJobListing);

           

            if (result == true)
            {
                MessageBox.Show("done");
            }
            else
            {
                MessageBox.Show("Not done");
               
            }

            canEditJobListing.Visibility = Visibility.Hidden;
            canViewJobListing.Visibility = Visibility.Visible;
            populatedgAdoptionApplicationsList();

        }
        /// NAME: Hassan Karar
        /// DATE:  2020/3/10
        /// CHECKED BY: 
        /// <summary>
        /// This method is to update the DGViewData when we do any actions.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// 
        private void populatedgAdoptionApplicationsList()
        {
            
            DGViewDatat.ItemsSource = _jobListingManager.RetrieveJobListing();

            
            DGViewDatat.Columns[1].Visibility = Visibility.Hidden;
           // DGViewDatat.Columns[7].Visibility = Visibility.Hidden;

            DGViewDatat.Columns[0].Header = "Job Listing ID";
            DGViewDatat.Columns[1].Header = "Position";
            DGViewDatat.Columns[2].Header = "Position";
            DGViewDatat.Columns[3].Header = "Benefits";
            DGViewDatat.Columns[4].Header = "Requirements";
            DGViewDatat.Columns[5].Header = "Starting Wage";
            DGViewDatat.Columns[6].Header = "Ressponsibilites";
            DGViewDatat.Columns[7].Header = "Active";
          

          


        }
    }
}
