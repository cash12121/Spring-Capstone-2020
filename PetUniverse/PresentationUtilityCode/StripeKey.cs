using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationUtilityCode
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/29/2020
    /// Approver: Jaeho Kim
    /// 
    /// Holds Stripe Keys, necessary for payment processing.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public static class StripeKey
    {
        private static readonly string _pKey = "pk_test_wa6e9NsSa4pcsAAiy3ghrCgF00SEQIB6t9";
        private static readonly string _sKey = "sk_test_LwRdJba4TJC91iOfd401NOxY00MuxLrgmJ";

        public static string SecretKey
        {
            get
            {
                return _sKey;
            }
        }

        public static string PublicKey
        {
            get
            {
                return _pKey;
            }
        }
    }
}
