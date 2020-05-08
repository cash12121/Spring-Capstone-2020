using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Creator: Kaleb Bachert
/// Created: 2/7/2020
/// Approver: Jordan Lindo
/// 
/// Fake Request Accessor Class for Unit Testing
/// </summary>

namespace DataAccessFakes
{
    public class FakeRequestAccessor : IRequestAccessor
    {
        private List<RequestVM> requests;
        private List<TimeOffRequest> timeOffRequests;
        private List<TimeOffRequestVM> timeOffRequestVMs;
        private List<AvailabilityRequestVM> availabilityRequestVMs;
        private List<ActiveTimeOff> activeTimeOffList;
        private List<ScheduleChangeRequest> scheduleChangeRequests;
        private List<ScheduleChangeRequestVM> scheduleChangeRequestVMs;

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 2/7/2020
        /// Approver: Jordan Lindo
        ///  
        /// Fake Request Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public FakeRequestAccessor()
        {
            requests = new List<RequestVM>()
            {
                new RequestVM()
                {
                    RequestID = 1000000,
                    RequestTypeID = "Time Off",
                    RequestingEmployeeID = 1000001,
                    DateCreated = DateTime.Now.AddDays(-5),
                    Open = true
                },

                new RequestVM()
                {
                    RequestID = 1000001,
                    RequestTypeID = "Time Off",
                    RequestingEmployeeID = 1000001,
                    DateCreated = DateTime.Now.AddDays(-3),
                    Open = true
                },

                new RequestVM()
                {
                    RequestID = 1000002,
                    RequestTypeID = "Availability Change",
                    RequestingEmployeeID = 1000001,
                    DateCreated = DateTime.Now,
                    Open = true
                }
            };

            timeOffRequestVMs = new List<TimeOffRequestVM>()
            {
                new TimeOffRequestVM()
                {
                    TimeOffRequestID = 1000000,
                    EffectiveStart = DateTime.Now.ToString(),
                    EffectiveEnd = DateTime.Now.AddDays(1).ToString(),
                    RequestID = 1000000
                },

                new TimeOffRequestVM()
                {
                    TimeOffRequestID = 1000001,
                    EffectiveStart = DateTime.Now.ToString(),
                    EffectiveEnd = DateTime.Now.AddDays(7).ToString(),
                    RequestID = 1000001
                }
            };

            timeOffRequests = new List<TimeOffRequest>()
            {
                new TimeOffRequest()
                {
                    TimeOffRequestID = 1000000,
                    EffectiveStart = DateTime.Now,
                    EffectiveEnd = DateTime.Now.AddDays(1),
                    RequestID = 1000000
                },

                new TimeOffRequest()
                {
                    TimeOffRequestID = 1000001,
                    EffectiveStart = DateTime.Now,
                    EffectiveEnd = DateTime.Now.AddDays(7),
                    RequestID = 1000001
                }
            };

            availabilityRequestVMs = new List<AvailabilityRequestVM>()
            {
                new AvailabilityRequestVM()
                {
                    SundayStartTime = "TEST TIME",
                    SundayEndTime = "TEST TIME",
                    MondayStartTime = "TEST TIME",
                    MondayEndTime = "TEST TIME",
                    TuesdayStartTime = "TEST TIME",
                    TuesdayEndTime = "TEST TIME",
                    WednesdayStartTime = "TEST TIME",
                    WednesdayEndTime = "TEST TIME",
                    ThursdayStartTime = "TEST TIME",
                    ThursdayEndTime = "TEST TIME",
                    FridayStartTime = "TEST TIME",
                    FridayEndTime = "TEST TIME",
                    SaturdayStartTime = "TEST TIME",
                    SaturdayEndTime = "TEST TIME",
                    AvailabilityRequestID = 1000000,
                    RequestID = 1000002
                }
            };

            activeTimeOffList = new List<ActiveTimeOff>()
            {
                new ActiveTimeOff()
                {
                    UserID = 100001,
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(15),
                }
            };

            scheduleChangeRequests = new List<ScheduleChangeRequest>();

            scheduleChangeRequestVMs = new List<ScheduleChangeRequestVM>()
            {
                new ScheduleChangeRequestVM()
                {
                    ScheduleChangeRequestID = 1000000,
                    RequestID = 1000004
                }
            };
        }

