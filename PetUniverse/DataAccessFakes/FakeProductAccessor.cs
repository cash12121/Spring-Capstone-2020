using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 02/14/2020
    /// Approver: Cash Carlson
    /// 
    /// Fake product accessor for testing purposes.
    /// </summary>
    public class FakeProductAccessor : IProductAccessor
    {
        private List<Product> products;


        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 02/21/2020
        /// Approver: Cash Carlson
        /// 
        /// Sets up fake data for testing purposes.
        /// </summary>
        /// <remarks>
        /// Updater: Cash Carlson
        /// Updated: 2020/04/29
        /// Update: Added more test data for other tests.
        /// </remarks>
        public FakeProductAccessor()
        {
            products = new List<Product>()
            {
                new Product()
                {
                    ProductID = "1234567890120",
                    ItemID = 0,
                    Name = "Test",
                    Category = "Test Category",
                    Type = "Test Type",
                    Description = "A test product description.",
                    Price = 0.50M,
                    Brand = "Test Brand",
                    Taxable = true
                },

                new Product()
                {
                    ProductID = "1234567890120",
                    ItemID = 0,
                    Name = "Test",
                    Category = "Test Category",
                    Type = "Test Type 2",
                    Description = "A test product description.",
                    Price = 0.50M,
                    Brand = "Test Brand",
                    Taxable = true
                },

                new Product()
                {
                    ProductID = "1234567890121",
                    ItemID = 0,
                    Name = "Test",
                    Category = "Test Category",
                    Type = "Test Type 3",
                    Description = "A test product description.",
                    Price = 0.50M,
                    Brand = "Test Brand",
                    Taxable = true,
                    Active = true
                },

                new Product()
                {
                    ProductID = "1234567890124",
                    ItemID = 0,
                    Name = "Test",
                    Category = "Test Category",
                    Type = "Test Type 4",
                    Description = "A test product description.",
                    Price = 0.50M,
                    Brand = "Test Brand",
                    Taxable = true,
                    Active = false
                }
            };
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 03/17/2020
        /// Approver: Jaeho Kim
        /// 
        /// Tests whether the manager correctly calls the add method.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="product"></param>
        /// <returns>int based on inserted product</returns>
        public int InsertProduct(Product product)
        {
            int rows = 0;
            bool duplicate = false;

            foreach (Product p in products)
            {
                if (p.ProductID == product.ProductID)
                {
                    duplicate = true;
                    break;
                }
            }

            if (duplicate)
            {
                throw new ApplicationException("Duplicate Item Detected.");
            }
            else
            {
                products.Add(product);
                rows++;
            }

            return rows;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 03/18/2020
        /// Approver: Jaeho Kim
        /// 
        /// Method that returns a fake collection of product type ids.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        public List<string> SelectAllProductTypeIDs()
        {
            return new List<string>
            {
                "Test Type ID"
            };
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 02/14/2020
        /// Approver: Cash Carlson
        /// 
        /// Returns dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="type">The type of item to filter by.</param>
        public List<Product> SelectProductByType(string type)
        {
            if (!type.Equals("Fail Type"))
            {
                if (type.Equals("All"))
                {
                    return (from p in products
                            select p).ToList();
                }
                else
                {
                    return (from p in products
                            where p.Type == type
                            select p).ToList();
                }
            }
            else
            {
                throw new ApplicationException("Failed to Load Products");
            }
        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 3/13/2020
        /// Approver: Robert Holmes
        /// 
        /// Fake Product Accessor Method, return list of product for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Updater: NA
        /// </remarks>
        public List<Product> SelectAllProducts()
        {
            return products;
        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 3/13/2020
        /// Approver: Robert Holmes
        /// 
        /// Fake Product Accessor Method to update the product, for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Updater: NA
        /// </remarks>
        public int UpdateProduct(Product oldProduct, Product newProduct)
        {
            int rows = 0;

            foreach (Product product in products)
            {
                if (
                    product.ProductID == oldProduct.ProductID &&
                    product.ItemID == oldProduct.ItemID &&
                    product.Category == oldProduct.Category &&
                    product.Type == oldProduct.Type &&
                    product.Name == oldProduct.Name &&
                    product.Price == oldProduct.Price &&
                    product.Taxable == oldProduct.Taxable

                  )
                {
                    product.ProductID = oldProduct.ProductID;
                    product.ItemID = newProduct.ItemID;
                    product.Category = newProduct.Category;
                    product.Type = newProduct.Type;
                    product.Name = newProduct.Name;
                    product.Price = newProduct.Price;
                    product.Taxable = newProduct.Taxable;

                    rows++;
                }
            }
            return rows;
        }

        /// /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Returns a single product based on the supplied product ID.
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
            Product result = null;

            foreach (var p in products)
            {
                if (p.ProductID.Equals(productID))
                {
                    result = p;
                    break;
                }
            }

            return result;
        }
        
        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Fake Accessor Method for Deactivation
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public int DeactivateProduct(string productID)
        {
            int deactive = 0;

            foreach(Product product in products)
            {
                if (product.ProductID == productID)
                {
                    product.Active = false;
                    deactive++;
                }
            }

            return deactive;
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Fake Accessor Method for Activatation
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public int ActivateProduct(string productID)
        {
            int active = 0;

            foreach (Product product in products)
            {
                if (product.ProductID == productID)
                {
                    product.Active = true;
                    active++;
                }
            }

            return active;
        }
    }
}
