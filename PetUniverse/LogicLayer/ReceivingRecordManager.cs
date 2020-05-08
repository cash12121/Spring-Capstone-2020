using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessLayer;
using DataAccessInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: 
    /// Approver: 
    ///
    /// Manager for receiving record manager
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class ReceivingRecordManager : IReceivingRecordManager
    {
        private IReceivingRecordAccessor _receivingRecordAccessor;

        public ReceivingRecordManager()
        {
            _receivingRecordAccessor = new ReceivingRecordAccessor();
        }

        public ReceivingRecordManager(IReceivingRecordAccessor receivingRecordAccessor)
        {
            _receivingRecordAccessor = receivingRecordAccessor;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: 
        /// Approver: 
        ///
        /// selects all receiving records
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<ReceivingRecord> RetrieveAllReceivingRecords()
        {
            List<ReceivingRecord> receivingRecords = null;

            try
            {
                receivingRecords = _receivingRecordAccessor.SelectAllReceivingRecords();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Receiving Records not found");
            }

            return receivingRecords;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: 
        /// Approver: 
        ///
        /// selects all receiving records
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ReceivingRecord RetrieveReceivingRecordByOrderID(int OrderID)
        {
            ReceivingRecord receivingRecord = new ReceivingRecord();

            try
            {
                receivingRecord = _receivingRecordAccessor.SelectReceivingRecordbyOrderID(OrderID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Receiving Records not found");
            }

            return receivingRecord;
        }
    }
}
