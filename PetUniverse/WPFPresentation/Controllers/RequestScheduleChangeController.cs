using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WPFPresentation.Models;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/2
///  APPROVER: Lane Sandburg
///  
///  Controller for Schedule Change Requests
/// </summary>
namespace WPFPresentation.Controllers
{
    [Authorize]
    public class RequestScheduleChangeController : Controller
    {
        private IRequestManager _requestManager = null;
        private IShiftManager _shiftManager = null;
        LogicLayerInterfaces.IUserManager _usrMgr = null;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Constructor for instantiating RequestManager and ShiftManager
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/5/4
        /// UPDATE: Added UserManager
        /// 
        /// </remarks>
        public RequestScheduleChangeController()
        {
            _requestManager = new RequestManager();
            _usrMgr = new LogicLayer.UserManager();
            _shiftManager = new ShiftManager();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///  View for submitting a new Schedule Change Request
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/5/4
        /// UPDATE: Checks if user exists as an employee to determine redirect
        /// 
        /// </remarks>
        // GET: RequestScheduleChange
        public ActionResult Create(int userID, string selectedDate)
        {
            UserWithShiftList model = new UserWithShiftList();

            ViewBag.Title = "Schedule Change Request";

            //Checks if the user exists in the database as an employee
            if (_usrMgr.FindUser(User.Identity.GetUserName()))
            {
                //Force past dates to be tomorrow
                if (Convert.ToDateTime(selectedDate) <= DateTime.Now)
                {
                    selectedDate = DateTime.Now.AddDays(1).ToShortDateString();
                }

                ViewBag.SelectedDate = selectedDate;

                Session["currentUserID"] = userID;

                if (0 != userID)
                {
                    //Get all of current user's shifts, one time only
                    if (null == (List<ShiftVM>)Session["userShiftList"])
                    {
                        Session["userShiftList"] = _shiftManager.RetrieveShiftsByUser(userID);
                    }

                    List<ShiftVM> selectedShiftList = new List<ShiftVM>();

                    //Add all shifts on the selected date to a list
                    foreach (var shift in (List<ShiftVM>)Session["userShiftList"])
                    {
                        if (Convert.ToDateTime(shift.Date) == Convert.ToDateTime(selectedDate))
                        {
                            selectedShiftList.Add(shift);
                        }
                    }

                    //Build a SelectListItem List
                    List<SelectListItem> shiftListSelectList = new List<SelectListItem>();
                    shiftListSelectList.Add(new SelectListItem()
                    {
                        Text = "-- Select a Shift --",
                        Value = ""
                    });
                    foreach (ShiftVM shift in selectedShiftList)
                    {
                        shiftListSelectList.Add(new SelectListItem()
                        {
                            Text = "Department: " + shift.Department + " Date: " + shift.Date + " Time: " + shift.StartTime + " - " + shift.EndTime,
                            Value = shift.ShiftID.ToString()
                        });
                    }
                    ViewBag.ShiftList = shiftListSelectList;

                    model.UserID = userID;
                }
                return View(model);
            }
            else //User is not an employee
            {
                return RedirectToAction("Login", "Account");
            }
        }


        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Post method for Create, submits the request if a shift was selected.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [HttpPost]
        public ActionResult CreateRequest(int shiftID, string shiftDate)
        {
            try
            {
                ScheduleChangeRequest request = new ScheduleChangeRequest();
                request.ShiftID = shiftID;

                _requestManager.AddScheduleChangeRequest(request, Convert.ToInt32(Session["currentUserID"]));

                return Json(Url.Action("Index", "ChooseRequestType", new { outputMessage = "SUCCESS: Schedule Change Request Submitted!" }));
            }
            catch (Exception ex) //Null selection, return to selection page with same date
            {
                return Json(Url.Action("Create", "RequestScheduleChange", new { userID = Session["currentUserID"], selectedDate = shiftDate }));
            }
        }


        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/30
        ///  APPROVER: NA
        ///  
        ///  This Action method is needed for JQuery Ajax redirects to work with the real Create GET action above
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        // GET: RequestScheduleChange
        public ActionResult CreateAjax(int userID, string selectedDate)
        {
            //When coming from an Ajax redirect, return View() will never work. This is the simplest way to fix this problem.
            return Json(Url.Action("Create", "RequestScheduleChange", new { userID = userID, selectedDate = selectedDate }));
        }
    }
}