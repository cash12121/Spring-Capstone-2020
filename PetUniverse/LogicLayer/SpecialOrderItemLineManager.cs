using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 4/26/2020
    /// 
    /// Approver: Brandyn T. Coverdill
    /// 
    /// This is the class for handling logic for orderitem lines
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public class SpecialOrderItemLineManager : ISpecialOrderItemLineManager
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// This is the instance of orderAccessor used in this class
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private ISpecialOrderItemLineAccessor _orderItemLineAccessor;

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// This is the default manager constructor that receives the fake orderaccessor
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public SpecialOrderItemLineManager()
        {
            _orderItemLineAccessor = new SpecialOrderItemLineAccessor();
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// This is the constructor that receives the real orderaccessor
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="orderAccessor"></param>
        public SpecialOrderItemLineManager(ISpecialOrderItemLineAccessor orderItemLineAccessor)
        {
            _orderItemLineAccessor = orderItemLineAccessor;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// This is the method that handles logic between InsertOrderitemline() and the presentation
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="newLine"></param>
        /// <returns></returns>
        public bool AddSpecialOrderItemLine(SpecialOrderItemLine newLine)
        {
            bool result;

            try
            {
                result = _orderItemLineAccessor.InsertSpecialOrderItemLine(newLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// This is the method that handles logic between selectorderitemlines() and the presentation
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public IEnumerable<SpecialOrderItemLine> SelectSpecialOrderItemLinesByOrderID(int orderID)
        {
            IEnumerable<SpecialOrderItemLine> lines;
            try
            {
                lines = _orderItemLineAccessor.SelectSpecialOrderItemLinesByOrderID(orderID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lines;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// This is the method that handles logic between deleteorderline() and the presentation
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public bool DeleteSpecialOrderItemLineByItemID(int itemID)
        {
            bool result;
            try
            {
                result = _orderItemLineAccessor.DeleteSpecialOrderItemLineByItemID(itemID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
