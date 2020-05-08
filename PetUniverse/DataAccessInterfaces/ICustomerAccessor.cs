using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 02/19/2020
    /// Approver: Thomas Dupuy, 02/21/2020
    ///
    /// This interface for accessing Customer data.
    /// </summary>
    public interface ICustomerAccessor
    {

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approver: Thomas Dupuy, 02/21/2020
        /// 
        /// This method gets a customer by the Customer Email. 
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="customerName"></param>
        /// <returns> a customer </returns>
        /// 
        Customer RetrieveCustomerByCustomerEmail(string customerEmail);

        /// <summary>
        /// Creator: Zach Bherensmeyer
        /// Created: 4/17/2020
        /// Approver: Steven Cardona
        ///
        /// Interface method signature for selecting all active customers
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>Returns a list of active customers</returns>
        List<Customer> SelectAllActiveCustomers();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/25/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to authenticate the customer and make sure they exist for login
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        Customer AuthenticateCustomer(string username, string passwordHash);        
    }
}