using DataTransferObjects;
using LogicLayer;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/2
///  APPROVER: Lane Sandburg
///  
///  Controller for Time Off Requests
/// </summary>

namespace WPFPresentation.Controllers
{
    [Authorize]
    public class RequestTimeOffController : Controller
    {
        private IRequestManager _requestManager = null;
        LogicLayerInterfaces.IUserManager _usrMgr = null;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Constructor for instantiating the Request Manager
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/5/4
        /// UPDATE: Added a UserManager
        /// 
        /// </remarks>
        public RequestTimeOffController()
        {
            _requestManager = new RequestManager();
            _usrMgr = new LogicLayer.UserManager();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  View for submitting a new Time Off Request
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/5/4
        /// UPDATE: Checks if user exists as an employee to determine redirect
        /// 
        /// </remarks>
        // GET: RequestTimeOff
        public ActionResult Create(PetUniverseUser user, string startDateError = null, string endDateError = null)
        {
            ViewBag.Title = "Time Off Request";

            ViewBag.StartDateError = startDateError;
            ViewBag.EndDateError = endDateError;

            Session["RequestingUserID"] = user.PUUserID;

            //Checks if the user exists in the database as an employee
            if (_usrMgr.FindUser(User.Identity.GetUserName()))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Post method for Create, adds request only if it passes validation, redirects to same page with errors otherwise
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        // POST: TimeOffRequest/Create
        [HttpPost]
        public ActionResult Create(string startDate, string endDate)
        {
            if (ModelState.IsValid)
            {
                TimeOffRequest request = new TimeOffRequest()
                {
                    EffectiveStart = Convert.ToDateTime(startDate),
                    EffectiveEnd = Convert.ToDateTime(endDate)
                };

                // Code to save the TimeOffRequest
                try
                {
                    _requestManager.AddTimeOffRequest(request, Convert.ToInt32(Session["RequestingUserID"]));

                    return Json(Url.Action("Index", "ChooseRequestType", new { outputMessage = "SUCCESS: Time Off Request Submitted!" }));
                }
                catch
                {
                    return Json(Url.Action("Index", "ChooseRequestType", new { outputMessage = "ERROR: Could Not Submit Time Off Request" }));
                }
            }
            else
            {
                return View();
            }
        }
    }
}