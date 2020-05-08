using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using Stripe;
using Stripe.Checkout;
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
    /// Controller for cart actions.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class CartController : Controller
    {
        IProductManager _productManager;
        ITransactionManager _transactionManager;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Default constructor, initializes class level variables.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public CartController()
        {
            _productManager = new ProductManager();
            _transactionManager = new TransactionManager();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Default view for cart.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="cart"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a product to the cart session object, or adds one to the amount if it is already present.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="cart"></param>
        /// <param name="productID"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(Cart cart, string productID, string returnUrl)
        {
            DataTransferObjects.Product product = _productManager.RetrieveAllProducts().FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Removes an item from the cart, or decrements the amount by one if it would not be reduced to zero by the decrement.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="cart"></param>
        /// <param name="productID"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveOneFromCart(Cart cart, string productID, string returnUrl)
        {
            var line = cart.Lines.FirstOrDefault(p => p.Product.ProductID == productID);
            if (line != null)
            {
                if (line.Amount == 1)
                {
                    return RedirectToAction("RemoveFromCart", new { cart = cart, productID = productID, returnUrl = returnUrl });
                }
                cart.DecrementItem(line.Product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Removes all of an item from the cart, regardless of current amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="cart"></param>
        /// <param name="productID"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFromCart(Cart cart, string productID, string returnUrl)
        {
            DataTransferObjects.Product product = _productManager.RetrieveAllProducts().FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Returns the pre-tax total of items currently in the cart.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="cart"></param>
        /// <returns></returns>
        public ContentResult GetPreTaxTotal(Cart cart)
        {
            decimal subTotal = 0.0m;
            foreach (var line in cart.Lines)
            {
                subTotal += (line.Product.Price * line.Amount);
            }

            return Content(subTotal.ToString("C"));
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Starts the checkout process by prompting the user to enter their information, or returns them to the index if their cart is empty.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ActionResult Checkout(Cart cart, OrderDetails orderDetails)
        {
            if (cart.Lines.Count() > 0)
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("CompleteCheckout", new { cart = cart, orderDetails = orderDetails });
                }
                else if (orderDetails == null)
                {
                    return View(new OrderDetails());
                }
                else
                {
                    return View(orderDetails);
                }
            }
            else
            {
                TempData["message"] = "Your cart must contain items to begin the checkout process.";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Collects payment information and displays a summary of the order.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="cart"></param>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CompleteCheckout(Cart cart, OrderDetails orderDetails)
        {
            StripeConfiguration.ApiKey = StripeKey.SecretKey;

            var customer = new Stripe.Customer
            {
                Name = orderDetails.CustomerName,
                Email = orderDetails.Email,
                Address = new Address
                {
                    Line1 = orderDetails.BillingAddressLine1,
                    Line2 = orderDetails.BillingAddressLine2,
                    City = orderDetails.BillingCity,
                    State = orderDetails.BillingState,
                    PostalCode = orderDetails.BillingPostalCode,
                    Country = orderDetails.BillingCountry
                },
                Phone = orderDetails.CustomerPhone
            };
            if (orderDetails.ShippingAddressLine1 == null)
            {
                orderDetails.ShippingAddressLine1 = orderDetails.BillingAddressLine1;
            }
            if (orderDetails.ShippingAddressLine2 == null)
            {
                orderDetails.ShippingAddressLine2 = orderDetails.BillingAddressLine2;
            }
            if (orderDetails.ShippingCity == null)
            {
                orderDetails.ShippingCity = orderDetails.BillingCity;
            }
            if (orderDetails.ShippingState == null)
            {
                orderDetails.ShippingState = orderDetails.BillingState;
            }
            if (orderDetails.ShippingPostalCode == null)
            {
                orderDetails.ShippingPostalCode = orderDetails.BillingPostalCode;
            }
            if (orderDetails.ShippingCountry == null)
            {
                orderDetails.ShippingCountry = orderDetails.BillingCountry;
            }
            if (orderDetails.ShippingName == null)
            {
                orderDetails.ShippingName = orderDetails.CustomerName;
            }
            if (orderDetails.ShippingPhone == null)
            {
                orderDetails.ShippingPhone = orderDetails.CustomerPhone;
            }
            customer.Shipping = new Shipping
            {
                Address = new Address
                {
                    Line1 = orderDetails.BillingAddressLine1,
                    Line2 = orderDetails.BillingAddressLine2,
                    City = orderDetails.BillingCity,
                    State = orderDetails.BillingState,
                    PostalCode = orderDetails.BillingPostalCode,
                    Country = orderDetails.BillingCountry
                },
                Name = orderDetails.ShippingName,
                Phone = orderDetails.ShippingPhone
            };
            decimal taxRate = 0.0M;
            try
            {
                taxRate = _transactionManager.RetrieveTaxRateBySalesTaxDateAndZipCode(
                    orderDetails.ShippingPostalCode.Substring(0, 5), _transactionManager.RetrieveLatestSalesTaxDateByZipCode(
                        orderDetails.ShippingPostalCode.Substring(0, 5)));
            }
            catch (Exception)
            {
                taxRate = 0.0M;
            }
            orderDetails.TaxRate = taxRate;

            decimal subTotal = 0.0M;
            decimal total = 0.0M;
            foreach (var line in cart.Lines)
            {
                if (line.Product.Taxable)
                {
                    subTotal += line.Product.Price * line.Amount;
                }
                else
                {
                    total += line.Product.Price * line.Amount;
                }
            }
            decimal tax = subTotal * taxRate;
            total += subTotal + tax;
            var options = new PaymentIntentCreateOptions
            {
                Customer = customer.Id,
                Amount = (int)(total * 100), // stripe totals are in pennies
                Currency = "usd",
                PaymentMethodTypes = new List<string>
                {
                    "card"
                }
            };
            var service = new PaymentIntentService();
            PaymentIntent intent = null;
            try
            {
                intent = service.Create(options);
            }
            catch (Exception)
            {
                return RedirectToAction("Checkout");
            }
            var ccvm = new CompleteCheckoutViewModel
            {
                Cart = cart,
                OrderDetails = orderDetails,
                Subtotal = subTotal,
                TaxAmount = tax,
                Total = total
            };
            ViewData["ClientSecret"] = intent.ClientSecret;

            return View(ccvm);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Saves the transaction to the database and thanks the user for their purchase.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="cart"></param>
        /// <param name="orderDetails"></param>
        /// <param name="stripeChargeID"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Thanks(Cart cart, CompleteCheckoutViewModel completeCheckoutViewModel, string stripeChargeID)
        {
            if (cart != null && completeCheckoutViewModel != null)
            {
                decimal subTotalTaxFree = 0.0M;
                decimal subTotalTaxable = 0.0M;
                var productAmounts = new Dictionary<DataTransferObjects.Product, int>();
                var productsSold = new List<ProductVM>();
                foreach (var line in cart.Lines)
                {
                    productAmounts.Add(line.Product, line.Amount);
                    productsSold.Add(new ProductVM
                    {
                        Name = line.Product.Name,
                        ItemName = line.Product.Name,
                        Active = line.Product.Active,
                        Brand = line.Product.Brand,
                        Category = line.Product.Category,
                        Description = line.Product.Description,
                        ItemDescription = line.Product.Description,
                        ItemID = line.Product.ItemID,
                        Quantity = line.Amount,
                        ItemQuantity = line.Amount,
                        Price = line.Product.Price,
                        ProductID = line.Product.ProductID,
                        Taxable = line.Product.Taxable,
                        Type = line.Product.Type
                    });
                    if (!line.Product.Taxable)
                    {
                        subTotalTaxFree += line.Product.Price * line.Amount;
                    }
                    else
                    {
                        subTotalTaxable += line.Product.Price * line.Amount;
                    }
                }
                decimal subTotalWithTax = subTotalTaxable * (1 + completeCheckoutViewModel.OrderDetails.TaxRate);
                subTotalTaxable += subTotalTaxFree;
                var transaction = new Transaction
                {
                    CustomerEmail = completeCheckoutViewModel.OrderDetails.Email,
                    StripeChargeID = stripeChargeID,
                    EmployeeID = 100000, // Admin account user id
                    SubTotal = subTotalTaxFree,
                    SubTotalTaxable = subTotalTaxable,
                    TaxRate = completeCheckoutViewModel.OrderDetails.TaxRate,
                    TransactionDateTime = DateTime.Now,
                    TransactionStatusID = "Completed",
                    TransactionTypeID = "Online Sale",
                    Total = subTotalWithTax + subTotalTaxFree,
                    ProductAmounts = productAmounts
                };
                _transactionManager.AddTransaction(transaction);
                var lineProducts = new TransactionLineProducts { ProductsSold = productsSold };
                _transactionManager.AddTransactionLineProducts(lineProducts);
            }
            cart.Clear();
            _transactionManager = new TransactionManager();
            return View();
        }

    }
}