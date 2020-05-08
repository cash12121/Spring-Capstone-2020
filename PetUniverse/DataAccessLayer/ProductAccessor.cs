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
    /// Created: 2/14/2020
    /// Approver: Cash Carlson
    /// 
    /// Retrieves records from permanent storage for products.
    /// </summary>
    /// <remarks>
    /// Updater: Robert Holmes
    /// Updated: 04/29/2020
    /// Update: Added SelectProductByID
    /// </remarks>
    public class ProductAccessor : IProductAccessor
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// SQLEXPRESS implemention of adding a new product to the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="product">Product to add</param>
        /// <returns></returns>
        public int InsertProduct(Product product)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_insert_product";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
            cmd.Parameters.AddWithValue("@ItemID", product.ItemID);
            cmd.Parameters.AddWithValue("@ProductTypeID", product.Type);
            cmd.Parameters.AddWithValue("@Taxable", product.Taxable);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Brand", product.Brand);

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
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// SQLEXPRESS implementation to select all the ProductTypeIDs in the table.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<string> SelectAllProductTypeIDs()
        {
            List<string> types = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_select_all_product_type_id";

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

            return types;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2/21/2020
        /// Approver: Cash Carlson
        /// 
        /// Queries the SQL database for a list of products that match the supplied type (or all if no type is supplied).
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public List<Product> SelectProductByType(string type = "All")
        {
            List<Product> products = new List<Product>();

            var conn = DBConnection.GetConnection();
            SqlCommand cmd;
            if (type.Equals("All"))
            {
                cmd = new SqlCommand("sp_select_all_products", conn);
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd = new SqlCommand("sp_select_products_by_type", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductTypeID", type);
            }
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.ProductID = reader.GetString(0);
                        p.ItemID = reader.GetInt32(1);
                        p.Name = reader.GetString(2);
                        p.Category = reader.GetString(3);
                        p.Type = reader.GetString(4);
                        p.Description = reader.GetString(5);
                        p.Price = reader.GetDecimal(6);
                        p.Brand = reader.GetString(7);
                        p.Taxable = reader.GetBoolean(8);

                        products.Add(p);
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
            return products;
        }

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/3/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Queries the SQL database for a list of all product.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public List<Product> SelectAllProducts()
        {
            List<Product> products = new List<Product>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_products", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var product = new Product();

                        product.ProductID = reader.GetString(0);
                        product.ItemID = reader.GetInt32(1);
                        product.Name = reader.GetString(2);
                        product.Category = reader.GetString(3);
                        product.Type = reader.GetString(4);
                        product.Description = reader.GetString(5);
                        product.Price = reader.GetDecimal(6);
                        product.Brand = reader.GetString(7);
                        product.Taxable = reader.GetBoolean(8);


                        products.Add(product);
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

            return products;
        }

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/3/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Queries the SQL database for an update product fields  .
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public int UpdateProduct(Product oldProduct, Product newProduct)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_product_price", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", oldProduct.ProductID);

            cmd.Parameters.AddWithValue("@NewItemID", newProduct.ItemID);
            cmd.Parameters.AddWithValue("@NewProductTypeID", newProduct.Type);
            cmd.Parameters.AddWithValue("@NewDescription", newProduct.Description);
            cmd.Parameters.AddWithValue("@NewPrice", newProduct.Price);
            cmd.Parameters.AddWithValue("@NewBrand", newProduct.Brand);
            cmd.Parameters.AddWithValue("@NewTaxable", newProduct.Taxable);

            cmd.Parameters.AddWithValue("@OldItemID", oldProduct.ItemID);
            cmd.Parameters.AddWithValue("@OldProductTypeID", oldProduct.Type);
            cmd.Parameters.AddWithValue("@OldDescription", oldProduct.Description);
            cmd.Parameters.AddWithValue("@OldPrice", oldProduct.Price);
            cmd.Parameters.AddWithValue("@OldBrand", oldProduct.Brand);
            cmd.Parameters.AddWithValue("@OldTaxable", oldProduct.Taxable);

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
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Returns a single product that matches the supplied productID.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        public Product SelectProductByID(string productID)
        {
            Product product = null;

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_select_product_by_id";

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
                        product = new Product
                        {
                            ProductID = reader.GetString(0),
                            Name = reader.GetString(1),
                            Taxable = reader.GetBoolean(2),
                            Price = reader.GetDecimal(3),
                            // 4 is ItemQuantity
                            Description = reader.GetString(5),
                            Active = reader.GetBoolean(6),
                            ItemID = reader.GetInt32(7),
                            Category = reader.GetString(8),
                            Type = reader.GetString(9),
                            Brand = reader.GetString(10)
                        };
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

            return product;
        }
        
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Tells Database to deactivate product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public int DeactivateProduct(string productID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_deactivate_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", productID);

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
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Tells Database to activate product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public int ActivateProduct(string productID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_activate_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", productID);

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
