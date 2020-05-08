using System;
using System.Collections.Generic;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    [TestClass]
    public class ScheduleManagerTests
    {
        private IScheduleAccessor _scheduleAccessor;
        private IShiftTimeAccessor _shiftTimeAccessor;


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/22/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a unit test constructor for ScheduleManager.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        public ScheduleManagerTests()
        {
            _scheduleAccessor = new FakeScheduleAccessor();
            _shiftTimeAccessor = new FakeShiftTimeAccessor();

        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a unit test constructor for ScheduleManager.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void GenerateScheduleTest()
        {
            IScheduleManager scheduleManager = new ScheduleManager(_scheduleAccessor,
                _shiftTimeAccessor);

            List<BaseScheduleLine> lines = new List<BaseScheduleLine>
            {
            new BaseScheduleLine
            {
                BaseScheduleID = 1000000,
                DepartmentID = "Management",
                ShiftTimeID = 100002,
                ERoleID = "Manager",
                Count = 1
            }};

            DateTime date = DateTime.Now;

            ScheduleVM scheduleVM = scheduleManager.GenerateSchedule(date, lines);

            int result = scheduleVM.ScheduleLines.Count;
            int target = 10;

            Assert.AreEqual(target, result);
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// 
        /// Test for adding a schedule
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddScheduleTester()
        {
            IScheduleManager scheduleManager = new ScheduleManager(_scheduleAccessor,
                _shiftTimeAccessor);
            ScheduleVM scheduleVM = new ScheduleVM()
            {
                ScheduleID = 1000001,
                CreatingUserID = 100000,
                StartDate = DateTime.Now.AddDays(14),
                EndDate = DateTime.Now.AddDays(28),
                Active = false,
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

            };

            int result = scheduleManager.AddSchedule(scheduleVM);
            int target = 1;

            Assert.AreEqual(target, result);
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// 
        /// Test for retrieving all schedules by active
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllSchedule()
        {
            IScheduleManager scheduleManager = new ScheduleManager(_scheduleAccessor,
                 _shiftTimeAccessor);

            List<ScheduleVM> result = scheduleManager.RetrieveAllSchedules();

            Assert.AreEqual(1, result.Count);
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// 
        /// Test for retrieving all schedules by active
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddScheduleHours()
        {
            IScheduleManager scheduleManager = new ScheduleManager(_scheduleAccessor,
                _shiftTimeAccessor);

            scheduleManager.AddScheduledHours(1000000);
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Kaleb Bachert
        /// 
        /// 
        /// Test for generating a schedule when too many schedules are active.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: 
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestGenerateScheduleCountTooHigh()
        {
            IScheduleManager scheduleManager = new ScheduleManager(_scheduleAccessor, _shiftTimeAccessor);

            // To ensure the list is at capacity.
            List<ScheduleVM> scheduleVMs = new List<ScheduleVM>
            {
                new ScheduleVM()
                {
                    ScheduleID = 1000003,
                    CreatingUserID = 100000,
                    StartDate = DateTime.Now.AddDays(15),
                    EndDate = DateTime.Now.AddDays(29),
                    Active = true,
                    CreatorName = "Last, First",
                    ScheduleLines = new List<ShiftUserVM>()
                },
                new ScheduleVM()
                {
                    ScheduleID = 1000004,
                    CreatingUserID = 100000,
                    StartDate = DateTime.Now.AddDays(30),
                    EndDate = DateTime.Now.AddDays(44),
                    Active = true,
                    CreatorName = "Last, First",
                    ScheduleLines = new List<ShiftUserVM>()
                }
            };
            foreach (var item in scheduleVMs)
            {
                scheduleManager.AddSchedule(item);
            }
            List<BaseScheduleLine> lines = new List<BaseScheduleLine>
            {
            new BaseScheduleLine
            {
                BaseScheduleID = 1000000,
                DepartmentID = "Management",
                ShiftTimeID = 100002,
                ERoleID = "Manager",
                Count = 1
            }};

            DateTime date = DateTime.Now;

            ScheduleVM scheduleVM = scheduleManager.GenerateSchedule(date, lines);
        }



    }
}
