using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Awaab Elamin, 2020/02/21
    /// This Class for creating  the properties of Home Inspector Adoption Appointment Decision.
    /// </summary>

    public interface IInHomeInspectionAppointmentDecisionManager
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This method used to get Adoption Applications Aappointments By Appointmen
        ///  type.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <returns>List of inHomeInspectionAppointmentDecision </returns>
        List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType();

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This method used to updates the Applications Aappointment Decision and
        ///  the in-home Inspector's notes.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="oldHomeInspectorAdoptionAppointmentDecision"></param>
        /// <param name="newHomeInspectorAdoptionAppointmentDecision"></param>
        /// <returns>True or false depending if the record was updated</returns>
        bool EditAppointment(HomeInspectorAdoptionAppointmentDecision
            oldHomeInspectorAdoptionAppointmentDecision, HomeInspectorAdoptionAppointmentDecision
            newHomeInspectorAdoptionAppointmentDecision);


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approved: Awaab Elamin, 02/21/2020
        /// This method gets the Customer email by Adoption Application ID
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns>CustomerEmail</returns>
        string GetCustomerEmailByAdoptionApplicationID(int adoptionApplicationID);


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/03/10
        /// Approver: Awaab Elamin 03/13/2020
        /// This method gets the Customer email by Adoption Application ID
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <param name="decision"></param>
        /// <returns>True or false depending if the record was updated</returns>
        bool UpdateHomeInspectorDecision(int adoptionApplicationID, string decision);

    }
}
