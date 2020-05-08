using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/29
    /// Approver: Awaab Elamin, 2020/03/03
    /// This Class is the public interface for Adoption Interviewer Manager class
    /// </summary>
    public interface IAdoptionInterviewerManager
    {

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/03/03
        /// This method used to get Adoption Applications Aappointments By Appointmen
        ///  type.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <returns>AdoptionApplications List</returns>
        List<AdoptionAppointment> SelectAdoptionAappointmentsByAppointmentType();



        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/03/03
        /// This method used to updates the appointment's record ,so the Interviewer can insert
        ///  his notes into the system.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="oldAdoptionAppointment"></param>
        /// <param name="newAdoptionAppointment"></param>
        /// <returns>True or false depending if the record was updated</returns>
        bool EditAppointment(AdoptionAppointment oldAdoptionAppointment
            , AdoptionAppointment newAdoptionAppointment);

    }
}




