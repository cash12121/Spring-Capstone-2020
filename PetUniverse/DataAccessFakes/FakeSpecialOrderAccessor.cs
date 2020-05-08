using DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE:3/30/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: 
    /// 
    /// Fake Order class for testing
    /// </summary>
    public class FakeSpecialOrderAccessor
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is a list of orders
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private List<SpecialOrder> specialOrders;

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This method returns a fake list of Ordersfor testing
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <returns>
        /// IEnumerable<OrderInvoice> The list of Order Invoices
        /// </returns>
        public IEnumerable<SpecialOrder> SelectSpecialOrders()
        {
            specialOrders = new List<SpecialOrder>() {
                new SpecialOrder()
                {
                    SpecialOrderID = 1,
                    UserID = 244
                }
            };
            return (IEnumerable<SpecialOrder>)specialOrders;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the method used to test updating the fake orders 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="oldOrderInvoice">The old invoice to be changed</param>
        /// <param name="newOrderInvoice">The invoice with the new values</param>
        /// <returns></returns>
        public int UpdateSpecialOrder(SpecialOrder oldOrder, SpecialOrder newOrder)
        {
            int result = 0;

            if (!oldOrder.Equals(newOrder))
            {
                oldOrder.SpecialOrderID = newOrder.SpecialOrderID;
                oldOrder.UserID = newOrder.UserID;
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the method used to test inserting a new order to the list
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="newOrderInvoice">The new invoice to be added</param>
        /// <returns></returns>
        public int InsertSpecialOrder(SpecialOrder newOrder)
        {
            int result = 0;
            FakeSpecialOrderAccessor fakeOrderAccessor = new FakeSpecialOrderAccessor();
            IEnumerable<SpecialOrder> orders = fakeOrderAccessor.SelectSpecialOrders();
            List<SpecialOrder> invoiceList = orders.ToList();
            if (!invoiceList.Contains(newOrder))
            {
                invoiceList.Add(newOrder);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the method used to test deleting an order from the list 
        /// </summary>
        /// <param name="orderInvoiceID">The ID of the invoice to be deleted</param>
        /// <returns></returns>
        public int DeleteSpecialOrder(int specialOrderID)
        {
            int result = 0;
            FakeSpecialOrderAccessor fakeOrderAccessor = new FakeSpecialOrderAccessor();
            IEnumerable<SpecialOrder> orders = fakeOrderAccessor.SelectSpecialOrders();
            List<SpecialOrder> invoiceList = orders.ToList();

            foreach (SpecialOrder order in orders)
            {
                if (order.SpecialOrderID.Equals(specialOrderID))
                {
                    invoiceList.Remove(order);
                    result = 1;
                }
            }

            return result;
        }
    }
}
