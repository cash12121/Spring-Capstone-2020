using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/7/2020
    /// Approver: Steven Cardona
    /// 
    /// This class controls the MainWindow window
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {

        private DispatcherTimer dt = null;
        //15 minutes in seconds
        private static int time = 900;
        private PetUniverseUser _user = null;
        private int _userID = 0;
        private int loginCount = 0;
        private IUserManager _userManager;
        private bool isLocked = false;
        private DateTime unlockDate;


        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This is a constructor for the main window class
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _userManager = new UserManager();
            this.ShowDialog();
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used to login the user after they click the button
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 3/15/2020
        /// Update: Added code to create log source in the event viewer     
        ///         
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            // Create the source, if it does not already exist.
            if (!EventLog.SourceExists("PetUniverseLog"))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("PetUniverseLog", "PetUniverseLog");
                return;
            }

            // Create an EventLog instance and assign its source.
            EventLog PULog = new EventLog();
            PULog.Source = "PetUniverseLog";

            loginCount += 1;
            isLocked = false;
            var userEmail = txtEmail.Text;
            var userPassword = pwdPassword.Password;
            unlockDate = getUnlockDate(userEmail);

            //Validating input
            if (!userEmail.IsValidEmail())
            {
                //Display a message, always say user name or password bad 
                //so bad users aren't sure what is wrong
                WPFErrorHandler.ErrorMessage("Invalid Username or Password.", "Login");
                txtEmail.Focus();
                return;
            }
            else if (!userPassword.IsValidPassword())
            {
                WPFErrorHandler.ErrorMessage("Invalid Username or Password.", "Login");
                txtEmail.Focus();
                if (_userManager.CheckIfUserExists(userEmail) == true)
                {
                    if (DateTime.Now > unlockDate)
                    {
                        //won't log them in, but will count as an active attempt to login
                        if (loginCount >= 3)
                        {
                            isLocked = true;
                            UnlockByTime(userEmail);
                            if (dt == null)
                            {
                                setTimer();
                            }
                            Lockout(userEmail);
                            time = 901;
                            dt.Start();
                        }
                    }
                    else
                    {
                        LogHelper.log.Error("User " + txtEmail.Text + " is locked out");
                        isLocked = true;
                        UnlockByTime(userEmail);
                        if (dt == null)
                        {
                            setTimer();
                        }
                        Lockout(userEmail);
                        time = 901;
                        dt.Start();
                    }
                }
                return;
            }

            //Check if user is already locked out
            if (DateTime.Now > unlockDate)
            {
                //Make sure user actually exists
                if (_userManager.CheckIfUserExists(userEmail) == true)
                {
                    //try to login
                    try
                    {
                        _user = _userManager.AuthenticateUser(userEmail, userPassword);
                        {
                            string userRoles = "";
                            for (int i = 0; i < _user.PURoles.Count; i++)
                            {
                                userRoles += _user.PURoles[i];
                                if (i < _user.PURoles.Count - 1)
                                {
                                    userRoles += ", ";
                                }
                            }

                            if (pwdPassword.Password == "newuser")
                            {
                                var updatePassword = new UpdatePassword(_user, _userManager);
                                if (updatePassword.ShowDialog() == false)
                                {
                                    MessageBox.Show("You must change your password to continue");
                                    return;
                                }
                            }
                            else
                            {                             
                                this.Visibility = Visibility.Hidden;
                                //Log successful login
                                LogHelper.log.Info("Email: " + txtEmail.Text + " Successfully logged in.");
                                var petUniverseHome = new PetUniverseHome(_user, userRoles);
                            }                            
                        }
                    }
                    catch (Exception ex)
                    {
                        if (loginCount >= 3)
                        {
                            isLocked = true;
                            UnlockByTime(userEmail);
                            if (dt == null)
                            {
                                setTimer();
                            }
                            Lockout(userEmail);
                            time = 901;
                            dt.Start();
                        }

                        //Log failed login
                        LogHelper.log.Error("Someone failed to login using email: " + txtEmail.Text);
                        LogicLayerErrorHandler.LoginErrorMessage(ex.Message);
                    }
                }
                else
                {
                    LogicLayerErrorHandler.LoginErrorMessage("Login Error.");
                }
            }
            else
            {
                LogHelper.log.Error("User " + txtEmail.Text + " is locked out");
                isLocked = true;
                UnlockByTime(userEmail);
                if (dt == null)
                {
                    setTimer();
                }
                Lockout(userEmail);
                time = 901;
                dt.Start();
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/4/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used to lockout the user
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        ///         
        /// </remarks>
        /// <param name="userEmail"></param>
        public void Lockout(string userEmail)
        {
            try
            {

                _userManager.LockoutUser(userEmail, DateTime.Now, DateTime.Now.AddMinutes(15));
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.LoginErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/4/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used to unlock the user
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        ///         
        /// </remarks>
        /// <param name="userEmail"></param>
        public void UnlockByTime(string userEmail)
        {
            try
            {
                if (_userManager.UnlockUserByTime(userEmail) == true)
                {
                    lblLockoutMessage.Content = "";
                    isLocked = false;
                }
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.LoginErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/4/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used to check that the user exists
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        ///         
        /// </remarks>
        /// <param name="userEmail"></param>
        public void CheckIfUserExists(string userEmail)
        {
            try
            {
                if (_userManager.CheckIfUserExists(userEmail) == true)
                {

                    if (loginCount >= 3)
                    {
                        Lockout(userEmail);
                        dt.Stop();
                        setTimer();
                        dt.Start();
                        isLocked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.LoginErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used to get the actual unlock date from the db
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        ///         
        /// </remarks>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public DateTime getUnlockDate(string userEmail)
        {
            DateTime date = new DateTime();
            try
            {
                date = _userManager.fetchUnlockDate(userEmail);
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.LoginErrorMessage(ex.Message);
            }
            return date;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 3/5/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This Method is used to create the timer
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        ///         
        /// </remarks>
        public void setTimer()
        {
            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Tick += dtTicker;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 3/5/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This Method is used deduct the timer
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        ///         
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtTicker(object sender, EventArgs e)
        {
            time--;

            string sec;
            if ((time % 60).ToString().Length < 2)
            {
                sec = "0" + (time % 60).ToString();
            }
            else
            {
                sec = (time % 60).ToString();
            }
            lblLockoutMessage.Content = String.Format("User is locked out for {0}:{1}", time / 60, sec);

            // example if you want to do something to time at a specific time
            if (time == 0)
            {
                lblLockoutMessage.Content = "";
            }
        }

        //Change Password
        private void ResetPassword_Click(object sender, RoutedEventArgs e)
        {            
            var resetPassword = new ResetPassword();
        }
    }
}