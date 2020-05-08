using DataTransferObjects;
using LogicLayer;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Interaction logic for ViewAddOrder.xaml
    /// </summary>
    public partial class ViewAddOrder : Page
    {
        private ItemManager _itemManager;
        private OrderItemLineManager _orderItemLineManager;
        private OrderManager _orderManager;
        private List<Item> _items = new List<Item>();
        private List<Item> _orderItems = new List<Item>();
        private Order _newOrder;
        private UserManager _userManager;
        private Item _item;
        private Order _order;
        private OrderItemLine _orderItemLine;
        private PetUniverseUser _user;
        private String firstName, lastName;

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Iconstructor  for ViewSpecialOrders.xaml
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/28/2020
        /// WHAT WAS CHANGED: When adding a new order, I removed the Update and Remove Order Button.
        /// </remarks>
        /// <returns></returns>
        public ViewAddOrder()
        {
            InitializeComponent();
            _itemManager = new ItemManager();
            _orderManager = new OrderManager();
            _order = new Order();
            btnBack.Visibility = Visibility.Visible;
            btnSaveOrder.Visibility = Visibility.Visible;
            txtUserID.Visibility = Visibility.Visible;
            txtOrderID.Visibility = Visibility.Visible;
            txtOrderID.IsReadOnly = true;
            txtOrderID.Text = "(Automatically Generated)";
            txtFirstName.Visibility = Visibility.Hidden;
            txtLastName.Visibility = Visibility.Hidden;
            lblFirstName.Visibility = Visibility.Hidden;
            lblLastName.Visibility = Visibility.Hidden;
            dgItems.Visibility = Visibility.Hidden;
            dgOrderItems.Visibility = Visibility.Hidden;
            btnAddOrderItem.Visibility = Visibility.Hidden;
            lblAllItems.Visibility = Visibility.Hidden;
            lblOrderItems.Visibility = Visibility.Hidden;
            lblQty.Visibility = Visibility.Hidden;
            txtQty.Visibility = Visibility.Hidden;
            btnEditOrder.Visibility = Visibility.Hidden;
            btnDeleteOrderItem.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/15/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// constructor  for View Order
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/28/2020
        /// WHAT WAS CHANGED: Made it so a few text fields not editable, as well as the datagrid.
        /// </remarks>
        /// <returns></returns>
        public ViewAddOrder(Order order)
        {
            InitializeComponent();
            _orderManager = new OrderManager();
            _orderItemLineManager = new OrderItemLineManager();
            _itemManager = new ItemManager();
            _order = order;
            btnBack.Visibility = Visibility.Visible;
            btnSaveOrder.Visibility = Visibility.Hidden;
            txtUserID.Visibility = Visibility.Visible;
            txtOrderID.Visibility = Visibility.Visible;
            txtOrderID.Text = order.OrderID.ToString();
            txtUserID.Text = order.UserID.ToString();
            btnSaveOrder.Visibility = Visibility.Hidden;
            FetchUserName();
            txtFirstName.Visibility = Visibility.Visible;
            txtLastName.Visibility = Visibility.Visible;
            lblFirstName.Visibility = Visibility.Visible;
            lblLastName.Visibility = Visibility.Visible;
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            dgItems.Visibility = Visibility.Visible;
            dgOrderItems.Visibility = Visibility.Visible;
            btnAddOrderItem.Visibility = Visibility.Visible;
            lblAllItems.Visibility = Visibility.Visible;
            lblOrderItems.Visibility = Visibility.Visible;
            lblQty.Visibility = Visibility.Visible;
            txtQty.Visibility = Visibility.Visible;
            RefreshOrderItemLines();
            txtOrderID.IsReadOnly = true;
            txtFirstName.IsReadOnly = true;
            txtLastName.IsReadOnly = true;
            dgItems.IsReadOnly = true;
            dgOrderItems.IsReadOnly = true;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Goes back to view all orders
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewOrders());
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// action to save new order
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/28/2020
        /// WHAT WAS CHANGED: Made it check to see if the User ID entered by the user was a real number.
        /// </remarks>
        /// <returns></returns>
        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderManager _orderManager = new OrderManager();
            if (txtUserID.Text == "")
            {
                "You must fill out all the Fields.".ErrorMessage();
                return;
            }

            // Checking to validate the text entered by the user is a number.
            int userIdIsANumber;

            if (Int32.TryParse(txtUserID.Text, out userIdIsANumber))
            {
                Order _newOrder = new Order()
                {
                    UserID = userIdIsANumber
                };

                try
                {
                    var result = _orderManager.AddOrder(_newOrder);
                    "Add Succesful".SuccessMessage();
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message, "Add Order Failed: You Must Enter a Valid Existing User ID");
                }
                this.NavigationService?.Navigate(new ViewOrders());
            }
            else
            {
                "Please enter a number for the User ID.".ErrorMessage();
            }
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/15/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// Helper method to retrieve user name from user table
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void FetchUserName()
        {
            _userManager = new UserManager();
            _user = _userManager.getUserByUserID(_order.UserID);
            firstName = _user.FirstName;
            lastName = _user.LastName;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// Action on item click to add item to order and create order line
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/28/2020
        /// WHAT WAS CHANGED: When the user clicks add item for the order, it makes the quantity empty.
        /// </remarks>
        /// <returns></returns>
        private void btnAddOrderItem_Click(object sender, RoutedEventArgs e)
        {
            if (dgItems.SelectedItem == null)
            {
                "You must have an item selected.".ErrorMessage();
            }
            if (txtQty == null || txtQty.Text == "0")
            {
                "You must enter a quantity".ErrorMessage();
            }
            else
            {
                try
                {
                    Int32.Parse(txtQty.Text);
                    if (Int32.Parse(txtQty.Text) < 20)
                    {
                        try
                        {
                            _item = (Item)dgItems.SelectedItem;
                            _orderItemLine = new OrderItemLine
                            {
                                OrderID = _order.OrderID,
                                ItemID = _item.ItemID,
                                Quantity = Int32.Parse(txtQty.Text)
                            };

                            _orderItemLineManager.AddOrderItemLine(_orderItemLine);

                            // After the item has been added to the OrderItem Datagrid, remove it from the item datagrid.
                            Item item = new Item();
                            item = _item;
                            item.ItemQuantity = Int32.Parse(txtQty.Text);
                            _orderItems.Add(item);
                            dgItems.Items.Refresh();
                            dgOrderItems.Items.Refresh();

                        }
                        catch
                        {
                            "Could not Add Item to Order".ErrorMessage();
                        }
                    }
                    else
                    {
                        "Cannot be greater than 20".ErrorMessage();
                    }
                }
                catch
                {
                    "Not a number".ErrorMessage();
                }
                txtQty.Text = "";
            }
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/27/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// Formate Item datagrid
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void dgItems_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgItems.Columns[0].Visibility = Visibility.Hidden;
            dgItems.Columns[1].Header = "Item Name";
            dgItems.Columns[2].Header = "Quantity";
            dgItems.Columns[3].Header = "Threshold";
            dgItems.Columns[4].Visibility = Visibility.Hidden;
            dgItems.Columns[5].Header = "Description";
            dgItems.Columns[6].Visibility = Visibility.Hidden;
            dgItems.Columns[0].Header = "Shelter Item";
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/27/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// action to edit the order when edit ordre is clicked
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void btnEditOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _newOrder = new Order()
                {
                    OrderID = Int32.Parse(txtOrderID.Text),
                    UserID = Int32.Parse(txtUserID.Text),
                    Active = true
                };
                _orderManager.EditOrder(_order, _newOrder);
                "Order Was Changed".SuccessMessage();
                this.NavigationService?.Navigate(new ViewOrders());
            }
            catch
            {
                "Could not edit order".ErrorMessage();
            }
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/27/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// Formate Order Items datagrid
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void dgOrderItems_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgOrderItems.Columns[0].Visibility = Visibility.Hidden;
            dgOrderItems.Columns[1].Header = "Item Name";
            dgOrderItems.Columns[2].Header = "Quantity";
            dgOrderItems.Columns[3].Header = "Threshold";
            dgOrderItems.Columns[4].Visibility = Visibility.Hidden;
            dgOrderItems.Columns[5].Header = "Description";
            dgOrderItems.Columns[6].Visibility = Visibility.Hidden;
            dgOrderItems.Columns[0].Header = "Shelter Item";
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/27/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// Remove Orderitem line from order when remove item is clicked
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void btnDeleteOrderItem_Click(object sender, RoutedEventArgs e)
        {
            if(dgOrderItems.SelectedItem != null)
            {
                try
                {
                    _item = (Item)dgOrderItems.SelectedItem;
                    _orderItemLineManager.DeleteOrderItemLineByItemID(_item.ItemID);
                    _orderItems.Remove(_item);
                    dgOrderItems.Items.Refresh();
                }
                catch
                {
                    "Unable to remove Item from order".ErrorMessage();
                }
            }
            else
            {
                "You must select an Item to remove.".ErrorMessage();
            }
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/27/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// populate datagrids on page load
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgOrderItems.ItemsSource = _orderItems;
            dgItems.ItemsSource = _items;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/15/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// Helper method to refresh the order item lines datagirid
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void RefreshOrderItemLines()
        {
            _items = _itemManager.retrieveItems();
            try
            {
                List<OrderItemLine> lines = (List<OrderItemLine>)_orderItemLineManager.SelectOrderItemLinesByOrderID(_order.OrderID);
                if (lines.Count > 0)
                {
                    foreach (OrderItemLine _orderItemLine in lines)
                    {
                        _orderItems.Add(_itemManager.SelectItemByItemID(_orderItemLine.ItemID));
                    }
                }
            }
            catch
            {
                if (dgOrderItems.ItemsSource != null)
                {
                    "Could not load order item lines".ErrorMessage();
                }
            }
        }
    }
}
