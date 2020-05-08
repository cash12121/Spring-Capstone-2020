using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 3/2/2020
    /// Approver: Timothy Lickteig
    /// 
    /// Class for the treatment record manager.
    /// </summary>
    public class TreatmentRecordManager : ITreatmentRecordManager
    {
        private ITreatmentRecordAccessor _treatmentRecordAccessor;

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Constructor for volunteer manager to access real data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public TreatmentRecordManager()
        {
            _treatmentRecordAccessor = new TreatmentRecordAccessor();
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Constructor for volunteer manager to the fake data object.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecordAccessor"></param>
        /// <returns></returns>
        public TreatmentRecordManager(ITreatmentRecordAccessor treatmentRecordAccessor)
        {
            _treatmentRecordAccessor = treatmentRecordAccessor;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Logic method passes a treatment record object to the accessor method
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecord"></param>
        /// <returns></returns>
        public bool AddNewTreatmentRecord(TreatmentRecord treatmentRecord)
        {
            bool result = true;

            try
            {
                result = _treatmentRecordAccessor.InsertTreatmentRecord(treatmentRecord) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Treatment record not added.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Logic method deletes a treatment record object from the accessor method
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecord"></param>
        /// <returns></returns>
        public int DeleteTreatmentRecord(int treatmentRecordID)
        {
            int rows = 0;
            try
            {
                rows = _treatmentRecordAccessor.DeleteTreatmentRecord(treatmentRecordID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Treatment record not removed!", ex);
            }
            return rows;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Logic method edits a treatment record object from the accessor method
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="oldTreatmentRecord"></param>
        /// <param name="newTreatmentRecord"></param>
        /// <returns></returns>
        public int EditTreatmentRecord(TreatmentRecord oldTreatmentRecord, TreatmentRecord newTreatmentRecord)
        {
            int rows = 0;
            try
            {
                rows = _treatmentRecordAccessor.UpdateTreatmentRecord(oldTreatmentRecord, newTreatmentRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rows;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Logic method that uses a TreatmentRecordAccessor method to get a treatment record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public TreatmentRecord GetTreatmentRecordByName(string treatmentRecordName)
        {
            TreatmentRecord result = null;
            try
            {
                result = _treatmentRecordAccessor.GetTreatmentRecordByName(treatmentRecordName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Logic method that uses a TreatmentRecordAccessor method to get a list of treatment records.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public List<TreatmentRecord> RetrieveTreatmentRecords()
        {
            try
            {
                return _treatmentRecordAccessor.SelectTreatmentRecords();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data was not found.", ex);
            }
        }
    }
}
