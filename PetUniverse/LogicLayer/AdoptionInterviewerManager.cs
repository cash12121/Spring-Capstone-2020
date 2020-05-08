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
    /// Created: 2020/02/29
    /// Approver: Awaab Elamin, 2020/03/03
    /// This Class for main logic of Interviewer.
    /// </summary>
    public class AdoptionInterviewerManager : IAdoptionInterviewerManager
    {

        private IAdoptionInterviewerAccessor _adoptionInterviewerAccessor;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/03/03
        /// This is the Constructor method for InHome Inspection 
        /// Appointment Decision Manager.
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>
        /// <param name="adoptionInterviewerAccessor"></param>
        public AdoptionInterviewerManager(IAdoptionInterviewerAccessor adoptionInterviewerAccessor)
        {
            _adoptionInterviewerAccessor = adoptionInterviewerAccessor;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/03/03
        /// This is no argument Constructor method.
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks> 
        public AdoptionInterviewerManager()
        {
            _adoptionInterviewerAccessor = new AdoptionInterviewerAccessor();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/03/03
        /// This method used to edit the Appointment notes.
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>
        /// <param name="newAdoptionAppointment"></param>
        /// <param name="oldAdoptionAppointment"></param>
        /// <returns>True or false depending if the record was updated</returns>
        public bool EditAppointment(AdoptionAppointment oldAdoptionAppointment, AdoptionAppointment newAdoptionAppointment)
        {
            bool result = false;
            try
            {
                result = (1 == _adoptionInterviewerAccessor.UpdateAppoinment
                   (oldAdoptionAppointment, newAdoptionAppointment));

            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update failed.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/03/03
        /// This method select Appointments by the appointment type.
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks>
        /// <returns>adoptionApplications List</returns>
        public List<AdoptionAppointment> SelectAdoptionAappointmentsByAppointmentType()
        {
            List<AdoptionAppointment> adoptionApplications = null;
            try
            {
                adoptionApplications = _adoptionInterviewerAccessor.SelectAdoptionAappointmentsByAppointmentType();

            }
            catch (Exception ex)
            {

                throw new ApplicationException("List not found", ex);
            }

            return adoptionApplications;
        }
    }
}


