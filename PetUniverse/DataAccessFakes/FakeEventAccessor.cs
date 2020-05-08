using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataAccessFakes
{
    /// <summary>    
    /// 
    /// Creator: Steve Coonrod
    /// Created: 02/06/2020
    /// Approver: Ryan Morganti
    /// 
    /// The Fake Event Data to ensure the classes and methods work properly.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class FakeEventAccessor : IEventAccessor
    {

        private List<PUEvent> puEvents = null;
        private List<Request> requests = null;
        private List<EventRequest> puEventRequests = null;
        private List<EventType> eventTypes = null;
        private EventApprovalVM eventApprovalVM = null;

        /// <summary>
        /// Creator: Steve Coonrod
        /// Created: 02/06/2020
        /// Approver: Ryan Morganti
        /// 
        /// No arg constructor
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public FakeEventAccessor()
        {
            //A fake repository containing 4 events
            puEvents = new List<PUEvent>()
            {
                new PUEvent()
                {
                    EventID = 1000000,
                    CreatedByID = 1000000,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    EventName = "Billy's Animal Parade",
                    EventTypeID = "Fundraiser",
                    EventDateTime = DateTime.Parse("04/20/2020 05:15 PM"),
                    Address = "202 First Street",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zipcode = "52402",
                    BannerPath = "billysParade.jpg",
                    Status = "PendingApproval",
                    Description = "Billy Little is hosting a childrens animal parade."
                },

                new PUEvent()
                {
                    EventID = 1000001,
                    CreatedByID = 1000010,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    EventName = "Fun at the Lake",
                    EventTypeID = "Adoption",
                    EventDateTime = DateTime.Parse("07/06/2020 06:30 PM"),
                    Address = "202 Fawn Lake Drive",
                    City = "Estes Park",
                    State = "CO",
                    Zipcode = "88233",
                    BannerPath = "FawnLake.jpg",
                    Status = "PendingApproval",
                    Description = "Come spend some time with our animals out at Fawn Lake Animal Shelter."
                },

                new PUEvent()
                {
                    EventID = 1000023,
                    CreatedByID = 1000142,
                    DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                    EventName = "Animal Cruelty Awareness Rally",
                    EventTypeID = "Awareness",
                    EventDateTime = DateTime.Parse("10/31/2020 05:15 PM"),
                    Address = "1187 Arbor Lane",
                    City = "Millbrook",
                    State = "WI",
                    Zipcode = "67421",
                    BannerPath = "ACAR.jpg",
                    Status = "PendingApproval",
                    Description = "Animals are cruel and you need to know about it."
                },

                new PUEvent()
                {
                    EventID = 1000418,
                    CreatedByID = 1000055,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    EventName = "Lets All Monkey Around",
                    EventTypeID = "Fundraiser",
                    EventDateTime = DateTime.Parse("01/24/2020 05:15 PM"),
                    Address = "9391 Amazing Place",
                    City = "Coolsville",
                    State = "MI",
                    Zipcode = "11697",
                    BannerPath = "monkeys.jpg",
                    Status = "Approved",
                    Description = "Come join us at the Amazing Place and go bananas with our monkeys."
                },
            };

            //A fake repository containing 4 requests
            requests = new List<Request>()
            {
                new Request()
                {
                    RequestID = 1000000,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    RequestTypeID = "Event",
                    Open = true
                },

                new Request()
                {
                    RequestID = 1000001,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    RequestTypeID = "Event",
                    Open = true
                },

                new Request()
                {
                    RequestID = 1000002,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    RequestTypeID = "Event",
                    Open = true
                },

                new Request()
                {
                    RequestID = 1000003,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    RequestTypeID = "Event",
                    Open = false
                },
            };

            // A fake repository of 4 event requests
            puEventRequests = new List<EventRequest>()
            {
                new EventRequest()
                {
                    EventID = 1000000,
                    RequestID = 1000000,
                    ReviewerID = 1000027,
                    DisapprovalReason = null,
                    DesiredVolunteers = 5,
                    Active = true
                },

                new EventRequest()
                {
                    EventID = 1000001,
                    RequestID = 1000001,
                    ReviewerID = 1000247,
                    DisapprovalReason = null,
                    DesiredVolunteers = 6,
                    Active = true
                },

                new EventRequest()
                {
                    EventID = 1000023,
                    RequestID = 1000002,
                    ReviewerID = 1000332,
                    DisapprovalReason = null,
                    DesiredVolunteers = 4,
                    Active = true
                },

                new EventRequest()
                {
                    EventID = 1000418,
                    RequestID = 1000003,
                    ReviewerID = 1001027,
                    DisapprovalReason = null,
                    DesiredVolunteers = 3,
                    Active = true
                }
            };

            eventTypes = new List<EventType>()
            {
                new EventType()
                {
                    EventTypeID = "Adoption",
                    Description = "An Adoption Event"
                },

                new EventType()
                {
                    EventTypeID = "Awareness",
                    Description = "An Awareness Event"
                },

                new EventType()
                {
                    EventTypeID = "Fundraiser",
                    Description = "A Fundraising Event"
                },

                new EventType()
                {
                    EventTypeID = "Recruiting",
                    Description = "A Recruiting Event"
                }
            };

            eventApprovalVM = new EventApprovalVM()
            {
                DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                EventName = "Animal Cruelty Awareness Rally",
                EventTypeID = "Awareness",
                EventDateTime = DateTime.Parse("10/31/2020 05:15 PM"),
                Address = "1187 Arbor Lane",
                City = "Millbrook",
                State = "WI",
                Zipcode = "67421",
                BannerPath = "ACAR.jpg",
                Status = "PendingApproval",
                Description = "Animals are cruel and you need to know about it.",
                RequestedByName = "Billy Anderson",
                DesiredVolunteers = 0,
                DisapprovalReason = null,
                ReviewerName = null
            };
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod, Matt Deaton
        /// Created: 02/06/2020
        /// Approver: Ryan Morganti
        /// 
        /// The method used to add a test event to the fake repository
        /// Returns 0 if failed
        /// Returns 1 if successful
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="puEvent"></param>
        /// <returns>result</returns>
        public int InsertEvent(PUEvent puEvent)
        {
            //Actual method returns the scope_identity EventID
            int result = 0;

            if (puEvent.EventName.Length < 8 || puEvent.EventName.Length > 150)
            {
                throw new ApplicationException("The Event Name value was outside the acceptable range.");
            }
            else if (puEvent.EventDateTime < DateTime.Now.AddDays(14))
            {
                throw new ApplicationException("The event date is too close. Must be at least 14 days in the future.");
            }
            else if (puEvent.Address.Length > 200 || puEvent.Address.Length < 6)
            {
                throw new ApplicationException("The address value was not within the acceptable range.");
            }
            else if (puEvent.City.Length < 2 || puEvent.City.Length > 50)
            {
                throw new ApplicationException("The city value was not within acceptable range.");
            }
            else if (puEvent.Zipcode.Length < 5 || puEvent.Zipcode.Length > 11)
            {
                throw new ApplicationException("The zipcode is not within acceptable range.");
            }
            else if (puEvent.BannerPath.Length < 5 || puEvent.BannerPath.Length > 250)
            {
                throw new ApplicationException("The picture file name is not within acceptable range.");
            }
            else if (!puEvent.BannerPath.ToLower().Contains(".jpg") && !puEvent.BannerPath.ToLower().Contains(".png"))
            {
                throw new ApplicationException("The picture file name is missing the file extension.");
            }
            else if (puEvent.Description.Length < 2 || puEvent.Description.Length > 500)
            {
                throw new ApplicationException("The discription value is not within the acceptable range.");
            }
            else
            {
                puEvents.Add(puEvent);
                if (puEvents.Count == 5)
                {
                    result = 1;
                }

            }
            return result;
        }


        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 02/06/2020
        /// Approver: Ryan Morganti
        /// 
        /// The method used to Edit a test event in the fake repository
        /// Returns false if failed
        /// Returns true if successful
        ///
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="oldEvent"></param>
        /// <param name="newEvent"></param>
        /// <returns></returns>
        public bool UpdateEventDetails(PUEvent oldEvent, PUEvent newEvent)
        {
            bool successfulEdit = false;

            if (newEvent.EventName.Length < 8 || newEvent.EventName.Length > 150)
            {
                throw new ApplicationException("The Event Name value was outside the acceptable range.");
            }
            else if (newEvent.EventDateTime < DateTime.Now.AddDays(14))
            {
                throw new ApplicationException("The event date is too close. Must be at least 14 days in the future.");
            }
            else if (newEvent.Address.Length > 200 || newEvent.Address.Length < 6)
            {
                throw new ApplicationException("The address value was not within the acceptable range.");
            }
            else if (newEvent.City.Length < 2 || newEvent.City.Length > 50)
            {
                throw new ApplicationException("The city value was not within acceptable range.");
            }
            else if (!Regex.Match(newEvent.Zipcode, "^[0-9]{5}(?:-[0-9]{4})?$").Success)
            {
                throw new ApplicationException("Invalid Zipcode");
            }
            else if (newEvent.BannerPath.Length < 6 || newEvent.BannerPath.Length > 250)
            {
                throw new ApplicationException("The picture file name is not within acceptable range.");
            }
            else if (!newEvent.BannerPath.Substring(newEvent.BannerPath.Length - 4).ToLower().Equals(".jpg")
                && !newEvent.BannerPath.Substring(newEvent.BannerPath.Length - 4).ToLower().Equals(".png"))
            {
                throw new ApplicationException("The picture file name is missing the file extension.");
            }
            else if (newEvent.Description.Length < 2 || newEvent.Description.Length > 500)
            {
                throw new ApplicationException("The discription value is not within the acceptable range.");
            }
            else
            {
                //Finds the event matching the old event's eventID and assigns the values from the new event
                PUEvent eventToBeEdited = puEvents.Find(delegate (PUEvent e) { return e.EventID == oldEvent.EventID; });
                eventToBeEdited.EventName = newEvent.EventName;
                eventToBeEdited.EventTypeID = newEvent.EventTypeID;
                eventToBeEdited.EventDateTime = newEvent.EventDateTime;
                eventToBeEdited.Address = newEvent.Address;
                eventToBeEdited.City = newEvent.City;
                eventToBeEdited.State = newEvent.State;
                eventToBeEdited.Zipcode = newEvent.Zipcode;
                eventToBeEdited.DateCreated = newEvent.DateCreated;
                eventToBeEdited.BannerPath = newEvent.BannerPath;
                eventToBeEdited.CreatedByID = newEvent.CreatedByID;
                eventToBeEdited.Description = newEvent.Description;
                eventToBeEdited.Status = newEvent.Status;
            }
            //Checks that the old events values now match the new events values
            if (oldEvent.EventName == newEvent.EventName
                && oldEvent.EventTypeID == newEvent.EventTypeID
                && oldEvent.EventDateTime == newEvent.EventDateTime
                && oldEvent.Address == newEvent.Address
                && oldEvent.City == newEvent.City
                && oldEvent.State == newEvent.State
                && oldEvent.Zipcode == newEvent.Zipcode
                && oldEvent.DateCreated == newEvent.DateCreated
                && oldEvent.BannerPath == newEvent.BannerPath
                && oldEvent.CreatedByID == newEvent.CreatedByID
                && oldEvent.Description == newEvent.Description
                && oldEvent.Status == newEvent.Status)
            {
                successfulEdit = true;
            }
            return successfulEdit;
        }


        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 02/06/2020
        /// Approver: Ryan Morganti
        /// 
        /// The method used to add a test event to the fake repository
        /// Returns false if failed
        /// Returns true if successful
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public bool DeleteEvent(int eventID)
        {
            bool successfulDelete = false;
            PUEvent eventToBeDeleted = puEvents.Find(delegate (PUEvent e) { return e.EventID == eventID; });
            puEvents.Remove(eventToBeDeleted);
            if (puEvents.Count == 3)
            {
                successfulDelete = true;
            }
            return successfulDelete;
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 02/06/2020
        /// Approver: Ryan Morganti
        /// 
        /// The method used to add a test event request to the fake repository
        /// Returns 1 if the event request was successfully added to the list
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="eventRequest"></param>
        /// <returns></returns>
        public int InsertEventRequest(EventRequest eventRequest)
        {
            int rowsEffected = 0;
            puEventRequests.Add(eventRequest);
            if (puEventRequests.Count == 5)
            {
                rowsEffected = 1;
            }

            return rowsEffected;
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 02/06/2020
        /// Approver: Ryan Morganti
        /// 
        /// The method used to add a test Request to the fake repository
        /// Returns 1 if the Request was successfully added to the list
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        public int InsertRequest(Request request)
        {
            int requestID = 0;
            requests.Add(request);
            if (requests.Count == 5)
            {
                requestID = 1;
            }
            return requestID;
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 02/06/2020
        /// Approver: Ryan Morganti
        /// 
        /// The method used to select a test event from the fake repository by EventID
        /// Returns the event with the matching ID
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<EventType> SelectAllEventTypes()
        {
            var eventTypeList = (from e in eventTypes
                                 select e).ToList();

            return eventTypeList;
        }


        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 02/06/2020
        /// Approver: Ryan Morganti
        /// 
        /// The method used to select a test event from the fake repository by EventID
        /// Returns the event with the matching ID
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public PUEvent SelectEventByID(int eventID)
        {
            var selectedEvent = (PUEvent)(from e in puEvents
                                          where e.EventID == eventID
                                          select e).SingleOrDefault();

            return selectedEvent;
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 02/06/2020
        /// Approver: Ryan Morganti
        /// 
        /// The method used to select all test events from the fake repository
        /// Returns 0 if failed
        /// Returns 1 if successful
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<PUEvent> SelectEventsAll()
        {
            var selectedEvents = (from e in puEvents
                                  select e).ToList();
            return selectedEvents;
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/15/2020
        /// Approver: Ryan Morganti
        /// 
        /// A fake accessor method for testing the SelectEventApprovalVM Method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <param name="createdByID"></param>
        /// <returns></returns>
        public EventApprovalVM SelectEventApprovalVM(int eventID, int createdByID)
        {
            if (eventID == 1000418 && createdByID == 1000055)
            {
                return eventApprovalVM;
            }
            else
            {
                throw new ApplicationException("Data Not Found");
            }
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/15/2020
        /// Approver: Ryan Morganti
        /// 
        /// A fake accessor method for testing the SelectEventRequestByEventID Method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public EventRequest SelectEventRequestByEventID(int eventID)
        {
            var selectedEventRequest = (from e in puEventRequests
                                        where e.EventID == eventID
                                        select e).SingleOrDefault();
            return selectedEventRequest;
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/15/2020
        /// Approver: Ryan Morganti
        /// 
        /// A fake accessor method for testing the UpdateEventRequest Method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="oldEventRequest"></param>
        /// <param name="newEventRequest"></param>
        /// <returns></returns>
        public bool UpdateEventRequest(EventRequest oldEventRequest, EventRequest newEventRequest)
        {
            bool successfulUpdate = false;

            if (newEventRequest.DisapprovalReason != null)
            {
                if (newEventRequest.DisapprovalReason.Length == 0)
                {
                    throw new ApplicationException("Disapproval Reason cannot be blank.");
                }
                if (newEventRequest.DisapprovalReason.Length > 500)
                {
                    throw new ApplicationException("Disapproval Reason is too long");
                }
            }
            else
            {
                //Finds the event request matching the old event request's eventID 
                //and assigns the values from the new event request
                EventRequest eventRequestToBeEdited = puEventRequests.Find(delegate (EventRequest e) { return e.EventID == oldEventRequest.EventID; });
                eventRequestToBeEdited.ReviewerID = newEventRequest.ReviewerID;
                eventRequestToBeEdited.DisapprovalReason = newEventRequest.DisapprovalReason;
                eventRequestToBeEdited.DesiredVolunteers = newEventRequest.DesiredVolunteers;
                eventRequestToBeEdited.Active = newEventRequest.Active;

                if (oldEventRequest.ReviewerID == newEventRequest.ReviewerID
                && oldEventRequest.DisapprovalReason == newEventRequest.DisapprovalReason
                && oldEventRequest.DesiredVolunteers == newEventRequest.DesiredVolunteers
                && oldEventRequest.Active == newEventRequest.Active)
                {
                    successfulUpdate = true;
                }
            }
            return successfulUpdate;
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/15/2020
        /// Approver: Ryan Morganti
        /// 
        /// A fake accessor method for testing the SelectEventsByStatus Method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<PUEvent> SelectEventsByStatus(string status)
        {
            var selectedEvents = (from e in puEvents
                                  where e.Status == status
                                  select e).ToList();
            return selectedEvents;
        }

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/15/2020
        /// Approver: Ryan Morganti
        /// 
        /// A fake accessor method for testing the UpdateEventStatus Method
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateEventStatus(int eventID, string status)
        {
            bool successfulUpdate = false;
            //retrieve the event Pre-update
            var selectedEvent = (from e in puEvents
                                 where e.EventID == eventID
                                 select e).SingleOrDefault();

            //keep its pre-update status
            string currentStatus = selectedEvent.Status;
            //Update the events status
            selectedEvent.Status = status;

            //Retrieve the same event after the update
            var checkEvent = (from e in puEvents
                              where e.EventID == eventID
                              select e).SingleOrDefault();

            //Check that the event's pre-update and post-update status is different
            if (checkEvent.Status != currentStatus)
            {
                successfulUpdate = true;
            }
            return successfulUpdate;
        }

    }
}
