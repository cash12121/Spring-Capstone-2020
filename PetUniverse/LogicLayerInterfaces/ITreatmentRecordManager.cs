using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 3/2/2020
    /// Approver:
    /// 
    /// Interface for the treatment record manager.
    /// </summary>
    public interface ITreatmentRecordManager
    {
        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Interface to add a new treatment record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecord"></param>
        /// <returns>true or false depending on if the treatment record was added</returns>
        bool AddNewTreatmentRecord(TreatmentRecord treatmentRecord);

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Return a treatment record object.
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
        /// Return a list of treatment record objects.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        List<TreatmentRecord> RetrieveTreatmentRecords();

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Interface to delete a new treatment record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="aTreatmentRecordID"></param>
        /// <returns>true or false depending on if the treatment record was deleted</returns>
        int DeleteTreatmentRecord(int treatmentRecordID);

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Interface to edit an existing treatment record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="oldTreatmentRecord"></param>
        /// <param name="newTreatmentRecord"></param>
        int EditTreatmentRecord(TreatmentRecord oldTreatmentRecord, TreatmentRecord newTreatmentRecord);
    }
}
