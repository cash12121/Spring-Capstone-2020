using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020-04-14
    /// Approver: Ethan Holmes
    ///
    /// Data access fakes for transaction admin.
    /// </summary>
    public class FakeTransactionAdminAccessor : ITransactionAdminAccessor
    {

        private List<TransactionType> _transactionTypes;
        private List<TransactionStatus> _transactionStatuses;

        public FakeTransactionAdminAccessor()
        {
            _transactionTypes = new List<TransactionType>()
            {
                new TransactionType()
                {
                    TransactionTypeID = "FAKEID1",
                    Description = "FakeDesc1",
                    DefaultInStore = true
                },
                new TransactionType()
                {
                    TransactionTypeID = "FAKEID2",
                    Description = "FakeDesc2",
                    DefaultInStore = false
                }
            };

            _transactionStatuses = new List<TransactionStatus>()
            {
                new TransactionStatus()
                {
                    TransactionStatusID = "FAKESTATUSID1",
                    Description = "FakeDesc1",
                    DefaultInStore = true
                },
                new TransactionStatus()
                {
                    TransactionStatusID = "FAKESTATUSID2",
                    Description = "FakeDesc2",
                    DefaultInStore = false
                }
            };
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Fake delete Transaction status.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionStatusID"></param>
        /// <returns>int</returns>
        public int DeleteTransactionStatus(string transactionStatusID)
        {
            int rows = 0;
            TransactionStatus tempTransactionStatus = new TransactionStatus();

            foreach (TransactionStatus transactionStatus in _transactionStatuses)
            {
                if (transactionStatus.TransactionStatusID == transactionStatusID)
                {
                    tempTransactionStatus = transactionStatus;
                    rows++;
                }
            }

            _transactionStatuses.Remove(tempTransactionStatus);

            return rows;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Fake delete Transaction type.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionTypeID"></param>
        /// <returns>int</returns>
        public int DeleteTransactionType(string transactionTypeID)
        {
            int rows = 0;
            TransactionType tempTransactionType = new TransactionType();

            foreach (TransactionType transactionType in _transactionTypes)
            {
                if (transactionType.TransactionTypeID == transactionTypeID)
                {
                    tempTransactionType = transactionType;
                    rows++;
                }
            }

            _transactionTypes.Remove(tempTransactionType);

            return rows;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Fake Insert Transaction STATUS.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionStatus"></param>
        public int InsertTransactionStatus(TransactionStatus transactionStatus)
        {
            int result = 0;
            FakeTransactionAdminAccessor fakeTransactionAdminAccessor = new FakeTransactionAdminAccessor();
            List<TransactionStatus> transactionStatuses = _transactionStatuses;

            if (!transactionStatuses.Contains(transactionStatus))
            {
                transactionStatuses.Add(transactionStatus);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Fake Insert Transaction TYPE.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionType"></param>
        public int InsertTransactionType(TransactionType transactionType)
        {
            int result = 0;
            FakeTransactionAdminAccessor fakeTransactionAdminAccessor = new FakeTransactionAdminAccessor();
            List<TransactionType> transactionTypes = _transactionTypes;

            if (!transactionTypes.Contains(transactionType))
            {
                transactionTypes.Add(transactionType);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Fake update Transaction STATUS.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="newTransactionStatus"></param>
        /// <param name="oldTransactionStatus"></param>
        /// <returns>int</returns>
        public int UpdateTransactionStatus(TransactionStatus oldTransactionStatus, TransactionStatus newTransactionStatus)
        {
            int rows = 0;

            foreach (TransactionStatus transactionStatus in _transactionStatuses)
            {
                if (transactionStatus.TransactionStatusID == oldTransactionStatus.TransactionStatusID &&
                    transactionStatus.Description == oldTransactionStatus.Description &&
                    transactionStatus.DefaultInStore == oldTransactionStatus.DefaultInStore)
                {
                    transactionStatus.TransactionStatusID = newTransactionStatus.TransactionStatusID;
                    transactionStatus.Description = newTransactionStatus.Description;
                    transactionStatus.DefaultInStore = newTransactionStatus.DefaultInStore;

                    rows++;
                }
            }
            return rows;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Fake Update Transaction type.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="oldTransactionType"></param>
        /// <param name="newTransactionType"></param>
        /// <returns>int</returns>
        public int UpdateTransactionType(TransactionType oldTransactionType, TransactionType newTransactionType)
        {
            int rows = 0;

            foreach (TransactionType transactionType in _transactionTypes)
            {
                if (transactionType.TransactionTypeID == oldTransactionType.TransactionTypeID &&
                    transactionType.Description == oldTransactionType.Description &&
                    transactionType.DefaultInStore == oldTransactionType.DefaultInStore)
                {
                    transactionType.TransactionTypeID = newTransactionType.TransactionTypeID;
                    transactionType.Description = newTransactionType.Description;
                    transactionType.DefaultInStore = newTransactionType.DefaultInStore;

                    rows++;
                }
            }
            return rows;
        }
    }
}
