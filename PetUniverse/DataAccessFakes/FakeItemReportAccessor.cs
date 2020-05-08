using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/07
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// Fake Accessor for Item Reports for damaged/missing items from the shelf.
    /// </summary>
    public class FakeItemReportAccessor : IItemReportAccessor
    {
        private List<ItemReport> _itemReport;
        private List<Item> _item;

        public FakeItemReportAccessor()
        {

            _item = new List<Item>()
            {
                new Item()
                {
                    ItemID = 10000,
                    ItemName = "Item A",
                    ItemCategoryID = "Cate A",
                    ItemQuantity = 100,
                    Active = true,
                    Description = "Desc for Item A"
                },
                new Item()
                {
                    ItemID = 20000,
                    ItemName = "Item B",
                    ItemCategoryID = "Cate B",
                    ItemQuantity = 100,
                    Active = true,
                    Description = "Desc for Item B"
                },
                new Item()
                {
                    ItemID = 30000,
                    ItemName = "Item C",
                    ItemCategoryID = "Cate C",
                    ItemQuantity = 100,
                    Active = true,
                    Description = "Desc for Item C"
                }
            };
            _itemReport = new List<ItemReport>()
            {
                new ItemReport()
                {
                    ItemID = 10000,
                    ItemName = "Item A",
                    Report = "Stolen from the store.",
                    Quantity = 10
                },
                new ItemReport()
                {
                    ItemID = 20000,
                    ItemName = "Item B",
                    Report = "Stolen from the store.",
                    Quantity = 10
                },
                new ItemReport()
                {
                    ItemID = 30000,
                    ItemName = "Item C",
                    Report = "Stolen from the store.",
                    Quantity = 10
                },
            };

        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method for adding a new item report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool addNewItemReport(ItemReport itemReport)
        {
            bool itemID = itemReport.ItemID.Equals(10000);
            bool report = itemReport.Report.Equals("Report Field: Test Create New Item Report");
            bool Quantity = itemReport.Quantity.Equals(10);
            bool itemName = itemReport.ItemName.Equals("Item A");
            if (itemID && report && Quantity && itemName)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Cannot add new Item Report.");
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method for getting all ItemReports.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<ItemReport> getAllItemReports()
        {

            _item = new List<Item>()
            {
                new Item()
                {
                    ItemID = 10000,
                    ItemName = "Item A",
                    ItemCategoryID = "Cate A",
                    ItemQuantity = 100,
                    Active = true,
                    Description = "Desc for Item A"
                },
                new Item()
                {
                    ItemID = 20000,
                    ItemName = "Item B",
                    ItemCategoryID = "Cate B",
                    ItemQuantity = 100,
                    Active = true,
                    Description = "Desc for Item B"
                },
                new Item()
                {
                    ItemID = 30000,
                    ItemName = "Item C",
                    ItemCategoryID = "Cate C",
                    ItemQuantity = 100,
                    Active = true,
                    Description = "Desc for Item C"
                }
            };
            _itemReport = new List<ItemReport>()
            {
                new ItemReport()
                {
                    ItemID = 10000,
                    ItemName = "Item A",
                    Report = "Stolen from the store.",
                    Quantity = 10
                },
                new ItemReport()
                {
                    ItemID = 20000,
                    ItemName = "Item B",
                    Report = "Stolen from the store.",
                    Quantity = 10
                },
                new ItemReport()
                {
                    ItemID = 30000,
                    ItemName = "Item C",
                    Report = "Stolen from the store.",
                    Quantity = 10
                },
            };

            return _itemReport;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method for removing an item report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int removeItemReport(int itemId, int itemQty, string report)
        {
            int rowsAffected = 0;

            ItemReport itemReport = new ItemReport();
            itemReport.ItemID = itemId;
            itemReport.Report = report;
            itemReport.ItemQuantity = itemQty;

            foreach (var rpt in _itemReport)
            {
                if (itemReport.ItemID == rpt.ItemID && itemReport.Report == rpt.Report && itemReport.ItemQuantity == rpt.ItemQuantity)
                {
                    try
                    {
                        _itemReport.Remove(rpt);
                        rowsAffected = 1;
                    }
                    catch
                    {
                        throw new ApplicationException();
                    }
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// method for updating an item report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int updateItemReport(int oldQty, string oldReport, int newQty, string newReport, int itemId)
        {
            int result = 0;

            oldQty = newQty;
            oldReport = newReport;

            if (oldQty == newQty && oldReport == newReport)
            {
                result = 1;
            }

            return result;
        }
    }
}
