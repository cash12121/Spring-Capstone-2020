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
    /// DATE: 2/14/2020
    /// CHECKED BY:
    /// 
    /// This class is the controller for Applications and Applicants.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    public class CareersController : Controller
    {
        private IApplicantManager _applicantManager;
        /// <summary>
        /// NAME : Derek Taylor
        /// DATE: 2/14/2020
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
        public CareersController()
        {
            _applicantManager = new ApplicantManager();
        }
        /// <summary>
        /// NAME : Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY:
        /// 
        /// This method is a constructor for the controller
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        public CareersController(IApplicantManager applicantManager)
        {
            _applicantManager = applicantManager;
        }
        /// <summary>
        /// NAME : Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY:
        /// 
        /// This Method returns the ViewList of Applicants and allows for sorting based on
        /// the last name of the Applicant.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <returns>ViewList of applicants</returns>
        public ActionResult ApplicantList(string sortOrder)
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_descending" : "";
            var applicants = from a in _applicantManager.RetrieveApplicants()
                             select a;
            switch (sortOrder)
            {
                case "name_descending":
                    applicants = applicants.OrderByDescending(a => a.LastName);
                    break;
                default:
                    applicants = applicants.OrderBy(a => a.LastName);
                    break;
            }
            ApplicantListViewModel viewModel = new ApplicantListViewModel
            {
                Applicants = applicants.ToList()
            };
            return View(viewModel);
        }

        /// <summary>
        /// Creator : Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        /// 
        /// This Method returns the Index Page View, which allows for the navigation to other views held by this controller
        /// </summary>
        /// <remarks>
        /// Updator: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Creator : Ryan Morganti
        /// Created: 2020/03/19
        /// Approver:
        /// 
        /// This Method returns the Positions Page View, which allows the user to view a list of positions
        /// This list will change depending on whether the user is authorized to activate/deactivate/create/deleted OR
        /// is browsing open positions to apply for
        /// </summary>
        /// <remarks>
        /// Updator: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ActionResult Positions()
        {
            var positions = _applicantManager.RetrieveAllPositions();
            return View(positions);
        }
    }
}