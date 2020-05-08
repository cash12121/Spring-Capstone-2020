using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 02/27/2020
    /// APPROVER: Rasha Mohammed
    /// 
    /// Fake Transaction Accessor Class for Unit Testing
    /// </summary>
    public class FakeTransactionAccessor : ITransactionAccessor
    {
        // initializing list of transaction VMs for testing
        private List<TransactionVM> _transactionsVMs;

        // initializing list of transaction VMs for testing items related to transaction
        private List<TransactionVM> items;

        // initializing list of transactions for testing
        private List<Transaction> _transactions;

        // initializing list of transaction types for testing
        private List<TransactionType> transactionTypes;

        // initializing list of transaction statuses for testing
        private List<TransactionStatus> transactionStatuses;

        // initializing lists of products related to transaction for testing
        private List<ProductVM> _productVMs1;
        private List<ProductVM> _productVMs2;
        private List<TransactionLineProducts> _transactionLineProducts;

        // initializing list of sales taxes for testing
        private List<SalesTax> salesTaxes;

        private List<Product> products;

        // this is the list of items for inventory
        private List<Item> itemList;

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This fake method is called to get a fake Transaction Accessor
        /// </summary>
        /// <remarks>
        /// Updater: Jaeho Kim
        /// Updated: 03/05/2020
        /// Update: Implemented the Select All Products by Transaction ID.
        /// </remarks>
        public FakeTransactionAccessor()
        {

            // Sample product for testing to update price 
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
            };

            DateTime transactionDate1 = new DateTime(2010, 10, 18);
            DateTime transactionDate2 = new DateTime(2011, 11, 19);

            _transactionsVMs = new List<TransactionVM>()
            {
                new TransactionVM()
                {
                    TransactionID = 1000,
                    TransactionDateTime = transactionDate1,
                    EmployeeID = 100000,
                    FirstName = "Bob",
                    LastName = "Jones",
                    TransactionTypeID = "FAKE_TYPE_1",
                    TransactionStatusID = "FAKE_STATUS_1"
                },
                new TransactionVM()
                {
                    TransactionID = 1001,
                    TransactionDateTime = transactionDate2,
                    EmployeeID = 100001,
                    FirstName = "Shawn",
                    LastName = "Gunner",
                    TransactionTypeID = "FAKE_TYPE_2",
                    TransactionStatusID = "FAKE_STATUS_2"
                }
            };


            _transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    TransactionID = 1000,
                    TransactionDateTime = transactionDate1,
                    TaxRate = 0.025M,
                    SubTotalTaxable = 20.22M,
                    SubTotal = 21.22M,
                    Total = 23.11M,
                    TransactionTypeID = "FAKE_TYPE_1",
                    EmployeeID = 100000,
                    TransactionStatusID = "FAKE_STATUS_1"
                },
                new Transaction()
                {
                    TransactionID = 1001,
                    TransactionDateTime = transactionDate2,
                    TaxRate = 0.031M,
                    SubTotalTaxable = 43.22M,
                    SubTotal = 42.22M,
                    Total = 44.11M,
                    TransactionTypeID = "FAKE_TYPE_1",
                    EmployeeID = 100001,
                    TransactionStatusID = "FAKE_STATUS_1",
                    CustomerEmail = "test@test.com"
                }
            };



            _productVMs1 = new List<ProductVM>
            {
                new ProductVM()
                {
                    Name = "CatFood",
                    ProductID = "ProductID100",
                },
                new ProductVM()
                {
                    Name = "SnakeFood",
                    ProductID = "ProductID400",
                }
            };

            _productVMs2 = new List<ProductVM>
            {
                new ProductVM()
                {
                    Name = "DogFood",
                    ProductID = "ProductID200",
                },
                new ProductVM()
                {
                    Name = "FishFood",
                    ProductID = "ProductID300",
                }
            };

            _transactionLineProducts = new List<TransactionLineProducts>()
            {
                new TransactionLineProducts()
                {
                    TransactionID = 1000,
                    ProductsSold = _productVMs1

                },
                new TransactionLineProducts()
                {
                    TransactionID = 1001,
                    ProductsSold = _productVMs2
                }
            };

            items = new List<TransactionVM>()
            {
                new TransactionVM()
                {
                    TransactionID = 10000,
                    ProductID = "tx123hyg",
                    Quantity = 2,

                },
                new TransactionVM()
                {
                    TransactionID = 10001,
                    ProductID = "123lok569",
                    Quantity = 1,

                },
                new TransactionVM()
                {
                    TransactionID = 10001,
                    ProductID = "123abc456",
                    Quantity = 3,

                }

            };


            DateTime salesTaxDate1 = new DateTime(2002, 10, 18);
            DateTime salesTaxDate2 = new DateTime(2003, 11, 19);
            salesTaxes = new List<SalesTax>()
            {
                new SalesTax()
                {
                    ZipCode = "1111",
                    TaxRate = 0.0025M,
                    TaxDate = salesTaxDate1
                },
                new SalesTax()
                {
                    ZipCode = "2222",
                    TaxRate = 0.0045M,
                    TaxDate = salesTaxDate2
                }
            };

            // sample transaction types
            transactionTypes = new List<TransactionType>()
            {
                new TransactionType()
                {
                    TransactionTypeID = "SALES",
                    Description= "FAKETRANSTYPEDESC",
                    DefaultInStore = true
                },
                new TransactionType()
                {
                    TransactionTypeID = "REFUND",
                    Description= "FAKETRANSTYPEDESC2",
                    DefaultInStore = false
                },
                new TransactionType()
                {
                    TransactionTypeID = "VOID",
                    Description= "FAKETRANSTYPEDESC3",
                    DefaultInStore = false
                }
            };

            // sample transaction statuses
            transactionStatuses = new List<TransactionStatus>()
            {
                new TransactionStatus()
                {
                    TransactionStatusID = "COMPLETE",
                    Description= "FAKETRANSSTATUSDESC",
                    DefaultInStore = true
                },
                new TransactionStatus()
                {
                    TransactionStatusID = "PENDING",
                    Description= "FAKETRANSSTATUSDESC2",
                    DefaultInStore = false
                },
                new TransactionStatus()
                {
                    TransactionStatusID = "CANCELLED",
                    Description= "FAKETRANSSTATUSDESC3",
                    DefaultInStore = false
                },
                new TransactionStatus()
                {
                    TransactionStatusID = "FAKESTATUS4",
                    Description= "FAKETRANSSTATUSDESC4",
                    DefaultInStore = false
                }
            };

            // sample items
            itemList = new List<Item>()
            {
                new Item()
                {
                    ItemID = 100,
                    ItemQuantity = 10
                },
                new Item()
                {
                    ItemID = 200,
                    ItemQuantity = 20
                },
                new Item()
                {
                    ItemID = 300,
                    ItemQuantity = 30
                }
            };
        }

        /// <summary>
        /// NAME: Rasha Mohammed
        /// DATE: 2/28/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test delete item from the transactionLine 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public int DeleteItemFromTransaction(string productID)
        {
            int result = 0;
            foreach (var item in items)
            {
                if (item.ProductID == productID)
                {
                    items.Remove(item);
                    result++;
                    break;
                }

            }
            return result;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/04/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Method to test insert transaction
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transaction">The transaction object that is added to the database</param>
        public int InsertTransaction(Transaction transaction)
        {
            int result = 0;
            FakeTransactionAccessor fakeTransactionAccessor = new FakeTransactionAccessor();
            List<Transaction> transactions = fakeTransactionAccessor.SelectAllTransactions();

            if (!transactions.Contains(transaction))
            {
                transactions.Add(transaction);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/04/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Method to test insert products related to transaction
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionLineProducts">The products related to the transaction</param>
        public int InsertTransactionLineProducts(TransactionLineProducts transactionLineProducts)
        {
            int result = 0;
            FakeTransactionAccessor fakeTransactionAccessor = new FakeTransactionAccessor();
            List<TransactionLineProducts> transactionLineProductsList =
                fakeTransactionAccessor.SelectAllTransactionLineProducts();

            if (!transactionLineProductsList.Contains(transactionLineProducts))
            {
                transactionLineProductsList.Add(transactionLineProducts);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 3/05/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionID">the transaction id that is related to the products</param>
        public List<TransactionVM> SelectAllProductsByTransactionID(int transactionID)
        {
            return (from v in _transactionsVMs
                    where v.TransactionID == 1000
                    select v).ToList();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2/27/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: Jaeho Kim
        /// Updated: 2020/03/03
        /// 
        /// Added missing properties from the data transfer object.
        /// </remarks>
        /// <returns>TransactionVM</returns>
        public List<TransactionVM> SelectAllTransactionVMs()
        {
            return _transactionsVMs;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/04/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Method to test select all transactions
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <returns>TransactionVM</returns>
        public List<Transaction> SelectAllTransactions()
        {
            return _transactions;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/04/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Method to test transaction line products
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <returns>TransactionLineProducts</returns>
        public List<TransactionLineProducts> SelectAllTransactionLineProducts()
        {
            return _transactionLineProducts;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/04/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Method to test select latest sales tax date
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="zipCode">The zip code of the sales tax rate</param>
        /// <returns>The Exact Date of the Sales Tax Rate of the Zip Code</returns>
        public DateTime SelectLatestSalesTaxDateByZipCode(string zipCode)
        {
            SalesTax salesTax = null;
            foreach (var aSalesTax in salesTaxes)
            {
                if (aSalesTax.ZipCode.Equals(zipCode))
                {
                    salesTax = aSalesTax;
                }
            }
            return salesTax.TaxDate;
        }


        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/04/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Method to test select product by id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="productID">the product upc number</param>
        /// <returns>ProductVM</returns>
        public ProductVM SelectProductByProductID(string productID)
        {
            ProductVM productVM = null;
            foreach (var product in _productVMs1)
            {
                if (product.ProductID.Equals(productID))
                {
                    productVM = product;
                }
            }
            return productVM;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/04/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Method to test select tax rate by zip code and latest date retrieved.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="zipCode">the zip code of the tax rate</param>
        /// <param name="salesTaxDate">the date of the tax rate</param>
        /// <returns>the tax rate</returns>
        public decimal SelectTaxRateBySalesTaxDateAndZipCode(string zipCode, DateTime salesTaxDate)
        {
            SalesTax salesTax = null;
            foreach (var aSalesTax in salesTaxes)
            {
                if (aSalesTax.ZipCode.Equals(zipCode) && aSalesTax.TaxDate.Equals(salesTaxDate))
                {
                    salesTax = aSalesTax;
                }
            }
            return salesTax.TaxRate;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/04/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Method to test select transactions by date.
        /// </summary>
        /// <remarks>
        /// Updater: Jaeho Kim
        /// Updated: 4/13/2020
        /// Update: Added 2nd parameter (second date time) for date time range.
        /// </remarks>
        /// <param name="transactionDate">the date of the transaction</param>
        /// <param name="secondTransactionDate"></param>
        /// <returns>TransactionVM</returns>
        public List<TransactionVM> SelectTransactionsByTransactionDate
            (DateTime transactionDate, DateTime secondTransactionDate)
        {
            return (from v in _transactionsVMs
                    where v.TransactionDateTime >= transactionDate
                    && v.TransactionDateTime <= secondTransactionDate
                    select v).ToList();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 3/08/2020
        /// Approver:  Rasha Mohammed
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="firstName">the employee's first name</param>
        /// <param name="lastName">the employee's last name</param>
        /// <returns>TransactionVM</returns>
        public List<TransactionVM> SelectTransactionsByEmployeeName(string firstName, string lastName)
        {
            return (from v in _transactionsVMs
                    where v.FirstName == "Bob" && v.LastName == "Jones"
                    select v).ToList();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionID"></param>
        /// <returns>TransactionVM</returns>
        public List<TransactionVM> SelectTransactionsByTransactionID(int transactionID)
        {
            return (from v in _transactionsVMs
                    where v.TransactionID == 1000
                    select v).ToList();
        }

        /// <summary>
        /// CREATOR: Rashs Mohammed
        /// CREATED: 4/11/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing to update the price.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int UpdateProduct(ProductVM oldProduct, ProductVM newProduct)
        {



            int rows = 0;

            foreach (Product product in products)
            {
                if (

                    product.Price == oldProduct.Price

                  )
                {

                    product.Price = newProduct.Price;


                    rows++;
                }
            }
            return rows;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <returns>TransactionType list</returns>
        public List<TransactionType> SelectAllTransactionTypes()
        {
            return (from v in transactionTypes
                    select v).ToList();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// Approver: Robert Holmes
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <returns>TransactionStatus list</returns>
        public List<TransactionStatus> SelectAllTransactionStatus()
        {
            return (from v in transactionStatuses
                    select v).ToList();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// Approver: Robert Holmes
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <returns>Transactiontype</returns>
        public TransactionType SelectDefaultTransactionType()
        {
            var _transactionType = new TransactionType();

            _transactionType = null;

            foreach (var transactionType in transactionTypes)
            {
                if (transactionType.DefaultInStore == true)
                {
                    _transactionType = transactionType;
                }
            }
            return _transactionType;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// Approver: Robert Holmes
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <returns>TransactionStatus</returns>
        public TransactionStatus SelectDefaultTransactionStatus()
        {
            var _transactionStatus = new TransactionStatus();

            _transactionStatus = null;

            foreach (var transactionStatus in transactionStatuses)
            {
                if (transactionStatus.DefaultInStore == true)
                {
                    _transactionStatus = transactionStatus;
                }
            }
            return _transactionStatus;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/25
        /// Approver: Robert Holmes
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <returns>int</returns>
        public int UpdateItemQuantity(TransactionLineProducts transactionLineProducts)
        {

            int rows = 0;
            foreach (Item item in itemList)
            {
                foreach(ProductVM productVM in transactionLineProducts.ProductsSold)
                {
                    if (productVM.ItemID == item.ItemID)
                    {

                        int newQuantity = item.ItemQuantity - productVM.ItemQuantity;
                        item.ItemQuantity = newQuantity;
                        rows++;
                    }
                }
            }
            return rows;
            
        }

        public List<Transaction> GetTransactionsByCustomerEmail(string email)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach(var item in _transactions)
            {
                if(item.CustomerEmail == email)
                {
                    transactions.Add(item);
                }
            }

            return transactions;
        }
    }
}
