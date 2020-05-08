using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/11/2020
    /// Approver: Michael Thompson
    /// 
    /// Interface for insert animal status method
    /// </summary>
    public class AnimalStatusAccessor : IAnimalStatusAccessor
    {
        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// deletes an animal status from the database
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        public int DeleteAnimalStatus(int animalID, string statusID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_animal_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@animalID", animalID);
            cmd.Parameters.AddWithValue("@StatusID", statusID);
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
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// Inserts an Animal Status into the database
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        public int InsertAnimalStatus(int animalID, string statusID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_animal_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@animalID", animalID);
            cmd.Parameters.AddWithValue("@StatusID", statusID);
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
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// Selects an animal status from the database by Animal ID.
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public List<string> SelectAnimalStatusesByAnimalID(int animalID)
        {
            List<string> statuses = new List<string>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_animal_status_ids_by_animal_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", animalID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string status = reader.GetString(0);
                        statuses.Add(status);
                    }

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
            return statuses;
        }
    }
}
