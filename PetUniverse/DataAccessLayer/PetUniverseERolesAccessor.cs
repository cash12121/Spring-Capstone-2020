using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class PetUniverseERolesAccessor : IPetUniverseUserERolesAccessor
    {
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: 
        /// 
        /// This Method is deletes a user's ERole
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int DeletePetUniverseUserERole(int userID, string eRoleID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_delete_user_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Param
            cmd.Parameters.AddWithValue("@ERoleID", eRoleID);
            cmd.Parameters.AddWithValue("@UserID", userID);

            //Execute Command
            try
            {
                //Open conn
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return nonQueryResults;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: 
        /// 
        /// This Method is inserts a user's ERole
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int InsertPetUniverseUserERole(int userID, string eRoleID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_insert_user_eERole", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Param
            cmd.Parameters.AddWithValue("@ERoleID", eRoleID);
            cmd.Parameters.AddWithValue("@UserID", userID);

            //Execute Command
            try
            {
                //Open conn
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return nonQueryResults;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: 
        /// 
        /// This Method is selects a user's ERoles by userID
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        public List<string> SelectPetUniverseUserERoleByPetUniverseUser(int userID)
        {
            List<string> eRoles = new List<string>();
            var conn = DBConnection.GetConnection();
            //Cmd
            var cmd = new SqlCommand("sp_select_user_eRole_by_user_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                //Open conn
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eRoles.Add(reader.GetString(0));
                    }
                }
                //Reader no longer needed
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return eRoles;
        }
    }
}
