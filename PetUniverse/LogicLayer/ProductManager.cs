using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/02/14
    /// Approver: Cash Carlson
    /// 
    /// Handles data requests from the presentation layer by requesting data from the data access layer.
    /// </summary>
    /// <remarks>
    /// Updater: Robert Holmes
    /// Updated: 04/29/2020
    /// Update: Added RetrieveProductByID
    /// </remarks>
    public class ProductManager : IProductManager
    {
        private IProductAccessor _productAccessor;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Instanciates product accessor with real data.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public ProductManager()
        {
            _productAccessor = new ProductAccessor();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Instanciates product accessor with custom defined data for testing.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="productAccessor">Product accessor class to use</param>
        public ProductManager(IProductAccessor productAccessor)
        {
            _productAccessor = productAccessor;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// Add a new product to the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="product">Product to add</param>
        /// <returns></returns>
        public bool AddProduct(Product product)
        {
            bool success = false;

            try
            {
                success = (1 == _productAccessor.InsertProduct(product));
            }
            catch (Exception)
            {
                throw;
            }
            return success;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Retrieves a list of all the products that match a certain type (or all if no type is provided)
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// /// <param name="type">Product type to search by</param>
        public List<Product> RetrieveAllProductsByType(string type = "All")
        {
            List<Product> products = new List<Product>();
            try
            {
                products = _productAccessor.SelectProductByType(type);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
            return products;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Retrieves a list of all the Product Type IDs from the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public List<string> RetrieveAllProductTypeIDs()
        {
            List<string> types = new List<string>();
            try
            {
                types = _productAccessor.SelectAllProductTypeIDs();
            }
            catch (Exception)
            {
                throw;
            }
            return types;
        }

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/1/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Update a field of the product .
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public bool EditProduct(Product oldProduct, Product newProduct)
        {
            bool result = false;

            try
            {
                result = _productAccessor.UpdateProduct(oldProduct, newProduct) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed", ex);
            }

            return result;
        }

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/3/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Retrieves a list of all the products .
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        /// 
        public List<Product> RetrieveAllProducts()
        {
            List<Product> result = null;
            try
            {

                result = _productAccessor.SelectAllProducts();

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);

            }

        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Returns a single product based on the provided productID.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        public Product RetrieveProductByID(string productID)
        {
            Product product = null;

            try
            {
                product = _productAccessor.SelectProductByID(productID);
            }
            catch (Exception)
            {
                throw;
            }

            return product;
        }
        
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Method to Deactivate Product by ProductID
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public bool DeactivateProduct(string productID)
        {
            bool result = false;

            try
            {
                result = _productAccessor.DeactivateProduct(productID) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Deactivation failed", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Method to Activate a Product by ProductID
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public bool ActivateProduct(string productID)
        {
            bool result = false;

            try
            {
                result = _productAccessor.ActivateProduct(productID) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Activatation failed", ex);
            }

            return result;
        }
    }
}
