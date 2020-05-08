using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Timothy Lickteig        
    /// Created: 04/27/2020
    /// Approver: Zoey McDonald
    /// 
    /// Interface for foster appointment managers
    /// </summary>
    public class FosterAppointmentManager : IFosterAppointmentManager
    {
        private IFosterAppointmentAccessor accessor;

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// no argument constructor
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>        
        public FosterAppointmentManager()
        {
            this.accessor = new FosterAppointmentAccessor();
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// constructor for fake accessors
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks> 
        public FosterAppointmentManager(IFosterAppointmentAccessor accessor)
        {
            this.accessor = accessor;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for cancelling foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="fosterAppointmentID">The ID of the record to delete</param>
        /// <returns>Whether the operation was successful</returns>
        public bool CancelFosterAppointment(int fosterAppointmentID)
        {
            try
            {
                return 1 == accessor.DeleteFosterAppointment(fosterAppointmentID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException
                    ("Error cancelling appointment: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for scheduling foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="fosterAppointmentID">The ID of the record to delete</param>
        /// <returns>Whether the operation was successful</returns>
        public bool ScheduleFosterAppointment(FosterAppointment appointment)
        {
            if (appointment.EndTime < appointment.StartTime)
            {
                throw new ApplicationException("End time cannot be before start time");
            }

            try
            {
                return 1 ==
                    accessor.InsertFosterAppointment(appointment);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error scheduling the appointment: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for updating foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="oldAppt">The old appointment</param>
        /// <param name="oldAppt">The old appointment</param>
        /// <returns>Whether the operation was successful</returns>
        public bool UpdateFosterAppointment(FosterAppointment oldAppt, FosterAppointment newAppt)
        {
            try
            {
                return 1 == accessor.UpdateFosterAppointment(oldAppt, newAppt);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error updating: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for accessing all appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>        
        /// <returns>The list of appointments</returns>
        public List<FosterAppointmentVM> ViewFosterAppointments()
        {
            try
            {
                return accessor.SelectAllFosterAppointments();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error viewing the appointments: " + ex.Message, ex);
            }
        }
    }
}
