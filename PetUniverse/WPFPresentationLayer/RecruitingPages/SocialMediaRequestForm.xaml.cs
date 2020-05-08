using DataTransferObjects;
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

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// 
    /// CREATOR: Steve Coonrod
    /// CREATED: 2020/4/10
    /// APPROVER: Matt Deaton
    ///  
    /// This is the logic behind the page for Requesting a Social Media Post
    ///  
    /// </summary>
    /// <remarks>
    /// 
    /// UPDATER: NA
    /// UPDATED: NA
    /// UPDATE: NA
    /// 
    /// </remarks>
    /// 
    /// </summary>
    public partial class SocialMediaRequestForm : Page
    {
        IRequestManager _requestManager;
        PetUniverseUser _user;
        PetUniverseHome _mainWindow;

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/4/10
        /// APPROVER: Matt Deaton
        ///  
        /// This is a constructor with 0 references that keeps the 
        ///     program from crashing at startup
        ///  
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// 
        /// </summary>
        public SocialMediaRequestForm() { }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/4/10
        /// APPROVER: Matt Deaton
        ///  
        /// The constructor for this form
        /// Takes the PetUniverse Home Window as a parameter so that the user
        ///     can be returned to a different tab upon successful submission
        /// Takes a user parameter to assign the requestingUserID to the request
        ///  
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// 
        /// </summary>
        /// <param name="mainWindow"></param>
        /// <param name="user"></param>
        public SocialMediaRequestForm(PetUniverseHome mainWindow, PetUniverseUser user)
        {
            _requestManager = new RequestManager();
            _user = user;
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/4/10
        /// APPROVER: Matt Deaton
        ///  
        /// This method is where the call to the request manager is made.
        ///     it is called after the user confirms that they want to send the request
        ///  
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// 
        /// </summary>
        /// <param name="request"></param>
        private void sendRequest(SocialMediaRequest request)
        {
            try
            {
                request.RequestID = _requestManager.AddSocialMediaRequest(request);

                if (request.RequestID != 0)
                {
                    txtDescription.Text = "";
                    txtTitle.Text = "";

                    MessageBox.Show("The request was sent successfully", "Request Sent", MessageBoxButton.OK);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem with the request.\n" + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 
        ///  CREATOR: Steve Coonrod
        ///  CREATED: 2020/4/10
        ///  APPROVER: Matt Deaton
        ///  
        ///  This is the click event to submit the form data to the database
        ///  It validates the form data, then creates a social media request object
        ///  to send through the manager to the accessor
        ///  
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            //The only validation happening on this form is that the strings
            //  from the text boxes are not empty
            //It is on the user creating the request to fill the fields out appropriately
            if (txtTitle.Text.Trim().Length > 0 && txtDescription.Text.Trim().Length > 0)
            {
                SocialMediaRequest newSocialMediaRequest = new SocialMediaRequest();
                newSocialMediaRequest.DateCreated = DateTime.Now;
                newSocialMediaRequest.Open = true;
                newSocialMediaRequest.RequestingUserID = _user.PUUserID;
                newSocialMediaRequest.RequestTypeID = "Social Media";
                newSocialMediaRequest.Title = txtTitle.Text;
                newSocialMediaRequest.Description = txtDescription.Text;

                MessageBoxResult confirmation = MessageBox.Show("Title:\n" + newSocialMediaRequest.Title
                    + "\n\nDescription:\n" + newSocialMediaRequest.Description
                    + "\n\nSend this request?", "Send Request", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (confirmation.Equals(MessageBoxResult.Yes))
                {
                    sendRequest(newSocialMediaRequest);
                }
            }
            else if (txtTitle.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a title for this post", "No Title", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtDescription.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a description for this post", "No Description", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
