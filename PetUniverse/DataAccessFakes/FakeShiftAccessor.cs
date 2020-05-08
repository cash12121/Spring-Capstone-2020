using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/2/7
///  APPROVER: Lane Sandburg
///  
///  Fake Shift Accessor Class for Unit Testing
/// </summary>
namespace DataAccessFakes
{
    public class FakeShiftAccessor : IShiftAccessor
    {
        List<PetUniverseShiftTime> shiftTimes = null;
        List<PetUniverseUser> petUniverseUsers = null;
        List<ShiftDetailsVM> shiftDetailsVMs = null;
        List<Schedule> schedules = null;
        List<EmployeeAvailability> availability = null;
        private List<ShiftUserVM> shiftUserVMs;
        List<ERole> eRoles = null;
        private List<ShiftVM> shiftVMs;
        private List<ScheduleWithHoursWorked> scheduleHours;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Fake Shift Accessor Constructor, generates dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public FakeShiftAccessor()
        {

            shiftUserVMs = new List<ShiftUserVM>()
            {
                new ShiftUserVM()
                {
                    DateString = DateTime.Today.ToShortDateString(),
                    EmployeeName = "Bob John",
                    RoleID = "Role",
                    EmployeeID = 1,
                    ScheduleID = 1,
                    ShiftID=  2
                },
                new ShiftUserVM()
                {
                    DateString = DateTime.Today.ToShortDateString(),
                    EmployeeName = "Trapp Glasgow",
                    RoleID = "Role",
                    EmployeeID = 1,
                    ScheduleID = 2,
                    ShiftID = 1
                }
            };

            //Fake Data Shifttime
            shiftTimes = new List<PetUniverseShiftTime>()
            {
                new PetUniverseShiftTime(){ShiftTimeID=1,StartTime="12:00",EndTime="00:00",DepartmentID="Test1" },
                new PetUniverseShiftTime(){ShiftTimeID=2,StartTime="12:00",EndTime="00:00",DepartmentID="Test2" }
            };

            //Fake data for Availability
            availability = new List<EmployeeAvailability>()
            {
                new EmployeeAvailability(){AvailabilityID = 1, DayOfWeek = "Monday", StartTime="10:00", EndTime = "18:00", EmployeeID =  1},
                new EmployeeAvailability(){AvailabilityID = 2, DayOfWeek = "Tuesday", StartTime="10:00", EndTime = "18:00", EmployeeID =  1},
                new EmployeeAvailability(){AvailabilityID = 1, DayOfWeek = "Friday", StartTime="10:00", EndTime = "18:00", EmployeeID =  1}

            };

            //Fake Data Users
            petUniverseUsers = new List<PetUniverseUser>()
            {
                new PetUniverseUser(){PUUserID=1,FirstName="John",LastName="Doe"},
                new PetUniverseUser(){PUUserID=2,FirstName="Doe",LastName="Jim"}

            };

            //Fake data for Availability
            eRoles = new List<ERole>()
            {
                new ERole(){ERoleID = "Role1", Description = "Desc", DepartmentID="Test1"},
                new ERole(){ERoleID = "Role2", Description = "Desc", DepartmentID="Test1"},
                new ERole(){ERoleID = "Role3", Description = "Desc", DepartmentID="Test1"}


            };

            //Fake Data Schedules
            schedules = new List<Schedule>()
            {
                new Schedule(){ScheduleID=1,StartDate=DateTime.Now,EndDate=DateTime.Now.AddDays(1)}
            };

            //Fake data for Shift
            shiftDetailsVMs = new List<ShiftDetailsVM>()
            {
                new ShiftDetailsVM(){ShiftID = 1, ShiftDate=DateTime.Now,RoleID="Role1",ScheduleID=1,ShiftTimeID=1,EmployeeID=1},
                new ShiftDetailsVM(){ShiftID = 2, ShiftDate=DateTime.Now,RoleID="Role1",ScheduleID=1,ShiftTimeID=1,EmployeeID=2}


            };
            shiftVMs = new List<ShiftVM>()
            {
                new ShiftVM()
                {
                    ShiftID = 1000000,
                    EmployeeWorking = 100001,
                    Department = "Fake1",
                    Date = new DateTime(2020, 4, 21).ToShortDateString(),
                    StartTime = "14:00:00",
                    EndTime = "22:00:00",
                    ShiftTimeID = 1000000
                },
                new ShiftVM()
                {
                    ShiftID = 1000001,
                    EmployeeWorking = 100001,
                    Department = "Fake2",
                    Date = new DateTime(2020, 4, 21).ToShortDateString(),
                    StartTime = "8:45:00",
                    EndTime = "12:45:00",
                    ShiftTimeID = 1000001
                },
                new ShiftVM()
                {
                    ShiftID = 1000002,
                    EmployeeWorking = 100001,
                    Department = "Fake1",
                    Date = new DateTime(2020, 4, 22).ToShortDateString(),
                    StartTime = "14:00:00",
                    EndTime = "22:00:00",
                    ShiftTimeID = 1000000
                },
                new ShiftVM()
                {
                    ShiftID = 1000003,
                    EmployeeWorking = 100000,
                    Department = "Fake1",
                    Date = new DateTime(2020, 4, 21).ToShortDateString(),
                    StartTime = "4:00:00",
                    EndTime = "7:00:00",
                    ShiftTimeID = 1000000
                }
            };

            scheduleHours = new List<ScheduleWithHoursWorked>()
            {
                new ScheduleWithHoursWorked()
                {
                    ScheduleID = 1000000,
                    ScheduleStartDate = DateTime.Now,
                    ScheduleEndDate = DateTime.Now.AddDays(13),
                    FirstWeekHours = 40,
                    SecondWeekHours = 20
                },
                new ScheduleWithHoursWorked()
                {
                    ScheduleID = 1000001,
                    ScheduleStartDate = DateTime.Now.AddDays(14),
                    ScheduleEndDate = DateTime.Now.AddDays(27),
                    FirstWeekHours = 35,
                    SecondWeekHours = 25
                }
            };
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that retrieves all the dummy ShiftVMs on a specified date, for testing
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<ShiftVM> SelectShiftsByDay(DateTime date)
        {
            return (from s in shiftVMs
                    where s.Date.Equals(date.ToShortDateString())
                    select s).ToList();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that retrieves all the dummy ShiftVMs for a user, for testing
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        public List<ShiftVM> SelectShiftsByUser(int userID)
        {
            return (from s in shiftVMs
                    where s.EmployeeWorking == userID
                    select s).ToList();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that retrieves the dummy hours worked for a dummy user within the dummy schedule
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="dateInSchedule"></param>
        public ScheduleWithHoursWorked SelectScheduleHoursByUserAndDate(int userID, DateTime dateInSchedule)
        {
            return (from s in scheduleHours
                    where s.ScheduleStartDate <= dateInSchedule
                    && s.ScheduleEndDate >= dateInSchedule
                    select s).First();
        }


        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that updates the dummy shift's dummy EmployeeWorking
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="shiftID"></param>
        /// <param name="newUserWorking"></param>
        /// <param name="oldUserWorking"></param>
        public int UpdateShiftUserWorking(int shiftID, int newUserWorking, int oldUserWorking)
        {
            int recordsUpdated = 0;

            foreach (ShiftVM shift in shiftVMs)
            {
                if (shift.ShiftID == shiftID && shift.EmployeeWorking == oldUserWorking)
                {
                    shift.EmployeeWorking = newUserWorking;
                    recordsUpdated++;
                }
            }

            return recordsUpdated;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that updates the dummy hours worked forthe dummy shift of the given week number
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="scheduleID"></param>
        /// <param name="weekNumber"></param>
        /// <param name="changeAmount"></param>
        public int UpdateEmployeeHoursWorked(int userID, int scheduleID, int weekNumber, double changeAmount)
        {
            int recordsUpdated = 0;

            foreach (ScheduleWithHoursWorked hoursWorked in scheduleHours)
            {
                if (hoursWorked.ScheduleID == scheduleID)
                {
                    if (weekNumber == 1)
                    {
                        hoursWorked.FirstWeekHours += changeAmount;
                        recordsUpdated++;
                    }
                    else if (weekNumber == 2)
                    {
                        hoursWorked.SecondWeekHours += changeAmount;
                        recordsUpdated++;
                    }
                }
            }

            return recordsUpdated;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert
        /// 
        /// Get fake list details by user ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<ShiftDetailsVM> SelectAllShiftsDetailsByUserID(int userID)
        {

            var shifts = shiftDetailsVMs.FindAll(sd => sd.EmployeeID == userID);
            if (shifts.Count > 0)
            {
                return shifts;
            }

            return null;

        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert
        /// 
        /// Get fake list details by ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="shiftID"></param>
        /// <returns></returns>
        public ShiftDetailsVM SelectShiftDetailsByID(int shiftID)
        {

            ShiftDetailsVM shiftVM = new ShiftDetailsVM();
            //Check if shift id exists
            foreach (var item in shiftDetailsVMs)
            {
                if (item.ShiftID == shiftID)
                {
                    shiftVM = item;

                }

            }
            //Check if emp ID is active
            if (petUniverseUsers.Find(pu => pu.PUUserID == shiftVM.EmployeeID) != null)
            {
                shiftVM.ShiftPUUserFirstName = petUniverseUsers.Find(pu => pu.PUUserID == shiftVM.EmployeeID).FirstName;
                shiftVM.ShiftPUUserLastName = petUniverseUsers.Find(pu => pu.PUUserID == shiftVM.EmployeeID).LastName;

                if (schedules.Find(pu => pu.ScheduleID == shiftVM.ScheduleID) != null)
                {
                    shiftVM.ShiftScheduleStartDate = schedules.Find(pu => pu.ScheduleID == shiftVM.ScheduleID).StartDate;
                    shiftVM.ShiftScheduleEndDate = schedules.Find(pu => pu.ScheduleID == shiftVM.ScheduleID).EndDate;
                    //Check ShiftTimeID
                    if (shiftTimes.Find(pu => pu.ShiftTimeID == shiftVM.ShiftTimeID) != null)
                    {
                        shiftVM.ShiftStartTime = shiftTimes.Find(pu => pu.ShiftTimeID == shiftVM.ShiftTimeID).StartTime;
                        shiftVM.ShiftEndTime = shiftTimes.Find(pu => pu.ShiftTimeID == shiftVM.ShiftTimeID).EndTime;
                        shiftVM.ShiftTimeDeptID = shiftTimes.Find(pu => pu.ShiftTimeID == shiftVM.ShiftTimeID).DepartmentID;
                        //Check if there's availabilites
                        if (availability.Find(pu => pu.EmployeeID == shiftVM.EmployeeID) != null)
                        {
                            shiftVM.ShiftAvailabilities = availability.FindAll(pu => pu.EmployeeID == shiftVM.EmployeeID);
                            return shiftVM;
                        }
                        return shiftVM;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }

        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver:
        /// 
        /// method to test getting shifts by department, and schedule id
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public List<ShiftUserVM> SelectShiftsByScheduleAndDepartmentID(int scheduleID, string departmentID)
        {
            var shifts = shiftUserVMs.FindAll(sv => sv.ScheduleID == scheduleID);
            //find department shift belongs to
            if (shiftTimes.Find(st => st.DepartmentID == departmentID) != null)
            {
                return shifts;
            }
            return null;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver:
        /// 
        /// method to test getting shifts by department, date, and schedule id
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <param name="departmentID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<ShiftUserVM> SelectShiftsByScheduleAndDepartmentIDWithDate(int scheduleID, string departmentID, DateTime date)
        {
            var shifts = shiftUserVMs.FindAll(sv => sv.ScheduleID == scheduleID && sv.DateString == date.ToShortDateString());
            //find department shift belongs to
            if (shiftTimes.Find(st => st.DepartmentID == departmentID) != null)
            {
                return shifts;
            }
            return null;
        }
    }
}
