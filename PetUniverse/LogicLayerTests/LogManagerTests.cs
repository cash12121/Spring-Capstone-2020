using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/11/2020
    /// Approver: Steven Cardona
    /// 
    /// This class tests the LogManager Class
    /// </summary>
    [TestClass]
    public class LogManagerTests
    {
        private FakeLogAccessor _fakeLogAccessor;
        private ILogManager _logManager;

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// Setup for tests to run
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updater: NA
        /// Update: NA        
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeLogAccessor = new FakeLogAccessor();
            _logManager = new LogManager(_fakeLogAccessor);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is test for the RetrieveLoginandOutLogs() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updater: NA
        /// Update: NA        
        /// </remarks>  
        [TestMethod]
        public void TestRetrieveListOfLoginandOutLogs()
        {
            //Arrange
            List<LogItem> _logs;
            //Act
            _logs = _logManager.RetrieveLoginandOutLogs();
            //Assert                                   
            Assert.AreEqual(1, _logs.Count);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// Method to reset all variable for next test run.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updater: NA
        /// Update: NA        
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeLogAccessor = null;
            _logManager = null;
        }
    }
}
