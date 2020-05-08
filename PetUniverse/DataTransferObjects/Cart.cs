using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/29/2020
    /// Approver: Jaeho Kim
    /// 
    /// A class to hold the items an online customer may purchase.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class Cart
    {
        private List<CartLine> _lines = new List<CartLine>();

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a product and an amount to the cart.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        public void AddItem(Product product, int amount)
        {
            CartLine line = _lines.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

            if (line == null)
            {
                _lines.Add(new CartLine { 
                    Product = product, 
                    Amount = amount 
                });
            }
            else
            {
                line.Amount += amount;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Removes an item and decrements amount in the cart.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public void DecrementItem(Product product, int amount)
        {
            CartLine line = _lines.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

            if (line == null)
            {
                // do nothing
            }
            else
            {
                line.Amount -= amount;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Removes all of an item from the cart.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public void RemoveLine(Product product)
        {
            _lines.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Removes all items from the cart.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public void Clear()
        {
            _lines.Clear();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// The collection of lines for the cart.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public IEnumerable<CartLine> Lines
        {
            get { return _lines; }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Simple class for holding the pairs of products and their amounts.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public class CartLine
        {
            public Product Product { get; set; }
            public int Amount { get; set; }
        }
    }
}
