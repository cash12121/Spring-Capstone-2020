using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WPFPresentation.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace WPFPresentation.Controllers
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/3/7
    /// Approver: Mohamed Elamin 
    /// controlling Adoption Application and questionnair
    /// </summary>
    [Authorize]
    public class AdoptionController : Controller
    {
        private AdoptionApplication adoptionApplication;
        private IAdoptionManager adoptionApplicationManager;
        private Questionnair questionnair;
        private IAdoptionCustomerManager _adoptionCustomerManager;
        private IAdoptionApplicationManager _adoptionApplicationManager;
        private AdoptionAnimalManager _adoptionAnimalManager;
        private IAdoptionAppointmentManager _adoptionAppointmentManager;
        private IUserManager _userManager;
        private IAnimalManager _animalManager;

        

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin 
        /// default constructor assgined intial values
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        public AdoptionController()
        {
            adoptionApplication = new AdoptionApplication();
            adoptionApplicationManager = new ReviewerManager();
            questionnair = new Questionnair();
            _adoptionCustomerManager = new AdoptionCustomerManager();
            _adoptionApplicationManager = new AdoptionApplicationManager();
            _adoptionAnimalManager = new AdoptionAnimalManager();
            _adoptionAppointmentManager = new AdoptionAppointmentManager();
            _userManager = new UserManager();
            _animalManager = new AnimalManager();
        }


        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin 
        /// main page of the adoption section
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Michael Thompson
        /// UPDATE DATE: 04/7/20
        /// Approver Thomas Dupuy
        /// CHANGE: Adding the correct ActionResult to show all animals
        /// </remarks>
        /// <returns ActionResult></returns>
        // GET: Adoption
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var animalProfiles = _adoptionAnimalManager.RetrieveAdoptionAnimalsByActiveAndAdoptable();
            return View(animalProfiles);
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 04/7/20
        /// Approver Thomas Dupuy
        ///
        /// Action result to for the profiles page. 
        /// Takes a user to a new appliction with the selected animal ID and their profile
        /// </summary>
        /// <param name="model"></param>
        /// <param name="animalID"></param>
        /// <returns>New adoption application page</returns>
        public ActionResult Start(LoginViewModel model, int animalID)
        {
            this.adoptionApplication.AnimalID = animalID;
            this.adoptionApplication.CustomerEmail = model.Email;

            return View(this.adoptionApplication);
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin
        /// controlling Adoption Application and questionnair
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        /// <param name="model"></param>
        /// <returns ActionResult></returns> 
        //GET:AdoptionApplication
        [HttpGet]
        //[Authorize]
        public ActionResult AdoptionApplication(LoginViewModel model)
        {
            //var user = new ApplicationUser
            //{
            //    UserName = model.Email,
            //    Email = model.Email,

            //};
            this.adoptionApplication.CustomerEmail = model.Email;
            this.adoptionApplication.Status = "Reviewer";
            this.adoptionApplication.RecievedDate = DateTime.Today;
            //if (adoptionApplication != null)
            //{                
            this.adoptionApplication.qusetionnair = adoptionApplicationManager.retrieveCustomerQuestionnar(this.adoptionApplication.CustomerEmail);
            //}
            return View(this.adoptionApplication);
        }


        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin, 2020/10/3
        /// controlling Adoption Application and questionnair
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        /// <param name="adoptionApplication"></param>
        /// <returns ActionResult></returns>
        //Post:AdoptionApplication
        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult AdoptionApplication(AdoptionApplication adoptionApplication)
        {
            if (adoptionApplicationManager.addAdoptionApplication(adoptionApplication))
            {

                ViewBag.StatusMessage = "update goes right!";
                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.StatusMessage = "Model state is not valid";
                return RedirectToAction("Index");

                //return View();
            }
        }


        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin, 20202/10/3
        /// controlling Adoption Application and questionnair
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        /// <param name="model"></param>
        /// <returns ActionResult></returns>
        //GET:Questionnair
        [HttpGet]
        public ActionResult Questionnair(LoginViewModel model)
        {
            List<String> questions = new List<String>();
            questions = adoptionApplicationManager.retrieveAllQuestions();
            if (model.Email == "")
            {
                questionnair = new Questionnair();

            }
            questionnair.Question1 = questions[0];
            questionnair.Question2 = questions[1];
            questionnair.Question3 = questions[2];
            questionnair.Question4 = questions[3];
            questionnair.Question5 = questions[4];
            questionnair.Question6 = questions[5];
            questionnair.Question7 = questions[6];
            questionnair.Question8 = questions[7];
            questionnair.Question9 = questions[8];
            questionnair.Question10 = questions[9];
            return View(questionnair);
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin, 20202/10/3
        /// controlling Adoption Application and questionnair
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        /// <param name="questionnair"></param>
        /// <returns ActionResult></returns>
        //POST:Questionnair
        [HttpPost]
        public ActionResult Questionnair(Questionnair questionnair)
        {
            if (adoptionApplicationManager.addQuestionnair(questionnair))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "You already filled the Questionnair";
                return View(questionnair);
            }
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/11/2020
        /// Approver: Michael Thompson
        /// returns a list view of applications for a particular customer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="customerEmail"></param>
        /// <returns></returns>
        public ActionResult CustomerApplicationList(string customerEmail)
        {
            var customer = _adoptionCustomerManager.RetrieveAdoptionCustomerByEmail(customerEmail);
            var applications = _adoptionApplicationManager.RetrieveAdoptionApplicationsByEmailAndActive(customerEmail);
            ViewBag.Title = "Animals you have applied to adopt";


            return View(applications);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/11/2020
        /// Approver: Michael Thompson
        ///
        /// returns a detail view of a customer adoption application
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        public ActionResult CustomerApplicationDetails(int adoptionApplicationID)
        {
            var adoptionApplication = _adoptionApplicationManager.RetrieveAdoptionApplicationByID(adoptionApplicationID);
            ViewBag.CustomerEmail = adoptionApplication.CustomerEmail;
            ViewBag.Title = "Your Adoption Application";
            return View(adoptionApplication);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/27/2020
        /// Approver: Michael Thompson
        ///
        /// shows a customers scheduled appointments
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        
        public ActionResult CustomerAppointmentSchedule(string email)
        {
            var schedule = _adoptionAppointmentManager.RetrieveAdoptionAppointmentsByCustomerEmailAndActive(email);
            ViewBag.Title = "Appointment Schedule";
            return View(schedule);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/27/2020
        /// Approver: Michael Thompson
        ///
        /// returns a detail view of a customer adoption appointment
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AppointmentDetails(int id)
        {
            var appointment = _adoptionAppointmentManager.RetrieveAdoptionAppointmentByAppointmentID(id);
            ViewBag.Title = "Appointment Details";
            return View(appointment);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/27/2020
        /// Approver: Michael Thompson
        ///
        /// Reschedule adoption appointment View
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RescheduleAppointment(int id)
        {
            var appointment = _adoptionAppointmentManager.RetrieveAdoptionAppointmentByAppointmentID(id);
            ViewBag.Title = "Reschedule Appointment";
            return View(appointment);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/27/2020
        /// Approver: Michael Thompson
        ///
        /// reschedule adoption apppointment post method
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RescheduleAppointment(FormCollection formCollection)
        {
            int appointmentID = Int32.Parse(formCollection[1]);
            try
            {
                
                DateTime dateTime = DateTime.Parse(formCollection[2]);
                _adoptionAppointmentManager.EditAdoptionAppointmentDateTime(appointmentID, dateTime);
                return RedirectToAction("AppointmentDetails", new { id = appointmentID });

            }
            catch (Exception)
            {
                //var appointment = _adoptionAppointmentManager.RetrieveAdoptionAppointmentByAppointmentID(id);
                return View(appointmentID);
            }
            
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/22/2020
        /// Approver: Michael Thompson
        ///
        /// Allows a customer to deactivate an adoption application essentially cancelling
        /// the adoption process.
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        public ActionResult CustomerCancelAdoption(int adoptionApplicationID)
        {
            var application = _adoptionApplicationManager.RetrieveAdoptionApplicationByID(adoptionApplicationID);
            ViewBag.Title = "Cancel Adoption";
            ViewBag.Subtitle = "Are you sure you want to cancel this adoption?";
            return View(application);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/22/2020
        /// Approver: Michael Thompson
        ///
        /// Allows a customer to deactivate an adoption application essentially cancelling
        /// the adoption process.
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CustomerCancelAdoption(FormCollection formCollection)
        {
            string applicationIDSring = formCollection[1];

            try
            {
                int applicationID = Int32.Parse(applicationIDSring);
                var application = _adoptionApplicationManager.RetrieveAdoptionApplicationByID(applicationID);
                _adoptionApplicationManager.DeactivateAdoptionApplication(applicationID);
                _adoptionAnimalManager.EditAnimalAdoptable(application.AnimalID, true);
                return RedirectToAction("CustomerApplicationList", new { customerEmail = formCollection[2] });
            }
            catch (Exception)
            {

                return View();
            }

        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/28/2020
        /// Approver: Michael Thompson
        ///
        /// Lets a customer apply to adopt an animal
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public ActionResult CustomerStartApplication(string email, int animalID)
        {
            if (ModelState.IsValid)
            {
                LogicLayer.CustomerManager custMgr = new LogicLayer.CustomerManager();
                try
                {
                    if (custMgr.FindCustomer(email))
                    {
                        // if a customer is in the database they can go straight to applying
                        return RedirectToAction("CustomerConfirmAdoptionApplication", new { animalID = animalID });
                    }
                    else
                    {
                        // if a customer isnt in the database they need to register as an
                        return RedirectToAction("AdoptionCustomerRegister", new { email = email , animalID = animalID});
                    }
                }
                catch (Exception)
                {

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/28/2020
        /// Approver: Michael Thompson
        ///
        /// Lets a customer apply to adopt an animal
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public ActionResult AdoptionCustomerRegister(string email, int animalID)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByEmail(email);
            ViewBag.GivenName = user.GivenName;
            ViewBag.AnimalID = animalID;
            return View();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/28/2020
        /// Approver: Michael Thompson
        ///
        /// Lets a customer register as a customer in the database
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AdoptionCustomerRegister(FormCollection formCollection)
        {
            int animalID = Int32.Parse(formCollection[1]);
            string email = formCollection[2];
            string firstName = formCollection[3];
            string lastName = formCollection[4];
            string phoneNumber = formCollection[5];
            string address1 = formCollection[6];
            string address2 = formCollection[7];
            string city = formCollection[8];
            string state = formCollection[9];
            string zip = formCollection[10];
            try
            {
                var customer = new AdoptionCustomer
                {
                    CustomerEmail = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    AddressLineOne = address1,
                    AddressLineTwo = address2,
                    City = city,
                    State = state,
                    Zipcode = zip
                };
                _adoptionCustomerManager.AddAdoptionCustomer(customer);
                return RedirectToAction("CustomerConfirmAdoptionApplication", new {animalID = animalID });
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/28/2020
        /// Approver: Michael Thompson
        ///
        /// Shows a confirmation page for applying for an adoption
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public ActionResult CustomerConfirmAdoptionApplication(int animalID)
        {
            var animals = _animalManager.RetrieveAnimalByAnimalID(animalID);
            var animal = animals[0];
            ViewBag.Title = "Confirm Adoption Application";
            ViewBag.AnimalID = animalID;
            return View(animal);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/28/2020
        /// Approver: Michael Thompson
        ///
        /// creates an adoption application
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public ActionResult CustomerAdoptionApplicationConfirmed(string email, int animalID)
        {
            try
            {
                var application = new Application
                {
                    AnimalID = animalID,
                    CustomerEmail = email,
                    Status = "Interview",
                    RecievedDate = DateTime.Now
                };
                _adoptionApplicationManager.AddAdoptionApplication(application);
                //var oldAnimals = _animalManager.RetrieveAnimalByAnimalID(animalID);
                //var oldAnimal = oldAnimals[0];
                //var newAnimal = new Animal
                //{
                //    AnimalID = oldAnimal.AnimalID,
                //    Adoptable = false,
                //    AnimalBreed = oldAnimal.AnimalBreed,
                //    Active = oldAnimal.Active,
                //    AnimalName = oldAnimal.AnimalName,
                //    AnimalSpeciesID = oldAnimal.AnimalSpeciesID,
                //    ArrivalDate = oldAnimal.ArrivalDate,
                //    CurrentlyHoused = oldAnimal.CurrentlyHoused,
                //    Dob = oldAnimal.Dob,
                //    ProfileDescription = oldAnimal.ProfileDescription,
                //    ProfileImage = oldAnimal.ProfileImage,
                //};
                _adoptionAnimalManager.EditAnimalAdoptable(animalID, false);
            }
            catch (Exception)
            {

                
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/28/2020
        /// Approver: Austin Gee
        ///
        /// returns a detail view of a customer adoption application
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        [AllowAnonymous]
        public FileContentResult GetImage(int animalId)
        {
            Animal animal = _animalManager.RetrieveOneAnimalByAnimalID(animalId);
            if (animal.ProfileImageData != null && animal.ProfileImageMimeType != null)
            {
                return File(animal.ProfileImageData, animal.ProfileImageMimeType);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/29/2020
        /// Approver: Austin Gee
        ///
        /// Returns a view of Frequently asked questions for a customer coming in for an interview for an animal
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        public ActionResult FAQ()
        {
            return View();
        }
    }
}