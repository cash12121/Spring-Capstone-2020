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
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// fake data access layer for order line
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class FakeOrderLineAccessor : IOrderLineAccessor
    {
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// fake to create orderLine
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool createOrderLine(OrderLine orderLine)
        {
            bool orderLineID = orderLine.OrderLineID.Equals(100000);
            bool receivingRecordID = orderLine.ReceivingRecordID.Equals(100000);
            bool ItemID = orderLine.ItemID.Equals(100000);
            bool MissingItemQuantity = orderLine.MissingItemQuantity.Equals(10);
            bool DamagedItemQuantity = orderLine.DamagedItemQuantity.Equals(10);

            if (orderLineID && receivingRecordID && ItemID && MissingItemQuantity && DamagedItemQuantity)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Cannot add new orderLine.");
            }
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// fake for deleteing orderline
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool deleteOrderLine(OrderLine testOrderLine)
        {
            bool result = false;
            OrderLine orderLine = new OrderLine();
            orderLine.OrderLineID = 100000;
            orderLine.ReceivingRecordID = 100000;
            orderLine.ItemID = 100000;
            orderLine.MissingItemQuantity = 10;
            orderLine.DamagedItemQuantity = 10;

            if (orderLine.OrderLineID == testOrderLine.OrderLineID &&
            orderLine.ReceivingRecordID == testOrderLine.ReceivingRecordID &&
            orderLine.ItemID == testOrderLine.ItemID &&
            orderLine.MissingItemQuantity == testOrderLine.MissingItemQuantity &&
            orderLine.DamagedItemQuantity == testOrderLine.DamagedItemQuantity)
            {
                testOrderLine = null;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// fake for selecting all orderLines
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<OrderLine> selectAllOrderLines()
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            OrderLine orderLine = new OrderLine();

            orderLine.OrderLineID = 100000;
            orderLine.ReceivingRecordID = 100000;
            orderLine.ItemID = 100000;
            orderLine.MissingItemQuantity = 10;
            orderLine.DamagedItemQuantity = 10;
            orderLines.Add(orderLine);

            orderLine.OrderLineID = 100001;
            orderLine.ReceivingRecordID = 100000;
            orderLine.ItemID = 100001;
            orderLine.MissingItemQuantity = 11;
            orderLine.DamagedItemQuantity = 11;
            orderLines.Add(orderLine);

            return orderLines;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// fake for selecting order line by receiving record id
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<OrderLine> SelectOrderLineByReceivingRecordID(int ReceivingRecordID)
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            OrderLine orderLine = new OrderLine();

            orderLine.OrderLineID = 100000;
            orderLine.ReceivingRecordID = 100000;
            orderLine.ItemID = 100000;
            orderLine.MissingItemQuantity = 10;
            orderLine.DamagedItemQuantity = 10;
            orderLines.Add(orderLine);

            orderLine.OrderLineID = 100001;
            orderLine.ReceivingRecordID = 100000;
            orderLine.ItemID = 100001;
            orderLine.MissingItemQuantity = 11;
            orderLine.DamagedItemQuantity = 11;
            orderLines.Add(orderLine);

            return orderLines;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// fake for updating order line
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int UpdateOrderLine(OrderLine oldOrderLine, OrderLine newOrderLine)
        {
            int result = 0;

            try
            {
                oldOrderLine = newOrderLine;
            }
            catch (Exception)
            {

                throw;
            }

            if (oldOrderLine == newOrderLine)
            {
                result = 1;
            }

            return result;
        }

    }
}
