using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 3/2/2020
    /// Approver:
    /// 
    /// Interface for accessing treatment record data.
    /// </summary>
    public interface ITreatmentRecordAccessor
    {
        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// A data access method for creating a new treatment record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecord"></param>
        /// <returns></returns>
        int InsertTreatmentRecord(TreatmentRecord treatmentRecord);

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// A data access method for creating a new treatment record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        TreatmentRecord GetTreatmentRecordByName(string treatmentRecordName);

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// A data access method for creating a new treatment record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        List<TreatmentRecord> SelectTreatmentRecords();

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/3/2020
        /// Approver: 
        /// 
        /// A data access method for deleting a treatment record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecordID"></param>
        /// <returns></returns>
        int DeleteTreatmentRecord(int treatmentRecordID);

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/3/2020
        /// Approver: 
        /// 
        /// A data access method for updating a treatment record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="oldTreatmentRecord"></param>
        /// <param name="newTreatmentRecord"></param>
        /// <returns></returns>
        int UpdateTreatmentRecord(TreatmentRecord oldTreatmentRecord, TreatmentRecord newTreatmentRecord);
    }
}
