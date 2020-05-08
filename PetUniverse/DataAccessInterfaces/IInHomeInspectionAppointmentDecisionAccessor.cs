using DataTransferObjects;
using System.Collections.Generic;


namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 02/19/2020
    /// Approver:  Awaab Elamin, 02/21/2020
    ///
    /// This interface for accessing Adoption Applications data.
    /// </summary>
    public interface IInHomeInspectionAppointmentDecisionAccessor
    {

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approver: Awaab Elamin, 02/21/2020
        /// 
        /// This method used to get Adoption Application Appointments By Appointment Type
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType();

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approver: Awaab Elamin, 02/21/2020
        /// 
        /// This method used to update an Adoptoin Application decisionID.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        int UpdateAppoinment(HomeInspectorAdoptionAppointmentDecision
            oldHomeInspectorAdoptionAppointmentDecision,
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision);

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approver: Awaab Elamin, 02/21/2020
        /// 
        /// This method gets the Customer email from the user table by AdoptionApplication ID.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <param name="decision"></param>
        int UpdateHomeInspectorDecision(int adoptionApplicationID, string decision);

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 02/19/2020
        /// Approved By: Awaab Elamin, 02/21/2020
        /// 
        /// This method gets the Customer email from the user table by AdoptionApplicationID.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationId"></param>
        string GetCustomerEmailByAdoptionApplicationID(int adoptionApplicationId);
    }
}