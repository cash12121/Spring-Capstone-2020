using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    public class FakeAvailabilityAccessor : IAvailabilityAccessor
    {
        List<AvailabilityVM> availabilitiesVM = null;
        List<EmployeeAvailability> availabilities = null;
        List<PetUniverseUser> petUniverseUsers = null;
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert: 
        /// 
        /// Populate fake lists 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        public FakeAvailabilityAccessor()
        {

            availabilities = new List<EmployeeAvailability>()
            {
                new EmployeeAvailability()
                {
                   AvailabilityID = 1, EmployeeID = 100000, DayOfWeek = "Monday", StartTime = new DateTime(2020, 4, 21, 10, 0, 0).ToString(), EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString()
                },
                new EmployeeAvailability()
                {
                   AvailabilityID = 2, EmployeeID = 100001, DayOfWeek = "Tuesday", StartTime = new DateTime(2020, 4, 21, 1, 0, 0).ToString(), EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString()
                },
                new EmployeeAvailability()
                {
                   AvailabilityID = 3, EmployeeID = 100000, DayOfWeek = "Thursday", StartTime = new DateTime(2020, 4, 21, 1, 0, 0).ToString(), EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString()
                },
                new EmployeeAvailability()
                {
                   AvailabilityID = 4, EmployeeID = 100001, DayOfWeek = "Thursday", StartTime = new DateTime(2020, 4, 21, 1, 0, 0).ToString(), EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString()
                }
            };

            //Fake data for Availability
            availabilitiesVM = new List<AvailabilityVM>()
            {
                new AvailabilityVM(){AvailabilityID = 1, DayOfWeek = "Monday", StartTime="10:00", EndTime = "18:00", EmployeeID =  1},
                new AvailabilityVM(){AvailabilityID = 2, DayOfWeek = "Tuesday", StartTime="10:00", EndTime = "18:00", EmployeeID =  1},
                new AvailabilityVM(){AvailabilityID = 3, DayOfWeek = "Friday", StartTime="10:00", EndTime = "18:00", EmployeeID =  1}

            };

            //Fake Data Users
            petUniverseUsers = new List<PetUniverseUser>()
            {
                new PetUniverseUser(){PUUserID=100000,FirstName="John",LastName="Doe"},
                new PetUniverseUser(){PUUserID=100001,FirstName="Doe",LastName="Jim"}

            };

        }


        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert: 
        /// 
        /// Get Fake method for activating availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availabilityID"></param>
        /// <returns></returns>
        public int ActivateAvailability(int availabilityID)
        {
            //Check if id is in list
            if (availabilities.Find(av => av.AvailabilityID == availabilityID) != null)
            {
                return 1;
            }
            throw new Exception();
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert: 
        /// 
        /// Get Fake method Deacivate Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availabilityID"></param>
        /// <returns></returns>
        public int DeactivateAvailability(int availabilityID)
        {
            //Check if id is in list
            if (availabilities.Find(av => av.AvailabilityID == availabilityID) != null)
            {
                return 1;
            }
            throw new Exception();
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert: 
        /// 
        /// Get Fake method Inserting Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availability"></param>
        /// <returns></returns>
        public int InsertAvailability(EmployeeAvailability availability)
        {
            int result = 0;
            if (availability.EndTime.Length > 20)
            {
                throw new Exception();
            }
            if (availability.StartTime.Length > 20)
            {
                throw new Exception();
            }
            if (availabilities.Find(av => av.AvailabilityID == availability.AvailabilityID) != null)
            {
                throw new Exception();
            }
            //Make sure user ID is in list
            if (petUniverseUsers.Find(av => av.PUUserID == availability.EmployeeID) != null)
            {
                result = 1;
            }
            if (result != 1)
            {
                throw new Exception();
            }
            if (availability.DayOfWeek == "Monday" || availability.DayOfWeek == "Tuesday" || availability.DayOfWeek == "Wednesday" || availability.DayOfWeek == "Thursday" || availability.DayOfWeek == "Friday" || availability.DayOfWeek == "Saturday" || availability.DayOfWeek == "Sunday")
            {
                return 1;
            }
            return 0;

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert: 
        /// 
        /// Get Fake method for selecting all availabilities 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns></returns>
        public List<EmployeeAvailability> SelectAllAvailabilities()
        {
            return availabilities;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert: 
        /// 
        /// Get Fake method for selecting availabilites by user ID 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<AvailabilityVM> SelectAvailabilityByUserID(int userID)
        {
            if (availabilities.Find(av => av.EmployeeID == userID) != null)
            {
                return availabilitiesVM;
            }
            throw new Exception();
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/11
        /// Approver: Kaleb Bachert: 
        /// 
        /// Get Fake method for updating Availabilites
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="newAvailability"></param>
        /// <param name="oldAvailability"></param>
        /// <returns></returns>
        public int UpdateAvailability(EmployeeAvailability newAvailability, EmployeeAvailability oldAvailability)
        {
            int result = 0;
            //check old availability
            if (availabilities.Find(av => av.AvailabilityID == oldAvailability.AvailabilityID && av.DayOfWeek == oldAvailability.DayOfWeek && av.EndTime == oldAvailability.EndTime && av.StartTime == oldAvailability.StartTime && av.EmployeeID == oldAvailability.EmployeeID) != null)
            {
                result = 1;
            }
            if (result != 1)
            {
                throw new Exception();
            }

            if (newAvailability.EndTime.Length > 20)
            {
                throw new Exception();
            }
            if (newAvailability.StartTime.Length > 20)
            {
                throw new Exception();
            }
            result = 0;
            //Make sure id match
            if (petUniverseUsers.Find(pu => pu.PUUserID == newAvailability.EmployeeID) != null)
            {
                result = 1;
            }
            if (result == 0)
            {
                throw new Exception();
            }
            result = 0;
            if (oldAvailability.AvailabilityID == newAvailability.AvailabilityID)
            {
                result = 1;
            }
            result = 0;

            //Make sure id match
            if (oldAvailability.AvailabilityID == newAvailability.AvailabilityID)
            {
                result = 1;
            }
            if (result == 0)
            {
                throw new Exception();
            }
            result = 0;
            if (newAvailability.DayOfWeek == "Monday" || newAvailability.DayOfWeek == "Tuesday" || newAvailability.DayOfWeek == "Wednesday" || newAvailability.DayOfWeek == "Thursday" || newAvailability.DayOfWeek == "Friday" || newAvailability.DayOfWeek == "Saturday" || newAvailability.DayOfWeek == "Sunday")
            {
                result = 1;
            }
            if (result == 0)
            {
                return 0;
            }
            return 1;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  Approver: Lane Sandburg
        ///  
        ///   Method that retrieves all the dummy Availabilities, for testing
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<EmployeeAvailability> SelectAllUsersAvailability()
        {
            return availabilities;
        }
    }
}