using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/11/2020
    /// Approver: Michael Thompson
    /// 
    /// class for status interafaces
    /// </summary>
    public interface IStatusAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// interface for inserting a status
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        int InsertStatus(string StatusID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// selects all statuses from the database
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        List<string> SelectAllStatuses();
    }
}