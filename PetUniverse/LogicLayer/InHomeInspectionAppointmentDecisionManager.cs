using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver:  Awaab Elamin, 2020/02/21
    /// This Class for creating  the properties of Home Inspector Adoption Appointment Decision.
    /// </summary>
    public class InHomeInspectionAppointmentDecisionManager : IInHomeInspectionAppointmentDecisionManager
    {
        private IInHomeInspectionAppointmentDecisionAccessor _inHomeInspectionAppointmentDecisionAccessor;


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is the Constructor method for InHome Inspection 
        /// Appointment Decision Manager class.
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>     
        public InHomeInspectionAppointmentDecisionManager()
        {
            _inHomeInspectionAppointmentDecisionAccessor = new InHomeInspectionAppointmentDecisionAccessor();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is the Constructor method for InHome Inspection 
        /// Appointment Decision Manager
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update:  Fixed Comments format.
        /// </remarks>
        /// <param name="inHomeInspectionAppointmentDecisionAccessor"></param>
        public InHomeInspectionAppointmentDecisionManager(IInHomeInspectionAppointmentDecisionAccessor inHomeInspectionAppointmentDecisionAccessor)
        {
            _inHomeInspectionAppointmentDecisionAccessor = inHomeInspectionAppointmentDecisionAccessor;

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This method used to updates the Applications Aappointment Decision and
        ///  the in-home Inspector's notes.
        /// </summary>
        /// <remarks>
        /// Updater Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update:  Fixed Comments format.
        /// </remarks>
        /// <param name="oldHomeInspectorAdoptionAppointmentDecision"></param>
        /// <param name="newHomeInspectorAdoptionAppointmentDecision"></param>
        /// <returns>True or false depending if the record was updated</returns>
        public bool EditAppointment(HomeInspectorAdoptionAppointmentDecision oldHomeInspectorAdoptionAppointmentDecision,
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision)
        {
            bool result = false;
            try
            {
                result = (1 == _inHomeInspectionAppointmentDecisionAccessor.UpdateAppoinment
                    (oldHomeInspectorAdoptionAppointmentDecision, newHomeInspectorAdoptionAppointmentDecision));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update failed.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/03/10
        /// Approved: Awaab Elamin , 2020/03/12
        /// This method is for getting the Customer Email by Adoption Application ID.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns>CustomerEmail</returns>
        public string GetCustomerEmailByAdoptionApplicationID(int adoptionApplicationID)
        {
            string customerEmail = null;
            try
            {
                customerEmail = _inHomeInspectionAppointmentDecisionAccessor.
                    GetCustomerEmailByAdoptionApplicationID(adoptionApplicationID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return customerEmail;
        }

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
        public List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType()
        {
            List<HomeInspectorAdoptionAppointmentDecision> inHomeInspectionAppointmentDecision = null;
            try
            {
                inHomeInspectionAppointmentDecision = _inHomeInspectionAppointmentDecisionAccessor.
                    SelectAdoptionApplicationsAappointmentsByAppointmentType();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("List not found", ex);
            }

            return inHomeInspectionAppointmentDecision;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/02/19
        /// Approved By: Awaab Elamin, 2020/02/21
        /// 
        /// This method used to Update Adoption Applications Appointment's decision.
        ///  type.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <param name="decision"></param>
        /// <returns>True or false depending if the record was updated</returns>
        public bool UpdateHomeInspectorDecision(int adoptionApplicationID, string decision)
        {
            bool result = false;
            if (_inHomeInspectionAppointmentDecisionAccessor.UpdateHomeInspectorDecision
                (adoptionApplicationID, decision) == 1)
            {
                result = true;
            }
            return result;
        }
    }
}
