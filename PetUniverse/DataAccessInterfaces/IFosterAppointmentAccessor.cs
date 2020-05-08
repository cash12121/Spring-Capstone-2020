using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Timothy Lickteig        
    /// Created: 04/27/2020
    /// Approver: Zoey McDonald
    /// 
    /// Interface for data access classes for foster appointments
    /// </summary>
    public interface IFosterAppointmentAccessor
    {
        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for inserting foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="appointment">The record to insert</param>
        /// <returns>The number of rows affected</returns>
        int InsertFosterAppointment(FosterAppointment appointment);

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for selecting all foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>        
        /// <returns>The list of appointment records</returns>
        List<FosterAppointmentVM> SelectAllFosterAppointments();

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
        /// <param name="oldAppt">The old record</param>
        /// <param name="newAppt">The new record</param>
        /// <returns>The number of rows affected</returns>
        int UpdateFosterAppointment(FosterAppointment oldAppt, FosterAppointment newAppt);

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for deleting foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="fosterAppointmentID">The ID of the record to delete</param>
        /// <returns>The number of rows affected</returns>
        int DeleteFosterAppointment(int fosterAppointmentID);
    }
}
