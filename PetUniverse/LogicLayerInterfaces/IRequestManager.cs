using DataTransferObjects;
using System.Collections.Generic;

/// <summary>
///  Creator: Kaleb Bachert
///  Created: 2/7/2020
///  Approver: Zach Behrensmeyer
///  
///  Interface for the Request Manager Class
/// </summary>

namespace LogicLayer
{
    public interface IRequestManager
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Interface method for retrieving all requests
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<RequestVM> RetrieveRequestsByStatus(bool open);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: NA
        ///  
        ///  Interface method for approving a request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        int ApproveRequest(int requestID, int userID, string requestType);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Interface method for selecting New DepartmentRequests
        /// based on list of DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptIDs"></param>
        /// <returns></returns>
        List<DepartmentRequest> RetrieveNewRequestsByDepartmentID(List<string> deptIDs);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver:  Derek Taylor
        ///
        /// Interface method for selecting Active DepartmentRequests
        /// based on list of DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptIDs"></param>
        /// <returns></returns>
        List<DepartmentRequest> RetrieveActiveRequestsByDepartmentID(List<string> deptIDs);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Interface method for selecting Complete DepartmentRequests
        /// based on list of DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptIDs"></param>
        /// <returns></returns>
        List<DepartmentRequest> RetrieveCompleteRequestsByDepartmentID(List<string> deptIDs);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver: Derek Taylor
        ///
        /// Interface method for selecting DepartmentIDs based on a UserID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<string> RetrieveAllDepartmentIDsByUserID(int userId);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/3
        ///  APPROVER: NA
        ///  
        ///  Interface method for adding a TimeOff Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        bool AddTimeOffRequest(TimeOffRequest request, int RequestingEmployeeID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for retrieving a TimeOffRequest by RequestID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        TimeOffRequestVM RetrieveTimeOffRequestByRequestID(int requestID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/17
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for adding an availability Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <param name="requestingEmployeeID"></param>
        bool AddAvailabilityRequest(AvailabilityRequestVM request, int requestingEmployeeID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        ///
        /// Interface method for selecting all requests types.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <returns></returns>
        List<string> RetriveAllRequestTypes();

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        ///
        /// Interface method for selecting all employee names and associated employee numbers.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <returns></returns>
        List<string[]> RetrieveEmployeeNames();

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        ///
        /// Interface method for selecting all DepartmentRequest responses.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="requestID"></param>
        /// <returns></returns>
        List<RequestResponse> RetrieveAllResponsesByRequestID(int requestID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approver: Derek Taylor
        ///
        /// Interface method for updating a DepartmentRequest status from 'new' to 'acknowledged'.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="requestID"></param>
        /// <returns></returns>
        int SetDeptRequestStatusToAcknowledged(int userID, int requestID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approver: Derek Taylor
        ///
        /// Interface method for updating a DepartmentRequest status from 'acknowledged' to 'completed'.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="requestID"></param>
        /// <returns></returns>
        int SetDeptRequestStatusToCompleted(int userID, int requestID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/18
        /// Approver: Derek Taylor
        ///
        /// Interface method for editing a DepartmentRequest's details.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
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
        int EditDepartmentRequestDetails(int userID, int requestID, string oldRequestedGroupID, string oldRequestTopic,
            string oldRequestBody, string newRequestedGroupID, string newRequestTopic, string newRequestBody);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for creating a schedule change request.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA     
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestingUserID"></param>
        bool AddScheduleChangeRequest(ScheduleChangeRequest request, int requestingUserID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for inserting Active Time Off, called once a request is approved
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="activeTimeOff"></param>

        bool AddActiveTimeOff(ActiveTimeOff activeTimeOff);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/9
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for retrieving a ScheduleChangeRequest by RequestID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        ScheduleChangeRequestVM RetrieveScheduleChangeRequestByRequestID(int requestID);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/07
        /// Approver: Kaleb Bachert 
        /// 
        /// interface method for Getting AvaibilityRequest 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="requestID"></param>
        /// <returns></returns>
        AvailabilityRequestVM RetrieveAvailabilityRequestByID(int requestID);


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/4/10
        /// APPROVER: Matt Deaton
        ///  
        /// Interface method for adding a social media request
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        int AddSocialMediaRequest(SocialMediaRequest request);


        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        /// <summary>
        /// This method is to add a request that gets the department name.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="department"></param>
        /// </remarks>
        /// 


        bool addNewRequestIsPosted(DepartmentRequest department);


        List<ViewResponds> responds();

        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        ///<summary>
        /// this method is testing the insertion of the responds.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="requestID"></param>
        /// <param name="text"></param>
        /// /// <param name="userID"></param>
        /// </remarks>

        bool insertRequestResponse(int requestID, string text, string userID);

        /// NAME: Hassan Karar
        /// DATE: 2020/2/7
        /// CHECKED BY: Derek Taylor
        ///<summary>
        /// this method test the cancelation of the  request.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="requestID"></param>
        /// </remarks>
        /// 


        bool cancleRequest(int requestID);


        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/05/05
        /// Approver: Steve Coonrod
        ///
        /// Interface method for creating a new DepartmentRequest.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        int CreateNewRequest(DepartmentRequest request);

    }
}
