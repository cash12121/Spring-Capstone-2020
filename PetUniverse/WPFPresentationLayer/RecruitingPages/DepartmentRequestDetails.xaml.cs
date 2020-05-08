using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// Interaction logic for DepartmentRequestDetails.xaml
    /// </summary>
    public partial class DepartmentRequestDetails : Page
    {
        private IRequestManager _requestManager;
        private IDepartmentManager _deptManager = new DepartmentManager();
        private string[] _status = new string[] { "new", "active", "done" };
        private PetUniverseUser _user;
        private DepartmentRequestVM _request;
        private List<string> _departmentIDs = new List<string>();
        private List<string> _userDeptIDs;
        private List<string> _requestTypes;
        private List<string[]> _employeeNames;
        private string _requestStatus;
        private bool _edit = false;

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        ///
        /// Base Constructor for a detailed view of existing Department Requests
        /// </summary>
        /// <remarks>
        /// Updater:  
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        public DepartmentRequestDetails(IRequestManager requestManager, PetUniverseUser user,
            DepartmentRequestVM deptRequest, List<string> deptIDs, List<string> requestTypes, List<string[]> empNames)
        {
            _requestManager = requestManager;
            _request = deptRequest;
            _user = user;
            _departmentIDs = deptIDs;
            _requestTypes = requestTypes;
            _employeeNames = empNames;
            InitializeComponent();
            cbbRequestedGroup.ItemsSource = _departmentIDs;
            cbbRequestType.ItemsSource = _requestTypes;
            PopulateFields();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/05/05
        /// Approver: Steve Coonrod
        ///
        /// Alternate Constructor for opening a detailed form to created a new Department Request
        /// </summary>
        /// <remarks>
        /// Updater:  
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        public DepartmentRequestDetails(IRequestManager requestManager, PetUniverseUser user, List<string> deptIDs, List<string> requestTypes, List<string[]> empNames, List<string> userDeptIDs)
        {
            //DepartmentRequest blankConstruct = new DepartmentRequest();
            //_request = new DepartmentRequestVM(blankConstruct); 
            _requestManager = requestManager;
            _user = user;
            _userDeptIDs = userDeptIDs;
            _departmentIDs = deptIDs;
            _requestTypes = requestTypes;
            _employeeNames = empNames;
            InitializeComponent();
            cbbRequestedGroup.ItemsSource = _departmentIDs;
            cbbRequestType.ItemsSource = _requestTypes;
            PopulateFields();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        ///
        /// Load Method to fill in all the appropriate field for the DepartmentRequest's detailed view.
        /// This method will load differently based on the date values assigned to various status point for the request.
        /// </summary>
        /// <remarks>
        /// Updater: Ryan Morganti  
        /// Updated: 2020/05/05
        /// Update: Added functionality for creating a new Department Request
        ///
        /// </remarks>
        private void PopulateFields()
        {
            if(_request == null)
            {
                lblRequestTypeHeader.Visibility = Visibility.Visible;
                lblRequestedGroupHeader.Visibility = Visibility.Visible;
                lblRequestingGroupHeader.Visibility = Visibility.Visible;
                cbbRequestedGroup.IsEnabled = true;
                cbbRequestingGroup.Visibility = Visibility.Visible;
                lblRequestUser.Visibility = Visibility.Hidden;
                txtDeptRequestTopic.IsReadOnly = false;
                lblRequestStatus.Visibility = Visibility.Hidden;
                txtDeptRequestBody.IsReadOnly = false;
                txtDeptRequestResponses.Visibility = Visibility.Hidden;

                btnRetractRequest.Visibility = Visibility.Hidden;
                btnUpdateRequestStatus.Visibility = Visibility.Hidden;
                btnCreateDepartmentRequest.Visibility = Visibility.Visible;

                cbbRequestType.SelectedItem = "General";
                cbbRequestingGroup.ItemsSource = _userDeptIDs.Distinct();
                cbbRequestedGroup.ItemsSource = _departmentIDs;

            }
            else if (_request.DateAcknowledged.Year < 2000) //New Requests
            {
                if (_user.PUUserID == _request.RequestorID)
                {
                    btnEditDepartmentRequest.Visibility = Visibility.Visible;
                    btnUpdateRequestStatus.IsEnabled = false;
                    btnUpdateRequestStatus.ToolTip = "Author not allowed to update status.";
                }

                _requestStatus = _status[0];
                cbbRequestedGroup.SelectedItem = _request.RequesteeGroupID;
                cbbRequestType.SelectedItem = _request.RequestTypeID;
                lblRequestUser.Content = "Requested By: " + _request.RequestorGroupID;
                lblRequestUser.ToolTip = _request.RequestorFirstName + " " + _request.RequestorLastName;
                lblRequestStatus.Content = "Status: New";
                txtDeptRequestTopic.Text = _request.Topic;
                txtDeptRequestBody.Text = _request.Body;

            }
            else if (_request.DateAcknowledged.Year > 2000 && _request.DateCompleted.Year < 2000) //Acknowledged Requests
            {
                _requestStatus = _status[1];
                btnRetractRequest.Visibility = Visibility.Hidden;
                //btnRespondToRequest.Visibility = Visibility.Visible;
                btnUpdateRequestStatus.Content = "Request Completed";
                cbbRequestedGroup.SelectedItem = _request.RequesteeGroupID;
                cbbRequestType.SelectedItem = _request.RequestTypeID;
                lblRequestUser.Content = "Requested By: " + _request.RequestorGroupID;
                lblRequestUser.ToolTip = string.Join(" ", new[] { _request.RequestorFirstName, _request.RequestorLastName });
                lblRequestStatus.Content = "Status: Acknowledged " + _request.DateAcknowledged.ToShortDateString();
                lblRequestStatus.ToolTip = _request.AcknowledgeFirstName + " " + _request.AcknowledgeLastName;
                txtDeptRequestTopic.Text = _request.Topic;
                txtDeptRequestBody.Text = _request.Body;

                //try
                //{
                //    txtDeptRequestResponses.Text =
                //        _requestManager.RetrieveAllResponsesByRequestID(_request.RequestID).ResponseListBuilder(_employeeNames);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, ex.InnerException.Message);
                //}
            }
            else if (_request.DateCompleted.Year > 2000) //Completed Requests
            {
                _requestStatus = _status[2];
                btnRetractRequest.Visibility = Visibility.Hidden;
                btnRespondToRequest.Visibility = Visibility.Hidden;
                btnUpdateRequestStatus.Visibility = Visibility.Hidden;
                cbbRequestedGroup.SelectedItem = _request.RequesteeGroupID;
                cbbRequestType.SelectedItem = _request.RequestTypeID;
                lblRequestUser.Content = "Requested By: " + _request.RequestorGroupID;
                lblRequestUser.ToolTip = string.Join(" ", new[] { _request.RequestorFirstName, _request.RequestorLastName });
                lblRequestStatus.Content = "Status: Completed " + _request.DateCompleted.ToShortDateString();
                lblRequestStatus.ToolTip = _request.CompleteFirstName + " " + _request.CompleteLastName;
                txtDeptRequestTopic.Text = _request.Topic;
                txtDeptRequestBody.Text = _request.Body;

                //try
                //{
                //    txtDeptRequestResponses.Text =
                //        _requestManager.RetrieveAllResponsesByRequestID(_request.RequestID).ResponseListBuilder(_employeeNames);
                //}
                //catch (Exception ex)
                //{

                //    MessageBox.Show(ex.Message, ex.InnerException.Message);
                //}
            }



        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        ///
        /// Click Event Method to close the request and return to the previous frame if able.
        /// </summary>
        /// <remarks>
        /// Updater:   
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseRequestDetails_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Unable to Navigate");
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approver: Derek Taylor
        ///
        /// Click Event Method to update the status of a DepartmentRequest based on its current status.
        /// Will display a success message and return to the list view if successful.
        /// Will display an error and remain on the detailed view if unsuccessful.
        /// </summary>
        /// <remarks>
        /// Updater: Ryan Morganti  
        /// Updated: 2020/05/06
        /// Update: Altered the navigation functionality to properly direct to the appropriate Request tab when leaving 
        ///         the detailed view.
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateRequestStatus_Click(object sender, RoutedEventArgs e)
        {
            if (_requestStatus == _status[0])
            {
                try
                {
                    int result = _requestManager.SetDeptRequestStatusToAcknowledged(_user.PUUserID, _request.RequestID);
                    if (result == 1)
                    {
                        MessageBox.Show("Status UPDATED!");
                        this.NavigationService?.Navigate(frRequestList.Content = new ListRequests(_user, "active"));
                
                    }
                    else
                    {
                        MessageBox.Show("Status update failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.InnerException.Message);
                }
            }
            else if (_requestStatus == _status[1])
            {
                try
                {
                    int result = _requestManager.SetDeptRequestStatusToCompleted(_user.PUUserID, _request.RequestID);
                    if (result == 1)
                    {
                        MessageBox.Show("Status UPDATED!");
                        this.NavigationService?.Navigate(frRequestList.Content = new ListRequests(_user, "done"));
                    }
                    else
                    {
                        MessageBox.Show("Status update failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.InnerException.Message);
                }
            }


        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/18
        /// Approver: Derek Taylor
        ///
        /// Click Event Method to update the details of a DepartmentRequest.
        /// </summary>
        /// <remarks>
        /// Updater:   
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditDepartmentRequest_Click(object sender, RoutedEventArgs e)
        {
            if (_edit)
            {
                if (cbbRequestedGroup.SelectedItem.ToString().IsValidDepartment(_departmentIDs))
                {
                    string newRequestedGroupID = cbbRequestedGroup.SelectedItem.ToString();
                    string newRequestTopic = txtDeptRequestTopic.Text;
                    string newRequestBody = txtDeptRequestBody.Text;

                    try
                    {
                        int result;
                        result = _requestManager.EditDepartmentRequestDetails(_request.RequestorID, _request.RequestID, _request.RequesteeGroupID, _request.Topic, _request.Body,
                                                                                newRequestedGroupID, newRequestTopic, newRequestBody);
                        if (result == 1)
                        {
                            MessageBox.Show("Request UPDATED!");

                        }
                        else
                        {
                            MessageBox.Show("Request update failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.InnerException.Message);
                    }
                }
            }
            else
            {
                _edit = true;
                cbbRequestedGroup.IsEnabled = true;
                txtDeptRequestTopic.IsReadOnly = false;
                txtDeptRequestBody.IsReadOnly = false;

                btnEditDepartmentRequest.Content = "Save";
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/05/06
        /// Approver: Steve Coonrod
        ///
        /// Click Event Method to create a new Department Request and navigate back
        /// to the department request tab view if successful.
        /// </summary>
        /// <remarks>
        /// Updater:   
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateDepartmentRequest_Click(object sender, RoutedEventArgs e)
        {
            DepartmentRequest request = new DepartmentRequest()
            {
                RequestingUserID = _user.PUUserID,
                RequestTypeID = cbbRequestType.Text,
                RequestorGroupID = cbbRequestingGroup.Text,
                RequesteeGroupID = cbbRequestedGroup.Text,
                Topic = txtDeptRequestTopic.Text,
                Body = txtDeptRequestBody.Text
            };

            try
            {
                int result;
                result = _requestManager.CreateNewRequest(request);
                if (result == 1)
                {
                    MessageBox.Show("Request CREATED!");
                    this.NavigationService?.Navigate(frRequestList.Content = new ListRequests(_user));
                }
                else
                {
                    MessageBox.Show("Request creation failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.InnerException.Message);
            }
        }
    }
}
