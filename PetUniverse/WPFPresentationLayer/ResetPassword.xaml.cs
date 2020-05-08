using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
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
using System.Windows.Shapes;

namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 4/29/2020
    /// Approver: Steven Cardona
    /// 
    /// This class controls the ResetPasword window
    /// 
    /// </summary>
    public partial class ResetPassword : Window
    {
        IUserManager _userManager = new UserManager();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        /// 
        /// This is a constructor for the resetWindow class
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        public ResetPassword()
        {            
            InitializeComponent();
            ShowDialog();            
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        /// 
        /// This is a method that happens on the initial submit click
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_userManager.CheckIfUserExists(txtEmail.Text))
                {
                    PetUniverseUser user = _userManager.getUserByEmail(txtEmail.Text);
                    //T
                    if(user.SecurityQuestion1 != null)
                    {
                        lblSecurityQ1.Content = user.SecurityQuestion1;
                        lblSecurityQ2.Content = user.SecurityQuestion2;
                        lblSecurityQ1.Visibility = Visibility.Visible;
                        lblSecurityQ2.Visibility = Visibility.Visible;
                        txtAnswer1.Visibility = Visibility.Visible;
                        txtAnswer2.Visibility = Visibility.Visible;
                        btnSubmit.Visibility = Visibility.Hidden;
                        btnSubmitConfirm.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Contact an admin!.");
                    }
                }
                else
                {
                    MessageBox.Show("No records of this user.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        /// 
        /// This takes you back to the login screen
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {            
            this.Visibility = Visibility.Hidden;
            this.Close();
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        /// 
        /// This allows the user to attempt to answer the security questions they set
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitConfirm_Click(object sender, RoutedEventArgs e)
        {
            PetUniverseUser user = _userManager.getUserByEmail(txtEmail.Text);

            if(user.SecurityAnswer1 == txtAnswer1.Text && user.SecurityAnswer2 == txtAnswer2.Text)
            {
                lblSecurityQ1.Visibility = Visibility.Hidden;
                lblSecurityQ2.Visibility = Visibility.Hidden;
                txtAnswer1.Visibility = Visibility.Hidden;
                txtAnswer2.Visibility = Visibility.Hidden;
                btnSubmit.Visibility = Visibility.Hidden;
                btnSubmitConfirm.Visibility = Visibility.Hidden;

                txtNewPassword.Visibility = Visibility.Visible;
                lblNewPassword.Visibility = Visibility.Visible;
                btnEnterPassword.Visibility = Visibility.Visible;
                lblEmail.Visibility = Visibility.Hidden;
                txtEmail.Visibility = Visibility.Hidden;

            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        /// 
        /// This Allows the user to change their password
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnterPassword_Click(object sender, RoutedEventArgs e)
        {
            PetUniverseUser user = _userManager.getUserByEmail(txtEmail.Text);

            if (txtNewPassword.Password.IsValidPassword())
            {
                _userManager.UpdatePasswordHashBySecurity(user.PUUserID, txtNewPassword.Password);
                MessageBox.Show("Password Reset!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Password does not reach requirements!");
            }
        }
    }
}