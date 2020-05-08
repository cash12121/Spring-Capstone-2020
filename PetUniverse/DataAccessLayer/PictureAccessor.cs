using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Rasha Mohammed
    /// Created: 4/1/2020
    /// Approver: Ethan Holmes
    /// 
    /// Retrieves records from permanent storage for picture.
    /// </summary>
    /// <remarks>
    /// Updater: Robert Holmes
    /// Updated: 04/29/2020
    /// Update: Added InsertPicture and SelectAllPicturesByProductID
    /// 
    /// </remarks>
    public class PictureAccessor : IPictureAccessor
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Saves a picture to the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="picture"></param>
        /// <returns></returns>
        public int InsertPicture(Picture picture)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            string cmdText = "sp_insert_picture";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", picture.ProductID);
            cmd.Parameters.AddWithValue("@PictureData", picture.ImageData);
            cmd.Parameters.AddWithValue("@PictureMimeType", picture.ImageMimeType);


            try
            {
                if (picture.IsUsingDefault)
                {
                    throw new ApplicationException("Unable to save default image to database.");
                }
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
        /// Creator: Rasha Mohammed
        /// Created: 4/1/2020
        /// Approver: Ethan Holmes
        /// 
        /// This method using queries to select all pictures form database.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 04/29/2020
        /// Update: Now utilizes btye[] instead of image path
        /// 
        /// </remarks>
        public List<Picture> SelectAllPicture()
        {
            List<Picture> pictures = new List<Picture>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select__all_image", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var picture = new Picture();
                        picture.PictureID = reader.GetInt32(0);
                        picture.ProductID = reader.GetString(1);
                        picture.ImageData = (byte[])reader[2];
                        picture.ImageMimeType = reader.GetString(3);

                        pictures.Add(picture);
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

            return pictures;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Returns a list of all pictures associated with the supplied product id.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<Picture> SelectAllPicturesByProductID(string productID)
        {
            List<Picture> result = new List<Picture>();

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_select_all_pictures_by_product_id";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", productID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        result.Add(new Picture
                        {
                            PictureID = reader.GetInt32(0),
                            ProductID = reader.GetString(1),
                            ImageData = (byte[])reader[2],
                            ImageMimeType = reader.GetString(3)
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}
