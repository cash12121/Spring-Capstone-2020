using DataAccessInterfaces;
using DataAccessLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/18/2020
    /// CHECKED BY: 
    /// 
    /// Class that holds methods that interact with the Appointment type data access methods
    /// </summary>
    public class AppointmentTypeManager : IAppointmentTypeManager
    {
        IAppointmentTypeAccessor _appointmentTypeAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// the default constructor
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AppointmentTypeManager()
        {
            _appointmentTypeAccessor = new AppointmentTypeAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// constructor that is passed in a AppointmentTypeAccessor object, used for testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AppointmentTypeManager(IAppointmentTypeAccessor appointmentTypeAccessor)
        {
            _appointmentTypeAccessor = appointmentTypeAccessor;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// Gets data from the Retrieve all appointment types data access method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<string> RetrieveAllAppontmentTypes()
        {
            try
            {
                return _appointmentTypeAccessor.SelectAllAppointmentTypes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Appointment types not found", ex);
            }
        }
    }
}