        private List<DepartmentRequest> _requests = new List<DepartmentRequest>()
        {
            new DepartmentRequest
            {
                RequesteeGroupID = "Management",
                RequestorGroupID = "Inventory",
                DateAcknowledged = DateTime.Now,
                DateCompleted = DateTime.Now.AddDays(2)
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "CustomerService",
                RequestorGroupID = "Inventory",
                DateAcknowledged = DateTime.Now,
                DateCompleted = DateTime.Now.AddDays(2)
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "Management",
                RequestorGroupID = "Management",
                DateAcknowledged = DateTime.Now,
                DateCompleted = DateTime.Now.AddDays(2)
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "CustomerService",
                RequestorGroupID = "Inventory",
                DateAcknowledged = DateTime.Now
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "CustomerService",
                RequestorGroupID = "CustomerService",
                DateAcknowledged = DateTime.Now
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "Management",
                RequestorGroupID = "CustomerService"
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "CustomerService",
                RequestorGroupID = "Inventory"
            }

        };

        List<string[]> EmployeeDepts = new List<string[]>
        {
            new string[] {"100000", "Management"},
            new string[] {"100001", "CustomerService"},
            new string[] {"100001", "Management"},
            new string[] {"100001", "Inventory"}
        };

        List<string[]> EmployeeNames = new List<string[]>
        {
            new string[] {"100000", "Ryan", "Morganti"},
            new string[] {"100001", "Derek", "Taylor"},
            new string[] {"100002", "Steve", "Coonrod"},
            new string[] {"100003", "Matthew", "Deaton"}
        };

        List<string> RequestTypes = new List<string>
        {
            "Department" ,
            "General",
            "Scheduling"
        };

        List<RequestResponse> responses = new List<RequestResponse>
        {
            new RequestResponse
            {
                RequestResponseID = 100,
                RequestID = 100,
                UserID = 100000,
                Response = "Yo",
                TimeStamp = DateTime.Now
            },
            new RequestResponse
            {
                RequestResponseID = 101,
                RequestID = 101,
                UserID = 100000,
                Response = "Yo",
                TimeStamp = DateTime.Now
            },
            new RequestResponse
            {
                RequestResponseID = 102,
                RequestID = 100,
                UserID = 100000,
                Response = "Yo",
                TimeStamp = DateTime.Now
            },
            new RequestResponse
            {
                RequestResponseID = 103,
                RequestID = 100,
                UserID = 100000,
                Response = "Yo",
                TimeStamp = DateTime.Now
            },
            new RequestResponse
            {
                RequestResponseID = 104,
                RequestID = 101,
                UserID = 100000,
                Response = "Yo",
                TimeStamp = DateTime.Now
            }
        };

