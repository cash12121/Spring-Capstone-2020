using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/18/2020
    /// Approver: Thomas Dupuy 
    /// 
    /// This is a simple interface for methods that have to do with Appointment Type data accessor
    /// </summary>
    public interface IAppointmentTypeAccessor
    {
        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/18/2020
        /// Approver: Thomas Dupuy 
        /// 
        /// Selects all Appointment types
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        List<string> SelectAllAppointmentTypes();
    }
}