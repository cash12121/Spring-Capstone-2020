using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 2/6/2020
    /// Approver: Alex Diers
    /// 
    /// This is a DataAccess class for TSQL it implements the IDepartmentAccessor
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class DepartmentAccessor : IDepartmentAccessor
    {
        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is a method for changing the active status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// <param name="departmentID"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public int UpdateDepartmentActive(string departmentID, bool active)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_department_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a method for inserting a department into the tsql database.
        /// </summary>
        /// <remarks>
        /// Updater: Alex Diers
        /// Updated: 5/5/2020
        /// Update: Added param and returns tags
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public int InsertDepartment(string departmentId, string description)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_department", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
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


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a method for selecting all departments from the tsql database.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<Department> SelectAllDepartments()
        {
            List<Department> departments = new List<Department>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_active_departments", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departments.Add(new Department
                        {
                            DepartmentID = reader.GetString(0),
                            Description = reader.IsDBNull(1) ? "" : reader.GetString(1)
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
            return departments;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method for selecting a department by id from the tsql database.
        /// </summary>
        /// <remarks>
        /// Updater: Alex Diers
        /// Updated: 5/5/2020
        /// Update: Added param and returns tags
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public Department SelectDepartmentByID(string departmentId)
        {
            Department department = null;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_department_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    department = new Department()
                    {
                        DepartmentID = reader.GetString(0),
                        Description = reader.IsDBNull(1) ? "" : reader.GetString(1)
                    };
                }
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
            return department;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method for updating a department in the tsql database.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// 
        /// <param name="oldDepartment"></param>
        /// <param name="newDepartment"></param>
        /// <returns></returns>
        public int UpdateDepartment(Department oldDepartment, Department newDepartment)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_department", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", oldDepartment.DepartmentID);
            cmd.Parameters.AddWithValue("@NewDescription", newDepartment.Description);

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
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method for deactivating a department in the tsql database.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<string> SelectDeactivatedDepartments()
        {
            List<string> departmentIDs = new List<string>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_deactivated_departments", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departmentIDs.Add(reader.GetString(0));
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
            return departmentIDs;
        }
    }
}


