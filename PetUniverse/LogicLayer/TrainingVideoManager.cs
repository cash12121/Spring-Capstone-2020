using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Alex Diers
    /// Created: 2/6/2020
    /// Approver: Lane Sandburg
    /// 
    /// This class manages the usage of the CRUD functions
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public class TrainingVideoManager : ITrainingVideoManager
    {
        private ITrainingVideoAccessor _trainingVideoAccessor;

        /// <summary>
        /// NAME : Alex Diers
        /// Created: 2/20/2020
        /// Approver: Lane Sandburg
        /// 
        /// No argument constructor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        public TrainingVideoManager()
        {
            _trainingVideoAccessor = new TrainingVideoAccessor();
        }


        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Lane Sandburg
        /// 
        /// Constructor for the TrainingVideoManager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="trainingVideoAccessor"></param>
        public TrainingVideoManager(ITrainingVideoAccessor trainingVideoAccessor)
        {
            _trainingVideoAccessor = trainingVideoAccessor;
        }

        public bool ActivateTrainingVideo(TrainingVideo video)
        {
            bool result = true;
            try
            {
                result = _trainingVideoAccessor.ActivateTrainingVideo(video) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Video not activate", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Jordan Lindo
        /// 
        /// Deactivate a Training Video
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        public bool DeactivateTrainingVideo(TrainingVideo video)
        {
            bool result = true;
            try
            {
                result = _trainingVideoAccessor.DeactivateTrainingVideo(video) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Video not deactivated", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Jordan Lindo
        /// 
        /// Implementation of the InsertTrainingVideo method from the ITrainingVideoManager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        public bool InsertTrainingVideo(TrainingVideo video)
        {
            bool result = true;
            try
            {
                result = _trainingVideoAccessor.InsertTrainingVideo(video) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Video not added", ex);
            }
            return result;
        }


        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/13/2020
        /// Approver: Lane Sandburg
        /// 
        /// Implementation of the RetrieveTrainingVideoManager method from the ITrainingVideoManager interface
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns></returns>
        public List<TrainingVideoVM> RetrieveTrainingVideosByEmployee()
        {
            try
            {
                return _trainingVideoAccessor.SelectTrainingVideosByEmployee();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/13/2020
        /// Approver: Lane Sandburg
        /// 
        /// Implementation of the RetrieveTrainingVideoManager method from the ITrainingVideoManager interface
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns></returns>
        public bool EditTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo)
        {
            bool result = false;
            try
            {
                result = _trainingVideoAccessor.UpdateTrainingVideo(oldVideo, newVideo) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Find videos based on active state
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<TrainingVideo> RetrieveTrainingVideosByActive(bool active = true)
        {
            try
            {
                return _trainingVideoAccessor.SelectTrainingVideosByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/5/2020
        /// Approver: Chase Schulte
        /// 
        /// Changes the status of a TrainingVideoVM to being watched
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="videoVM"></param>
        /// <returns></returns>
        public bool EditIsWatched(TrainingVideoVM videoVM)
        {
            bool result = true;

            try
            {
                result = _trainingVideoAccessor.UpdateIsWatched(videoVM) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/5/2020
        /// Approver: Chase Schulte
        /// 
        /// Changes the status of a TrainingVideoVM to not being watched
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="videoVM"></param>
        /// <returns></returns>
        public bool EditNotWatched(TrainingVideoVM videoVM)
        {
            bool result = true;

            try
            {
                result = _trainingVideoAccessor.UpdateNotWatched(videoVM) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/5/2020
        /// Approver: Chase Schulte
        /// 
        /// Creates a list of TrainingVideoVM objects based on the data from the DAL
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public List<TrainingVideoVM> RetrieveTrainingVideosByEmployee(bool watched = false)
        {
            try
            {
                return _trainingVideoAccessor.SelectTrainingVideosByEmployee(watched);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}
