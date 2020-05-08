using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/23
    /// Approver: 
    /// Approver: 
    ///
    /// Fake data accessor for receivingRecords
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class FakeReceivingRecordAccessor : IReceivingRecordAccessor
    {
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/23
        /// Approver: 
        /// Approver: 
        ///
        /// Method for selecting all receivingRecords
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<ReceivingRecord> SelectAllReceivingRecords()
        {
            List<ReceivingRecord> receivingRecordList = new List<ReceivingRecord>()
            {
                new ReceivingRecord
                {
                    ReceivingRecordID = 100000,
                    OrderID = 100000,
                    ShipperID = "100000",
                    ReceivingOrderDate = DateTime.Now
                 },

                new ReceivingRecord
                {
                    ReceivingRecordID = 100000,
                    OrderID = 100000,
                    ShipperID = "100000",
                    ReceivingOrderDate = DateTime.Now
                },

                new ReceivingRecord
                {
                    ReceivingRecordID = 100000,
                    OrderID = 100000,
                    ShipperID = "100000",
                    ReceivingOrderDate = DateTime.Now
                }
            };

            return receivingRecordList;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/23
        /// Approver: 
        /// Approver: 
        ///
        /// Method for selecting all receivingRecords matching the given orderID
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ReceivingRecord SelectReceivingRecordbyOrderID(int OrderID)
        {
            ReceivingRecord receivingRecord = new ReceivingRecord();
            List<ReceivingRecord> receivingRecordList = new List<ReceivingRecord>();
            List<ReceivingRecord> filteredReceivingRecordList = new List<ReceivingRecord>();


            // ReceivingRecords to filter out
            for (int i = 0; i < 4; i++)
            {
                receivingRecord.OrderID = 100001;
                receivingRecord.ShipperID = "100000";
                receivingRecord.ReceivingRecordID = 100000;
                receivingRecord.ReceivingOrderDate = DateTime.Now;
                receivingRecordList.Add(receivingRecord);
            }

            // ReceivingRecord to select
            receivingRecord.OrderID = 100000;
            receivingRecord.ShipperID = "100000";
            receivingRecord.ReceivingRecordID = 100000;
            receivingRecord.ReceivingOrderDate = DateTime.Now;
            receivingRecordList.Add(receivingRecord);

            // Filter
            var results = from ReceivingRecord in receivingRecordList
                          where receivingRecord.OrderID == 100000
                          select receivingRecord;

            // Add matching ReceivingRecords to new list 
            foreach (ReceivingRecord i in results)
            {
                filteredReceivingRecordList.Add(i);
            }

            return filteredReceivingRecordList[0];
        }
    }
}
