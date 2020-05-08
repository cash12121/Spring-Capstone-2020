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
    /// Creator: Alex Diers
    /// Created: 2/6/2020
    /// Approver: Lane Sandburg
    /// 
    /// This class houses the actual tests for TrainingVideo
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    [TestClass]
    public class TrainingVideoTests
    {
        private ITrainingVideoAccessor _trainingVideoAccessor;

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Constructor for the FakeTrainingVideoAccessor class
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public TrainingVideoTests()
        {
            _trainingVideoAccessor = new FakeTrainingVideoAccessor();
        }


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Tests the creation of a TrainingVideo object
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerInsertVideoTest()
        {
            //Arrange
            TrainingVideo video = new TrainingVideo();
            video.TrainingVideoID = "A";
            video.RunTimeMinutes = 1;
            video.RunTimeSeconds = 1;
            video.Description = "A";
            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.InsertTrainingVideo(video);

            //Assert
            Assert.IsTrue(test);
        }



        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Tests the retrieval of the TrainingVideos an Employee needs to view
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerSelectVideosByEmployeeTest()
        {
            // arrange
            List<TrainingVideoVM> videos;
            ITrainingVideoManager videoManager = new TrainingVideoManager(_trainingVideoAccessor);

            // act
            videos = videoManager.RetrieveTrainingVideosByEmployee();
            videos.AddRange(videoManager.RetrieveTrainingVideosByEmployee(true));
            // assert
            Assert.AreEqual(2, videos.Count);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Deacitvate active training video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerDeactivateActiveVideo()
        {
            //Arrange
            TrainingVideo video = new TrainingVideo()
            {
                TrainingVideoID = "A",
                RunTimeMinutes = 1,
                RunTimeSeconds = 1,
                Description = "A",
                Active = true

            };

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.DeactivateTrainingVideo(video);

            //Assert
            Assert.AreEqual(test, true);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Deacitvate on already deactive training video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerDeactivateDeactiveVideo()
        {
            //Arrange
            TrainingVideo video = new TrainingVideo()
            {
                TrainingVideoID = "B",
                RunTimeMinutes = 1,
                RunTimeSeconds = 1,
                Description = "A",
                Active = false

            };

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.DeactivateTrainingVideo(video);

            //Assert
            Assert.AreEqual(test, true);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Deacitvate on invalid training video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TrainingVideoManagerDeactivateInvalidVideo()
        {
            //Arrange
            TrainingVideo video = new TrainingVideo()
            {
                TrainingVideoID = "C",
                RunTimeMinutes = 1,
                RunTimeSeconds = 1,
                Description = "A",
                Active = true

            };

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.DeactivateTrainingVideo(video);

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Acitvate active training video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerActivateActiveVideo()
        {
            //Arrange
            TrainingVideo video = new TrainingVideo()
            {
                TrainingVideoID = "A",
                RunTimeMinutes = 1,
                RunTimeSeconds = 1,
                Description = "A",
                Active = true

            };

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.ActivateTrainingVideo(video);

            //Assert
            Assert.AreEqual(test, true);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Acitvate on already deactive training video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManageractivateDeactiveVideo()
        {
            //Arrange
            TrainingVideo video = new TrainingVideo()
            {
                TrainingVideoID = "B",
                RunTimeMinutes = 1,
                RunTimeSeconds = 1,
                Description = "A",
                Active = false

            };

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.ActivateTrainingVideo(video);

            //Assert
            Assert.AreEqual(test, true);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Acitvate on invalid training video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TrainingVideoManagerActivateInvalidVideo()
        {
            //Arrange
            TrainingVideo video = new TrainingVideo()
            {
                TrainingVideoID = "C",
                RunTimeMinutes = 1,
                RunTimeSeconds = 1,
                Description = "A",
                Active = true

            };

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.ActivateTrainingVideo(video);

        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Tests the retrieval of the TrainingVideos an Employee needs to view
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerUpdateVideoTest()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "A";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "A";
            newVideo.RunTimeMinutes = 2;
            newVideo.RunTimeSeconds = 2;
            newVideo.Description = "B";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);

            //Assert
            Assert.IsTrue(test);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video with no changes
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerUpdateVideoWithNoChangesTest()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "A";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "A";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = 1;
            newVideo.Description = "A";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);

            //Assert
            Assert.IsTrue(test);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video with that's inactive
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerUpdateInActiveVideoTest()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "B";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = 1;
            newVideo.Description = "A";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);

            //Assert
            Assert.IsTrue(test);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video with a new null description
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerNullDescription()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "B";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = 1;
            newVideo.Description = null;

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);

            //Assert
            Assert.IsTrue(test);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video with a new empty description
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerEmptyDescription()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "B";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = 1;
            newVideo.Description = "";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);

            //Assert
            Assert.IsTrue(test);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video with changes to pk
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TrainingVideoManagerUpdateVideoChangePrimaryKey()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "A";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = 1;
            newVideo.Description = "A";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video with too long of a description
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TrainingVideoManagerUpdateVideoDescriptionTooLong()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "A";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "A";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = 1;
            newVideo.Description =
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);

            //Assert
            Assert.IsTrue(test);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video with null minutes
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainingVideoManagerUpdateVideoNullMinutes()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "A";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = int.Parse(null);
            newVideo.RunTimeSeconds = 1;
            newVideo.Description = "A";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video with null seconds
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainingVideoManagerUpdateVideoNullSeconds()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "A";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = int.Parse(null);
            newVideo.Description = "A";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video that isn't in the list
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TrainingVideoManagerUpdateVideoNonExistantPK()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "C";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = 1;
            newVideo.Description = "A";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update on a null pk
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TrainingVideoManagerVideoUpdateNullPK()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "C";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = 1;
            newVideo.Description = "A";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test update a training video that has a valid pk but invalid details
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TrainingVideoManagerUpdateVideoInvalidDetails()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "A";
            oldVideo.RunTimeMinutes = 2;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = 1;
            newVideo.RunTimeSeconds = 1;
            newVideo.Description = "A";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.EditTrainingVideo(oldVideo, newVideo);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Select all active videos
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>

        [TestMethod]
        public void TestTrainingVideoManagerSelectVideosByActive()
        {
            // arrange
            List<TrainingVideo> videos;
            ITrainingVideoManager videoManager = new TrainingVideoManager(_trainingVideoAccessor);

            // act
            videos = videoManager.RetrieveTrainingVideosByActive(true);

            // assert
            Assert.AreEqual(1, videos.Count);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Select all inactive videos
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>

        [TestMethod]
        public void TestTrainingVideoManagerSelectVideosByInActive()
        {
            // arrange
            List<TrainingVideo> videos;
            ITrainingVideoManager videoManager = new TrainingVideoManager(_trainingVideoAccessor);

            // act
            videos = videoManager.RetrieveTrainingVideosByActive(false);

            // assert
            Assert.AreEqual(1, videos.Count);
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/5/2020
        /// Approver: Chase Schulte
        /// 
        /// Tests the ability to retrieve TrainingVideoVM objects and sort by relevant employee data
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTrainingVideosByEmployeeUnwatched()
        {
            // arrange
            List<TrainingVideoVM> videos;
            ITrainingVideoManager videoVMManager = new TrainingVideoManager(_trainingVideoAccessor);

            // act
            videos = videoVMManager.RetrieveTrainingVideosByEmployee(false);

            // assert
            Assert.AreEqual(1, videos.Count);
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/5/2020
        /// Approver: Chase Schulte
        /// 
        /// Tests the ability to retrieve TrainingVideoVM objects and sort by relevant employee data
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTrainingVideosByEmployeeWatched()
        {
            // arrange
            List<TrainingVideoVM> videos;
            ITrainingVideoManager videoVMManager = new TrainingVideoManager(_trainingVideoAccessor);

            // act
            videos = videoVMManager.RetrieveTrainingVideosByEmployee(true);

            // assert
            Assert.AreEqual(1, videos.Count);
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/5/2020
        /// Approver: Chase Schulte
        /// 
        /// Tests the ability to update a TrainingVideoVM IsWatched field
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestUpdateIsWatched()
        {
            //Arrange
            TrainingVideoVM videoVM = new TrainingVideoVM()
            {
                TrainingVideoID = "B",
                RunTimeMinutes = 1,
                RunTimeSeconds = 1,
                Description = "A",
                Active = true,
                IsWatched = false,
                UserID = 2,
                FirstName = "Tom",
                LastName = "Hardy"
            };

            bool test;
            ITrainingVideoManager videoVMManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = videoVMManager.EditIsWatched(videoVM);

            //Assert
            Assert.AreEqual(test, true);
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/5/2020
        /// Approver: Chase Schulte
        /// 
        /// Tests the ability to update a TrainingVideoVM IsWatched field
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestUpdateNotWatched()
        {
            //Arrange
            TrainingVideoVM videoVM = new TrainingVideoVM()
            {
                TrainingVideoID = "B",
                RunTimeMinutes = 1,
                RunTimeSeconds = 1,
                Description = "A",
                Active = true,
                IsWatched = true,
                UserID = 2,
                FirstName = "Tom",
                LastName = "Hardy"
            };

            bool test;
            ITrainingVideoManager videoVMManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = videoVMManager.EditNotWatched(videoVM);

            //Assert
            Assert.AreEqual(test, true);
        }
    }
}
