using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// CREATOR: Derek Taylor
    /// CREATED: 2020-02-06
    /// APPROVER: Ryan Morganti
    ///
    /// The EventManagerTests class that allows testing of the 
    /// classes and methods used for event handling.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Updater: NA
    /// Updated: NA
    /// Update: NA   
    /// 
    /// </remarks>
    [TestClass]
    public class EventManagerTests
    {
        private IEventAccessor _fakeEventAccessor;
        private PUEventManager _eventManager;

        [TestInitialize]
        public void TestSetup()
        {
            _fakeEventAccessor = new FakeEventAccessor();
            _eventManager = new PUEventManager(_fakeEventAccessor);
        }


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for all GOOD values
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAddEventGood()
        {
            // Arrange
            bool successful = false;

            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "3873 M Ave",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            int eventID = _eventManager.AddEvent(mockEvent);
            // Act
            if (eventID == 1)
            {
                successful = true;
            }

            // Assert
            Assert.IsTrue(successful);
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Name value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Name must be at least 8 characters.")]
        public void TestAddEventNameTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "",//This is what will throw an exception
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(3),
                Address = "3873 M Ave",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Name value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Name is too long.")]
        public void TestAddEventNameTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "This is the name of the event, it is not going to make sense. It's only" +
                " purpose is to be far too long to be a name for an event, and therefore not allowed in the system." +
                "Im not going to count but I think that should be long enough.",//This is what will throw an exception
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(3),
                Address = "3873 M Ave",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Date value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Date is too close. Must be 14 days or more.")]
        public void TestAddEventDateTooClose()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(3),//This is what will throw an exception
                Address = "3873 M Ave",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Address value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Address is too short")]
        public void TestAddEventAddressTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "",//This is what will throw an exception
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Address value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Address is too long.")]
        public void TestAddEventAddressTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "This is the name of the event, it is not going to make sense. It's only" +
                " purpose is to be far too long to be a name for an event, and therefore not allowed in the system." +
                "Im not going to count but I think that should be long enough.",//This is what will throw an exception
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event City value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event City is too short.")]
        public void TestAddEventCityTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "242 A Street",
                City = "",//This is what will throw an exception
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event City value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event City is too long.")]
        public void TestAddEventCityTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "sdkljfksdlafkldsflksdagflksdgflksdagfklgsdfklgsdlkfgsdlkfglksadgflksdgflksdagflksdg",//This is what will throw an exception
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Zipcode value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event zipcode is too short.")]
        public void TestAddEventZipcodeTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "",//This is what will throw an exception
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Zipcode value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event zipcode is too long.")]
        public void TestAddEventZipcodeTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363636334353",//This is what will throw an exception
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Picture File Name value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event picture file name is too short.")]
        public void TestAddEventPictureFileNameTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = ".jpg",//This is what will throw an exception
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Picture File Name value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event picture file name is too long.")]
        public void TestAddEventPictureFileNameTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = "welrjkhwelkjhrlkwehrkljwehrklwehrklewhkrlhweklrhweklrhweklhrwekljhrklj" +
                "wehrkljwehrkljwehrkjwehrkhweklrhwklehrklwehrklwehrkljhwekrlhweklrhweklhrklwe" +
                "hrklewjhrkljwehrkwehrklwehrkewhrkjewhrklwehrkwehrklhwekrhweklrhwek" +
                "lhrkwejhrkwehrkwehrkwekfbekfewklbvkwebivcubegfbrelkbgferbgfidsgiddefault.jpg",//This is what will throw an exception
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Picture File Name value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event picture file name is missing its extension.")]
        public void TestAddEventPictureFileNameMissingExtension()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = "billy",//This is what will throw an exception
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Description value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event description is too short.")]
        public void TestAddEventDescriptionTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = "billy.jpg",
                Status = "PendingApproval",
                Description = ""//This is what will throw an exception
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Description value
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event description is too long.")]
        public void TestAddEventDescriptionTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = "billy.jpg",
                Status = "PendingApproval",
                Description = "ksadjlfhlksdjhfklsdhflksdhklfjhsdlkjfhdsklfhlksdhfkljdshfksdhfksdhfklhsdlkfjhsdkfhsdf" +
                "sdlkfhsdlkfhklsdjhfkljsdhfkljsdhfkjhsdkfhsdkjfhklsjdhfkjdlshfkjsdhfkjsdhfkljdshfkjldshfklhsdkfhkdlsjhfkljdshfkljhsdkfjhdsklfhds'sd" +
                "sdkjalfhsdaklfhsdkljfhsdjfhksdlhfkljsdajhfkljsdhfkjlsdhfksdhfklhsdkljfhklsdhfkljsdhfklsdhfkljsdhfklhsdklfhdskhfkdsjfhksdjhflkdsjfhsd" +
                "sdlkjfhkljdshfksdjhfksdjhfkjsdhfjlkefbelauafbrliusbfaursbfcireusbgfidsbfciurvbfiudsbgkljsdbfkjldsbflkjsdbfkjlsdbfkjldsbfkbsdklbfkdsjbf" +
                "sdkljbfkljsdbgfgbdskbgsdkbfkjsdbfkjsdbkfjbdskljfbksjldbfkdsjbfkjdsbfkjsdbfkjbdskfbdskbfkljdsbffdsakjfblksdajbfkljsdbfkjsdbfkjlbsdklfjbdas" +
                "sdjkjfbdlsakjbfkjsdfvkjcwre laubfdskjbfwerbfvdskjfberfn owjdsfnsdjfbnsd jkacsbdfnjdsbgfksdjgbkjsdbgkjsdbkgjbsdksdjlkfhsdkhfklsdaf" +
                "kjgjjgjhghghgjhghsdgfkjsdgfvbsdbfhsdbf hsdkfb kjsd bfksdlj fdsjkfh sdlkjfhkjldsh flksjd hfkjldsh fkjlsdh hflkjsdaghflivurfvbdslvkjds f" +
                "osjdfh lkjsdhf ojsdhfoiu5h6asd4h 98aohfvo9werusda8fh4v65dsh45" +
                "9298uhjfhjgdfhyukdulkgf2"//This is what will throw an exception
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        //====================================== End of Insert Event Tests ===========================================\\



        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// All values are good values
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditEventGood()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "233 Boremer Drive",//Editing this value
                City = "New City",//Editing this value
                State = "IA",//Editing this value
                Zipcode = "38474",//Editing this value
                BannerPath = "ACAR.jpg",
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);
            //Double check
            //get a new instance of the same event to check that an update occurred
            PUEvent checkOldEventUpdated = _eventManager.GetEventByID(1000023);
            //Assert
            Assert.AreEqual("233 Boremer Drive", checkOldEventUpdated.Address);
            Assert.AreEqual("New City", checkOldEventUpdated.City);
            Assert.IsTrue(successful);
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Name is too short.")]
        public void TestEditEventNewNameTooShort()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "*seven*",//This is what is edited
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "Millbrook",
                State = "WI",
                Zipcode = "67421",
                BannerPath = "ACAR.jpg",
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Name is too long.")]
        public void TestEditEventNewNameTooLong()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "This name will be far too long to be a proper event name. " +
                            "Surely we should not allow a name this long for an event." +
                            "I think a mistake was made lets throw the exception.",//This is what is edited
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "Millbrook",
                State = "WI",
                Zipcode = "67421",
                BannerPath = "ACAR.jpg",
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Date is too close. Must be more than 14 days away.")]
        public void TestEditEventNewDateTooClose()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(3),//This is what is edited
                Address = "1187 Arbor Lane",
                City = "Millbrook",
                State = "WI",
                Zipcode = "67421",
                BannerPath = "ACAR.jpg",
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Address is too short.")]
        public void TestEditEventNewAddressTooShort()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "*five",//This is what is edited
                City = "Millbrook",
                State = "WI",
                Zipcode = "67421",
                BannerPath = "ACAR.jpg",
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Address is too long.")]
        public void TestEditEventNewAddressTooLong()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "This is the name of the event, it is not going to make sense. It's only" +
                " purpose is to be far too long to be a name for an event, and therefore not allowed in the system." +
                "Im not going to count but I think that should be long enough.",//This is what will throw an exception
                City = "Millbrook",
                State = "WI",
                Zipcode = "67421",
                BannerPath = "ACAR.jpg",
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event city is too short.")]
        public void TestEditEventNewCityTooShort()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "A",//This is what will throw an exception
                State = "WI",
                Zipcode = "67421",
                BannerPath = "ACAR.jpg",
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event City is too long.")]
        public void TestEditEventNewCityTooLong()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "ACityNameThatIsFarTooLongToBeARealCityNameIWouldThink",//This is what will throw an exception
                State = "WI",
                Zipcode = "67421",
                BannerPath = "ACAR.jpg",
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Zipcode is invalid.")]
        public void TestEditEventNewZipcodeInvalid()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "Milbrook",
                State = "WI",
                Zipcode = "6742353",//This is what will throw an exception
                BannerPath = "ACAR.jpg",
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event banner path is too short.")]
        public void TestEditEventNewBannerPathTooShort()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "Millbrook",
                State = "WI",
                Zipcode = "67425",
                BannerPath = "A.jpg",//This is what will throw an exception
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event banner path is too long.")]
        public void TestEditEventNewBannerPathTooLong()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "Millbrook",
                State = "WI",
                Zipcode = "67425",
                BannerPath = "welrjkhwelkjhrlkwehrkljwehrklwehrklewhkrlhweklrhweklrhweklhrwekljhrklj" +
                "wehrkljwehrkljwehrkjwehrkhweklrhwklehrklwehrklwehrkljhwekrlhweklrhweklhrklwe" +
                "hrklewjhrkljwehrkwehrklwehrkewhrkjewhrklwehrkwehrklhwekrhweklrhwek" +
                "lhrkwejhrkwehrkwehrkwekfbekfewklbvkwebivcubegfbrelkbgferbgfidsgiddefault.jpg",//This is what will throw an exception
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event banner path is missing its extension")]
        public void TestEditEventNewBannerPathMissingExtension()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "Millbrook",
                State = "WI",
                Zipcode = "67425",
                BannerPath = "aPicture",//This is what will throw an exception
                Status = "Pending Approval",
                Description = "Animals are cruel and you need to know about it."
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event description is too short.")]
        public void TestEditEventNewDescriptionTooShort()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "Millbrook",
                State = "WI",
                Zipcode = "67425",
                BannerPath = "aPicture.jpg",
                Status = "Pending Approval",
                Description = "A"//This is what will throw an exception
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the EditEvent method
        /// Expects an exception to be thrown
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event description is too short.")]
        public void TestEditEventNewDescriptionTooLong()
        {
            //Arrange
            bool successful = false;
            //Get an instance of the pre-updated event
            PUEvent oldEvent = _eventManager.GetEventByID(1000023);
            //Create a new event that will be have the edited values
            PUEvent newEvent = new PUEvent()
            {
                EventID = 1000023,
                CreatedByID = 1000142,
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "1187 Arbor Lane",
                City = "Millbrook",
                State = "WI",
                Zipcode = "67425",
                BannerPath = "aPicture.jpg",
                Status = "Pending Approval",
                Description = new string('a', 501)//This is what will throw an exception
            };

            //Act
            //Call the edit event method. It returns true if the edit occurred
            successful = _eventManager.EditEvent(oldEvent, newEvent);

            //Assert
            //Will throw an exception
        }

        //=================== End of Edit Event Tests ====================\\

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the DeleteEvent method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestDeleteEvent()
        {
            //Arrange 
            int eventIDForTheEventToBeDeleted = 1000418;

            //Act
            bool successful = _eventManager.DeleteEvent(eventIDForTheEventToBeDeleted);

            //Assert
            List<PUEvent> fakeEvents = _eventManager.GetAllEvents();
            Assert.IsTrue(successful);
        }



        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the SelectAllEvents method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestSelectAllEvents()
        {
            //Arrange
            List<PUEvent> selectedEvents;
            //Act
            selectedEvents = _eventManager.GetAllEvents();
            //Assert
            Assert.AreEqual(4, selectedEvents.Count);

        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-28
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the SelectAllEventTypes method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestSelectAllEventTypes()
        {
            //Arrange
            List<EventType> eventTypes;
            //Act
            eventTypes = _eventManager.GetAllEventTypes();
            //Assert
            Assert.AreEqual(4, eventTypes.Count);
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-28
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the InsertRequest method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestInsertRequest()
        {
            //Arrange
            Request newRequest = new Request()
            {
                DateCreated = DateTime.Now,
                RequestTypeID = "Event",
                RequestingUserID = 1000000
            };
            //Act
            int requestID = _eventManager.AddRequest(newRequest);
            //Assert
            Assert.AreEqual(1, requestID);
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-28
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the InsertEventRequest method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestInsertEventRequest()
        {
            //Arrange
            EventRequest newEventRequest = new EventRequest()
            {
                EventID = 1000006,
                RequestID = 1000006,
                ReviewerID = 1000027,
                DisapprovalReason = null,
                DesiredVolunteers = 5,
                Active = true
            };
            //Act
            int rowsEffected = _eventManager.AddEventRequest(newEventRequest);
            //Assert
            Assert.AreEqual(1, rowsEffected);
        }



        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the GetEventByID method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestGetEventByID()
        {
            int _eventID = 1000000;
            //Arrange
            PUEvent selectedEvent;
            //Action
            selectedEvent = _eventManager.GetEventByID(_eventID);
            //Assert
            Assert.IsNotNull(selectedEvent);
        }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the SelectEventApprovalVM method
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        /// </summary>
        [TestMethod]
        public void TestSelectEventApprovalVMGood()
        {
            //Arrange & Act
            EventApprovalVM selectedEventVM = _eventManager.GetEventApprovalVM(1000418, 1000055);

            //Assert
            Assert.IsNotNull(selectedEventVM);
        }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the SelectEventApprovalVM methoddated On:
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "No Event has an ID matching the ID provided.")]
        public void TestSelectEventApprovalVMBad()
        {
            //Arrange & Act
            //The EventID provided wont match any event
            EventApprovalVM selectedEventVM = _eventManager.GetEventApprovalVM(1000401, 1000055);
            //Should throw an Exception
        }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the SelectEventRequestByEventID method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestSelectEventRequestByEventIDGood()
        {
            //Arrange & Act
            EventRequest selectedEventRequest = _eventManager.GetEventRequestByEventID(1000418);
            //Assert
            Assert.IsNotNull(selectedEventRequest);
        }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the SelectEventRequestByEventID method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestSelectEventRequestByEventIDBAD()
        {
            //Arrange & Act
            //The EventID provided wont match any event
            EventRequest selectedEventRequest = _eventManager.GetEventRequestByEventID(1000401);
            //Assert
            Assert.IsNull(selectedEventRequest);
        }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the UpdateEventRequest method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestUpdateEventRequestGood()
        {
            //Arrange
            EventRequest selectedEventRequest = _eventManager.GetEventRequestByEventID(1000418);

            EventRequest updatedEventRequest = new EventRequest()
            {
                EventID = 1000418,
                RequestID = 1000003,
                ReviewerID = 100000,
                DisapprovalReason = null,
                DesiredVolunteers = 4,
                Active = false
            };

            //Act
            bool successfulUpdate = _eventManager.UpdateEventRequest(selectedEventRequest, updatedEventRequest);

            //Assert
            Assert.IsTrue(successfulUpdate);
        }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the UpdateEventRequest method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "No Disapproval Reason cannot be blank.")]
        public void TestUpdateEventRequestBADBlankReason()
        {
            //Arrange
            EventRequest selectedEventRequest = _eventManager.GetEventRequestByEventID(1000418);

            EventRequest updatedEventRequest = new EventRequest()
            {
                EventID = 1000418,
                RequestID = 1000003,
                ReviewerID = 100000,
                DisapprovalReason = "",//This throws the exception
                DesiredVolunteers = 0,
                Active = false
            };

            //Act
            bool successfulUpdate = _eventManager.UpdateEventRequest(selectedEventRequest, updatedEventRequest);
            //Should throw an Exception
        }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the UpdateEventRequest method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "No Disapproval Reason is too long.")]
        public void TestUpdateEventRequestBADReasonTooLong()
        {
            //Arrange
            EventRequest selectedEventRequest = _eventManager.GetEventRequestByEventID(1000418);

            EventRequest updatedEventRequest = new EventRequest()
            {
                EventID = 1000418,
                RequestID = 1000003,
                ReviewerID = 100000,
                DisapprovalReason = new string('a', 501),//This throws the exception
                DesiredVolunteers = 0,
                Active = false
            };

            //Act
            bool successfulUpdate = _eventManager.UpdateEventRequest(selectedEventRequest, updatedEventRequest);
            //Should throw an Exception
        }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the SelectEventsByStatus method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestSelectEventsByStatus()
        {
            //Arrange
            List<PUEvent> events;
            //Act
            events = _eventManager.GetEventsByStatus("PendingApproval"); //Should be 3
            //Assert
            Assert.AreEqual(3, events.Count);
        }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti
        /// 
        /// A test method for testing the UpdateEventStatus method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        [TestMethod]
        public void TestUpdateEventStatus()
        {
            //Arrange
            string newStatus = "Approved";
            //Act
            bool successfulUpdate = _eventManager.UpdateEventStatus(1000000, newStatus);
            //Assert
            Assert.IsTrue(successfulUpdate);
        }


        [TestCleanup]
        public void TestTearDown()
        {
            _fakeEventAccessor = null;
            _eventManager = null;
        }
    }

}
