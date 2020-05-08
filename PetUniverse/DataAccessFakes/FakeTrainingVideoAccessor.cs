using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Alex Diers
    /// Created: 2/6/2020
    /// Approver: Lane Sandburg
    /// 
    /// This class is used for testing of the TrainingVideo object
    /// </summary>
    public class FakeTrainingVideoAccessor : ITrainingVideoAccessor
    {
        private List<TrainingVideoVM> trainingVideoVMs;
        private List<TrainingVideo> trainingVideos;

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Creates a TrainingVideo object and adds it to the List for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public FakeTrainingVideoAccessor()
        {
            trainingVideos = new List<TrainingVideo>
            {
                new TrainingVideo()
                {
                    TrainingVideoID  = "A",
                    RunTimeMinutes = 1,
                    RunTimeSeconds = 1,
                    Description = "A",
                    Active = true
                },
                new TrainingVideo()
                {
                    TrainingVideoID  = "B",
                    RunTimeMinutes = 1,
                    RunTimeSeconds = 1,
                    Description = "A",
                    Active = false
                }

            };
            trainingVideoVMs = new List<TrainingVideoVM>
            {
                new TrainingVideoVM()
                {
                    TrainingVideoID  = "A",
                    RunTimeMinutes = 1,
                    RunTimeSeconds = 1,
                    Description = "A",
                    Active = true,
                    IsWatched = true,
                    UserID = 1,
                    FirstName = "Tom",
                    LastName = "Hanks"

                },
                new TrainingVideoVM()
                {
                    TrainingVideoID  = "B",
                    RunTimeMinutes = 1,
                    RunTimeSeconds = 1,
                    Description = "A",
                    Active = true,
                    IsWatched = false,
                    UserID = 2,
                    FirstName = "Tom",
                    LastName = "Hardy"
                }
            };
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Method to activate video
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="videoID"></param>
        /// <returns>int</returns>
        public int ActivateTrainingVideo(TrainingVideo videoID)
        {
            TrainingVideo trainingVideo = null;

            //Fail immediately if null
            if (videoID == null)
            {
                throw new Exception();
            }

            //Check that video is in list, if so assign it, else fail
            foreach (var v in trainingVideos)
            {
                if (videoID.TrainingVideoID == v.TrainingVideoID)
                {
                    trainingVideo = v;
                }
            }

            //Throw exception if video isn't in list
            if (trainingVideo == null || videoID.TrainingVideoID != trainingVideo.TrainingVideoID)
            {
                throw new Exception();
            }

            //Activate it
            trainingVideo.Active = true;

            if (trainingVideo.Active == true)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Method to deactivate video
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="videoID"></param>
        /// <returns></returns>
        public int DeactivateTrainingVideo(TrainingVideo videoID)
        {
            TrainingVideo trainingVideo = null;

            //Fail immediatly if null
            if (videoID == null)
            {
                throw new Exception();
            }

            //Check that video is in list, if so assign it, else fail
            foreach (var v in trainingVideos)
            {
                if (videoID.TrainingVideoID == v.TrainingVideoID)
                {
                    trainingVideo = v;
                }
            }

            //Throw exception if video isn't in list
            if (trainingVideo == null || videoID.TrainingVideoID != trainingVideo.TrainingVideoID)
            {
                throw new Exception();
            }

            //Deactivate it
            trainingVideo.Active = false;

            if (trainingVideo.Active == false)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Method to test the insertion of a TrainingVideo object
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        public int InsertTrainingVideo(TrainingVideo video)
        {
            TrainingVideo newVideo = new TrainingVideo();

            newVideo = video;

            try
            {
                trainingVideos.Add(newVideo);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test finding videos based on active state
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<TrainingVideo> SelectTrainingVideosByActive(bool active = true)
        {
            List<TrainingVideo> newVideos = new List<TrainingVideo>();
            foreach (var video in trainingVideos)
            {
                if (video.Active == active)
                {
                    newVideos.Add(video);
                }
            }
            return newVideos;
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Method tests viewing TrainingVideo objects by Employee
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/01/2020
        /// Update: NA
        /// </remarks>
        public List<TrainingVideo> SelectTrainingVideosByEmployee()
        {
            return (from t in trainingVideos
                    select t).ToList();
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Method tests viewing TrainingVideo objects by Employee
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public int UpdateTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo)
        {
            bool videoTrue = false;

            //Fail immediatly if null
            if (oldVideo == null)
            {
                throw new Exception();
            }

            //Check that eRole is in list, if so assign it, else fail
            foreach (var trainingVideo
                in trainingVideos)
            {
                if (oldVideo.TrainingVideoID == trainingVideo.TrainingVideoID && oldVideo.RunTimeSeconds == trainingVideo.RunTimeSeconds && oldVideo.RunTimeMinutes == trainingVideo.RunTimeMinutes && oldVideo.Description == trainingVideo.Description && trainingVideo != null)
                {
                    videoTrue = true;
                }
            }

            //Throw exception if eRole isn't in list
            if (videoTrue == false)
            {
                throw new Exception();
            }

            //Make sure PK remains the same
            if (oldVideo.TrainingVideoID != newVideo.TrainingVideoID)
            {
                throw new Exception();
            }

            //Make sure description isn't too long
            if (newVideo.Description != null && newVideo.Description.Length > 1000)
            {
                throw new Exception();
            }

            //Update old ERole to newVideo
            oldVideo = newVideo;

            //Make sure old eRole is updated
            if (oldVideo == newVideo)
            {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 3/5/2020
        /// CHECKED BY: Chase Schulte
        /// 
        /// Creates a list from the mock objects sorted by employee data
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED DATE: 
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        public List<TrainingVideoVM> SelectTrainingVideosByEmployee(bool watched = false)
        {
            List<TrainingVideoVM> videos = new List<TrainingVideoVM>();
            foreach (var video in trainingVideoVMs)
            {
                if (video.IsWatched == watched)
                {
                    videos.Add(video);
                }
            }
            return videos;
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 3/5/2020
        /// CHECKED BY: Chase Schulte
        /// 
        /// Uses mock objects to update their IsWatched value
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED DATE: 
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="videoVM"></param>
        /// <returns></returns>
        public int UpdateIsWatched(TrainingVideoVM videoVM)
        {
            TrainingVideoVM trainingVideoVM = null;

            //Fail immediatly if null
            if (videoVM == null)
            {
                throw new Exception();
            }

            //Check that video is in list, if so assign it, else fail
            foreach (var v in trainingVideoVMs)
            {
                if (videoVM.TrainingVideoID == v.TrainingVideoID)
                {
                    trainingVideoVM = v;
                }
            }

            //Throw exception if video isn't in list
            if (trainingVideoVM == null || videoVM.TrainingVideoID != trainingVideoVM.TrainingVideoID)
            {
                throw new Exception();
            }

            //Deactivate it
            trainingVideoVM.IsWatched = true;

            if (trainingVideoVM.IsWatched == true)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 3/5/2020
        /// CHECKED BY: Chase Schulte
        /// 
        /// Uses mock objects to update their IsWatched value
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED DATE: 
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="videoVM"></param>
        /// <returns></returns>
        public int UpdateNotWatched(TrainingVideoVM videoVM)
        {
            TrainingVideoVM trainingVideoVM = null;

            //Fail immediatly if null
            if (videoVM == null)
            {
                throw new Exception();
            }

            //Check that video is in list, if so assign it, else fail
            foreach (var v in trainingVideoVMs)
            {
                if (videoVM.TrainingVideoID == v.TrainingVideoID)
                {
                    trainingVideoVM = v;
                }
            }

            //Throw exception if video isn't in list
            if (trainingVideoVM == null || videoVM.TrainingVideoID != trainingVideoVM.TrainingVideoID)
            {
                throw new Exception();
            }

            //Deactivate it
            trainingVideoVM.IsWatched = false;

            if (trainingVideoVM.IsWatched == false)
            {
                return 1;
            }
            return 0;
        }

    }
}

