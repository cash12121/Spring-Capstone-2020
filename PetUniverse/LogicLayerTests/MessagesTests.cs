using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{

    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 03/16/2020
    /// Approver: Steven Cardona
    /// 
    /// The tests for the Messages manager
    /// </summary>
    [TestClass]
    public class MessagesTests
    {
        private Messages messages;
        private FakeMessageAccessor _fakeMessageAccessor;
        private MessagesManager messagesManager;


        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/19/2020
        /// Approver: Steven Cardona
        /// 
        /// Setup for tests to run
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeMessageAccessor = new FakeMessageAccessor();
            messagesManager = new MessagesManager(_fakeMessageAccessor);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/19/2020
        /// Approver:Steven Cardona
        /// 
        /// Test for Retrieving departments like the provided input
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestGetDepartmentsLikeInput()
        {
            //arrange
            string query = "s";
            List<string> results = new List<string>();

            // act
            results = messagesManager.RetrieveDepartmentsLikeInput(query);

            // assert
            Assert.AreEqual(results.Count, 1);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/19/2020
        /// Approver: Steven Cardona
        /// 
        /// Test for retrieveing users like the provided input
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestGetUsersLikeInput()
        {
            //arrange
            string query = "s";
            List<string> results = new List<string>();
            // act
            results = messagesManager.GetUsersLikeInput(query);

            // assert
            Assert.AreEqual(results.Count, 1);
        }


        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/19/2020
        /// Approver: Steven Cardona
        /// 
        /// Test for Sending an email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestSendEmail()
        {
            //arrange
            bool sent;
            string content = "TEST";
            string subject = "TEST";
            int senderid = 100000;
            int recieverid = 100001;

            // act
            sent = messagesManager.sendEmail(content, subject, senderid, recieverid);

            // assert
            Assert.IsTrue(sent);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/01/2020
        /// Approver: Steven Cardona
        /// 
        /// Test method to set message seen
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA 
        /// </remarks>
        [TestMethod]
        public void TestSetMessageSeen()
        {
            //Arrange
            bool seen;
            int MessageID = 100000;

            //act
            seen = messagesManager.setMessageSeen(MessageID);

            //assert
            Assert.IsTrue(seen);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/31/2020
        /// Approver: Steven Cardona
        /// 
        /// Test method for getting messages
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA 
        /// </remarks>
        [TestMethod]
        public void TestGetMessagesByRecipientID()
        {
            //arrange
            int RecipientID = 100000;
            List<Messages> results = new List<Messages>();
            // act
            results = messagesManager.GetMessagesByRecipient(RecipientID);

            // assert
            Assert.AreEqual(results.Count, 1);

        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/19/2020
        /// Approver: Steven Cardona
        /// 
        /// Method to reset all variable for next test run.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA 
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeMessageAccessor = null;
        }
    }
}
