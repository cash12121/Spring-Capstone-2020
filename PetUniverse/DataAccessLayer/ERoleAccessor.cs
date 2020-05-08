using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Chase Schulte
    /// Created: 02/15/2020
    /// Approver: Kaleb Bachert
    ///
    /// Reads and writes to database by invoking eRole Stored Procedures
    /// Class for the creation of User Objects with set data fields
    public class ERoleAccessor : IERoleAccessor
    {

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/09/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Activate a role id in the database by invoking the "sp_activate_eRole" stored procedure
        /// </summary>
        ///
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int ActivateERole(string eRoleID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();
            //Cmd
            var cmd = new SqlCommand("sp_activate_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ERoleID", eRoleID);
            try
            {
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nonQueryResults;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/09/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Deactivate a role id in the database by invoking the "sp_deactivate_eRole" stored procedure
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int DeactivateERole(string eRoleID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();
            //Cmd
            var cmd = new SqlCommand("sp_deactivate_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ERoleID", eRoleID);
            try
            {
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nonQueryResults;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/09/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Delete a role in the database by invoking the "sp_delete_eRole" stored procedure
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int DeleteERole(string eRoleID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();
            //Cmd
            var cmd = new SqlCommand("sp_delete_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ERoleID", eRoleID);
            try
            {
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nonQueryResults;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Insert a role the database by invoking the "sp_delete_eRole" stored procedure
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <param name="DepartmentID"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public int InsertERole(ERole eRole)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_insert_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Param
            cmd.Parameters.AddWithValue("@ERoleID", eRole.ERoleID);
            cmd.Parameters.AddWithValue("@DepartmentID", eRole.DepartmentID);
            cmd.Parameters.AddWithValue("@Description", eRole.Description);

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
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Method grabs all eRoles
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// 
        /// <returns></returns>
        public List<ERole> SelectAllERoles()
        {
            //Conn
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_eRoles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            List<ERole> eRoles = new List<ERole>();
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                //Reader
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eRoles.Add(new ERole()
                        {
                            ERoleID = reader.GetString(0),
                            DepartmentID = reader.GetString(1),
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            EActive = reader.GetBoolean(3)
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

            return eRoles;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/16/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Method grabs all eRoles by active state
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns></returns>
        public List<ERole> SelectAllERolesByActive(bool active = true)
        {
            //Conn
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_active_eRoles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Active", active);
            List<ERole> eRoles = new List<ERole>();
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                //Reader
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eRoles.Add(new ERole()
                        {
                            ERoleID = reader.GetString(0),
                            DepartmentID = reader.GetString(1),
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            EActive = reader.GetBoolean(3)
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
            return eRoles;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/16/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Method grabs a eRole and allows it to be modified
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="oldERole"></param>
        /// <param name="newERole"></param>
        /// <returns></returns>
        public int UpdateERole(ERole oldERole, ERole newERole)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_update_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Vals
            cmd.Parameters.AddWithValue("OldERoleID", oldERole.ERoleID);
            cmd.Parameters.AddWithValue("OldDepartmentID", oldERole.DepartmentID);
            cmd.Parameters.AddWithValue("OldDescription", oldERole.Description);

            cmd.Parameters.AddWithValue("NewDepartmentID", newERole.DepartmentID);
            cmd.Parameters.AddWithValue("NewDescription", newERole.Description);

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
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a data transfer object for BaseScheduleLine.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public List<ERole> SelectAllERolesByDepartment(string departmentID)
        {
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_erole_by_departmentid", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
            List<ERole> eRoles = new List<ERole>();
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eRoles.Add(new ERole()
                        {
                            ERoleID = reader.GetString(0),
                            Description = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            EActive = reader.GetBoolean(2),
                            DepartmentID = departmentID,
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
            return eRoles;
        }

    }
}
