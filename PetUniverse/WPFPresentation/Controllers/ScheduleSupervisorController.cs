using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WPFPresentation.Controllers
{
    public class ScheduleSupervisorController : Controller
    {
        private UserManager _userManager = new UserManager();
        private IShiftTimeManager _shiftTimeManager = new ShiftTimeManager();
        private ApplicationUserManager userManager;
        private IShiftManager _shiftManager = new ShiftManager();

        // GET: ScheduleSupervisor
        // GET: ScheduleVolunteer/ShiftCalendar/5
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 04/25/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Creates a calendar for Shifts by viewing employee
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ShiftCalendarEmployee(int? id)
        {
            var userId = User.Identity.GetUserId();
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == userId);
            //make sure logged in user has an active employee id
            if (_userManager.RetrieveAllActivePetUniverseUsers().Find(us => us.PUUserID == user.EmployeeID) != null)
            {
                int employeeID = (int)user.EmployeeID;
                ViewBag.name = _userManager.RetrieveAllActivePetUniverseUsers().Find(pu => pu.PUUserID == employeeID).FirstName + " " + _userManager.RetrieveAllActivePetUniverseUsers().Find(pu => pu.PUUserID == employeeID).LastName;
                if (id != null)
                {
                    //Make sure the shift belongs to that user
                    if (_shiftManager.RetrieveShiftsByUser(employeeID).Find(shift => shift.ShiftID == id) != null)
                    {
                        ViewBag.ShiftID = (int)id;
                        var shiftDetails = _shiftManager.RetrieveShfitDetailsByID((int)id);
                        ViewBag.ShiftDetails = shiftDetails;
                    }

                }
                else
                {
                    ViewBag.ShiftID = null;
                }
                var shifts = _shiftManager.RetrieveShfitDetailsByUserID(employeeID);
                if (shifts.Count > 0)
                {
                    DateTime? latestDate = shifts.Max(r => r.ShiftDate);
                    ViewBag.DefaultDate = Convert.ToDateTime(latestDate).ToShortDateString();
                }
                else
                {
                    ViewBag.DefaultDate = "";
                }
                return View(shifts);

            }
            else
            {
                return RedirectToAction("Login", "Account", Url.Action("Home/Index"));
            }
        }
    }
}