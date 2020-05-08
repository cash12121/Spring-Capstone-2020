using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/04
    ///  APPROVER: Matt Deaton
    ///  
    ///   Donation Manager class to handle the logic of querying for data about donations
    /// </summary>
    public class DonationManager : IDonationManager
    {
        private IDonationAccessor _donationAccessor;

        public DonationManager()
        {
            _donationAccessor = new DonationAccessor();
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/05
        ///  APPROVER: Matt Deaton
        ///  
        /// Constructor for passing a particular DonationAccessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public DonationManager(IDonationAccessor donationAccessor)
        {
            _donationAccessor = donationAccessor;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/16
        ///  APPROVER: Derek Taylor
        ///  
        ///  Donation Manager method used creating a newly scheduled RecurringDonation.
        ///  Method will pass data on to the data store access layer and return a successful or failed result.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int CreateNewRecurringDonation(RecurringDonationVM donation)
        {
            int result = 0;

            try
            {
                result = _donationAccessor.InsertNewRecurringDonation(donation);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not schedule a new Recurring Donation", ex);
            }

            return result;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Donation Manager method used to alter the active status of a recurring
        ///  donation record.  Stopping recurring donations associated with it.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int DeleteRecurringDonation(int recurringDonationID)
        {
            int result = 0;

            try
            {
                result = _donationAccessor.DeactivateRecurringDonation(recurringDonationID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not cancel recurring donation", ex);
            }

            return result;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/04
        ///  APPROVER: Matt Deaton
        ///  
        ///  Donation Manager method for retrieving a list of donations from the past year.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<Donation> RetrieveAllDonationsFromPastYear()
        {
            List<Donation> donations = new List<Donation>();

            try
            {
                donations = _donationAccessor.SelectDonationsFromPastYear();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not locate past donations", ex);
            }

            return donations;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Donation Manager method used to retrieve a collection of recurring donation records
        ///  from the associated username.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<RecurringDonationVM> RetrieveAllRecurringDonationsByUser(string username)
        {
            List<RecurringDonationVM> donations = new List<RecurringDonationVM>();

            try
            {
                donations = _donationAccessor.SelectRecurringDonationsByUser(username);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not locate recurring donations", ex);
            }

            return donations;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Donation Manager method used to retrieve a single recurring donation record with
        ///  its associated ID.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public RecurringDonationVM RetrieveRecurringDonationByID(int id)
        {
            try
            {
                return _donationAccessor.SelectRecurringDonationByID(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not locate recurring donations", ex);
            }
        }
    }
}
