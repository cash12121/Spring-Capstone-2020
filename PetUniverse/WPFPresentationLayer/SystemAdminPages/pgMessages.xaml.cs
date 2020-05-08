using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.SystemAdminPages
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 3/16/2020
    /// Appover: Steven Cardona
    /// 
    /// This class controls pgMessages
    /// 
    /// </summary>
    public partial class pgMessages : Page
    {

        private IMessagesManager _messagesManager;
        private IUserManager _userManager;
        private PetUniverseUser _user;

        //Using a data table here because I don't provide the email in the table. 
        //I wanted to bind this data to a datagrid and this seemed like a reasonable solution.
        DataTable messageTable = new DataTable("MessagesDT");

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// This is a no arg constructor for the pgMessage Page
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        public pgMessages()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// This is a constructor for the pgMessage View to pass a user 
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        public pgMessages(PetUniverseUser user)
        {
            _messagesManager = new MessagesManager();
            _userManager = new UserManager();
            this._user = user;
            InitializeComponent();
            //Hide reply button because it populates fields for you, if no message is selected that button should be hidden.
            btnReply.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover:Steven Cardona
        /// 
        /// When btnCompose is clicked. Changes visible canvas
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/1/2020
        /// Update: Set message content to empty on btncompose click
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompose_Click(object sender, RoutedEventArgs e)
        {
            canViewMessages.Visibility = Visibility.Hidden;
            canSendMessage.Visibility = Visibility.Visible;
            txtMessage.Text = "";
            txtRecipient.Text = "";
            txtSubject.Text = "";
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// When btnSend is clicked. It sends a message and goes back to view emails page
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 3/27/2020
        /// Update: Added Send to All logic
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            List<PetUniverseUser> users = new List<PetUniverseUser>();

            //Make sure user is not sending empty messages.
            if (txtRecipient.Text == "")
            {
                WPFErrorHandler.ErrorMessage("Must have a recipient");
            }
            else if (txtSubject.Text == "" && txtMessage.Text == "")
            {
                WPFErrorHandler.ErrorMessage("Please enter subject and message");
            }
            else if (txtSubject.Text == "")
            {
                WPFErrorHandler.ErrorMessage("Please enter subject");
            }
            else if (txtMessage.Text == "")
            {
                WPFErrorHandler.ErrorMessage("Please enter message");
            }
            else
            {
                //Logic to send to all users at once
                if (txtRecipient.Text == "All" || txtRecipient.Text == "all")
                {
                    users = _userManager.RetrieveAllActivePetUniverseUsers();

                    foreach (PetUniverseUser newuser in users)
                    {
                        try
                        {
                            _messagesManager.sendEmail(txtMessage.Text, txtSubject.Text, _user.PUUserID, newuser.PUUserID);
                        }
                        catch (Exception ex)
                        {
                            WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
                        }
                    }
                    users = null;
                    canSendMessage.Visibility = Visibility.Hidden;
                    canViewMessages.Visibility = Visibility.Visible;
                    txtMessage.Text = "";
                    txtRecipient.Text = "";
                    txtSubject.Text = "";
                }

                //Only things that can be sent to are emails, all, and departments, if the department exists it will send
                else if (!txtRecipient.Text.Contains("@"))
                {
                    users = _userManager.GetDepartmentUsers(txtRecipient.Text);

                    foreach (PetUniverseUser newuser in users)
                    {
                        try
                        {
                            _messagesManager.sendEmail(txtMessage.Text, txtSubject.Text, _user.PUUserID, newuser.PUUserID);
                        }
                        catch (Exception ex)
                        {
                            WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
                        }
                    }
                    users = null;
                    canSendMessage.Visibility = Visibility.Hidden;
                    canViewMessages.Visibility = Visibility.Visible;
                    txtMessage.Text = "";
                    txtRecipient.Text = "";
                    txtSubject.Text = "";
                }

                //Sends message to email
                else
                {
                    sendEmail();
                    canSendMessage.Visibility = Visibility.Hidden;
                    canViewMessages.Visibility = Visibility.Visible;
                    txtMessage.Text = "";
                    txtRecipient.Text = "";
                    txtSubject.Text = "";
                }
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// Logic for smart search on emails and departments
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRecipient_KeyUp(object sender, KeyEventArgs e)
        {
            string query = (sender as TextBox)?.Text;
            List<string> departments = new List<string>();
            List<string> users = new List<string>();
            List<string> results = new List<string>();

            string value = txtRecipient.Text;

            //Hide autocomplete list
            if (query != null && query.Length == 0)
            {
                dgAutoComplete.Visibility = Visibility.Collapsed;
            }
            else
            {
                //Get the department
                try
                {
                    departments = _messagesManager.RetrieveDepartmentsLikeInput(value);
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message);
                }
                try
                {
                    //Get the user
                    users = _messagesManager.GetUsersLikeInput(value);
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message);
                }

                //Filter for All
                if (txtRecipient.Text == "a" || txtRecipient.Text == "A" || txtRecipient.Text == "Al" || txtRecipient.Text == "al" || txtRecipient.Text == "All" || txtRecipient.Text == "all")
                {
                    results.Add("All");
                }

                if (departments.Count > 0)
                {
                    foreach (string dep in departments)
                    {
                        results.Add(dep);
                    }
                }

                if (users.Count > 0)
                {
                    foreach (string user in users)
                    {
                        results.Add(user);
                    }
                }

                if (users.Count == 0 && departments.Count == 0)
                {
                    dgAutoComplete.Visibility = Visibility.Collapsed;
                }

                if (results.Count > 0)
                {
                    dgAutoComplete.Visibility = Visibility.Visible;
                    dgAutoComplete.ItemsSource = results;
                }
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// Allows user to select search item from list
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAutoComplete_MouseUp(object sender, MouseButtonEventArgs e)
        {
            txtRecipient.Text = dgAutoComplete.SelectedItem.ToString();
            dgAutoComplete.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// Logic to hide list search when it loses focus
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAutoComplete_LostFocus(object sender, RoutedEventArgs e)
        {
            dgAutoComplete.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// DataAccessor for get user by Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int getUserIDByEmail(string recipient)
        {
            PetUniverseUser _recipient = new PetUniverseUser();
            try
            {
                _recipient = _userManager.getUserByEmail(recipient);
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
            }
            return _recipient.PUUserID;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// Logic to send message
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendEmail()
        {
            int recipient = getUserIDByEmail(txtRecipient.Text);
            try
            {
                _messagesManager.sendEmail(txtMessage.Text, txtSubject.Text, _user.PUUserID, recipient);
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/01/2020
        /// Appover: Steven Cardona
        /// 
        /// Logic to get messages for current user and build a data table
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns></returns>
        private DataTable getMessages()
        {

            messageTable.Rows.Clear();
            List<Messages> messages = new List<Messages>();

            if (!messageTable.Columns.Contains("Sender"))
            {
                messageTable.Columns.Add(new DataColumn()
                {
                    ColumnName = "Sender",
                    DataType = typeof(string)
                });
                messageTable.Columns.Add(new DataColumn()
                {
                    ColumnName = "Subject",
                    DataType = typeof(string)
                });
                messageTable.Columns.Add(new DataColumn()
                {
                    ColumnName = "MessageBody",
                    DataType = typeof(string)
                });
                messageTable.Columns.Add(new DataColumn()
                {
                    ColumnName = "MessageID",
                    DataType = typeof(int)
                });
                messageTable.Columns.Add(new DataColumn()
                {
                    ColumnName = "SenderID",
                    DataType = typeof(int)
                });
                messageTable.Columns.Add(new DataColumn()
                {
                    ColumnName = "Seen",
                    DataType = typeof(bool)
                });
            }

            //Fill table data
            try
            {
                if (_messagesManager != null)
                {
                    messages = _messagesManager.GetMessagesByRecipient(_user.PUUserID);
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
            }

            foreach (var m in messages)
            {
                PetUniverseUser Sender = _userManager.getUserByUserID(m.SenderID);

                messageTable.Rows.Add(Sender.Email.ToString(), m.MessageSubject, m.MessageBody, m.MessageID, m.SenderID, m.Seen);
            }
            return messageTable;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/01/2020
        /// Appover: Steven Cardona
        /// 
        /// Page load logic
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns></returns>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var messageTable = getMessages();

            dgMessages.ItemsSource = messageTable.DefaultView;

            foreach (var column in this.dgMessages.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
            dgMessages.Columns.RemoveAt(2);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/01/2020
        /// Appover: Steven Cardona
        /// 
        /// Message Double Click Logic
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns></returns>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgMessages_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Show reply
            btnReply.Visibility = Visibility.Visible;

            //Creating row value from selected item
            DataRowView selected = dgMessages.SelectedItem as DataRowView;
            if (selected != null)
            {
                //Set message to send context
                txtMessageContent.Text = selected["MessageBody"].ToString();
                txtRecipient.Text = selected["Sender"].ToString();

                //Mocking reply subject
                if (!selected["Subject"].ToString().Contains("RE:"))
                {
                    txtSubject.Text = "RE: " + selected["Subject"].ToString();
                }
                else
                {
                    txtSubject.Text = selected["Subject"].ToString();
                }

                //Set the message as seen so it loses bolding
                _messagesManager.setMessageSeen(Convert.ToInt32(selected["MessageID"]));

                if (Convert.ToBoolean(selected["Seen"]) == false)
                {
                    getMessages();
                }
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/01/2020
        /// Appover: Steven Cardona
        /// 
        /// btnReply click logic
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns></returns>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReply_Click(object sender, RoutedEventArgs e)
        {
            canSendMessage.Visibility = Visibility.Visible;
            canViewMessages.Visibility = Visibility.Hidden;
        }
    }
}
