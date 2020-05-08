using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 02/14/2020
    /// Approver: Cash Carlson
    /// 
    /// Interface for product data accessor to facilitate loose coupling.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// </remarks>
    public interface IProductAccessor
    {
        /// /// <summary>
        /// Creator: Robert Holmes
        /// Created: 02/14
        /// Approver: Cash Carlson
        /// 
        /// Interface for a method to get all products by product type.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="type"></param>
        /// <returns></returns>
        List<Product> SelectProductByType(string type = "All");

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 3/1/2020
        /// Approver: Robert Holmes
        /// 
        /// The method is used to update the product.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// </remarks>
        int UpdateProduct(Product oldProduct, Product newProduct);

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/1/2020
        /// APPROVER: Robert Holmes
        /// 
        /// The method is used to select all the products on the product.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        List<Product> SelectAllProducts();

        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to insert a new product.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        int InsertProduct(Product product);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to retrieve all ProductTypeIDs from the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <returns></returns>
        List<string> SelectAllProductTypeIDs();

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to supply a single product.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        Product SelectProductByID(string productID);
        
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Interface for a method to deactivate a product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        int DeactivateProduct(string productID);

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Interface for a method to activate a product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        int ActivateProduct(string productID);
    }
}