using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Alex Diers
    /// Created: 2/6/2020
    /// Approver: Lane Sandburg
    /// 
    /// Interface for the Manager class
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public interface ITrainingVideoManager
    {
        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Jordan Lindo
        /// 
        /// Method for managing the creation of a TrainingVideo object
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        bool InsertTrainingVideo(TrainingVideo video);



        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/13/2020
        /// Approver: Lane Sandburg
        /// 
        /// Method for the retrieval of the TrainingVideos an Employee needs to view
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        bool EditTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Deactivate a video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        bool DeactivateTrainingVideo(TrainingVideo video);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Activate a video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        bool ActivateTrainingVideo(TrainingVideo video);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Find videos based on active state
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<TrainingVideo> RetrieveTrainingVideosByActive(bool active = true);

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/15/2020
        /// Approver: Lane Sandburg
        /// 
        /// Used to select a list of TrainingVideo objects by Employee that needs to view them
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<TrainingVideoVM> RetrieveTrainingVideosByEmployee(bool watched = false);

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/15/2020
        /// Approver: Chase Schulte
        /// 
        /// Used to change the record of a video to being watched 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="isWatched"></param>
        /// <returns></returns>
        bool EditIsWatched(TrainingVideoVM videoVM);

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 3/15/2020
        /// Approver: Chase Schulte
        /// 
        /// Used to change the record of a video to not being watched 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="isWatched"></param>
        /// <returns></returns>
        bool EditNotWatched(TrainingVideoVM videoVM);
    }
}