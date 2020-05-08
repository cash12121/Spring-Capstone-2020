using DataAccessInterfaces;
using DataAccessLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/11/2020
    /// Approver: Michael Thompson
    /// 
    /// class for status Logic Layer Methods
    /// </summary>
    public class StatusManager : IStatusManager
    {

        IStatusAccessor _statusAccessor;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// no argument default constructor
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public StatusManager()
        {
            _statusAccessor = new StatusAccessor();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// full constructor used for testing
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public StatusManager(IStatusAccessor statusAccessor)
        {
            _statusAccessor = statusAccessor;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// Adds a status to the database
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public bool AddStatus(string statusID)
        {
            bool result = false;
            try
            {
                result = 1 == _statusAccessor.InsertStatus(statusID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Status not added.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// Retrieves all statuses from the data access layer
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public List<string> RetriveAllStatuses()
        {
            List<string> statuses = new List<string>();
            try
            {
                statuses = _statusAccessor.SelectAllStatuses();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Status not added.", ex);
            }
            return statuses;
        }
    }
}
