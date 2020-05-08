using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{

    /// <summary>
    /// CREATOR: Ethan Holmes
    /// DATE: 4/14/2020
    /// APPROVER: Rasha Mohammed 
    /// 
    /// Class contains methods for handling customer portal data.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public class PoSCustomerPortalAccessor : IPoSCustomerPortalAccessor
    {

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Inserts a credit card record.
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



            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_credit_card", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CardType", cardType);
            cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
            cmd.Parameters.AddWithValue("@SecurityCode", securityCode);




            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }


        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Deletes a Credit Card record.
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

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_credit_card", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CardNumber", cardNumber);


            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// This will return a list of all Credit Cards.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public List<CreditCardVM2> GetAllCreditCards()
        {
            List<CreditCardVM2> creditCards = new List<CreditCardVM2>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_all_credit_cards", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        creditCards.Add(new CreditCardVM2()
                        {
                            CardType = reader.GetString(0),
                            CardNumber = reader.GetString(1)

                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return creditCards;
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// This will insert a shipping error record into the DB.
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="errorDesc"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int ReportShippingError(string errorType, string errorDesc)
        {
            int rows = 0;



            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_customer_error", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ErrorType", errorType);
            cmd.Parameters.AddWithValue("@Description", errorDesc);




            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
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



            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_customer_survey", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerName", customerName);
            cmd.Parameters.AddWithValue("@ServiceRating", serviceRating);
            cmd.Parameters.AddWithValue("@Notes", notes);




            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
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



            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_emp_cust_problem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@ProblemType", problemType);
            cmd.Parameters.AddWithValue("@Description", description);




            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

    }
}
