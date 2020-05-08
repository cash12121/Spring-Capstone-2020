using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/17/2020
    /// Approver: Chase Schulte
    /// 
    /// Fake class for the BaseScheduleAccessor
    /// </summary>
    public class FakeBaseScheduleAccessor : IBaseScheduleAccessor
    {

        //Base Schedule object
        private static BaseScheduleVM _baseScheduleVM = new BaseScheduleVM()
        {
            Active = true,
            BaseScheduleID = 1000000,
            CreatingUserID = 100000,
            CreationDate = DateTime.Parse("2020-01-03"),
            BaseScheduleLines = _lines
        };

        //Line items for the Base Schedule
        private static List<BaseScheduleLine> _lines = new List<BaseScheduleLine>()
            {
                new BaseScheduleLine()
                {
                    BaseScheduleID = 1000000,
                    DepartmentID = "Management",
                    ERoleID = "Manager",
                    ShiftTimeID = 1000000,
                    Count = 1
                },

                new BaseScheduleLine()
                {
                    BaseScheduleID = 1000000,
                    DepartmentID = "Sales",
                    ERoleID = "Cashier",
                    ShiftTimeID = 1000004,
                    Count = 6
                }
            };

        private List<BaseSchedule> _baseSchedules = new List<BaseSchedule>()
        {
            _baseScheduleVM
        };

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: Chase Schulte
        /// 
        /// Fake insert
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Added if else block and result value to logic
        /// 
        /// </remarks>
        /// <param name="baseScheduleVM"></param>
        /// <returns></returns>
        public int InsertBaseScheduleVM(BaseScheduleVM baseScheduleVM)
        {
            int result = 0;
            if (baseScheduleVM != null)
            {
                _baseSchedules.Add(baseScheduleVM);
                result = 1;
            }
            else
            {
                throw new ApplicationException("Could not insert data");
            }
            return result;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver:
        /// 
        /// Fake Retrieve one
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        public BaseScheduleVM RetrieveActiveBaseSchedule()
        {
            return _baseScheduleVM;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver:
        /// 
        /// fake retrieve all
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        public List<BaseSchedule> RetrieveAllBaseSchedules()
        {
            return _baseSchedules;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: 
        /// 
        /// fake retrieve lines by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        public List<BaseScheduleLine> RetrieveBaseScheduleLinesByBaseScheduleID(int baseScheduleID)
        {
            return _lines;
        }
    }
}
