using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/11/2020
    /// Approver: Steven Cardona
    /// 
    /// This class is where I am calling the data access layer for Logs
    /// </summary>
    public class LogManager : ILogManager
    {
        private ILogAccessor _logAccessor;

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// No argument Constructor for LogManager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public LogManager()
        {
            try
            {
                _logAccessor = new LogAccessor();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This Constructor accesses the fake data for logs
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="logAccessor"></param>
        public LogManager(ILogAccessor logAccessor)
        {
            _logAccessor = logAccessor;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This method calls the logaccessor to get a list of logs
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>      
        /// <returns>List of Logs</returns>
        public List<LogItem> RetrieveLoginandOutLogs()
        {
            List<LogItem> logs = new List<LogItem>();
            try
            {
                logs = _logAccessor.GetLoginLogout();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return logs;
        }
    }
}
