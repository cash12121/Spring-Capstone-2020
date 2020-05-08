using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/15
///  APPROVER: Lane Sandburg
///  
///  Fake ActiveTimeOff Accessor Class for Unit Testing
/// </summary>
namespace DataAccessFakes
{
    public class FakeActiveTimeOffAccessor : IActiveTimeOffAccessor
    {
        private List<ActiveTimeOff> activeTimeOffs;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Fake ActiveTimeOff Accessor Constructor, generates dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public FakeActiveTimeOffAccessor()
        {
            activeTimeOffs = new List<ActiveTimeOff>()
            {
                new ActiveTimeOff()
                {
                    UserID = 100000,
                    EndDate = new DateTime(2020, 4, 22),
                    StartDate = new DateTime(2020, 4, 22)
                },
                new ActiveTimeOff()
                {
                    UserID = 100001,
                    EndDate = new DateTime(2020, 4, 27),
                    StartDate = new DateTime(2020, 4, 25)
                },
                new ActiveTimeOff()
                {
                    UserID = 100002,
                    EndDate = new DateTime(2020, 4, 29),
                    StartDate = new DateTime(2020, 4, 28)
                }
            };
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that retrieves all the dummy ActiveTimeOffs, for testing
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<ActiveTimeOff> SelectAllUsersActiveTimeOff()
        {
            return activeTimeOffs;
        }
    }
}