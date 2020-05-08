using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/30/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: 
    /// 
    /// This is the class for handling logic for Orders
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public class SpecialOrderManager : ISpecialOrderManager
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the instance of orderAccessor used in this class
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private ISpecialOrderAccessor _specialOrderAccessor;

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the default manager constructor that receives the fake orderaccessor
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public SpecialOrderManager()
        {
            _specialOrderAccessor = new SpecialOrderAccessor();
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the constructor that receives the real orderaccessor
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="orderAccessor"></param>
        public SpecialOrderManager(ISpecialOrderAccessor specialOrderAccessor)
        {
            _specialOrderAccessor = specialOrderAccessor;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the method that handles logic between SelectOrders() and the presentation
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        public IEnumerable<SpecialOrder> RetrieveSpecialOrders()
        {
            {
                IEnumerable<SpecialOrder> orders; ;

                try
                {
                    orders = _specialOrderAccessor.SelectSpecialOrders();
                }
                catch (Exception)
                {
                    throw;
                }

                return orders;
            }
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the method that handles logic between UpdateOrder() and the presentation
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="oldOrder"></param>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public bool EditSpecialOrder(SpecialOrder oldOrder, SpecialOrder newOrder)
        {
            bool result = false;

            try
            {
                result = (1 == _specialOrderAccessor.UpdateSpecialOrder(oldOrder, newOrder));
            }
            catch (Exception)
            {
                throw;
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
        /// This is the method that handles logic between InsertOrder() and the presentation
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public bool AddSpecialOrder(SpecialOrder newOrder)
        {
            bool result;

            try
            {
                result = (1 == _specialOrderAccessor.InsertSpecialOrder(newOrder));
            }
            catch (Exception)
            {
                throw;
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
        /// This is the method that handles logic between DeleteOrder() and the presentation
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public bool DeleteSpecialOrder(int specialOrderID)
        {
            bool result = true;
            try
            {
                result = (1 == _specialOrderAccessor.DeleteSpecialOrder(specialOrderID));
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
