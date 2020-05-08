using DataAccessInterfaces;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/12/2020
    /// Approver: Michael Thompson
    /// 
    /// Status Data Access fake used for testing purposes
    /// </summary>
    public class FakeStatusAccessor : IStatusAccessor
    {
        private List<string> _statuses;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Constructor for the fake accessor, creates a list of 
        /// Statuses for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public FakeStatusAccessor()
        {
            _statuses = new List<string>()
            {
                "Sick",
                "Dead",
                "Emaciated",
                "Paper Trained"
            };
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Adds a StatusID to the statuses list
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int InsertStatus(string StatusID)
        {
            int rows = 0;
            try
            {
                _statuses.Add(StatusID);
                rows = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// selects all the statuses from the list
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public List<string> SelectAllStatuses()
        {
            return _statuses;
        }
    }
}
