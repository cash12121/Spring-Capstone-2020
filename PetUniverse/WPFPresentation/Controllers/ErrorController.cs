using System.Web.Mvc;

namespace PU.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error(string controllerRedirect = "Home", string page = "Index")
        {
            ViewBag.ControllerRedirect = controllerRedirect;
            ViewBag.Page = page;
            return View();
        }
    }
}