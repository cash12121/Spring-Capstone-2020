using Microsoft.AspNet.Identity;
using System.Web.Mvc;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/15
///  APPROVER: Lane Sandburg
///  
///  Controller for Selecting a Request Type to submit
/// </summary>

namespace WPFPresentation.Controllers
{
    public class ChooseRequestTypeController : Controller
    {
        LogicLayerInterfaces.IUserManager _usrMgr = new LogicLayer.UserManager();

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///  View that allows you to pick from scheduling Request Types to submit
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/5/4
        /// UPDATE: Checks if user exists as an employee to determine redirect
        /// 
        /// </remarks>
        [Authorize]
        // GET: ChooseRequestType
        public ActionResult Index(string outputMessage = null)
        {
            ViewBag.Title = "Choose a Request Type";

            ViewBag.OutputMessage = outputMessage;

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
    }
}