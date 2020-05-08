using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/17/2020
    /// Approver: Chase Schulte
    /// 
    /// This is a unit test set for BaseScheduleManager.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Approver: NA
    /// 
    /// </remarks>
    [TestClass]
    public class BaseScheduleManagerTests
    {
        private IBaseScheduleAccessor _baseScheduleAccessor;


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a unit test constructor for BaseScheduleManager.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        public BaseScheduleManagerTests()
        {
            _baseScheduleAccessor = new FakeBaseScheduleAccessor();
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a unit test for BaseScheduleManager.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddBaseScheduleTestGood()
        {
            IBaseScheduleManager baseScheduleManager = new BaseScheduleManager(_baseScheduleAccessor);
            BaseScheduleVM goodVM = new BaseScheduleVM()
            {
                Active = true,
                BaseScheduleID = 1000001,
                CreatingUserID = 100000,
                CreationDate = DateTime.Now,
                BaseScheduleLines = new List<BaseScheduleLine>()
                {
                    new BaseScheduleLine()
                    {
                        BaseScheduleID = 1000001,
                        DepartmentID = "Management",
                        ERoleID = "Manager",
                        ShiftTimeID = 1000000,
                        Count = 1
                    },
                    new BaseScheduleLine()
                    {
                        BaseScheduleID = 1000001,
                        DepartmentID = "Sales",
                        ERoleID = "Cashier",
                        ShiftTimeID = 1000004,
                        Count = 6
                    }
                }
            };

            int result = baseScheduleManager.AddBaseSchedule(goodVM);


            Assert.AreEqual(true, (result != 0));
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a unit test for BaseScheduleManager bad count.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AddBaseScheduleTestBadCount()
        {
            IBaseScheduleManager baseScheduleManager = new BaseScheduleManager(_baseScheduleAccessor);
            BaseScheduleVM badVM = new BaseScheduleVM()
            {
                Active = true,
                BaseScheduleID = 1000001,
                CreatingUserID = 100000,
                CreationDate = DateTime.Now,
                BaseScheduleLines = new List<BaseScheduleLine>()
                {
                    new BaseScheduleLine()
                    {
                        BaseScheduleID = 1000001,
                        DepartmentID = "Management",
                        ERoleID = "Manager",
                        ShiftTimeID = 1000000,
                        Count = -1
                    },
                    new BaseScheduleLine()
                    {
                        BaseScheduleID = 1000001,
                        DepartmentID = "Sales",
                        ERoleID = "Cashier",
                        ShiftTimeID = 1000004,
                        Count = 6
                    }
                }
            };

            int result = baseScheduleManager.AddBaseSchedule(badVM);
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a unit test for BaseScheduleManager get active.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void GetActiveBaseSchedule()
        {
            IBaseScheduleManager baseScheduleManager = new BaseScheduleManager(_baseScheduleAccessor);

            BaseScheduleVM vM = new BaseScheduleVM()
            {
                Active = true,
                BaseScheduleID = 1000000,
                CreatingUserID = 100000,
                CreationDate = DateTime.Parse("2020-01-03")
            };
            bool success = false;

            BaseScheduleVM otherVM = baseScheduleManager.GetActiveBaseSchedule();

            if (vM.BaseScheduleID == otherVM.BaseScheduleID && vM.CreatingUserID == otherVM.CreatingUserID
                && vM.CreationDate.Equals(otherVM.CreationDate))
            {
                success = true;
            }

            Assert.AreEqual(true, success);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a unit test for BaseScheduleManager get active.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void GetAllBaseSchedule()
        {
            IBaseScheduleManager baseScheduleManager = new BaseScheduleManager(_baseScheduleAccessor);
            BaseSchedule schedule = new BaseSchedule()
            {
                Active = true,
                BaseScheduleID = 1000000,
                CreatingUserID = 100000,
                CreationDate = DateTime.Parse("2020-01-03")
            };
            bool success = false;

            List<BaseSchedule> others = baseScheduleManager.GetAllBaseSchedules();

            if (others.Count == 1)
            {
                foreach (BaseSchedule other in others)
                {
                    if (schedule.BaseScheduleID == other.BaseScheduleID
                        && schedule.CreatingUserID == other.CreatingUserID
                        && schedule.CreationDate.Equals(other.CreationDate))
                    {
                        success = true;
                    }
                }
            }

            Assert.AreEqual(true, success);

        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a unit test for BaseScheduleManager get active.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void GetBaseScheduleLinesByBaseScheduleID()
        {
            IBaseScheduleManager baseScheduleManager = new BaseScheduleManager(_baseScheduleAccessor);
            BaseScheduleLine baseScheduleLine = new BaseScheduleLine()
            {
                BaseScheduleID = 1000000,
                DepartmentID = "Management",
                ERoleID = "Manager",
                ShiftTimeID = 1000000,
                Count = 1
            };


            List<BaseScheduleLine> others = baseScheduleManager.GetBaseScheduleLinesByBaseScheduleID(1000000);
            bool success = false;

            if (others.Count == 2)
            {
                foreach (BaseScheduleLine line in others)
                {
                    if (line.DepartmentID.Equals(baseScheduleLine.DepartmentID)
                        && line.ERoleID.Equals(baseScheduleLine.ERoleID)
                        && line.ShiftTimeID == baseScheduleLine.ShiftTimeID
                        && line.BaseScheduleID == baseScheduleLine.BaseScheduleID
                        && line.Count == baseScheduleLine.Count)
                    {
                        success = true;
                    }
                }
            }

            Assert.AreEqual(true, success);

        }
    }
}
