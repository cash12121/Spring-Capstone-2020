using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 3/2/2020
    /// Approver: Timothy Lickteig
    /// 
    /// Fake treatment record accessor class uses collection of treatment record objects, not database.
    /// </summary>
    public class FakeTreatmentRecordAccessor : ITreatmentRecordAccessor
    {
        private List<TreatmentRecord> treatmentRecords;

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// List of Treatment Records to use in tests instead of real data.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public FakeTreatmentRecordAccessor()
        {
            treatmentRecords = new List<TreatmentRecord>()
            {
                new TreatmentRecord()
                {
                    TreatmentRecordID = 1,
                    VetID = "vet10",
                    AnimalID = 3,
                    FormName = "Form Name",
                    TreatmentDate = DateTime.Now.Date,
                    TreatmentDescription = "This is a treatment description.",
                    Notes = "These are notes. Blah Blah.",
                    Reason = "Reason",
                    Urgency = 5
                },

                new TreatmentRecord()
                {
                    TreatmentRecordID = 2,
                    VetID = "vet200",
                    AnimalID = 4,
                    FormName = "Form Name 2",
                    TreatmentDate = DateTime.Now.Date,
                    TreatmentDescription = "This is another treatment description.",
                    Notes = "These are more notes. Blah Blah.",
                    Reason = "Another Reason",
                    Urgency = 3
                }
            };
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Fake to delete treatment record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecordID"></param>
        /// <returns></returns>
        public int DeleteTreatmentRecord(int treatmentRecordID)
        {
            return 1;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Fake to get a treatment record by name.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecordName"></param>
        /// <returns></returns>
        public TreatmentRecord GetTreatmentRecordByName(string treatmentRecordName)
        {
            TreatmentRecord _fakeReturnTreatmentRecord = new TreatmentRecord();

            if(treatmentRecordName != null && treatmentRecordName != "")
            {
                _fakeReturnTreatmentRecord.VetID = "Valid VetID";
                _fakeReturnTreatmentRecord.AnimalID = 3;
                _fakeReturnTreatmentRecord.FormName = "Valid Form Name";
                _fakeReturnTreatmentRecord.TreatmentDate = DateTime.Parse("03/13/2021");
                _fakeReturnTreatmentRecord.TreatmentDescription = "Valid Description";
                _fakeReturnTreatmentRecord.Notes = "Valid Notes";
                _fakeReturnTreatmentRecord.Reason = "Valid Reason";
                _fakeReturnTreatmentRecord.Urgency = 2;

                return _fakeReturnTreatmentRecord;
            }
            else
            {
                _fakeReturnTreatmentRecord.VetID = "Invalid VetID";
                _fakeReturnTreatmentRecord.AnimalID = 3;
                _fakeReturnTreatmentRecord.FormName = "Invalid Form Name";
                _fakeReturnTreatmentRecord.TreatmentDate = DateTime.Parse("03/13/2021");
                _fakeReturnTreatmentRecord.TreatmentDescription = "Invalid Description";
                _fakeReturnTreatmentRecord.Notes = "Invalid Notes";
                _fakeReturnTreatmentRecord.Reason = "Invalid Reason";
                _fakeReturnTreatmentRecord.Urgency = 2;

                return _fakeReturnTreatmentRecord;
            }
        }


        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Treatment Records to use in tests instead of real data.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecord"></param>
        /// <returns></returns>
        public int InsertTreatmentRecord(TreatmentRecord treatmentRecord)
        {
            try
            {
                treatmentRecords.Add(treatmentRecord);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// List of Treatment Records in fake data.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public List<TreatmentRecord> SelectTreatmentRecords()
        {
            try
            {
                treatmentRecords = new List<TreatmentRecord>();
                return treatmentRecords;
            }
            catch
            {
                treatmentRecords = null;
                return treatmentRecords;
            }
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Update a Treatment Record in fake data.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="newTreatmentRecord"></param>
        /// <param name="oldTreatmentRecord"></param>
        public int UpdateTreatmentRecord(TreatmentRecord oldTreatmentRecord, TreatmentRecord newTreatmentRecord)
        {
            int rows = 0;
            int index = 0;

            foreach (TreatmentRecord tmpTreatmentRecord in treatmentRecords)
            {
                if (tmpTreatmentRecord.TreatmentRecordID == oldTreatmentRecord.TreatmentRecordID)
                {
                    rows = 1;
                    break;
                }
                index++;
            }

            if (rows == 1)
            {
                treatmentRecords[index] = newTreatmentRecord;
            }
            return rows;
        }
    }
}
