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
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// Logic layer for order line manager
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: Jesse Tomash
    /// Update:
    /// </remarks>
    public class OrderLineManager : IOrderLineManager
    {
        private IOrderLineAccessor _orderLineAccessor;


        public OrderLineManager()
        {
            _orderLineAccessor = new OrderLineAccessor();
        }

        public OrderLineManager(IOrderLineAccessor orderLineAccessor)
        {
            _orderLineAccessor = orderLineAccessor;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// selects order line by receiving record id
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: Jesse Tomash
        /// Update:
        /// </remarks>
        public List<OrderLine> RetrieveOrderLineByReceivingRecordID(int ReceivingRecordID)
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            try
            {
                orderLines = _orderLineAccessor.SelectOrderLineByReceivingRecordID(ReceivingRecordID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Order Lines not found");
            }

            return orderLines;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// updates order line
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int UpdateOrderLine(OrderLine oldOrderLine, OrderLine newOrderLine)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _orderLineAccessor.UpdateOrderLine(oldOrderLine, newOrderLine);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update Failed.");
            }

            return rowsAffected;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: 
        /// Approver:  
        ///
        /// method to select all orderlines
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

            try
            {
                orderLines = _orderLineAccessor.selectAllOrderLines();
            }
            catch (Exception)
            {

                throw new ApplicationException("OrderLines not found");
            }

            return orderLines;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: 
        /// Approver:  
        ///
        /// method to create orderlines
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool createOrderLine(OrderLine orderLine)
        {
            bool result = false;

            try
            {
                result = _orderLineAccessor.createOrderLine(orderLine);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: 
        /// Approver:  
        ///
        /// method to delete orderLines
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool deleteOrderLine(OrderLine orderLine)
        {
            bool result = false;

            try
            {
                result = _orderLineAccessor.deleteOrderLine(orderLine);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
