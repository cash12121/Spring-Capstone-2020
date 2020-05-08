using DataTransferObjects;
using PresentationUtilityCode;
using Stripe;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Interaction logic for frmCardEntry.xaml
    /// </summary>
    public partial class frmCardEntry : Window
    {
        private AmountDue _due;
        private Transaction _transaction;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Constructor that utilizes AmountDue to persist data between windows.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="due"></param>
        /// <param name="transaction"></param>
        public frmCardEntry(AmountDue due, Transaction transaction)
        {
            InitializeComponent();
            lblChargeAmount.Content = "Amount Due: " + due.Amount.ToString("C");
            _due = due;
            _transaction = transaction;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Closes the window when cancel is selected.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Utilizes Stripe API to charge a card for the remaining amount of a transaction.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCharge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StripeConfiguration.ApiKey = StripeKey.SecretKey;
                string cardnumber = removeMask(txtCardnumber.Text);
                var tokenOptions = new TokenCreateOptions
                {
                    Card = new CreditCardOptions
                    {
                        Number = cardnumber,
                        ExpYear = int.Parse(txtExpiration.Text.Substring(txtExpiration.Text.Length - 2)),
                        ExpMonth = int.Parse(txtExpiration.Text.Substring(0, 2)),
                        Cvc = removeMask(txtCSC.Text)
                    }
                };
                
                var tokenService = new TokenService();
                var stripeToken = tokenService.Create(tokenOptions);

                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt32(_due.Amount * 100), //Amount is in cents, amount in AmountDue is stored as a decimal
                    Currency = "usd",
                    Description = "Thank you for your PetUniverse purchase.",
                    Source = stripeToken.Id
                };

                var service = new ChargeService();
                Charge charge = service.Create(chargeOptions);
                if (charge.Paid)
                {
                    _transaction.StripeChargeID = charge.Id;
                    _due.Amount = 0m;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue charging your card: " + ex.Message);
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Returns just the digits of a string, used to remove character artifacts from MaskedTextBoxes.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="s"></param>
        /// <returns></returns>
        private string removeMask(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                Regex regex = new Regex("\\d");
                string toCheck = s[i].ToString();
                if (regex.IsMatch(toCheck))
                {
                    sb.Append(toCheck);
                }
            }

            return sb.ToString();
        }
    }
}
