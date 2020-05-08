using DataTransferObjects;
using System.Collections.Generic;
using System.Linq;


namespace PresentationUtilityCode
{
    /// <summary>
    /// Creator: Ryan Morganti
    /// Created: 2020/02/13
    /// Approver: Derek Taylor
    /// 
    /// Utility Class used for filtering and aggregating collection data used within the Request system.
    /// </summary>
    public static class RequestUtilities
    {

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        /// 
        /// Method for determining whether a User is also an employee
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsEmployee(this PetUniverseUser user)
        {
            return (from r in user.PURoles
                    where r == "Employee"
                    select r).Any();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        /// 
        /// Extension Method for filtering out duplicate Requests when a User has two
        /// Department IDs that are associated with a single Request
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static List<DepartmentRequest> DistinctRequests(this List<DepartmentRequest> requests)
        {
            //This line of code was found when looking for a way to filter out duplicate requests
            //when multiple DepartmentIDs associated with a single user are associated to a single
            //request as well
            //https://stackoverflow.com/a/491832
            return requests.GroupBy(r => r.RequestID).Select(r => r.First()).ToList();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/08
        /// Approver: Derek Taylor
        /// 
        /// Extension Method for filter out the Department Name from a Department object.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="depts"></param>
        /// <returns></returns>
        public static List<string> DepartmentIDFilter(this List<Department> depts)
        {
            return (from n in depts
                    select n.DepartmentID).ToList();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        /// 
        /// Extension Method for applying Employee names out of a list into DepartmentRequest ViewModels
        /// based on their employee number.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <param name="employeeNames"></param>
        /// <returns></returns>
        public static DepartmentRequestVM PopulateUserNames(this DepartmentRequestVM request, List<string[]> employeeNames)
        {
            request.RequestorFirstName = (from n in employeeNames
                                          where n[0] == request.RequestingUserID.ToString()
                                          select n[1]).Single();
            request.RequestorLastName = (from n in employeeNames
                                         where n[0] == request.RequestingUserID.ToString()
                                         select n[2]).Single();
            if (request.DateAcknowledged.Year > 2000)
            {
                request.AcknowledgeFirstName = (from n in employeeNames
                                                where n[0] == request.AcknowledgingEmployee.ToString()
                                                select n[1]).Single();
                request.AcknowledgeLastName = (from n in employeeNames
                                               where n[0] == request.AcknowledgingEmployee.ToString()
                                               select n[2]).Single();
            }
            if (request.DateCompleted.Year > 2000)
            {
                request.CompleteFirstName = (from n in employeeNames
                                             where n[0] == request.CompletedEmployee.ToString()
                                             select n[1]).Single();
                request.CompleteLastName = (from n in employeeNames
                                            where n[0] == request.CompletedEmployee.ToString()
                                            select n[2]).Single();
            }
            return request;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        /// 
        /// Extension Method for pulling response objects together and creating one large list for display.
        /// ***THIS MAY NEED TO BE TEMPORARY, COULD NOT FIND A BETTER METHOD ON MY OWN***
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="responses"></param>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static string ResponseListBuilder(this List<RequestResponse> responses, List<string[]> employees)
        {
            string builtResponses = "";
            List<RequestResponse> responsesOrdered = responses.OrderByDescending(x => x.TimeStamp).ToList();

            foreach (RequestResponse rr in responsesOrdered)
            {
                string employeeName = (from n in employees
                                       where n[0] == rr.UserID.ToString()
                                       select n[1] + " " + n[2]).Single();
                string response = employeeName + "\n" + rr.TimeStamp.ToString() + "\n" + rr.Response + "\n\n\n";
                builtResponses += response;
            }

            return builtResponses;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/18
        /// Approver: Derek Taylor
        /// 
        /// Extension Method for verifying that a correct DepartmentID is being used when attempting to edit a DepartmentRequest object.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <param name="DeptIDs"></param>
        /// <returns></returns>
        public static bool IsValidDepartment(this string departmentID, List<string> DeptIDs)
        {
            return (from d in DeptIDs
                    where d == departmentID
                    select d).Any();
        }

    }
}
