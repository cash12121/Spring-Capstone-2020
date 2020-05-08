using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// Interaction logic for ListRequests.xaml
    /// </summary>
    public partial class ListRequests : Page
    {
        private IRequestManager _requestManager;
        private IDepartmentManager _departmentManager;
        private PetUniverseUser _user;
        private List<string> _departmentIDs; 
        private List<string> _requestTypes;  
        private List<string> _userDepartmentIDs;
        private List<string[]> _employeeNames;
        private List<DepartmentRequest> _doneRequests;
        private List<DepartmentRequest> _activeRequests;
        private List<DepartmentRequest> _newRequests;

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver: Derek Taylor
        ///
        /// Base Constructor for opening the Request page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        public ListRequests(PetUniverseUser user)
        {
            _user = user;
            _requestManager = new RequestManager();
            _departmentManager = new DepartmentManager();
            PopulateDepartments();
            PopulateEmployeeNames();
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/05/05
        /// Approver: 
        ///
        /// Overloaded Constructor for tab redirection when viewing and exiting Department REquest details
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        public ListRequests(PetUniverseUser user, string tabview)
        {
            _user = user;    
            _requestManager = new RequestManager();
            _departmentManager = new DepartmentManager();
            PopulateDepartments();
            PopulateEmployeeNames();
            InitializeComponent();
            switch (tabview)
            {
                case "new":
                    tabsetRequests.SelectedIndex = 0;
                    break;
                case "active":
                    tabsetRequests.SelectedIndex = 1;
                    break;
                case "done":
                    tabsetRequests.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver: Derek Taylor
        ///
        /// Helper method to populate an employee user's departments, based on their userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        private void PopulateDepartments()
        {
            try
            {
                
                _userDepartmentIDs = _requestManager.RetrieveAllDepartmentIDsByUserID(_user.PUUserID);
                _departmentIDs = _departmentManager.RetrieveAllDepartments().DepartmentIDFilter();
                _requestTypes = _requestManager.RetriveAllRequestTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        ///
        /// Load Method to retrieve a list of Employee names and associated employee numbers.  This allows the DepartmentRequestVM to 
        /// display appropriate employee names instead of just their numbers.
        /// </summary>
        /// <remarks>
        /// Updater:  
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        private void PopulateEmployeeNames()
        {
            try
            {
                _employeeNames = _requestManager.RetrieveEmployeeNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Load Method to retrieve a list of New Requests when the NewRequestTab loads, and bind 
        /// that list to the datagrid.
        /// </summary>
        /// <remarks>
        /// Updater: Ryan Morganti  
        /// Updated: 2020/03/05
        /// Update: Centralized all request tabs into one Page.
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgNewRequestList_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> param;
            if (_userDepartmentIDs.Contains("Management"))
            {
                param = _departmentIDs;
            }
            else
            {
                param = _userDepartmentIDs;
            }
            try
            {
                _newRequests = _requestManager.RetrieveNewRequestsByDepartmentID(param);
                                
                dgNewRequestList.ItemsSource = _newRequests.DistinctRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Method for filtering which columns to fill once the DataGrid for NewRequests is given a source
        /// </summary>
        /// <remarks>
        /// Updater: Ryan Morganti  
        /// Updated: 2020/03/05
        /// Update: Centralized all request tabs into one Page.
        ///
        /// </remarks>
        /// /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgNewRequestList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgNewRequestList.Columns.RemoveAt(15);
            dgNewRequestList.Columns.RemoveAt(14);
            dgNewRequestList.Columns.RemoveAt(11);
            dgNewRequestList.Columns.RemoveAt(10);
            dgNewRequestList.Columns.RemoveAt(8);
            dgNewRequestList.Columns.RemoveAt(7);
            dgNewRequestList.Columns.RemoveAt(6);
            dgNewRequestList.Columns.RemoveAt(5);
            dgNewRequestList.Columns.RemoveAt(4);
            dgNewRequestList.Columns.RemoveAt(1);
            dgNewRequestList.Columns.RemoveAt(0);
            dgNewRequestList.Columns[1].DisplayIndex = 0;
            dgNewRequestList.Columns[1].Header = "To";
            dgNewRequestList.Columns[2].DisplayIndex = 1;
            dgNewRequestList.Columns[2].Header = "Topic";
            dgNewRequestList.Columns[0].DisplayIndex = 2;
            dgNewRequestList.Columns[0].Header = "From";
            dgNewRequestList.Columns[4].DisplayIndex = 3;
            dgNewRequestList.Columns[4].Header = "Date";
            dgNewRequestList.Columns[3].DisplayIndex = 4;
            dgNewRequestList.Columns[3].Header = "Type";

            
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Load Method to retrieve a list of Active Requests when the ActiveRequestTab loads, and bind 
        /// that list to the datagrid.
        /// </summary>
        /// <remarks>
        /// Updater: Ryan Morganti  
        /// Updated: 2020/03/05
        /// Update: Centralized all request tabs into one Page.
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgActiveRequestList_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgActiveRequestList.ItemsSource == null)
                {
                    if (_userDepartmentIDs.Contains("Management"))
                    {
                        _activeRequests = _requestManager.RetrieveActiveRequestsByDepartmentID(_departmentIDs);
                    }
                    else
                    {
                        _activeRequests = _requestManager.RetrieveActiveRequestsByDepartmentID(_userDepartmentIDs);
                    }
                    
                    dgActiveRequestList.ItemsSource = _activeRequests.DistinctRequests();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Method for filtering which columns to fill once the DataGrid for ActiveRequests is given a source
        /// </summary>
        /// <remarks>
        /// Updater: Ryan Morganti  
        /// Updated: 2020/03/05
        /// Update: Centralized all request tabs into one Page.
        ///
        /// </remarks>
        /// /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgActiveRequestList_AutoGeneratedColumns(object sender, EventArgs e)
        {            
            dgActiveRequestList.Columns.RemoveAt(15);
            dgActiveRequestList.Columns.RemoveAt(14);
            dgActiveRequestList.Columns.RemoveAt(11);
            dgActiveRequestList.Columns.RemoveAt(10);
            dgActiveRequestList.Columns.RemoveAt(8);
            dgActiveRequestList.Columns.RemoveAt(7);
            dgActiveRequestList.Columns.RemoveAt(6);
            dgActiveRequestList.Columns.RemoveAt(5);
            dgActiveRequestList.Columns.RemoveAt(4);
            dgActiveRequestList.Columns.RemoveAt(1);
            dgActiveRequestList.Columns.RemoveAt(0);
            dgActiveRequestList.Columns[1].DisplayIndex = 0;
            dgActiveRequestList.Columns[1].Header = "To";
            dgActiveRequestList.Columns[2].DisplayIndex = 1;
            dgActiveRequestList.Columns[2].Header = "Topic";
            dgActiveRequestList.Columns[0].DisplayIndex = 2;
            dgActiveRequestList.Columns[0].Header = "From";
            dgActiveRequestList.Columns[4].DisplayIndex = 3;
            dgActiveRequestList.Columns[4].Header = "Date";
            dgActiveRequestList.Columns[3].DisplayIndex = 4;
            dgActiveRequestList.Columns[3].Header = "Type";
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Load Method to retrieve a list of Completed Requests when the DoneRequestTab loads, and bind 
        /// that list to the datagrid.
        /// </summary>
        /// <remarks>
        /// Updater: Ryan Morganti  
        /// Updated: 2020/03/05
        /// Update: Centralized all request tabs into one Page.
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDoneRequestList_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgDoneRequestList.ItemsSource == null)
                {
                    if (_userDepartmentIDs.Contains("Management"))
                    {
                        _doneRequests = _requestManager.RetrieveCompleteRequestsByDepartmentID(_departmentIDs);
                    }
                    else
                    {
                        _doneRequests = _requestManager.RetrieveCompleteRequestsByDepartmentID(_userDepartmentIDs);
                    }
                    
                    dgDoneRequestList.ItemsSource = _doneRequests.DistinctRequests();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Method for filtering which columns to fill once the DataGrid for DoneRequests is given a source
        /// </summary>
        /// <remarks>
        /// Updater: Ryan Morganti  
        /// Updated: 2020/03/05
        /// Update: Centralized all request tabs into one Page.
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDoneRequestList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgDoneRequestList.Columns.RemoveAt(15);
            dgDoneRequestList.Columns.RemoveAt(14);
            dgDoneRequestList.Columns.RemoveAt(11);
            dgDoneRequestList.Columns.RemoveAt(10);
            dgDoneRequestList.Columns.RemoveAt(8);
            dgDoneRequestList.Columns.RemoveAt(7);
            dgDoneRequestList.Columns.RemoveAt(6);
            dgDoneRequestList.Columns.RemoveAt(5);
            dgDoneRequestList.Columns.RemoveAt(4);
            dgDoneRequestList.Columns.RemoveAt(1);
            dgDoneRequestList.Columns.RemoveAt(0);
            dgDoneRequestList.Columns[1].DisplayIndex = 0;
            dgDoneRequestList.Columns[1].Header = "To";
            dgDoneRequestList.Columns[2].DisplayIndex = 1;
            dgDoneRequestList.Columns[2].Header = "Topic";
            dgDoneRequestList.Columns[0].DisplayIndex = 2;
            dgDoneRequestList.Columns[0].Header = "From";
            dgDoneRequestList.Columns[4].DisplayIndex = 3;
            dgDoneRequestList.Columns[4].Header = "Date";
            dgDoneRequestList.Columns[3].DisplayIndex = 4;
            dgDoneRequestList.Columns[3].Header = "Type";
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/05
        /// Approver: Derek Taylor
        ///
        /// Event Method for opening a select New request into a detailed view.
        /// </summary>
        /// <remarks>
        /// Updater:  
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgNewRequestList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DepartmentRequestVM requestVM = new DepartmentRequestVM((DepartmentRequest)dgNewRequestList.SelectedItem);
            requestVM.PopulateUserNames(_employeeNames);
            this.NavigationService?.Navigate(frDeptRequestDetails.Content
                = new DepartmentRequestDetails(_requestManager, _user, requestVM, _departmentIDs, _requestTypes, _employeeNames));
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        ///
        /// Event Method for opening a select Active request into a detailed view.
        /// </summary>
        /// <remarks>
        /// Updater:  
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgActiveRequestList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DepartmentRequestVM requestVM = new DepartmentRequestVM((DepartmentRequest)dgActiveRequestList.SelectedItem);
            requestVM.PopulateUserNames(_employeeNames);
            this.NavigationService?.Navigate(frDeptRequestDetails.Content
                = new DepartmentRequestDetails(_requestManager, _user, requestVM, _departmentIDs, _requestTypes, _employeeNames));
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        ///
        /// Event Method for opening a select Completed request into a detailed view.
        /// </summary>
        /// <remarks>
        /// Updater:  
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDoneRequestList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DepartmentRequestVM requestVM = new DepartmentRequestVM((DepartmentRequest)dgDoneRequestList.SelectedItem);
            requestVM.PopulateUserNames(_employeeNames);
            this.NavigationService?.Navigate(frDeptRequestDetails.Content
                = new DepartmentRequestDetails(_requestManager, _user, requestVM, _departmentIDs, _requestTypes, _employeeNames));
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/05/05
        /// Approver: Steve Coonrod
        ///
        /// Click Event Method for opening a new DepartmentRequestDetails form
        /// in order to create and submit a new Department Request.
        /// </summary>
        /// <remarks>
        /// Updater:  
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateNewRequest_Click(object sender, RoutedEventArgs e)
        {            
            this.NavigationService?.Navigate(frDeptRequestDetails.Content
                = new DepartmentRequestDetails(_requestManager, _user, _departmentIDs, _requestTypes, _employeeNames, _userDepartmentIDs));
        }

        

        
    }
}
