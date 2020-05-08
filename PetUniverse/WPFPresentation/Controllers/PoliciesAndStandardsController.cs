using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Web.Mvc;


/// <summary>
/// Creator: Lane Sandburg
/// Created: 3/17/2020
/// Approver: Kaleb Bachert
/// 
/// This class is the controller logic for dealing with employees and
/// viewing/accepting the company Policies And Standards
/// </summary>
/// <remarks>
/// </remarks>
namespace WPFPresentation.Controllers
{
    public class PoliciesAndStandardsController : Controller
    {
        private IUserManager _userManager = null;


        public PoliciesAndStandardsController()
        {
            _userManager = new UserManager();

        }

        // GET: PoliciesAndStandards
        public ActionResult Index(PetUniverseUser user)
        {
            ViewBag.Title = "Policies";
            ViewBag.UserID = user.PUUserID;
            return View();
        }
        // GET: PoliciesAndStandards
        [HttpPost]
        public ActionResult Index(int userID)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userManager.HasReadPoliciesAndStandards(userID);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {

                    return RedirectToAction("Index", "Home");
                }

            }

            return View();

        }

        // GET: PoliciesAndStandards/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PoliciesAndStandards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoliciesAndStandards/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PoliciesAndStandards/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PoliciesAndStandards/Edit/5
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

        // GET: PoliciesAndStandards/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PoliciesAndStandards/Delete/5
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
