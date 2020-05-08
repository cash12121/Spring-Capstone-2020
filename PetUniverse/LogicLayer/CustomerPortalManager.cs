using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{

    /// <summary>
    /// CREATOR: Ethan Holmes
    /// DATE: 4/14/2020
    /// APPROVER: Rasha Mohammed 
    /// 
    /// Contains methods for handling the interaction between the data and the logic for
    /// Customer portal data.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public class CustomerPortalManager : IPoSCustomerPortalManager
    {

        private IPoSCustomerPortalAccessor _accessor;


        public CustomerPortalManager(IPoSCustomerPortalAccessor accessor)
        {
            _accessor = accessor;
        }


        public CustomerPortalManager()
        {
            _accessor = new PoSCustomerPortalAccessor();
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// This method will Insert a VolunteerTask Object into 
        /// the database.
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="taskDescription"></param>
        /// <param name="dueDate"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int ReportShippingError(string errorType, string errorDesc)
        {
            int rows = 0;

            try
            {

                rows = _accessor.ReportShippingError(errorType, errorDesc);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Insert Failed.", ex);
            }
            return rows;
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Logic for adding a credit card record.
        /// </summary>
        /// <param name="cardType"></param>
        /// <param name="cardNumber"></param>
        /// <param name="securityCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int AddCreditCard(string cardType, string cardNumber, string securityCode)
        {
            int rows = 0;

            try
            {

                rows = _accessor.AddCreditCard(cardType, cardNumber, securityCode);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Insert Failed.", ex);
            }
            return rows;
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Retrieves all credit card records.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public List<CreditCardVM2> GetAllCreditCards()
        {
            List<CreditCardVM2> results = new List<CreditCardVM2>();
            try
            {
                results = _accessor.GetAllCreditCards();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("No Data", ex);

            }
            return results;
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Deletes a credit card record.
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int DeleteCreditCard(string cardNumber)
        {
            int rows = 0;

            try
            {
                rows = _accessor.DeleteCreditCard(cardNumber);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Delete failed.", ex);
            }
            return rows;
        }

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 04/28/2020
        /// Approver: Rasha Mohammed
        /// 
        /// submits Survey record.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int InsertCustomerSurvey(string customerName, string serviceRating, string notes)
        {
            int rows = 0;

            try
            {

                rows = _accessor.InsertCustomerSurvey(customerName, serviceRating, notes);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Insert Failed.", ex);
            }
            return rows;
        }

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 04/28/2020
        /// Approver: Rasha Mohammed
        /// 
        /// submits Conflict record.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int InsertEmpCustProblem(string problemType, string name, string description)
        {
            int rows = 0;

            try
            {

                rows = _accessor.InsertEmpCustProblem(problemType, name, description);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Insert Failed.", ex);
            }
            return rows;
        }

    }
}
