using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 4/26/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// 
    /// The Interface for the orderitemlinemanager Class
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public interface ISpecialOrderItemLineManager
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// The interface method for the method to add an orderitemline
        /// </summary>
        /// <param name="newLine"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        bool AddSpecialOrderItemLine(SpecialOrderItemLine newLine);

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// The interface method for the method to delete an orderitemline
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        bool DeleteSpecialOrderItemLineByItemID(int itemID);
    }
}
