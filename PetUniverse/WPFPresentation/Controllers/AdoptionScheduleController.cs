using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System.Web.Mvc;

namespace WPFPresentation.Controllers
{
    /// <summary>
    /// NAME: Thomas Dupuy
    /// DATE: 3/19/2020
    /// CHECKED BY: Michael Thompson
    /// 
    /// This Controller lets the customer schedule their next appointment
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionScheduleController : Controller
    {
        private IAppointmentManager _appointmentManager = null;
        private ILocationManager _locationManager = null;

        public AdoptionScheduleController()
        {
            _appointmentManager = new AppointmentManager();
            _locationManager = new LocationManager();
        }

        // GET: Schedules
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// NAME: Thomas Dupuy
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This Method returns the view to create the Interview
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        // GET: Schdules/CreateInterviewAppointment
        public ActionResult CreateInterview()
        {
            ViewBag.Title = "Add A New Interview Appointment";
            return View();
        }

        /// <summary>
        /// NAME: Thomas Dupuy
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This Method creats a new location and appointment based on the customer's info
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        // POST: Schdules/CreateInterviewAppointment
        [HttpPost]
        public ActionResult CreateInterview(AppointmentLocationVM appointmentLocationVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Location location = new Location()
                    {
                        LocationID = appointmentLocationVM.LocationID,
                        Name = appointmentLocationVM.LocationName,
                        Address1 = appointmentLocationVM.LocationAddress1,
                        Address2 = appointmentLocationVM.LocationAddress2,
                        City = appointmentLocationVM.LocationCity,
                        State = appointmentLocationVM.LocationState,
                        Zip = appointmentLocationVM.LocationZip
                    };
                    _locationManager.AddLocation(location);

                    Appointment appointment = new Appointment()
                    {
                        AppointmentID = appointmentLocationVM.AppointmentID,
                        AdoptionApplicationID = appointmentLocationVM.AdoptionApplicationID,
                        AppointmentTypeID = "Interview",
                        DateTime = appointmentLocationVM.DateTime,
                        LocationID = appointmentLocationVM.LocationID
                    };
                    _appointmentManager.AddAppointment(appointment);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        /// <summary>
        /// NAME: Thomas Dupuy
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This Method returns the view to create the Meet And Greet
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        // GET: Schdules/CreateInterviewAppointment
        public ActionResult CreateMeetAndGreet()
        {
            ViewBag.Title = "Add A New Meet And Greet Appointment";
            return View();
        }

        /// <summary>
        /// NAME: Thomas Dupuy
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This Method creats a new location and appointment based on the customer's info
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        // POST: Schdules/CreateInterviewAppointment
        [HttpPost]
        public ActionResult CreateMeetAndGreet(AppointmentLocationVM appointmentLocationVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Location location = new Location()
                    {
                        LocationID = appointmentLocationVM.LocationID,
                        Name = appointmentLocationVM.LocationName,
                        Address1 = appointmentLocationVM.LocationAddress1,
                        Address2 = appointmentLocationVM.LocationAddress2,
                        City = appointmentLocationVM.LocationCity,
                        State = appointmentLocationVM.LocationState,
                        Zip = appointmentLocationVM.LocationZip
                    };
                    _locationManager.AddLocation(location);

                    Appointment appointment = new Appointment()
                    {
                        AppointmentID = appointmentLocationVM.AppointmentID,
                        AdoptionApplicationID = appointmentLocationVM.AdoptionApplicationID,
                        AppointmentTypeID = "Meet And Greet",
                        DateTime = appointmentLocationVM.DateTime,
                        LocationID = appointmentLocationVM.LocationID
                    };
                    _appointmentManager.AddAppointment(appointment);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        /// <summary>
        /// NAME: Thomas Dupuy
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This Method returns the view to create the In Home Inspecion
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        // GET: Schdules/CreateInterviewAppointment
        public ActionResult CreateInHomeInspecion()
        {
            ViewBag.Title = "Add A New In Home Inspecion Appointment";
            return View();
        }

        /// <summary>
        /// NAME: Thomas Dupuy
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This Method creats a new location and appointment based on the customer's info
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        // POST: Schdules/CreateInterviewAppointment
        [HttpPost]
        public ActionResult CreateInHomeInspecion(AppointmentLocationVM appointmentLocationVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Location location = new Location()
                    {
                        LocationID = appointmentLocationVM.LocationID,
                        Name = appointmentLocationVM.LocationName,
                        Address1 = appointmentLocationVM.LocationAddress1,
                        Address2 = appointmentLocationVM.LocationAddress2,
                        City = appointmentLocationVM.LocationCity,
                        State = appointmentLocationVM.LocationState,
                        Zip = appointmentLocationVM.LocationZip
                    };
                    _locationManager.AddLocation(location);

                    Appointment appointment = new Appointment()
                    {
                        AppointmentID = appointmentLocationVM.AppointmentID,
                        AdoptionApplicationID = appointmentLocationVM.AdoptionApplicationID,
                        AppointmentTypeID = "In Home Inspecion",
                        DateTime = appointmentLocationVM.DateTime,
                        LocationID = appointmentLocationVM.LocationID
                    };
                    _appointmentManager.AddAppointment(appointment);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        /// <summary>
        /// NAME: Thomas Dupuy
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This Method returns the view to create the Contract Signing
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        // GET: Schdules/CreateInterviewAppointment
        public ActionResult CreateContractSigning()
        {
            ViewBag.Title = "Add A New Contract Signing Appointment";
            return View();
        }

        /// <summary>
        /// NAME: Thomas Dupuy
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This Method creats a new location and appointment based on the customer's info
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        // POST: Schdules/CreateInterviewAppointment
        [HttpPost]
        public ActionResult CreateContractSigning(AppointmentLocationVM appointmentLocationVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Location location = new Location()
                    {
                        LocationID = appointmentLocationVM.LocationID,
                        Name = appointmentLocationVM.LocationName,
                        Address1 = appointmentLocationVM.LocationAddress1,
                        Address2 = appointmentLocationVM.LocationAddress2,
                        City = appointmentLocationVM.LocationCity,
                        State = appointmentLocationVM.LocationState,
                        Zip = appointmentLocationVM.LocationZip
                    };
                    _locationManager.AddLocation(location);

                    Appointment appointment = new Appointment()
                    {
                        AppointmentID = appointmentLocationVM.AppointmentID,
                        AdoptionApplicationID = appointmentLocationVM.AdoptionApplicationID,
                        AppointmentTypeID = "Contract Signing",
                        DateTime = appointmentLocationVM.DateTime,
                        LocationID = appointmentLocationVM.LocationID
                    };
                    _appointmentManager.AddAppointment(appointment);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        ///// <summary>
        ///// NAME: Thomas Dupuy
        ///// DATE: 4/15/2020
        ///// CHECKED BY: 
        ///// 
        ///// This Method returns the view to create the Interview
        ///// </summary>
        ///// <remarks>
        ///// UPDATED BY: NA
        ///// UPDATE DATE: NA
        ///// WHAT WAS CHANGED: NA
        ///// 
        ///// </remarks>
        //// GET: Schdules/CreateInterviewAppointment
        //public ActionResult EditInterview(string id)
        //{
        //    AppointmentLocationVM appointmentLocationVM = _appointmentManager.RetrieveAppointmentByID(int.Parse(id));
        //    Location location = new Location()
        //    {
        //        LocationID = appointmentLocationVM.LocationID,
        //        Name = appointmentLocationVM.LocationName,
        //        Address1 = appointmentLocationVM.LocationAddress1,
        //        Address2 = appointmentLocationVM.LocationAddress2,
        //        City = appointmentLocationVM.LocationCity,
        //        State = appointmentLocationVM.LocationState,
        //        Zip = appointmentLocationVM.LocationZip
        //    };
        //    ViewBag.Title = "Reshedule An Interview Appointment";
        //    return View(appointmentLocationVM, location);
        //}

        ///// <summary>
        ///// NAME: Thomas Dupuy
        ///// DATE: 4/15/2020
        ///// CHECKED BY: 
        ///// 
        ///// This Method creats a new location and appointment based on the customer's info
        ///// </summary>
        ///// <remarks>
        ///// UPDATED BY: NA
        ///// UPDATE DATE: NA
        ///// WHAT WAS CHANGED: NA
        ///// 
        ///// </remarks>
        //// POST: Schdules/CreateInterviewAppointment
        //[HttpPost]
        //public ActionResult EditInterview(string id, AppointmentLocationVM appointmentLocationVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Location location = new Location()
        //            {
        //                LocationID = appointmentLocationVM.LocationID,
        //                Name = appointmentLocationVM.LocationName,
        //                Address1 = appointmentLocationVM.LocationAddress1,
        //                Address2 = appointmentLocationVM.LocationAddress2,
        //                City = appointmentLocationVM.LocationCity,
        //                State = appointmentLocationVM.LocationState,
        //                Zip = appointmentLocationVM.LocationZip
        //            };
        //            _locationManager.AddLocation(location);

        //            Appointment appointment = new Appointment()
        //            {
        //                AppointmentID = appointmentLocationVM.AppointmentID,
        //                AdoptionApplicationID = appointmentLocationVM.AdoptionApplicationID,
        //                AppointmentTypeID = "Interview",
        //                DateTime = appointmentLocationVM.DateTime,
        //                LocationID = appointmentLocationVM.LocationID
        //            };
        //            _appointmentManager.EditAppointment(appointment);

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //    return View();
        //}
    }
}