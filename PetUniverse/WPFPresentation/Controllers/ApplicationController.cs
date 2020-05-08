using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Linq;
using System.Web.Mvc;
using WPFPresentation.Models;

namespace WPFPresentation.Controllers
{
    /// <summary>
    /// NAME : Derek Taylor
    /// DATE: 3/16/2020
    /// CHECKED BY: Ryan Morganti
    /// 
    /// This class is the controller for Applications and Applicants.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    public class ApplicationController : Controller
    {
        private IApplicationManager _applicationManager;
        public int applicantID = 100001;
        /// <summary>
        /// NAME : Derek Taylor
        /// DATE: 3/16/2020
        /// CHECKED BY:
        /// 
        /// This method is the constructor for the controller
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        public ApplicationController()
        {
            _applicationManager = new ApplicationManager();
        }
        // GET: Application
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Creator : Derek Taylor
        /// Created: 3/17/2020
        /// Approver:
        /// 
        /// This Method returns the applicant
        /// </summary>
        /// <remarks>
        /// Updator: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ActionResult Applications()
        {
            var applications = _applicationManager.RetrieveApplicationsByApplicantID(applicantID);
            return View(applications);
        }
    }
}