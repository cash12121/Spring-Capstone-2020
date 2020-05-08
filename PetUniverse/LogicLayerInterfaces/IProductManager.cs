using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/02/14
    /// Approver: Cash Carlson
    /// 
    /// Interface for product manager logic layer class to facilitate loose coupling.
    /// </summary>
    /// <remarks>
    /// Updater: Robert Holmes
    /// Updated: 04/29/2020
    /// Update: Added method signatures.
    /// </remarks>
    public interface IProductManager
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Interface to retrieve all products by type.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        List<Product> RetrieveAllProductsByType(string type = "All");

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 3/1/2020
        /// Approver: Robert Holmes
        /// 
        /// Interface to update product value from product from old one to new one.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        bool EditProduct(Product oldProduct, Product newProduct);

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/1/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Interface to retrieve all products.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        List<Product> RetrieveAllProducts();

        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to add a product.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="product"></param>
        /// <returns></returns>
        bool AddProduct(Product product);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to retrieve all the product type IDs from the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        List<string> RetrieveAllProductTypeIDs();

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to retrieve a single product based on the supplied productID.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        Product RetrieveProductByID(string productID);
        
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// An interface for a mehtod to deactivate a product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        bool DeactivateProduct(string productID);

         /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// An interface for a mehtod to activate a product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        bool ActivateProduct(string productID);
    }
}
