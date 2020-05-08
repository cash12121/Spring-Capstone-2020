using LogicLayer;
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

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// Creator: Hassan Karar.
    /// Created:  2020/3/10
    /// Approver: Derek Taylor
    ///
    /// This class Interaction logic for CreatNewRequest.xaml
    ///
    /// </summary>
    public partial class CreatNewRequest : Page
    {
        private IRequestManager createRequest = new RequestManager();
        private IRequestManager show = new RequestManager();


        private IRequestManager neededRequest;
        private UserManager UserManager;
        private DepartmentManager departmentManager;
        private RequestManager RequestManager;
        public CreatNewRequest()
        {
            InitializeComponent();
            neededRequest = new RequestManager();
           
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This method is when the page loaded.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>

        private void Page_Loaded(object sender, RoutedEventArgs e)

        {
            // this is for the Requests droup down menu.

            DGResponds.ItemsSource = show.responds();

            RequestManager = new RequestManager();
            List<String> request = new List<string>();
            List<RequestVM> requests = new List<RequestVM>();
            requests = RequestManager.RetrieveAllRequests();
            foreach (var RequestVM in requests)
            {
                request.Add(RequestVM.RequestID.ToString());
            }

            cboRequestsID.ItemsSource = request;

            // this is for the users droup down menu.

            UserManager = new UserManager();
            List<String> user = new List<string>();
            List<PetUniverseUser> users = new List<PetUniverseUser>();
            users = UserManager.RetrieveAllActivePetUniverseUsers();
            foreach (var PetUniverseUser in users)
            {
                user.Add(PetUniverseUser.PUUserID.ToString());
            }

            cboUsersID.ItemsSource = user;
            cboUser.ItemsSource = user;


            // this is for the Departments droup down menu.

            departmentManager = new DepartmentManager();
            List<String> departmentIDs = new List<string>();
            List<Department> departments = new List<Department>();
            departments = departmentManager.RetrieveAllDepartments();
            foreach (var department in departments)
            {
                departmentIDs.Add(department.DepartmentID);
            }

            cboDepartmentName.ItemsSource = departmentIDs;
           
        }


        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This method is creating event for Cot focus to the body of request response.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>

        private void btnOpenRecord_Click(object sender, RoutedEventArgs e)
        {
            DepartmentRequest department = new DepartmentRequest();
  

            //Authenticate
            if (null == cboDepartmentName.SelectedItem)
            {
                lblError.Content = "please choose a department";
                return;
            }
            if  ((txtSubject.Text == "Subject") || ("" == txtSubject.Text))
            {
                lblError.Content = "Please enter the subject";
                return;
            }

            if ((txtBody.Text == "Inter The Body...") || ("" == txtBody.Text))
            {
                lblError.Content = "Please enter the body";
                return;
            }
            lblError.Content = "";


            if (null == cboRequestsID.SelectedItem)
            {
                lblError.Content = "please choose a RequestID";
                return;
            }

            if (null == cboUsersID.SelectedItem)
            {
                lblError.Content = "please choose the UserID";
                return;
            }


            //add to the bag
            department.DeptRequestID = Convert.ToInt32(cboRequestsID.SelectedItem.ToString());
            department.RequesteeGroupID = cboDepartmentName.SelectedItem.ToString();
            department.AcknowledgingEmployee = Convert.ToInt32(cboUsersID.SelectedItem.ToString());
            department.Subject = txtSubject.Text;
            department.Body = txtBody.Text;
            try
            {
                if (neededRequest.addNewRequestIsPosted(department))
                {
                    txtBody.Select(0, 0);

                    txtResponse.Select(0, 0);

                    cboDepartmentName.SelectedItem = null;
                    cboUsersID.SelectedItem = null;
                    cboRequestsID.SelectedItem = null;
                    txtSubject.Clear();
                    txtBody.Clear();

                    lblError.Content = "the reqest added correctly";
                }
                else
                {

                    lblError.Content = "the reqest did not added correctly";
                    return;
                }
            }
            catch (Exception)
            {

                lblError.Content = " This Request is already choosen";
            }

            
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This method is creating event for Cot focus to the body of request response.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>

        private void txtSubject_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSubject.Text = "";
        }

        /// NAME: Hassan Karar
        /// DATE: 3/11/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This method is creating event for Cot focus to the subject of request response.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>
        private void txtBody_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBody.Text = "";
        }



        /// NAME: Hassan Karar
        /// DATE: 3/11/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This method is creating event for view the response.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>
        /// 
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            canCreatNewRequest.Visibility = Visibility.Hidden;
            canSubmitResponse.Visibility = Visibility.Hidden;
            canViewResponse.Visibility = Visibility.Visible;
        }


        /// NAME: Hassan Karar
        /// DATE: 3/11/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This method is creating event for view the response.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>
        /// 

        private void txtResponse_GotFocus(object sender, RoutedEventArgs e)
        {
            txtResponse.Text = "";
        }


        /// NAME: Hassan Karar
        /// DATE: 3/11/2020
        /// CHECKED BY:Derek Taylor
        /// <summary>
        ///  This method is creating event for view the response.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>
        /// 

        private void btnSubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            DataTransferObjects.ViewResponds viewResponds = new DataTransferObjects.ViewResponds();
            viewResponds = (DataTransferObjects.ViewResponds)DGResponds.SelectedItem;

            try
            {

                if (cboUser.SelectedItem == null)
                {
                    
                    lblSubmitError.Content = "You have to select a user";
                    return;
                }

                if (txtResponse == null)
                {
                    lblSubmitError.Content = "You have to insert a response";
                }

                createRequest.insertRequestResponse(Convert.ToInt32(viewResponds.RequestID),
                 txtResponse.Text, cboUser.SelectedItem.ToString());

                lblSubmitError.Content = "the respond is submitted ";
                cboUser.SelectedItem = null;
                txtResponse.Clear();


            }

            catch (Exception)

            {

                lblSubmitError.Content = " we already have a response for this request";
                return;
            }

           

        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }


        /// NAME: Hassan Karar
        /// DATE: 3/11/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This method is creating event for view the response.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>
        /// 

        private void btnCancleRequest_Click(object sender, RoutedEventArgs e)
        {

            DataTransferObjects.ViewResponds respo = new DataTransferObjects.ViewResponds();

            if (btnCancleRequest.Content.ToString() != "{NewItemPlaceholder}")
                respo = (DataTransferObjects.ViewResponds)DGResponds.SelectedItem;

            bool result = false;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            if (respo != null)
            {
                result = show.cancleRequest(respo.RequestID);

            }
            if (result)
            {
                lblViewError.Content = "Request Cancled";
                DGResponds.ItemsSource = show.responds();
            }

            else
            {
                lblViewError.Content = "you have to select a request first";

            }
        }


        /// NAME: Hassan Karar
        /// DATE: 3/11/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This method is creating event for view the response.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>
        /// 

        private void btnSubmitView_Click(object sender, RoutedEventArgs e)
        {
            DataTransferObjects.ViewResponds respo = new DataTransferObjects.ViewResponds();

            if (DGResponds.SelectedItem == null)
            {
                lblViewError.Content = "You have to select a Request first";
                return;
            }

            if (DGResponds.SelectedItem != null
                && (DGResponds.SelectedItem.ToString() != "{NewItemPlaceholder}"))

            {
                respo = (DataTransferObjects.ViewResponds)DGResponds.SelectedItem;
                canCreatNewRequest.Visibility = Visibility.Hidden;
                canSubmitResponse.Visibility = Visibility.Visible;
                canViewResponse.Visibility = Visibility.Hidden;

            }

            
            else
            {
                lblError.Content = "you have to select a request";
            }
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This event to take you back to the main page.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>
        /// 
        private void btnSubmitBack_Click(object sender, RoutedEventArgs e)
        {
            canCreatNewRequest.Visibility = Visibility.Hidden;
            canSubmitResponse.Visibility = Visibility.Hidden;
            canViewResponse.Visibility = Visibility.Visible;
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This event to take you back to the main page.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="object"></param>
        /// <param name="e"></param>
        /// </remarks>
        /// 

        private void btnBackR_Click(object sender, RoutedEventArgs e)
        {
            canCreatNewRequest.Visibility = Visibility.Visible;
            canSubmitResponse.Visibility = Visibility.Hidden;
            canViewResponse.Visibility = Visibility.Hidden;
        }
    }

}



