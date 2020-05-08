using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator : Zach Behrensmeyer
    /// Created: 2/3/2020
    /// Approver: Steven Cardona
    /// 
    /// This is the interface for LogManager
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This calls the LogItem Authentication Data Accessor Method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>List of Logs</returns>
        List<LogItem> RetrieveLoginandOutLogs();
    }
}
