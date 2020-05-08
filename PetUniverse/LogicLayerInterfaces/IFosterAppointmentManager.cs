using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IFosterAppointmentManager
    {
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
        bool ScheduleFosterAppointment(FosterAppointment appointment);

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
        List<FosterAppointmentVM> ViewFosterAppointments();

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
        bool UpdateFosterAppointment(FosterAppointment oldAppt, FosterAppointment newAppt);

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
        bool CancelFosterAppointment(int fosterAppointmentID);
    }
}
