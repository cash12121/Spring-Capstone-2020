using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class FakeEmployeeAvailabilityAccessor : IEmployeeAvailabilityAccessor
    {
        private EmployeeAvailability _employeeAvailability;
        private List<PetUniverseUser> _userList;

        public FakeEmployeeAvailabilityAccessor()
        {
            _userList = new List<PetUniverseUser>()
            {
                new PetUniverseUser{
                    PUUserID = 100000,
                    FirstName = "Test1",
                    LastName = "Test1",
                    City = "Cedar Rapids",
                    Email = "test1@PetUniverse.com",
                    PhoneNumber = "5632341221",
                    State = "IA",
                    ZipCode = "52406",
                    Active = true

                },
                new PetUniverseUser()
                {
                    PUUserID = 100001,
                    FirstName = "Test2",
                    LastName = "Test2",
                    City = "New York",
                    Email = "test2@PetUniverse.com",
                    PhoneNumber = "5632348893",
                    State = "NY",
                    ZipCode = "10021",
                    Active = true
                }

            };

        }
        /// <summary>
        /// Creator: Lane Sandburg
        /// Created:4/2/2020
        /// Approver: Jordan Lindo
        /// 
        /// Data Access Fake for Inserting a new employee Availability
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="employeeAvailability">Test availability being created</param>
        /// <returns>True if fakeemployeeAvailability and employeeAvailability are equal</returns>
        public bool InsertNewEmployeeAvailability(EmployeeAvailability employeeAvailability)
        {
            bool employeeID = employeeAvailability.EmployeeID.Equals(100000);
            bool dayOfTheWeek = employeeAvailability.DayOfWeek.Equals("Monday");
            bool startTime = employeeAvailability.StartTime.Equals("10:50:06");
            bool endTime = employeeAvailability.EndTime.Equals("11:50:06");

            if (employeeID && dayOfTheWeek && startTime && endTime)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Unable to add availability");
            }



        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created:4/9/2020
        /// Approver: Jordan Lindo
        /// 
        /// Data Access Fake for selecting employees Availability by id
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="employeeID">employee id serching for</param>
        /// <returns>List<EmployeeAvailability></returns>
        public List<EmployeeAvailability> SelectEmployeeAvailabilityByID(int employeeID)
        {
            List<EmployeeAvailability> availabilities = new List<EmployeeAvailability>();
            List<EmployeeAvailability> EmpAvailabilities = new List<EmployeeAvailability>();


            availabilities.Add(new EmployeeAvailability()
            {
                AvailabilityID = 100000,
                EmployeeID = 100000,
                DayOfWeek = "Monday",
                StartTime = "06:00:00",
                EndTime = "09:00:00",
                Active = true
            });
            availabilities.Add(new EmployeeAvailability()
            {
                AvailabilityID = 100001,
                EmployeeID = 100001,
                DayOfWeek = "Monday",
                StartTime = "06:00:00",
                EndTime = "09:00:00",
                Active = true
            });
            foreach (var availbility in availabilities)
            {
                if (availbility.EmployeeID == employeeID)
                {
                    EmpAvailabilities.Add(availbility);
                }
            }

            return EmpAvailabilities;

        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created:4/9/2020
        /// Approver: Jordan Lindo
        /// 
        /// Data Access Fake for selecting last employeeID in table(newest entry)
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <returns>employee id</returns>
        public int SelectLastCreatedEmployeeID()
        {
            int ID = _userList[_userList.Count - 1].PUUserID;
            return ID;
        }
    }
}
