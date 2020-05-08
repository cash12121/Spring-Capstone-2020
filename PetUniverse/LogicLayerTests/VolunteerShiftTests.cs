using DataAccessFakes;
using DataTransferObjects;
using DataAccessInterfaces;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    


    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-02-05
    ///     CHECKED BY: Zoey McDonald
    ///     Test class for the VolunteerShiftManager class
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    [TestClass]
    public class VolunteerShiftTests
    {

        private IVolunteerShiftAccessor _fakeShiftAccessor = new FakeVolunteerShiftAccessor();
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager AddVolunteerShift method
        /// </summary>        
        [TestMethod]
        public void TestVolunteerShiftManagerAddsNewShift()
        {
            //Arrange
            IVolunteerShiftManager manager = new VolunteerShiftManager(_fakeShiftAccessor);

            //Act
            int rows = manager.AddVolunteerShift(new VolunteerShiftVM()
            {
                VolunteerShiftID = 100,
                VolunteerID = 1,
                ShiftTitle = "The Shift",
                IsSpecialEvent = false,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 100,
                ShiftNotes = "This shift is cool",
                VolunteerTaskID = 100,
                Recurrance = "None",
                ShiftDescription = "This is a cool shift",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero + TimeSpan.Parse("00:06:00:00")
            });

            //Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-08
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager RemoveVolunteerShift method
        /// </summary>
        [TestMethod]
        public void TestVolunteerShiftManagerRemoveAnExistingShift()
        {
            //Arrange
            IVolunteerShiftManager manager = new VolunteerShiftManager(_fakeShiftAccessor);

            //Act            
            int rows = manager.RemoveVolunteerShift(2);

            //Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-08
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager RemoveVolunteerShift method
        /// </summary>
        [TestMethod]
        public void TestVolunteerShiftManagerRemoveNonExistingShift()
        {
            //Arrange
            IVolunteerShiftManager manager = new VolunteerShiftManager(_fakeShiftAccessor);

            //Act            
            int rows = manager.RemoveVolunteerShift(1000);

            //Assert
            Assert.AreEqual(0, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-10
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager EditVolunteerShift method
        /// </summary>
        [TestMethod]
        public void TestVolunteerShiftManagerEditAShiftRecord()
        {
            //Arrange
            IVolunteerShiftManager manager = new VolunteerShiftManager(_fakeShiftAccessor);

            //Act            
            int rows = manager.EditVolunteerShift(
                new VolunteerShiftVM()
                {
                    VolunteerShiftID = 1
                },
                new VolunteerShiftVM()
                {
                    VolunteerShiftID = 1,
                    ShiftDescription = "Hello World!",
                    VolunteerShiftDate = DateTime.Now,
                    ShiftTitle = "This is the title",
                    ShiftStartTime = TimeSpan.Zero,
                    ShiftEndTime = TimeSpan.Zero,
                    Recurrance = "None",
                    IsSpecialEvent = true,
                    ShiftNotes = "These are the notes2",
                    ScheduleID = 0
                }
                );

            //Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-17
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager ReturnAllVolunteerShifts method
        /// </summary>
        [TestMethod]
        public void TestVolunteerShiftManagerReturnAllVolunteerShifts()
        {
            IVolunteerShiftManager manager = new VolunteerShiftManager(_fakeShiftAccessor);

            manager.AddVolunteerShift(new VolunteerShiftVM()
            {
                VolunteerID = 0,
                VolunteerShiftID = 0,
                ShiftTitle = "Pretty dope shift",
                IsSpecialEvent = true,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 0,
                ShiftNotes = "Some things to note",
                VolunteerTaskID = 0,
                Recurrance = "Weekly",
                ShiftDescription = "Something descriptive",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero
            });
            manager.AddVolunteerShift(new VolunteerShiftVM()
            {
                VolunteerID = 0,
                VolunteerShiftID = 0,
                ShiftTitle = "Even cooler shift",
                IsSpecialEvent = false,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 0,
                ShiftNotes = "Some other things to note",
                VolunteerTaskID = 0,
                Recurrance = "Daily",
                ShiftDescription = "Something more descriptive",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero
            });

            int count = manager.ReturnAllVolunteerShifts().Count;

            Assert.AreEqual(true, count > 1);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager 
        ///         SelectVolunteerShift method
        /// </summary>
        [TestMethod]
        public void testVolunteerShiftManagerSelectShift()
        {
            IVolunteerShiftManager manager = new VolunteerShiftManager(_fakeShiftAccessor);

            int shiftID = manager.SelectVolunteerShift(1).VolunteerShiftID;

            Assert.AreEqual(shiftID, 1);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager 
        ///         ReturnAllVolunteerShiftsForAVolunteer method
        /// </summary>
        [TestMethod]
        public void testVolunteerShiftManagerReturnAllShiftsForAVolunteer()
        {
            IVolunteerShiftManager manager = new VolunteerShiftManager(_fakeShiftAccessor);

            List<VolunteerShiftVM> shifts =
                manager.ReturnAllVolunteerShiftsForAVolunteer(1);

            Assert.AreEqual(true, shifts.Count > 0);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-02
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the volunteerShiftManager
        ///         SignVolunteerUpForShift method
        /// </summary>                       
        [TestMethod]
        public void testVolunteerShiftManagerSignVolunteerUpForShift()
        {
            IVolunteerShiftManager manager = new VolunteerShiftManager(_fakeShiftAccessor);

            int rows = manager.SignVolunteerUpForShift(1000001, 1000001);

            Assert.AreEqual(1, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-08
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the volunteerShiftManager
        ///         CancelVolunteerShift method
        /// </summary>                       
        [TestMethod]
        public void testVolunteerShiftManagerCancelVolunteerShift()
        {
            IVolunteerShiftManager manager = new VolunteerShiftManager(_fakeShiftAccessor);

            int rows = manager.CancelVolunteerShift(1000001, 1000001);

            Assert.AreEqual(1, rows);
        }
    }
}
