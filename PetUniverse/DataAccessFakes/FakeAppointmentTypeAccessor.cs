using DataAccessInterfaces;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/18/2020
    /// Approver: Mohammed Elamin
    /// 
    /// Fakes for testing Appointment type manager class
    /// </summary>
    public class FakeAppointmentTypeAccessor : IAppointmentTypeAccessor
    {

        List<string> _appointmentTypes;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/18/2020
        /// Approver: Mohammed Elamin
        /// 
        /// the default constructor for this class
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public FakeAppointmentTypeAccessor()
        {
            _appointmentTypes = new List<string>()
            {
                "In Home Inspection",
                "Meet and Greet",
                "Interview"
            };
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/18/2020
        /// Approver: Mohammed Elamin
        /// 
        /// A fake get all appointments method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<string> SelectAllAppointmentTypes()
        {
            return _appointmentTypes;
        }
    }
}
