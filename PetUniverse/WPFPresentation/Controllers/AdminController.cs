using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WPFPresentation.Models;

namespace WPFPresentation.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager userManager;

        // GET: Admin
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return View(userManager.Users.OrderBy(n => n.FamilyName).ToList());
        }

        // GET: Admin/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser appUser = userManager.FindById(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }

            var roleMgr = new LogicLayer.ERoleManager();
            var allRoles = roleMgr.RetrieveAllERoles();
            var allRoleIds = new List<string>();

            foreach (var role1 in allRoles)
            {
                allRoleIds.Add(role1.ERoleID);
            }

            var roles = userManager.GetRoles(id);
            var noRoles = allRoleIds.Except(roles);

            ViewBag.Roles = roles;
            ViewBag.NoRoles = noRoles;

            return View(appUser);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult RemoveRole(string id, string role)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == id);

            if (role == "Administrator")
            {
                var adminUsers = userManager.Users.ToList()
                    .Where(u => userManager.IsInRole(u.Id, "Administrator"))
                    .ToList().Count();
                if (adminUsers < 2)
                {
                    ViewBag.Error = "Cannot remove last adminstrator.";
                    return RedirectToAction("Details", "Admin", new { id = user.Id });
                }
            }
            userManager.RemoveFromRole(id, role);

            if (user.EmployeeID != null)
                try
                {
                    var roleMgr = new LogicLayer.PetUniverseUserERolesManager();
                    roleMgr.DeletePetUniverseUserERole(Convert.ToInt32(user.EmployeeID), role);
                }
                catch (Exception)
                {
                    //Do nothing
                }

            return RedirectToAction("Details", "Admin", new { id = user.Id });
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddRole(string id, string role)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == id);

            userManager.AddToRole(id, role);

            if (user.EmployeeID != null)
            {
                try
                {
                    var usrMgr = new LogicLayer.PetUniverseUserERolesManager();
                    usrMgr.AddPetUniverseUserERole(Convert.ToInt32(user.EmployeeID), role);
                }
                catch (Exception)
                {
                    //Do nothing
                }
            }
            return RedirectToAction("Details", "Admin", new { id = user.Id });
        }
    }
}