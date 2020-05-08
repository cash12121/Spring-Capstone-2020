using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///  Creator: Kaleb Bachert
///  Created: 2/9/2020
///  Approver: Zach Behrensmeyer
///  
///  Accessor Class for Requests
/// </summary>
/// <remarks>
/// Updater: NA
/// Updated: NA
/// Update: NA
/// 
/// </remarks>

namespace DataAccessLayer
{
    public class RequestAccessor : IRequestAccessor
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method retrieves all Requests from the Database by status.
        ///  
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/3/6
        /// UPDATE: Changed the Request DTO, updated fields here
        /// 
        /// </remarks>
        public List<RequestVM> SelectRequestsByStatus(bool open)
        {
            List<RequestVM> requests = new List<RequestVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_requests_by_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("OpenStatus", open);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RequestVM request = new RequestVM();

                        request.RequestID = reader.GetInt32(0);
                        request.RequestTypeID = reader.GetString(1);
                        request.RequestingEmployeeID = reader.GetInt32(2);
                        request.DateCreated = reader.GetDateTime(3);
                        request.RequestingEmail = reader.GetString(4);

                        requests.Add(request);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requests;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: NA
        ///  
        ///  This method approves a currently unapproved, and open request in the database
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/3/7
        /// UPDATE: Changes Stored Procedure name based on requestType
        /// UPDATER: Chase Schulte
        /// UPDATED: 2020/04/08
        /// UPDATE:  added new request type 
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public int ApproveRequest(int requestID, int userID, string requestType)
        {
            int requestsChanged = 0;

            var conn = DBConnection.GetConnection();
            SqlCommand cmd;

            switch (requestType)
            {
                case "Time Off":
                    cmd = new SqlCommand("sp_approve_time_off_request", conn);
                    break;
                case "Schedule Change":
                    cmd = new SqlCommand("sp_approve_schedule_change_request", conn);
                    break;
                case "Availability Change":
                    cmd = new SqlCommand("sp_approve_availability_change_request", conn);
                    break;
                default:
                    throw new ApplicationException("Request Type has no method for approving requests. Must be added to the RequestAccessor.");
            }
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("RequestID", requestID);
            cmd.Parameters.AddWithValue("UserID", userID);

            try
            {
                conn.Open();
                requestsChanged = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requestsChanged;
        }
        ///  CREATOR: Chase Schulte
        ///  CREATED: 2020/04/21
        ///  APPROVER: Kaleb Bachert
        ///  
        ///  This method retrieves a availabilityRequestByID
        /// </summary>
        /// <remarks>
        /// UPDATER:
        /// UPDATED:
        /// UPDATE: 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public AvailabilityRequestVM SelectAvailabilityRequestByID(int requestID)
        {
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_availbility_request_by_request_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("RequestID", requestID);
            AvailabilityRequestVM availabilityRequest = new AvailabilityRequestVM();
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    availabilityRequest.AvailabilityRequestID = reader.GetInt32(0);
                    availabilityRequest.SundayStartTime = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    availabilityRequest.SundayEndTime = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    availabilityRequest.MondayStartTime = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    availabilityRequest.MondayEndTime = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    availabilityRequest.TuesdayStartTime = reader.IsDBNull(5) ? "" : reader.GetString(5);
                    availabilityRequest.TuesdayEndTime = reader.IsDBNull(6) ? "" : reader.GetString(6);
                    availabilityRequest.WednesdayStartTime = reader.IsDBNull(7) ? "" : reader.GetString(7);
                    availabilityRequest.WednesdayEndTime = reader.IsDBNull(8) ? "" : reader.GetString(8);
                    availabilityRequest.ThursdayStartTime = reader.IsDBNull(9) ? "" : reader.GetString(9);
                    availabilityRequest.ThursdayEndTime = reader.IsDBNull(10) ? "" : reader.GetString(10);
                    availabilityRequest.FridayStartTime = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    availabilityRequest.FridayEndTime = reader.IsDBNull(12) ? "" : reader.GetString(12);
                    availabilityRequest.SaturdayStartTime = reader.IsDBNull(13) ? "" : reader.GetString(13);
                    availabilityRequest.SaturdayEndTime = reader.IsDBNull(14) ? "" : reader.GetString(14);
                    availabilityRequest.RequestID = reader.GetInt32(15);
                    availabilityRequest.RequestingUserID = reader.GetInt32(16);
                    availabilityRequest.FirstName = reader.GetString(17);
                    availabilityRequest.LastName = reader.GetString(18);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return availabilityRequest;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approvor: Derek Taylor
        ///
        /// Method for pulling Active Department Requests based on DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<DepartmentRequest> SelectActiveRequestsByDepartmentID(string deptID)
        {
            List<DepartmentRequest> requests = new List<DepartmentRequest>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_active_requests_by_departmentID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", deptID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DepartmentRequest newRequest = new DepartmentRequest();

                        newRequest.RequestID = reader.GetInt32(0);
                        newRequest.DateCreated = reader.GetDateTime(1);
                        newRequest.RequestTypeID = reader.GetString(2);
                        newRequest.RequestingUserID = reader.GetInt32(3);
                        newRequest.RequestorGroupID = reader.GetString(4);
                        newRequest.RequesteeGroupID = reader.GetString(5);
                        newRequest.DateAcknowledged = reader.GetDateTime(6);
                        newRequest.AcknowledgingEmployee = reader.GetInt32(7);
                        if (!reader.IsDBNull(8))
                        {
                            newRequest.Subject = reader.GetString(8);
                        }
                        newRequest.Topic = reader.GetString(9);
                        newRequest.Body = reader.GetString(10);

                        requests.Add(newRequest);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requests;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver:  Derek Taylor
        ///
        /// Method for querying a list of departmentIDs associated with a userID 
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<string> SelectAllEmployeeDepartments(int userID)
        {
            List<string> depts = new List<string>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_user_departmentID_by_eroleID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string dept = reader.GetString(0);
                        depts.Add(dept);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return depts;

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Method for pulling Completed Department Requests based on DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<DepartmentRequest> SelectCompleteRequestsByDepartmentID(string deptID)
        {
            List<DepartmentRequest> requests = new List<DepartmentRequest>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_completed_requests_by_departmentID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", deptID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DepartmentRequest newRequest = new DepartmentRequest();

                        newRequest.RequestID = reader.GetInt32(0);
                        newRequest.DateCreated = reader.GetDateTime(1);
                        newRequest.RequestTypeID = reader.GetString(2);
                        newRequest.RequestingUserID = reader.GetInt32(3);
                        newRequest.RequestorGroupID = reader.GetString(4);
                        newRequest.RequesteeGroupID = reader.GetString(5);
                        newRequest.DateAcknowledged = reader.GetDateTime(6);
                        newRequest.AcknowledgingEmployee = reader.GetInt32(7);
                        newRequest.DateCompleted = reader.GetDateTime(8);
                        newRequest.CompletedEmployee = reader.GetInt32(9);
                        if (!reader.IsDBNull(10))
                        {
                            newRequest.Subject = reader.GetString(10);
                        }
                        newRequest.Topic = reader.GetString(11);
                        newRequest.Body = reader.GetString(12);

                        requests.Add(newRequest);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requests;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approvor: Derek Taylor
        ///
        /// Method for pulling New Department Requests based on DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<DepartmentRequest> SelectNewRequestsByDepartmentID(string deptID)
        {
            List<DepartmentRequest> requests = new List<DepartmentRequest>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_new_requests_by_departmentID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", deptID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DepartmentRequest newRequest = new DepartmentRequest();

                        newRequest.RequestID = reader.GetInt32(0);
                        newRequest.DateCreated = reader.GetDateTime(1);
                        newRequest.RequestTypeID = reader.GetString(2);
                        newRequest.RequestingUserID = reader.GetInt32(3);
                        newRequest.RequestorGroupID = reader.GetString(4);
                        newRequest.RequesteeGroupID = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                        {
                            newRequest.Subject = reader.GetString(6);
                        }
                        newRequest.Topic = reader.GetString(7);
                        newRequest.Body = reader.GetString(8);

                        requests.Add(newRequest);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requests;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/3
        ///  APPROVER: NA
        ///  
        ///  This method creates a Time Off Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public int InsertTimeOffRequest(TimeOffRequest request, int requestingUserID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_time_off_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EffectiveStart", request.EffectiveStart);
            cmd.Parameters.AddWithValue("@EffectiveEnd", request.EffectiveEnd);
            cmd.Parameters.AddWithValue("@RequestingUserID", requestingUserID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method gets a TimeOffRequest by RequestID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public TimeOffRequestVM SelectTimeOffRequestByRequestID(int requestID)
        {
            TimeOffRequestVM request = null;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_time_off_request_by_requestid", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("RequestID", requestID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        request = new TimeOffRequestVM();

                        request.TimeOffRequestID = reader.GetInt32(0);
                        request.EffectiveStart = reader.GetDateTime(1).ToString();
                        request.EffectiveEnd = reader.IsDBNull(2) ? "" : reader.GetDateTime(2).ToString();
                        request.ApprovalDate = reader.IsDBNull(3) ? "" : reader.GetDateTime(3).ToString();
                        request.ApprovingUserID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        request.RequestID = reader.GetInt32(5);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return request;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/18
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method adds a new Availability Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public int InsertAvailabilityRequest(AvailabilityRequestVM request, int requestingUserID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_availability_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SundayStart", request.SundayStartTime);
            cmd.Parameters.AddWithValue("@SundayEnd", request.SundayEndTime);
            cmd.Parameters.AddWithValue("@MondayStart", request.MondayStartTime);
            cmd.Parameters.AddWithValue("@MondayEnd", request.MondayEndTime);
            cmd.Parameters.AddWithValue("@TuesdayStart", request.TuesdayStartTime);
            cmd.Parameters.AddWithValue("@TuesdayEnd", request.TuesdayEndTime);
            cmd.Parameters.AddWithValue("@WednesdayStart", request.WednesdayStartTime);
            cmd.Parameters.AddWithValue("@WednesdayEnd", request.WednesdayEndTime);
            cmd.Parameters.AddWithValue("@ThursdayStart", request.ThursdayStartTime);
            cmd.Parameters.AddWithValue("@ThursdayEnd", request.ThursdayEndTime);
            cmd.Parameters.AddWithValue("@FridayStart", request.FridayStartTime);
            cmd.Parameters.AddWithValue("@FridayEnd", request.FridayEndTime);
            cmd.Parameters.AddWithValue("@SaturdayStart", request.SaturdayStartTime);
            cmd.Parameters.AddWithValue("@SaturdayEnd", request.SaturdayEndTime);
            cmd.Parameters.AddWithValue("@RequestingUserID", requestingUserID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approvor: Derek Taylor
        ///
        /// Method for pulling all request types to load the request type combo box in detailed view
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <returns></returns>
        public List<string> SelectAllRequestTypes()
        {
            List<string> requestTypes = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_request_types", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string type = reader.GetString(0);
                        requestTypes.Add(type);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requestTypes;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approvor: 
        ///
        /// Method for pulling employee names and their associated user numbers.
        /// Aids in associating names to user numbers for UI views.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <returns></returns>
        public List<string[]> SelectAllEmployeeNames()
        {
            List<string[]> names = new List<string[]>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_employee_names", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] nombres = new string[3];
                        nombres[0] = reader.GetInt32(0).ToString();
                        nombres[1] = reader.GetString(1);
                        nombres[2] = reader.GetString(2);
                        names.Add(nombres);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return names;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approvor: Derek Taylor
        ///
        /// Method for pulling all Department Request Responses associated with a request.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public List<RequestResponse> SelectAllRequestResponsesByRequestID(int requestID)
        {
            List<RequestResponse> responses = new List<RequestResponse>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_responses_by_request_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RequestID", requestID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RequestResponse response = new RequestResponse();
                        response.RequestID = requestID;
                        response.RequestResponseID = reader.GetInt32(0);
                        response.UserID = reader.GetInt32(1);
                        response.Response = reader.GetString(2);
                        response.TimeStamp = reader.GetDateTime(3);
                        responses.Add(response);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return responses;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approvor: Derek Taylor
        ///
        /// Method for updating a DepartmentRequest's status to 'Acknowledged'
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public int UpdateDepartmentRequestStatusToAcknowledged(int userID, int requestID)
        {
            int results = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_department_request_acknowledged", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@DepartmentRequestID", requestID);

            try
            {
                conn.Open();
                results = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return results;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approvor: Derek Taylor
        ///
        /// Method for updating a DepartmentRequest's status to 'Completed'
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public int UpdateDepartmentRequestStatusToCompleted(int userID, int requestID)
        {
            int results = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_department_request_complete", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@DepartmentRequestID", requestID);

            try
            {
                conn.Open();
                results = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return results;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/18
        /// Approvor: Derek Taylor
        ///
        /// Method for updating a DepartmentRequest's fields.
        /// </summary>
        /// <remarks>
        /// Updator:
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
        public int UpdateDepartmentRequest(int userID, int requestID, string oldRequestedGroupID, string oldRequestTopic,
            string oldRequestBody, string newRequestedGroupID, string newRequestTopic, string newRequestBody)
        {
            int results = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_department_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@DepartmentRequestID", requestID);
            cmd.Parameters.AddWithValue("@OldRequestedGroupID", oldRequestedGroupID);
            cmd.Parameters.AddWithValue("@OldRequestTopic", oldRequestTopic);
            cmd.Parameters.AddWithValue("@OldRequestBody", oldRequestBody);
            cmd.Parameters.AddWithValue("@NewRequestedGroupID", newRequestedGroupID);
            cmd.Parameters.AddWithValue("@NewRequestTopic", newRequestTopic);
            cmd.Parameters.AddWithValue("@NewRequestBody", newRequestBody);

            try
            {
                conn.Open();
                results = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return results;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/5
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method adds a new Active Time Off record
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="activeTimeOff"></param>
        public int InsertActiveTimeOff(ActiveTimeOff activeTimeOff)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_active_time_off", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", activeTimeOff.UserID);
            cmd.Parameters.AddWithValue("@StartDate", activeTimeOff.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", activeTimeOff.EndDate);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method adds a new Schedule Change Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <param name="requestingUserID"></param>
        public int InsertScheduleChangeRequest(ScheduleChangeRequest request, int requestingUserID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_schedule_change_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ShiftID", request.ShiftID);
            cmd.Parameters.AddWithValue("@RequestingUserID", requestingUserID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/9
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method gets a ScheduleChangeRequest by RequestID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public ScheduleChangeRequestVM SelectScheduleChangeRequestByRequestID(int requestID)
        {
            ScheduleChangeRequestVM request = null;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_schedule_change_request_by_requestid", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("RequestID", requestID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        request = new ScheduleChangeRequestVM();

                        request.ScheduleChangeRequestID = reader.GetInt32(0);
                        request.ShiftID = reader.GetInt32(1);
                        request.ApprovalDate = reader.IsDBNull(2) ? "" : reader.GetDateTime(2).ToString();
                        request.ApprovingUserID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        request.RequestID = reader.GetInt32(4);
                        request.EmployeeWorking = reader.GetInt32(5);
                        request.Date = reader.GetDateTime(6).ToShortDateString();
                        request.DepartmentID = reader.GetString(7);
                        request.StartTime = reader.GetString(8);
                        request.EndTime = reader.GetString(9);
                        request.Role = reader.GetString(10);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return request;
        }


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/4/10
        /// APPROVER: Matt Deaton
        ///  
        /// This method adds a new Social Media Request to the DB
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
        public int InsertSocialMediaRequest(SocialMediaRequest request)
        {
            int requestID = 0;
            //Connection
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_social_media_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime);
            cmd.Parameters.Add("@RequestTypeID", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@RequestingUserID", SqlDbType.Int);
            cmd.Parameters.Add("@Open", SqlDbType.Bit);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Direction = ParameterDirection.Output;

            //Values
            cmd.Parameters["@DateCreated"].Value = request.DateCreated;
            cmd.Parameters["@RequestTypeID"].Value = request.RequestTypeID;
            cmd.Parameters["@RequestingUserID"].Value = request.RequestingUserID;
            cmd.Parameters["@Open"].Value = request.Open;
            cmd.Parameters["@Title"].Value = request.Title;
            cmd.Parameters["@Description"].Value = request.Description;

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
                requestID = (int)cmd.Parameters["@RequestID"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requestID;
        }


        /// NAME: Hassan Karar
        /// DATE: 2/7/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// 
        public RequestAccessor()
        {
        }

        /// NAME: Hassan Karar
        /// DATE: 2/7/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        /// This method is to accessing  the data for the insert_DepartmentRequest stored procedure. 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="department"></param>
        /// <param name="subjec"></param>
        /// <param name="body"></param>
        /// </remarks>
        /// 


        public bool addNewRequestIsPosted(DepartmentRequest department)
        {
            int effect = 0;

            bool result = false;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_DepartmentRequest", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeptRequestID", department.DeptRequestID);
            cmd.Parameters.AddWithValue("@RequestGroupID", department.RequesteeGroupID);
            cmd.Parameters.AddWithValue("@RequestingUserID", department.AcknowledgingEmployee);
            cmd.Parameters.AddWithValue("@RequestSubject", department.Subject);
            cmd.Parameters.AddWithValue("@RequestBody", department.Body);


            try
            {
                conn.Open();
                effect = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (effect == 1)
                {
                    result = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }


        /// NAME: Hassan Karar
        /// DATE: 2/7/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        /// This method is to accessing  the data for the Cancle_Request sored procedure. 
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
            int effect = 0;
            bool result = false;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_Cancle_Request");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RequestID", requestID);
            try
            {
                conn.Open();
                effect = Convert.ToInt32(cmd.ExecuteScalar());
                if (effect != 0)
                {
                    result = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// NAME: Hassan Karar
        /// DATE: 2/7/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        /// This method is to accessing  the data for the insert_RequestResponse stored procedure.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="requestID"></param>
        /// <param name="text"></param>
        /// </remarks>
        /// 

        public bool insertRequestResponse(int requestID, string text, string userID)
        {
            int effect = 0;
            bool result = false;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_RequestResponse");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RequestID", requestID);
            cmd.Parameters.AddWithValue("@Response", text);
            cmd.Parameters.AddWithValue("@UserID", userID);
            try
            {
                conn.Open();
                effect = Convert.ToInt32(cmd.ExecuteScalar());

                if (effect != 0)
                {
                    result = true;

                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// NAME: Hassan Karar
        /// DATE: 2/7/2020
        /// CHECKED BY: Derek Taylor
        /// <summary>
        /// This method is accessing the select_DepartmentRequest stored procedure and connecting to it
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="department"></param>
        /// <param name="subjec"></param>
        /// <param name="body"></param>
        /// </remarks>
        /// 

        public List<ViewResponds> viewRequestRsponds()
        {
            List<ViewResponds> responds
                = new List<ViewResponds>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_DepartmentRequest");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var view = new ViewResponds();
                        view.RequestID = reader.GetInt32(0);
                        view.Subject = reader.GetString(1);
                        view.RequestBody = reader.GetString(2);

                        responds.Add(view);

                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return responds;
        }

        /// <summary>
        ///  Creator: Hassan Karar.
        ///  Created: 2/9/2020
        ///  Approver: 
        ///  
        ///  This method calls the SelectAllRequests method from the Accessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// 


        public List<RequestVM> SelectAllRequests()
        {
            List<RequestVM> requests = new List<RequestVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_requests", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RequestVM request = new RequestVM();

                        request.RequestID = reader.GetInt32(0);
                        request.RequestTypeID = reader.GetString(1);

                        requests.Add(request);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requests;
        }



        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/05/05
        /// Approver: Steve Coonrod
        ///
        /// Database Access method for inserting a new Request Record, and using it's
        /// Identity key as the primary key for the DepartmentRequest record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        public int InsertNewDepartmentRequest(DepartmentRequest request)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_request", conn);
            var cmd2 = new SqlCommand("sp_insert_new_department_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
            cmd.Parameters.AddWithValue("RequestTypeID", request.RequestTypeID);
            cmd.Parameters.AddWithValue("RequestingUserID", request.RequestingUserID);
            cmd.Parameters.AddWithValue("@Open", true);
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
                request.RequestID = (int)cmd.Parameters["@RequestID"].Value;


                cmd2.Parameters.AddWithValue("@DeptRequestID", request.RequestID);
                cmd2.Parameters.AddWithValue("@RequestingUserID", request.RequestingUserID);
                cmd2.Parameters.AddWithValue("@RequestGroupID", request.RequestorGroupID);
                cmd2.Parameters.AddWithValue("@RequestedGroupID", request.RequesteeGroupID);
                cmd2.Parameters.AddWithValue("@RequestTopic", request.Topic);
                cmd2.Parameters.AddWithValue("@RequestBody", request.Body);


                result = cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        

    }
}
