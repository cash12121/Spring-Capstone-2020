using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/05
    ///  APPROVER: Matt Deaton
    ///  
    ///  Fake Donation Accessor Class for Unit Testing
    /// </summary>
    public class FakeDonationAccessor : IDonationAccessor
    {

        private List<Donation> _donations = new List<Donation>()
        {
            new Donation {
                DonationID = 1,
                DateOfDonation = DateTime.Now.AddYears(-2)
            },
            new Donation {
                DonationID = 2,
                DateOfDonation = DateTime.Now.AddMonths(-11)
            },
            new Donation {
                DonationID = 3,
                DateOfDonation = DateTime.Now.AddMonths(-4)
            },
            new Donation {
                DonationID = 4,
                DateOfDonation = DateTime.Now
            }
        };

        private List<RecurringDonationVM> _recurring = new List<RecurringDonationVM>()
        {
            new RecurringDonationVM
            {
                RecurringDonationID = 1,
                Active = true,
                UserName = "ryan"
            },
            new RecurringDonationVM
            {
                RecurringDonationID = 2,
                Active = true,
                UserName = "Bobby"
            },
            new RecurringDonationVM
            {
                RecurringDonationID = 3,
                Active = true,
                UserName = "ryan"
            }
        };

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Fake Donation Accessor Method to test the deactivation of a recurring
        ///  donation base off its ID.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int DeactivateRecurringDonation(int recurringDonationID)
        {
            return _recurring.Select(r => { r.Active = false; return r;}).Where(r => r.RecurringDonationID == recurringDonationID).Count();
            
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/16
        ///  APPROVER: Derek Taylor
        ///  
        ///  Fake Donation Accessor Method to test inserting a new recurring
        ///  donation record.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int InsertNewRecurringDonation(RecurringDonationVM donation)
        {
            List<RecurringDonationVM> rds = new List<RecurringDonationVM>();
            foreach (var r in _recurring)
            {
                rds.Add(r);
            }
            rds.Add(donation);

            return rds.Count();
        }



        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/05
        ///  APPROVER: Matt Deaton
        ///  
        ///  Fake Donation Accessor Method to test retrieval of donation history
        ///  for the past year.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<Donation> SelectDonationsFromPastYear()
        {
            var donations = (from d in _donations
                             where d.DateOfDonation > DateTime.Now.AddYears(-1)
                             select d).ToList();
            return donations;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Fake Donation Accessor Method to test retrieving one recurring donation record by
        ///  its ID.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public RecurringDonationVM SelectRecurringDonationByID(int id)
        {
            return (from r in _recurring
                    where r.RecurringDonationID == id
                    select r).Single();
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Fake Donation Accessor Method to test retrieving a collection of 
        ///  recurring donation records by their associated username.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<RecurringDonationVM> SelectRecurringDonationsByUser(string username)
        {
            return (from r in _recurring
                    where r.UserName == username
                    select r).ToList();
        }
    }
}
