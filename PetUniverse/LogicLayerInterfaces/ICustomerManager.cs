using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy , 2020/02/21
    ///
    /// This Interface that defines methods for Customer 
    /// </summary>
    public interface ICustomerManager
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/29/2020
        /// Approved By: 
        /// 
        /// This method for getting Customer by email, 
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="customerEmail"></param>     
        /// <returns>Customer</returns>
        Customer RetrieveCustomerByCustomerEmail(string customerEmail);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/17/2020
        /// Approver: Steven Cardona
        ///
        /// Retrieves a list of all active customers
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        ///
        /// <returns>List of all active customers</returns>
        List<Customer> RetrieveAllActiveCustomers();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/20/2020
        /// Approver: Steven Cardona
        /// 
        /// Method for the Identity System
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>        
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool FindCustomer(string email);


        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 4/25/2020
        /// Approver: Steven Cardona
        /// 
        /// This calls the User Authentication Data Accessor Method for customers
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Returns Valid User Info</returns>
        Customer AuthenticateCustomer(string email, string password);
    }
}
