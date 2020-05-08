using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 02/29/2020
    /// Approver: Awaab Elamin, 03/03/2020
    ///
    /// This interface for accessing Appointment Applications data.
    /// </summary>
    public interface IAdoptionInterviewerAccessor
    {

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approve: Awaab Elamin, 03/03/2020
        /// 
        /// This method used to get Adoption Applictions if their status
        /// is In-home Inspection. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="newAdoptionAppointment"></param>
        /// <param name="oldAdoptionAppointment"></param>
        int UpdateAppoinment(AdoptionAppointment oldAdoptionAppointment, AdoptionAppointment
           newAdoptionAppointment);

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Awaab Elamin, 03/03/2020
        /// 
        /// This method used to get Adoption Applictions if their status
        /// is Interviewer. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <returns>list of Adoption Applications</returns>
        List<AdoptionAppointment> SelectAdoptionAappointmentsByAppointmentType();
    }
}