        List<DepartmentRequest> DepartmentRequestStatuses = new List<DepartmentRequest>
        {
            new DepartmentRequest
            {
                RequestID = 100001
            },
            new DepartmentRequest
            {
                RequestID = 100002
            },
            new DepartmentRequest
            {
                RequestID = 100009,
                RequestingUserID = 100000,
                RequesteeGroupID = "Management",
                Topic = "topic1",
                Body = "Bodies everywhere"
            }
        };

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// This is the mock access method for Active Requests
        /// queried based on DepartmentID and year value of DateAcknowledged
        /// and DateCompleted
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns>List of requests</returns>
        public List<DepartmentRequest> SelectActiveRequestsByDepartmentID(string deptID)
        {
            return (from r in _requests
                    where (r.RequesteeGroupID == deptID ||
                    r.RequestorGroupID == deptID) &&
                    (r.DateAcknowledged.Year > 2000 &&
                    r.DateCompleted.Year < 2000)
                    select r).ToList();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// Mock Access Method for selecting a list of departments based on UserID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<string> SelectAllEmployeeDepartments(int userID)
        {
            return (from e in EmployeeDepts
                    where e[0] == userID.ToString()
                    select e[1]).ToList();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// This is the mock access method for Complete Requests
        /// queried based on DepartmentID and year values of DateAcknowledged
        /// and DateCompleted
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns>List of complete requests</returns>
        public List<DepartmentRequest> SelectCompleteRequestsByDepartmentID(string deptID)
        {
            return (from r in _requests
                    where (r.RequesteeGroupID == deptID ||
                    r.RequestorGroupID == deptID) &&
                    (r.DateAcknowledged.Year > 2000 &&
                    r.DateCompleted.Year > 2000)
                    select r).ToList();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// This is the mock access method for New Requests
        /// queried based on DepartmentID and year values of DateAcknowledged
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns>List of new requests</returns>
        public List<DepartmentRequest> SelectNewRequestsByDepartmentID(string deptID)
        {
            return (from r in _requests
                    where (r.RequesteeGroupID == deptID ||
                    r.RequestorGroupID == deptID) &&
                    r.DateAcknowledged.Year < 2000
                    select r).ToList();
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 2/7/2020
        /// Approver: Jordan Lindo
        ///  
        /// Method that retrieves all the dummy Requests, for testing
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public List<RequestVM> SelectRequestsByStatus(bool open)
        {
            return (from r in requests
                    where r.Open = open
                    select r).ToList();
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 2/7/2020
        /// Approver: Jordan Lindo
        ///  
        /// Method that approves a dummy Request, for testing
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int ApproveRequest(int requestID, int userID, string requestType)
        {
            timeOffRequests[1].ApprovingUserID = userID;
            timeOffRequests[1].ApprovalDate = DateTime.Now;

            return 1;
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 3/3/2020
        /// Approver: Lane Sandburg
        ///  
        /// Method that inserts a dummy Request, for testing
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int InsertTimeOffRequest(TimeOffRequest request, int requestingUserID)
        {
            int oldCount = timeOffRequests.Count;

            timeOffRequests.Add(request);

            return timeOffRequests.Count - oldCount;
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 3/5/2020
        /// Approver: Lane Sandburg
        ///  
        /// Method that retrieves a dummy request by ID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public TimeOffRequestVM SelectTimeOffRequestByRequestID(int RequestID)
        {
            return timeOffRequestVMs.Where(request => request.RequestID == RequestID).First();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/9
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Method that retrieves a dummy request by ID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public ScheduleChangeRequestVM SelectScheduleChangeRequestByRequestID(int RequestID)
        {
            return scheduleChangeRequestVMs.Where(request => request.RequestID == RequestID).First();
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 3/17/2020
        /// Approver: Lane Sandburg
        ///  
        /// Method that inserts a new availability request
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int InsertAvailabilityRequest(AvailabilityRequestVM request, int requestingUserID)
        {
            int oldCount = availabilityRequestVMs.Count;

            availabilityRequestVMs.Add(request);

            return availabilityRequestVMs.Count - oldCount;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/03/10
        ///  APPROVER: Derek Taylor
        ///  
        ///  Method for returning a fake list of RequestTypes from the database.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<string> SelectAllRequestTypes()
        {
            return (from r in RequestTypes
                    select r).ToList();
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/03/10
        ///  APPROVER: Derek Taylor
        ///  
        ///  Method for returning a fake list of Employee names and their associated userIDs.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<string[]> SelectAllEmployeeNames()
        {
            return (from r in EmployeeNames
                    select r).ToList();
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/03/10
        ///  APPROVER: Derek Taylor
        ///  
        ///  Method for returning a fake list of RequestResponses linked to a designated Request from the database.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public List<RequestResponse> SelectAllRequestResponsesByRequestID(int requestID)
        {
            return (from r in responses
                    where r.RequestID == requestID
                    select r).ToList();
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/03/16
        ///  APPROVER: Derek Taylor
        ///  
        ///  Method for updating a DepartmentRequest record to Acknowledged, by supplying an accurate requestID and a userID.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userId"></param>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public int UpdateDepartmentRequestStatusToAcknowledged(int userId, int requestID)
        {
            int result;
            List<DepartmentRequest> requests = new List<DepartmentRequest>();
            requests = DepartmentRequestStatuses.Where(r => r.RequestID == requestID)
                                                .Select(r => { r.DateAcknowledged = DateTime.Now; r.AcknowledgingEmployee = userId; return r; })
                                                .ToList();

            if (requests.Count == 1)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/03/16
        ///  APPROVER: Derek Taylor
        ///  
        ///  Method for updating a DepartmentRequest record to Complete, by supplying an accurate requestID and a userID.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public int UpdateDepartmentRequestStatusToCompleted(int userID, int requestID)
        {
            int result;
            List<DepartmentRequest> requests = new List<DepartmentRequest>();
            requests = DepartmentRequestStatuses.Where(r => r.RequestID == requestID)
                                                .Select(r => { r.DateCompleted = DateTime.Now; r.CompletedEmployee = userID; return r; })
                                                .ToList();

            if (requests.Count == 1)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/03/16
        ///  APPROVER: Derek Taylor
        ///  
        ///  Method for updating a DepartmentRequest's details, based on a requestID and userID.
        ///  
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="requestID"></param>
        /// <param name="oldRequestedGroupID"></param>
        /// <param name="oldRequestTopic"></param>
        /// <param name="oldRequestBody"></param>
        /// <param name="newRequestedGroupID"></param>
        /// <param name="newRequestTopic"></param>
        /// <param name="newRequestBody"></param>
        /// <returns></returns>
        public int UpdateDepartmentRequest(int userID, int requestID, string oldRequestedGroupID, string oldRequestTopic, string oldRequestBody,
                                            string newRequestedGroupID, string newRequestTopic, string newRequestBody)
        {
            List<DepartmentRequest> request = DepartmentRequestStatuses.Where(r => r.RequestingUserID == userID && r.RequestID == requestID
                                                                        && r.RequesteeGroupID == oldRequestedGroupID && r.Topic == oldRequestTopic
                                                                        && r.Body == oldRequestBody)
                                                                 .Select(r =>
                                                                 {
                                                                     r.RequesteeGroupID = newRequestedGroupID; r.Topic = newRequestTopic;
                                                                     r.Body = newRequestBody; return r;
                                                                 })
                                                                 .ToList();
            if (request.Count == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that inserts a new ActiveTimeOff record (Approved Time Off)
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int InsertActiveTimeOff(ActiveTimeOff activeTimeOff)
        {
            int oldCount = activeTimeOffList.Count;

            activeTimeOffList.Add(activeTimeOff);

            return activeTimeOffList.Count - oldCount;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that inserts a new Schedule Change Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int InsertScheduleChangeRequest(ScheduleChangeRequest request, int requestingUserID)
        {
            int oldCount = scheduleChangeRequests.Count;

            scheduleChangeRequests.Add(request);

            return scheduleChangeRequests.Count - oldCount;
        }

        public AvailabilityRequestVM SelectAvailabilityRequestByID(int requestID)
        {
            foreach (var item in availabilityRequestVMs)
            {
                if (item.RequestID == requestID)
                {
                    return item;
                }
            }
            throw new Exception();
        }


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-04-10
        /// APPROVER: Matt Deaton
        ///  
        /// This is a fake accessor method for inserting a social media request
        /// It returns a mock RequestID for the request if it passes the
        /// validation on the title and description values, otherwise it
        /// returns 0 for an unsuccessful insertion
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int InsertSocialMediaRequest(SocialMediaRequest request)
        {
            if (request.Title.Trim().Length > 0 && request.Description.Trim().Length > 0)
            {
                return 1000014;
            }
            else
            {
                return 0;
            }

        }


        private string department, subject, body;
        private int requestID;
        private string response;
        private List<ViewResponds> viewResponds;


        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        /// This method is to add a fake data to the request.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="department"></param>
        /// </remarks>
        /// 

        public bool addNewRequestIsPosted(DepartmentRequest department)
        {
            bool result = true;
            this.department = department.RequestID.ToString();
            this.subject = department.Subject;
            this.body = department.Body;
            if ((null != this.department) && (null != this.subject) && (null != this.body))
            {
                result = true;
            }
            return result;
        }

        /// NAME: Hassan Karar
        /// DATE:2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        /// This method is to send feke data for deleting a a reguest to logic layer test.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="requestID"></param>
        /// </remarks>
        /// 

        public bool cancleRequest(int requestID)
        {
            throw new NotImplementedException();
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        /// This method is to send feke data for submit a response and send it to logic layer test.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="requestID"></param>
        /// <param name="text"></param>
        /// /// <param name="userID"></param>
        /// </remarks>
        /// 


        public bool insertRequestResponse(int requestID, string text, string userID)
        {

            this.requestID = requestID;
            response = text;

            bool result = false;

            if (this.requestID != 0 && response != "")
            {
                result = true;
            }

            return result;

        }


        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        ///  This method is sending feke list of reguesr responses to test it.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="ViewResponds"></param>
        /// </remarks>
        /// 
        public List<ViewResponds> viewRequestRsponds()
        {

            return viewResponds;

        }


        ///
        ///  CREATOR: Hassan Karar.
        ///  CREATED: 2020/2/7
        ///  APPROVER: 
        ///   <summary>
        ///   Method that retrieves all the Requests.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// <param name=""></param>
        /// </remarks>
        public List<RequestVM> SelectAllRequests()
        {
            return (from r in requests select r).ToList();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/05/06
        /// Approver: Steve Coonrod
        ///
        /// Fake Access Method for inserting a new DepartmentRequest record.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        public int InsertNewDepartmentRequest(DepartmentRequest request)
        {
            int count = _requests.Count;

            _requests.Add(request);

            if(count < _requests.Count)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
