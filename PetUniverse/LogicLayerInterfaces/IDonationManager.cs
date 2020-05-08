using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/04
    ///  APPROVER: Matt Deaton
    ///  
    ///   Donation Manager Interface class
    /// </summary>
    public interface IDonationManager
    {
        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/04
        ///  APPROVER: Matt Deaton
        ///  
        ///  Donation Manager Interface method used when interacting with the logic layer to make requests
        ///  about Donations from the past year.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        List<Donation> RetrieveAllDonationsFromPastYear();

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/16
        ///  APPROVER: Derek Taylor
        ///  
        ///  Donation Manager Interface method used when creating a new recurring donation to move to the datastore
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        int CreateNewRecurringDonation(RecurringDonationVM donation);

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Donation Manager Interface method used when retrieving a collection of recurring donation
        ///  records by their associated username.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<RecurringDonationVM> RetrieveAllRecurringDonationsByUser(string username);

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Donation Manager Interface method used when removing a recurring donation record from active status.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        int DeleteRecurringDonation(int recurringDonationID);

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Donation Manager Interface method used when retrieving a single recurring donation record.
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        RecurringDonationVM RetrieveRecurringDonationByID(int id);
    }
}
