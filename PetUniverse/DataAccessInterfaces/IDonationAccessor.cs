using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/04
    ///  APPROVER: Matt Deaton
    ///  
    ///   Donation Access class for connection to the database when making donation relation queries
    /// </summary>
    public interface IDonationAccessor
    {
        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/04
        ///  APPROVER: Matt Deaton
        ///  
        ///  Interface method to interact with the Donation Access class when querying about the 
        ///  past year's donation history.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<Donation> SelectDonationsFromPastYear();

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/16
        ///  APPROVER: Derek Taylor
        ///  
        ///  Interface method to interact with the Donation Access class when inserting a new
        ///  recurring donation record.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        int InsertNewRecurringDonation(RecurringDonationVM donation);

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Interface method to interact with the Donation Access class when selecting a collection
        ///   of recurring donation records by their associated username.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<RecurringDonationVM> SelectRecurringDonationsByUser(string username);

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Interface method to interact with the Donation Access class when deactivating a
        ///  recurring donation record, identified by its ID.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        int DeactivateRecurringDonation(int recurringDonationID);

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Interface method to interact with the Donation Access class when selecting a 
        ///  recurring donation record by its ID.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        RecurringDonationVM SelectRecurringDonationByID(int id);
    }
}
