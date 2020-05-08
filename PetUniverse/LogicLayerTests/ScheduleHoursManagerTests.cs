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
    public class ScheduleHoursManagerTests
    {
        private IScheduleHoursAccessor _scheduleHoursAccessor;

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schutle
        /// 
        /// The constructor for test class.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ScheduleHoursManagerTests()
        {
            _scheduleHoursAccessor = new FakeScheduleHoursAccessor();
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schutle
        /// 
        /// The test method for add all schedule hours.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAddAllScheduleHours()
        {
            IScheduleHoursManager scheduleHoursManager =
                new ScheduleHoursManager(_scheduleHoursAccessor);
            List<PUUserVMHours> list = new List<PUUserVMHours>
            {
                new PUUserVMHours
                {
                    FirstName = "Empty",
                    Week1Hours = 1
                }
            };

            int result = scheduleHoursManager.AddAllScheduleHours(1000000, list);

            Assert.AreEqual(1, result);
        }
    }
}
