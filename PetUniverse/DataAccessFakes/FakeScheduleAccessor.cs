using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/8/2020
    /// Approver:  Chase Schulte
    /// 
    /// Test class for Schedule.
    /// </summary>
    public class FakeScheduleAccessor : IScheduleAccessor
    {
        private List<ScheduleVM> _schedules;
        private List<PUUserVMAvailability> _employees;

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/08/2020
        /// Approver:  Chase Schulte
        /// 
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public FakeScheduleAccessor()
        {

            _schedules = new List<ScheduleVM>
            {
                new ScheduleVM()
                {
                    ScheduleID = 1000000,
                    CreatingUserID = 100000,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14),
                    Active = true,
                    CreatorName = "Last, First",
                    ScheduleLines = new List<ShiftUserVM>()
                    {
                        new ShiftUserVM()
                        {
                            ScheduleID = 1000000,
                            ShiftID = 1000000,
                            ShiftTimeID = 1000000,
                            ShiftDate = DateTime.Now,
                            EmployeeID = 1000000,
                            RoleID = "Manager"
                        },
                        new ShiftUserVM()
                        {
                            ScheduleID = 1000000,
                            ShiftID = 1000001,
                            ShiftTimeID = 1000000,
                            ShiftDate = DateTime.Now,
                            EmployeeID = 1000001,
                            RoleID = "Supervisor"
                        }
                    }
                },
                new ScheduleVM()
                {
                    ScheduleID = 1000001,
                    CreatingUserID = 100000,
                    StartDate = DateTime.Now.AddDays(-32),
                    EndDate = DateTime.Now.AddDays(-18),
                    Active = false,
                    CreatorName = "Last, First",
                    ScheduleLines = new List<ShiftUserVM>()
                    {
                        new ShiftUserVM()
                        {
                            ScheduleID = 1000000,
                            ShiftID = 1000002,
                            ShiftTimeID = 1000000,
                            ShiftDate = DateTime.Now,
                            EmployeeID = 1000000,
                            RoleID = "Manager"
                        },
                        new ShiftUserVM()
                        {
                            ScheduleID = 1000000,
                            ShiftID = 1000003,
                            ShiftTimeID = 1000000,
                            ShiftDate = DateTime.Now,
                            EmployeeID = 1000001,
                            RoleID = "Supervisor"
                        }
                    }
                },
                new ScheduleVM()
                {
                    ScheduleID = 1000002,
                    CreatingUserID = 100000,
                    StartDate = DateTime.Now.AddDays(-21),
                    EndDate = DateTime.Now.AddDays(-7),
                    Active = true,
                    CreatorName = "Last, First",
                    ScheduleLines = new List<ShiftUserVM>()
                    {
                        new ShiftUserVM()
                        {
                            ScheduleID = 1000002,
                            ShiftID = 1000004,
                            ShiftTimeID = 1000000,
                            ShiftDate = DateTime.Now,
                            EmployeeID = 1000000,
                            RoleID = "Manager"
                        },
                        new ShiftUserVM()
                        {
                            ScheduleID = 1000002,
                            ShiftID = 1000005,
                            ShiftTimeID = 1000000,
                            ShiftDate = DateTime.Now,
                            EmployeeID = 1000001,
                            RoleID = "Supervisor"
                        }
                    }
                }

            };
            _employees = new List<PUUserVMAvailability>
            {
                new PUUserVMAvailability
                {
                    FirstName = "Good",
                    LastName = "One",
                    PUUserID = 1,
                    PURoles = new List<string>
                    {
                        "Manager"
                    },
                    Availability = new EmployeeAvailability
                    {
                        StartTime = "04:00",
                        EndTime = "22:00"
                    }

                },
                new PUUserVMAvailability
                {
                    FirstName = "BadShort",
                    LastName = "twoLast",
                    PUUserID = 2,
                    PURoles = new List<string>
                    {
                        "Manager"
                    },
                    Availability = new EmployeeAvailability
                    {
                        StartTime = "04:00",
                        EndTime = "06:00"
                    }
                },
                new PUUserVMAvailability
                {
                    FirstName = "BadWrongTime",
                    LastName = "threeLast",
                    PUUserID = 2,
                    PURoles = new List<string>
                    {
                        "Manager"
                    },
                    Availability = new EmployeeAvailability
                    {
                        StartTime = "14:00",
                        EndTime = "23:00"
                    }
                }
            };
        }



        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/14/2020
        /// Approver:  Chase Schulte
        /// 
        /// Method for getting a list of employees available to be added to a schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="date"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public List<PUUserVMAvailability> GetListOfAvailableEmployees(DateTime date, BaseScheduleLine line)
        {
            List<PUUserVMAvailability> employees = _employees;
            return employees;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/8/2020
        /// Approver:  Chase Schulte
        /// 
        /// Test for inserting a schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public int InsertSchedule(ScheduleVM schedule)
        {
            int rows = 0;
            _schedules.Add(schedule);
            if (_schedules.Contains(schedule))
            {
                rows = 1;
            }
            return rows;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/8/2020
        /// Approver: Chase Schulte
        /// 
        /// Test for selecting all schedules by active status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<ScheduleVM> SelectAllSchedules(bool active)
        {
            List<ScheduleVM> result = new List<ScheduleVM>();

            foreach (ScheduleVM schedule in _schedules)
            {
                if(schedule.Active == active)
                {
                    result.Add(schedule);
                }
            }


            return result;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/28/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test for counting active schedules.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public int GetCountOfActiveSchedules()
        {
            int count = 0;
            foreach (ScheduleVM schedule in _schedules)
            {
                if (schedule.Active == true)
                {
                    count++;
                }
            }
            return count;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/28/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test for counting active schedules.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public int DeactivateSchedule(int scheduleID)
        {
            int result = 0;
            foreach (var item in _schedules)
            {
                if(item.ScheduleID == scheduleID)
                {
                    item.Active = false;
                    result++;
                }
            }
            return result;
        }
    }
}
