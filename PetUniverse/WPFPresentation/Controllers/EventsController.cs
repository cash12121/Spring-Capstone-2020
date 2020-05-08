using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WPFPresentation.Controllers
{
    public class EventsController : Controller
    {
        private IPUEventManager _eventManager;
        private IUserManager _userManager;
        private List<String> _eventTypes = new List<String>();

        public EventsController()
        {
            _userManager = new UserManager();
            _eventManager = new PUEventManager();
            getEventTypes();

        }
        public EventsController(IPUEventManager eventManager)
        {
            _userManager = new UserManager();
            _eventManager = eventManager;
            getEventTypes();
        }
        private void getEventTypes()
        {
            try
            {

                foreach (var eventType in _eventManager.GetAllEventTypes())
                {
                    _eventTypes.Add(eventType.EventTypeID);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }



        // GET: Event
        public ActionResult Index()
        {
            var events = (IEnumerable<PUEvent>)(from e in _eventManager.GetAllEvents()
                                                where e.Status == "Approved" || e.Status == "Active"
                                                select e).ToList().OrderBy(e => e.EventDateTime);

            return View(events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var puEvent = _eventManager.GetEventByID(id);
            var puEventVM = _eventManager.GetEventApprovalVM(id, puEvent.CreatedByID);
            return View(puEventVM);
        }

        // GET: Event/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EventTypes = _eventTypes;
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(PUEvent puEvent)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userid = User.Identity.GetUserId();
            int userID = 0;
            Int32.TryParse(userid, out userID);
            if (ModelState.IsValid)
            {
                try
                {
                    PetUniverseUser current = _userManager.getUserByEmail(Membership.GetUser().Email);
                    puEvent.Status = "PendingApproval";
                    puEvent.DateCreated = DateTime.Now;
                    puEvent.BannerPath = "default.png";
                    puEvent.CreatedByID = userID;
                    puEvent.EventID = _eventManager.AddEvent(puEvent);
                    if (puEvent.EventID != 0)
                    {


                        Request request = new Request()
                        {
                            DateCreated = DateTime.Now,
                            Open = true,
                            RequestingUserID = puEvent.CreatedByID,
                            RequestTypeID = "Event"
                        };
                        request.RequestID = _eventManager.AddRequest(request);
                        if (request.RequestID != 0)
                        {
                            EventRequest eventRequest = new EventRequest()
                            {
                                Active = true,
                                DateCreated = DateTime.Now,
                                EventID = puEvent.EventID,
                                Open = request.Open,
                                RequestID = request.RequestID,
                                RequestingUserID = request.RequestingUserID,
                                RequestTypeID = request.RequestTypeID
                            };

                            _eventManager.AddEventRequest(eventRequest);
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            ViewBag.EventTypes = _eventTypes;
            return View(puEvent);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
