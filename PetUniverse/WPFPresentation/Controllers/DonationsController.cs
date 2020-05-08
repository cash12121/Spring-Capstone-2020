using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;

namespace WPFPresentation.Controllers
{
    public class DonationsController : Controller
    {
        private IDonationManager _donationManager;

        public DonationsController()
        {
            _donationManager = new DonationManager();
        }


        // GET: Donations
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Creator: Steve Coonrod
        /// Created: 2020/04/15
        /// Approver: Matt Deaton
        ///
        /// ActionResult Method to display the FAQ list
        /// </summary>
        /// <remarks>
        /// 
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <returns></returns>
        public ActionResult DonationFAQ()
        {
            return View();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/05
        /// Approver: Matt Deaton
        ///
        /// ActionResult Method to load a ListView of the Past Donations received by the
        /// PetUniverse Shelter
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        [Authorize]
        public ActionResult PastDonations()
        {
            ViewBag.Title = "PastDonations";
            var donations = _donationManager.RetrieveAllDonationsFromPastYear();
            return View(donations);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/16
        /// Approver: Derek Taylor
        ///
        /// ActionResult Method to load a Form for setting up a Recurring Donation linked
        /// to the user account currently logged in.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        [Authorize]
        public ActionResult NewRecurringDonation()
        {
            //ViewBag.IntervalList = GetIntervalList();
            ViewBag.Title = "NewRecurringDonation";
            return View(new RecurringDonationVM());
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/16
        /// Approver: Derek Taylor
        ///
        /// ActionResult Method to POST a newly set Recurring Donation for the current user.
        /// </summary>
        /// <remarks>
        /// Updator: Ryan Morganti
        /// Updated: 2020/04/29
        /// Update: Added Identity system to link current user
        ///
        /// </remarks>
        [Authorize]
        [HttpPost]
        public ActionResult NewRecurringDonation(RecurringDonationVM recurringDonation)
        {
            int result = 0;
            
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(User.Identity.GetUserId());
            recurringDonation.UserName = user.Email;
            if (ModelState.IsValid)
            {
                try
                {
                    result = _donationManager.CreateNewRecurringDonation(recurringDonation);
                    if (result == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    return View();
                }

            }
            return View();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/29
        /// Approver: Derek Taylor
        ///
        /// ActionResult Method to load a ListView of active Recurring Donations
        /// linked to the current user account.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        [Authorize]
        public ActionResult ActiveDonations()
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(User.Identity.GetUserId());
            var username = user.Email;
            List<RecurringDonationVM> donations = _donationManager.RetrieveAllRecurringDonationsByUser(username);
            var activeDonations = (from d in donations
                                   where d.Active == true
                                   select d).ToList();
            foreach(var d in activeDonations)
            {
                if(d.Interval < 3)
                {
                    d.IntervalVM = d.Interval > 1 ? "Monthly" : "Weekly";
                } else
                {
                    d.IntervalVM = "Yearly";
                }
                
            }
            return View(activeDonations);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/29
        /// Approver: Derek Taylor
        ///
        /// ActionResult Method to Confirm Cancellation of an active
        /// Recurring Donation for the current user account.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        [Authorize]
        public ActionResult CancelRecurringDonation(int id)
        {
            var donation = _donationManager.RetrieveRecurringDonationByID(id);
            return View(donation);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/29
        /// Approver: Derek Taylor
        ///
        /// ActionResult Method to POST confirmation of recurring donation cancellation
        /// for the current user account.  Will redirect back to the active recurring donation view
        /// if successful.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        [Authorize]
        [HttpPost]
        public ActionResult CancelRecurringDonation(int id, FormCollection collection)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                try
                {
                    result = _donationManager.DeleteRecurringDonation(id);
                    if (result == 1)
                    {
                        return RedirectToAction("ActiveDonations");
                    }
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
    }
}