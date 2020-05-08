using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver: Cash Carlson
    /// 
    /// Concrete implementation of the IPromotionAccessor interface for SQLEXPRESS technology.
    /// </summary>
    public class PromotionAccessor : IPromotionAccessor
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// SQLEXPRESS implementation of adding a new promotion to the database.
        /// </summary>
        /// <returns></returns>
        public int InsertNewPromotion(Promotion promotion)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_insert_promotion";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);
            cmd.Parameters.AddWithValue("@PromotionTypeID", promotion.PromotionTypeID);
            cmd.Parameters.AddWithValue("@StartDate", promotion.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", promotion.EndDate);
            cmd.Parameters.AddWithValue("@Discount", promotion.Discount);
            cmd.Parameters.AddWithValue("@Description", promotion.Description);

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

            if (rows == 1)
            {
                insertPromoProducts(promotion);
            }
            return rows;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// SQLEXPRESS implemementation of getting all promotions
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="onlyActive"></param>
        /// <returns></returns>
        public List<Promotion> SelectAllPromotions(bool onlyActive = true)
        {
            List<Promotion> promotions = new List<Promotion>();

            var conn = DBConnection.GetConnection();
            string cmdText;
            if (onlyActive)
            {
                cmdText = "sp_select_all_active_promotions";
            }
            else
            {
                cmdText = "sp_select_all_promotions";
            }
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        promotions.Add(new Promotion()
                        {
                            PromotionID = reader.GetString(0)
                            ,
                            PromotionTypeID = reader.GetString(1)
                            ,
                            StartDate = reader.GetDateTime(2)
                            ,
                            EndDate = reader.GetDateTime(3)
                            ,
                            Discount = reader.GetDecimal(4)
                            ,
                            Description = reader.GetString(5)
                            ,
                            Active = reader.GetBoolean(6)
                        });
                    }
                    reader.Close();
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

            foreach (Promotion promo in promotions)
            {
                promo.Products = getProductsForPromotion(promo.PromotionID);
            }

            return promotions;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Gets all of the related products for a promotion ID.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private List<Product> getProductsForPromotion(string promotionID)
        {
            List<Product> products = new List<Product>();

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_select_all_products_by_promotion_id";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PromotionID", promotionID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        products.Add(new Product()
                        {
                            ProductID = reader.GetString(0)
                            ,
                            ItemID = reader.GetInt32(1)
                            ,
                            Name = reader.GetString(2)
                            ,
                            Category = reader.GetString(3)
                            ,
                            Type = reader.GetString(4)
                            ,
                            Description = reader.GetString(5)
                            ,
                            Price = reader.GetDecimal(6)
                            ,
                            Brand = reader.GetString(7)
                            ,
                            Taxable = reader.GetBoolean(8)
                        });

                    }
                    reader.Close();
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
            return products;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Retrieves all promotion types from the data base.
        /// </summary>
        /// <returns></returns>
        public List<string> SelectAllPromotionTypes()
        {
            List<string> types = new List<string>();

            var cmdText = @"sp_select_promotion_types";
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        types.Add(reader.GetString(0));
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

            return types;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Saves products to database with related promotion id.
        /// </summary>
        /// <param name="promotion"></param>
        private void insertPromoProducts(Promotion promotion)
        {
            foreach (Product p in promotion.Products)
            {
                var cmdText = "sp_insert_promo_product";
                var conn = DBConnection.GetConnection();

                var cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);
                cmd.Parameters.AddWithValue("@ProductID", p.ProductID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// SQLEXPRESS implementation to update a promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="oldPromotion"></param>
        /// <param name="newPromotion"></param>
        /// <returns></returns>
        public int UpdatePromotion(Promotion oldPromotion, Promotion newPromotion)
        {
            int rows = 0;

            var cmdText = "sp_update_promotion";
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PromotionID", oldPromotion.PromotionID);
            cmd.Parameters.AddWithValue("@OldPromotionTypeID", oldPromotion.PromotionTypeID);
            cmd.Parameters.AddWithValue("@OldStartDate", oldPromotion.StartDate);
            cmd.Parameters.AddWithValue("@OldEndDate", oldPromotion.EndDate);
            cmd.Parameters.AddWithValue("@OldDiscount", oldPromotion.Discount);
            cmd.Parameters.AddWithValue("@OldDescription", oldPromotion.Description);
            cmd.Parameters.AddWithValue("@OldActive", oldPromotion.Active);
            cmd.Parameters.AddWithValue("@NewPromotionTypeID", newPromotion.PromotionTypeID);
            cmd.Parameters.AddWithValue("@NewStartDate", newPromotion.StartDate);
            cmd.Parameters.AddWithValue("@NewEndDate", newPromotion.EndDate);
            cmd.Parameters.AddWithValue("@NewDiscount", newPromotion.Discount);
            cmd.Parameters.AddWithValue("@NewDescription", newPromotion.Description);
            cmd.Parameters.AddWithValue("@NewActive", newPromotion.Active);

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
            if (rows == 1)
            {
                removePromoProducts(oldPromotion);
                insertPromoProducts(newPromotion);
            }

            return rows;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Removes old promotion product relationships.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void removePromoProducts(Promotion promotion)
        {
            var conn = DBConnection.GetConnection();
            var cmdText = "sp_delete_promo_products";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/04/07
        /// Approver: Rasha Mohammed
        /// 
        /// SQLEXPRESS implementation of deactivating an active promo.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="promotion"></param>
        /// <returns></returns>
        public int DeactivatePromo(Promotion promotion)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_deactivate_promotion";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);

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
        /// Creator: Robert Holmes
        /// Created: 2020/04/07
        /// Approver: Rasha Mohammed
        /// 
        /// SQLEXPRESS implementation of reactiveating an inactive promo.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public int ReactivatePromo(Promotion promotion)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_reactivate_promotion";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);

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
    }
}
