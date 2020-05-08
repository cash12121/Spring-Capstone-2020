using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;

namespace WPFPresentation.Controllers
{
    /// <summary>
    /// CREATED BY: Matt Deaton
    /// DATE CREATED: 2020-04-07
    /// APPROVED BY: Ryan Morganti
    /// 
    /// The controller class used for Foster Applicants.
    /// 
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED:
    /// CHANGE:
    /// 
    /// </remarks>
    public class FosterApplicantController : Controller
    {
        private IApplicantManager _applicantManager = null;

        public FosterApplicantController()
        {
            _applicantManager = new ApplicantManager();
        }

        // GET: FosterApplicant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SuccessDetails()
        {
            return View();
        }

        // GET: FosterApplicant/Details/5
        public ActionResult Details(int applicantID)
        {
            return View();
        }

        // GET: FosterApplicant/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Apply to Foster";
            return View();
        }

        // POST: FosterApplicant/Create
        [HttpPost]
        public ActionResult Create(Applicant fosterApplicant)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    _applicantManager.AddFosterApplicant(fosterApplicant);
                    TempData["successMessage"] = string.Format("Application Submitted Successfully!");
                    return RedirectToAction("SuccessDetails");
                }
                catch
                {
                    TempData["errorMessage"] = string.Format("Application Not Submitted");
                    return View();
                }
            }
            return View();
        }// End Create(Applicant fosterApplicant)

        // GET: FosterApplicant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FosterApplicant/Edit/5
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

        // GET: FosterApplicant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FosterApplicant/Delete/5
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
