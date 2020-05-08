using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFPresentation.Models;

namespace WPFPresentation.Controllers
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/29/2020
    /// Approver: 
    /// 
    /// Handles filter related server actions.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class FilterController : Controller
    {
        private IProductManager _productManager;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: 
        /// 
        /// Default constructor, initializes class level variables.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public FilterController()
        {
            _productManager = new ProductManager();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: 
        /// 
        /// Creates a list of the distinct entries for each filter criteria.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public PartialViewResult FilterDropDowns()
        {
            var filterList = new FilterViewModel();
            var products = _productManager.RetrieveAllProducts();
            filterList.Categories = products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            filterList.Types = products
                .Select(x => x.Type)
                .Distinct()
                .OrderBy(x => x);
            filterList.Brands = products
                .Select(x => x.Brand)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(filterList);
        }
    }
}