using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WPFPresentation.Controllers
{
    public class VolunteerShiftController : Controller
    {
        private UserManager _userManager = new UserManager();
        private IVolunteerShiftManager _volunteerShiftManager = new VolunteerShiftManager();

        // GET: VolunteerShift
        public ActionResult Index(int? id)
        {
            //Get lastest date and set the calendar to default there
            int shiftId = 10000;
            if (_volunteerShiftManager.ReturnAllVolunteerShifts() != null)
            {
                ViewBag.allShifts = _volunteerShiftManager.ReturnAllVolunteerShifts();

                //Get most rectent event's date
                var volunteerShifts = _volunteerShiftManager.ReturnAllVolunteerShifts();
                DateTime latestDate = volunteerShifts.Max(r => r.VolunteerShiftDate);
                // create veiwbag.shiftdetails

                ViewBag.DefaultDate = latestDate.ToShortDateString();
            }
            else
            {
                ViewBag.allShifts = "No shifts found";
                ViewBag.DefaultDate = "";
            }


            if (id != null)
            {
                if (_volunteerShiftManager.SelectVolunteerShift(shiftId) != null)
                {
                    ViewBag.ShiftId = (int)id;
                    var volunteerShiftDetails = _volunteerShiftManager.SelectVolunteerShift((int)id);
                    ViewBag.VolunteerShiftDetails = volunteerShiftDetails;

                }
            }

            var shifts = _volunteerShiftManager.ReturnAllVolunteerShifts();
            return View(shifts);
        }
    }
}