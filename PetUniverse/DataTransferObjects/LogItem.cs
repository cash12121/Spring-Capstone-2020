using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Created: Zach Behrensmeyer
    /// Created: 2/11/20
    /// Approver: Steven Cardona
    /// 
    /// This class is where we create the properties of a LogItem
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class LogItem
    {
        public int LogID { get; set; }
        public DateTime LogDate { get; set; }
        public string LogThread { get; set; }
        public string LogLevel { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
