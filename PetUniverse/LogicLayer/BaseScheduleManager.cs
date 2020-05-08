using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/15/2020
    /// Approver: Chase Schulte
    /// 
    /// BaseSchedule Manager class
    /// </summary>
    public class BaseScheduleManager : IBaseScheduleManager
    {
        private IBaseScheduleAccessor _baseScheduleAccessor;

        public BaseScheduleManager()
        {
            _baseScheduleAccessor = new BaseScheduleAccessor();
        }

        public BaseScheduleManager(IBaseScheduleAccessor baseScheduleAccessor)
        {
            _baseScheduleAccessor = baseScheduleAccessor;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3//2020
        /// Approver: Chase Schulte
        /// 
        /// Inserts a base scchedule and deacitveats the old schedule
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="baseScheduleVM"></param>
        /// <returns></returns>
        public int AddBaseSchedule(BaseScheduleVM baseScheduleVM)
        {
            int result = 0;
            bool goodCount = true;
            foreach (BaseScheduleLine line in baseScheduleVM.BaseScheduleLines)
            {
                if (goodCount && line.Count < 0)
                {
                    goodCount = false;
                }
            }

            try
            {
                if (goodCount)
                {
                    result = _baseScheduleAccessor.InsertBaseScheduleVM(baseScheduleVM);
                }
                else
                {
                    throw new ApplicationException("A count entered is invalid");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Base Schedule not added.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Gets the active base schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns></returns>
        public BaseScheduleVM GetActiveBaseSchedule()
        {
            try
            {
                return _baseScheduleAccessor.RetrieveActiveBaseSchedule();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Couldn't retrieve data.", ex);
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Gets all base schedules
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns></returns>
        public List<BaseSchedule> GetAllBaseSchedules()
        {
            try
            {
                return _baseScheduleAccessor.RetrieveAllBaseSchedules();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Couldn't retrieve data.", ex);
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Gets all base schedule lines by base scheduleid
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="baseScheduleID"></param>
        /// <returns></returns>
        public List<BaseScheduleLine> GetBaseScheduleLinesByBaseScheduleID(int baseScheduleID)
        {
            try
            {
                return _baseScheduleAccessor.RetrieveBaseScheduleLinesByBaseScheduleID(baseScheduleID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Couldn't retrieve data.", ex);
            }
        }
    }
}
