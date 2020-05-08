using DataTransferObjects;
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
    /// Approver: Jaeho Kim
    /// 
    /// Controller for product related actions.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class ProductController : Controller
    {
        private IProductManager _productManager;
        private IPictureManager _pictureManager;

        public int PageSize = 9;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Default Constructor, intitializes class level variables.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ProductController()
        {
            _productManager = new ProductManager();
            _pictureManager = new PictureManager();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Default display for a list of products, also handles navigation and filtering.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <param name="brand"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        // GET: Product
        public ViewResult Index(string category = null, string type = null, string brand = null, int page = 1)
        {
            var products = _productManager.RetrieveAllProducts();
            if (category != null && category.Equals("")) { category = null; }
            if (type != null && type.Equals("")) { type = null; }
            if (brand != null && brand.Equals("")) { brand = null; }
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products
                .Where(p => category == null || p.Category.ToLower().Equals(category.ToLower()))
                .Where(p => type == null || p.Type.ToLower().Equals(type.ToLower()))
                .Where(p => brand == null || p.Brand.ToLower().Equals(brand.ToLower()))
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                CurrentCategory = category,
                CurrentType = type,
                CurrentBrand = brand
            };
            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = products
                .Where(p => category == null || p.Category.ToLower().Equals(category.ToLower()))
                .Where(p => type == null || p.Type.ToLower().Equals(type.ToLower()))
                .Where(p => brand == null || p.Brand.ToLower().Equals(brand.ToLower()))
                .Count()
            };
            return View(model);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Action for view the details about a specific item.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        public ActionResult Details(string productID)
        {
            Product product = null;
            if (productID != null)
            {
                product = _productManager.RetrieveProductByID(productID);
            }
            
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Gets the image for a product or returns the default if there isn't one.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public FileResult GetImage(string productID)
        {
            Picture picture = _pictureManager.RetrieveMostRecentPictureByProductID(productID);
            if (picture != null)
            {
                return File(picture.ImageData, picture.ImageMimeType);
            }
            else
            {
                string path = Server.MapPath("/Content/Images/MISSING.jpg");
                return File(path, "image/jpeg");
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Gets "popular" items for display on the home page.
        /// Currently just gets the first few items in alphabetical order.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: Doesn't just get the same item every time.
        /// </remarks>
        public PartialViewResult GetPopularItem(int index)
        {
            var products = _productManager.RetrieveAllProducts()
                .OrderBy(p => p.Name);
            Product product = products.Skip(index % products.Count()).First();
            return PartialView("_PopularProductPartial", product);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Allows users to search for produts.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ViewResult Search(string searchString, int page = 1)
        {
            var products = _productManager.RetrieveAllProducts();
            var model = new ProductListViewModel
            {
                Products = products.Where(p =>
                p.ProductID.ToLower().Contains(searchString.ToLower()) ||
                p.Name.ToLower().Contains(searchString.ToLower()) ||
                p.Description.ToLower().Contains(searchString.ToLower()) ||
                p.Brand.ToLower().Contains(searchString.ToLower()) ||
                p.Type.ToLower().Contains(searchString.ToLower()) ||
                p.Category.ToLower().Contains(searchString.ToLower()))
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
            };
            model.PagingInfo = new PagingInfo
            {
                CurrentPage = 1,
                ItemsPerPage = PageSize,
                TotalItems = products
                .Count()
            };
            ViewData["SearchString"] = searchString;
            return View(model);
        }
    }
}