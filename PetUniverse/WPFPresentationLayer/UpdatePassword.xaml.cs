using DataTransferObjects;
using LogicLayerInterfaces;
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
    /// Created: 4/24/2020
    /// Approver: Steven Cardona
    /// 
    /// This class controls the UpdatePassword window
    /// 
    /// </summary>
    public partial class UpdatePassword : Window
    {
        private PetUniverseUser _PUUser = null;
        private IUserManager _userManager = null;

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/24/2020
        /// Approver: Steven Cardona
        /// 
        /// This is a constructor for UpdatePassword class
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="PUUser"></param>
        /// <param name="UserManager"></param>
        public UpdatePassword(PetUniverseUser PUUser, IUserManager UserManager)
        {
            InitializeComponent();
            _PUUser = PUUser;
            _userManager = UserManager;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/24/2020
        /// Approver: Steven Cardona
        /// 
        /// Method used to change the password and check to make sure its valid
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (pwdCurrentUserPassword.Password.Length < 7)
            {
                MessageBox.Show("Current password is incorrect. Try again.");
                pwdCurrentUserPassword.Password = "";
                pwdCurrentUserPassword.Focus();
                return;
            }
            if (pwdNewUserPassword.Password.Length < 7 ||
                pwdNewUserPassword.Password == pwdCurrentUserPassword.Password)
            {
                MessageBox.Show("New password is incorrect. Try again.");
                pwdNewUserPassword.Password = "";
                pwdNewUserPassword.Focus();
                return;
            }
            if (pwdRetypeUserPassword.Password != pwdNewUserPassword.Password)
            {
                MessageBox.Show("New Password and Retype must match.");
                pwdNewUserPassword.Password = "";
                pwdRetypeUserPassword.Password = "";
                pwdNewUserPassword.Focus();
                return;
            }
            try
            {
                if (_userManager.UpdatePassword(_PUUser.PUUserID,
                    pwdNewUserPassword.Password.ToString(),
                    pwdCurrentUserPassword.Password.ToString()))
                {
                    MessageBox.Show("Password Updated");
                    btnSubmit.Visibility = Visibility.Hidden;
                    lblCurrentPassword.Visibility = Visibility.Hidden;
                    lblNewPassword.Visibility = Visibility.Hidden;
                    lblRetypePassword.Visibility = Visibility.Hidden;
                    pwdCurrentUserPassword.Visibility = Visibility.Hidden;
                    pwdNewUserPassword.Visibility = Visibility.Hidden;
                    pwdRetypeUserPassword.Visibility = Visibility.Hidden;
                    btnSecuritySubmit.Visibility = Visibility.Visible;
                    lblA1.Visibility = Visibility.Visible;
                    lblA2.Visibility = Visibility.Visible;
                    lblSecurityQuestion1.Visibility = Visibility.Visible;
                    lblQ2.Visibility = Visibility.Visible;
                    txtA2.Visibility = Visibility.Visible;
                    txtAnswer1.Visibility = Visibility.Visible;
                    txtQ1.Visibility = Visibility.Visible;
                    txtQ2.Visibility = Visibility.Visible;
                    lblSecurity.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Current password is incorrect. Try again.");
                    pwdCurrentUserPassword.Password = "";
                    pwdCurrentUserPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                this.DialogResult = false;
            }
        }

        private void btnSecuritySubmit_Click(object sender, RoutedEventArgs e)
        {
            _userManager.UpdateSecurityInfo(_PUUser.PUUserID, txtQ1.Text, txtQ2.Text, txtAnswer1.Text, txtA2.Text);
            MessageBox.Show("Security Questions Set!");
            this.DialogResult = true;
            this.Close();
        }
    }
}
