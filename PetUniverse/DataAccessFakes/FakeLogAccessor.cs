using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/11/2020
    /// Approver: Steven Cardona
    /// 
    /// This class is where we can pull fake LogItems from from
    /// </summary>
    public class FakeLogAccessor : ILogAccessor
    {
        private List<LogItem> logs;

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This fake method is called to get a fake LogItem
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>fake LogItem</returns>
        public FakeLogAccessor()
        {
            logs = new List<LogItem>()

            {
                new LogItem(){
                LogID = 1,
                LogDate = DateTime.Now,
                LogThread = "",
                LogLevel = "Info",
                Logger = "",
                Message = "Joe logged in",
                Exception = ""
                }
            };
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This fake method is called to get a fake list of logitems
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>Fake list of logs</returns>
        public List<LogItem> GetLoginLogout()
        {
            return (from l in logs select l).ToList();
        }
    }
}
