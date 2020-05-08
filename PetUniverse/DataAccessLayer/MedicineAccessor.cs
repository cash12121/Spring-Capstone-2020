using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig    
    ///     DATE: 2020-02-09
    ///     CHECKED BY: Zoey McDonald
    ///     Class for accessing medicine records
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class MedicineAccessor : IMedicineAccessor
    {
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicineID">The ID of the Medicine to delete</param>
        /// <returns>The number of rows affected</returns>
        public int DeleteMedicine(int medicineID)
        {
            //Declare variables
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_medicine");
            int rows = 0;

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Add parameters
            cmd.Parameters.AddWithValue("@MedicineID", medicineID);

            //Try to execute the query
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
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicine">The medicine to enter</param>
        /// <returns>The number of rows affected</returns>
        public int InsertMedicine(Medicine medicine)
        {
            //Declare variables
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_medicine");
            int rows = 0;

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Add parameters
            cmd.Parameters.AddWithValue("@MedicineName", medicine.MedicineName);
            cmd.Parameters.AddWithValue("@MedicineDosage", medicine.MedicineDosage);
            cmd.Parameters.AddWithValue("@MedicineDescription", medicine.MedicineDescription);

            //Try to execute the query
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

        public List<Medicine> SelectAllMedicines()
        {
            //Declare variables
            List<Medicine> medicines = new List<Medicine>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_medicine");

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Try to execute the query
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Medicine med = new Medicine();
                    med.MedicineID = reader.GetInt32(0);
                    med.MedicineName = reader.GetString(1);
                    med.MedicineDosage = reader.GetString(1);
                    med.MedicineDescription = reader.GetString(2);
                    medicines.Add(med);
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

            return medicines;
        }
    }
}
