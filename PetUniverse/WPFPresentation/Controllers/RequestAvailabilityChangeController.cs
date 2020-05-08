using DataTransferObjects;
using LogicLayer;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFPresentation.Models;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/16
///  APPROVER: Lane Sandburg
///  
///  Controller for Availability Change Requests
/// </summary>

namespace WPFPresentation.Controllers
{
    [Authorize]
    public class RequestAvailabilityChangeController : Controller
    {
        private IRequestManager _requestManager = null;
        LogicLayerInterfaces.IUserManager _usrMgr = null;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Constructor for instantiating a RequestManager
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/5/4
        /// UPDATE: Added UserManager
        /// 
        /// </remarks>
        public RequestAvailabilityChangeController()
        {
            _requestManager = new RequestManager();
            _usrMgr = new LogicLayer.UserManager();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  View for submitting a new Availability Change Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        // GET: RequestTimeOff
        public ActionResult Create(PetUniverseUser user)
        {
            ViewBag.Title = "Availability Change Request";

            Session["currentUserID"] = user.PUUserID;

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
        ///  CREATED: 2020/4/19
        ///  APPROVER: NA
        ///  
        ///  Post method for Create, submits the request, data already validated
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [HttpPost]
        public ActionResult Create(List<String> availabilityStringList)
        {
            List<AvailabilityRequestVM> availabilityRequestList = new List<AvailabilityRequestVM>();

            List<EmployeeAvailability> sundayAvailabilities = new List<EmployeeAvailability>();
            List<EmployeeAvailability> mondayAvailabilities = new List<EmployeeAvailability>();
            List<EmployeeAvailability> tuesdayAvailabilities = new List<EmployeeAvailability>();
            List<EmployeeAvailability> wednesdayAvailabilities = new List<EmployeeAvailability>();
            List<EmployeeAvailability> thursdayAvailabilities = new List<EmployeeAvailability>();
            List<EmployeeAvailability> fridayAvailabilities = new List<EmployeeAvailability>();
            List<EmployeeAvailability> saturdayAvailabilities = new List<EmployeeAvailability>();

            //Add each availability to a List of Availabilities for that day
            for (int i = 0; i < availabilityStringList.Count; i = i + 3)
            {
                string weekDay = availabilityStringList[i];
                string startTime = availabilityStringList[i + 1];
                string endTime = availabilityStringList[i + 2];

                switch (weekDay)
                {
                    case "Sunday":
                        sundayAvailabilities.Add(new EmployeeAvailability()
                        {
                            DayOfWeek = weekDay,
                            StartTime = startTime,
                            EndTime = endTime
                        });
                        break;
                    case "Monday":
                        mondayAvailabilities.Add(new EmployeeAvailability()
                        {
                            DayOfWeek = weekDay,
                            StartTime = startTime,
                            EndTime = endTime
                        });
                        break;
                    case "Tuesday":
                        tuesdayAvailabilities.Add(new EmployeeAvailability()
                        {
                            DayOfWeek = weekDay,
                            StartTime = startTime,
                            EndTime = endTime
                        });
                        break;
                    case "Wednesday":
                        wednesdayAvailabilities.Add(new EmployeeAvailability()
                        {
                            DayOfWeek = weekDay,
                            StartTime = startTime,
                            EndTime = endTime
                        });
                        break;
                    case "Thursday":
                        thursdayAvailabilities.Add(new EmployeeAvailability()
                        {
                            DayOfWeek = weekDay,
                            StartTime = startTime,
                            EndTime = endTime
                        });
                        break;
                    case "Friday":
                        fridayAvailabilities.Add(new EmployeeAvailability()
                        {
                            DayOfWeek = weekDay,
                            StartTime = startTime,
                            EndTime = endTime
                        });
                        break;
                    case "Saturday":
                        saturdayAvailabilities.Add(new EmployeeAvailability()
                        {
                            DayOfWeek = weekDay,
                            StartTime = startTime,
                            EndTime = endTime
                        });
                        break;
                }
            }

            //Determine which List has the most availabilities
            int maxCount = sundayAvailabilities.Count;
            if (mondayAvailabilities.Count > maxCount)
            {
                maxCount = mondayAvailabilities.Count;
            }
            else if (tuesdayAvailabilities.Count > maxCount)
            {
                maxCount = tuesdayAvailabilities.Count;
            }
            else if (wednesdayAvailabilities.Count > maxCount)
            {
                maxCount = wednesdayAvailabilities.Count;
            }
            else if (thursdayAvailabilities.Count > maxCount)
            {
                maxCount = thursdayAvailabilities.Count;
            }
            else if (fridayAvailabilities.Count > maxCount)
            {
                maxCount = fridayAvailabilities.Count;
            }
            else if (saturdayAvailabilities.Count > maxCount)
            {
                maxCount = saturdayAvailabilities.Count;
            }

            //Create a number of AvailabilityRequests equal to the maxCount
            while (maxCount > 0)
            {
                availabilityRequestList.Add(new AvailabilityRequestVM()
                {
                    SundayStartTime = "",
                    SundayEndTime = "",
                    MondayStartTime = "",
                    MondayEndTime = "",
                    TuesdayStartTime = "",
                    TuesdayEndTime = "",
                    WednesdayStartTime = "",
                    WednesdayEndTime = "",
                    ThursdayStartTime = "",
                    ThursdayEndTime = "",
                    FridayStartTime = "",
                    FridayEndTime = "",
                    SaturdayStartTime = "",
                    SaturdayEndTime = ""
                });
                maxCount--;
            }

            //Add each Availability for the same day to another AvailabilityRequest
            for (int i = 0; i < sundayAvailabilities.Count; i++)
            {
                availabilityRequestList[i].SundayStartTime = sundayAvailabilities[i].StartTime + ":00";
                availabilityRequestList[i].SundayEndTime = sundayAvailabilities[i].EndTime + ":00";
            }
            for (int i = 0; i < mondayAvailabilities.Count; i++)
            {
                availabilityRequestList[i].MondayStartTime = mondayAvailabilities[i].StartTime + ":00";
                availabilityRequestList[i].MondayEndTime = mondayAvailabilities[i].EndTime + ":00";
            }
            for (int i = 0; i < tuesdayAvailabilities.Count; i++)
            {
                availabilityRequestList[i].TuesdayStartTime = tuesdayAvailabilities[i].StartTime + ":00";
                availabilityRequestList[i].TuesdayEndTime = tuesdayAvailabilities[i].EndTime + ":00";
            }
            for (int i = 0; i < wednesdayAvailabilities.Count; i++)
            {
                availabilityRequestList[i].WednesdayStartTime = wednesdayAvailabilities[i].StartTime + ":00";
                availabilityRequestList[i].WednesdayEndTime = wednesdayAvailabilities[i].EndTime + ":00";
            }
            for (int i = 0; i < thursdayAvailabilities.Count; i++)
            {
                availabilityRequestList[i].ThursdayStartTime = thursdayAvailabilities[i].StartTime + ":00";
                availabilityRequestList[i].ThursdayEndTime = thursdayAvailabilities[i].EndTime + ":00";
            }
            for (int i = 0; i < fridayAvailabilities.Count; i++)
            {
                availabilityRequestList[i].FridayStartTime = fridayAvailabilities[i].StartTime + ":00";
                availabilityRequestList[i].FridayEndTime = fridayAvailabilities[i].EndTime + ":00";
            }
            for (int i = 0; i < saturdayAvailabilities.Count; i++)
            {
                availabilityRequestList[i].SaturdayStartTime = saturdayAvailabilities[i].StartTime + ":00";
                availabilityRequestList[i].SaturdayEndTime = saturdayAvailabilities[i].EndTime + ":00";
            }

            //Submit each AvailabilityRequest with the same RequestID
            foreach (AvailabilityRequestVM request in availabilityRequestList)
            {
                try
                {
                    _requestManager.AddAvailabilityRequest(request, Convert.ToInt32(Session["currentUserID"]));
                }
                catch (Exception ex)
                {
                    return Json(Url.Action("Index", "ChooseRequestType", new { outputMessage = "ERROR: Availability Change Request Could Not Submit!" }));
                }
            }
            return Json(Url.Action("Index", "ChooseRequestType", new { outputMessage = "SUCCESS: Availability Change Request Submitted!" }));
        }
    }
}