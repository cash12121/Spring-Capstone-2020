using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver: Cash Carlson
    /// 
    /// Interaction logic for pgPromotion.xaml
    /// </summary>
    public partial class pgPromotion : Page
    {
        Frame _frame;
        IPromotionManager _promotionManager = new PromotionManager();
        List<Promotion> _promotions;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Default constructor
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public pgPromotion()
        {
            InitializeComponent();
            try
            {
                _promotions = _promotionManager.GetAllPromotions();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Failed to load promotions.", ex.GetType().ToString());
            }
            dgPromotions.ItemsSource = _promotions;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Constructor that takes a frame for navigation purposes.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="frame">Frame used for navigation.</param>
        public pgPromotion(Frame frame)
        {
            _frame = frame;
            InitializeComponent();
            try
            {
                _promotions = _promotionManager.GetAllPromotions(onlyActive: false);
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Failed to load promotions.", ex.GetType().ToString());
            }
            dgPromotions.ItemsSource = _promotions;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Navigates to the "add" version of the View/Add/Edit page
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPromotion_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new pgAddEditViewPromotion(_promotionManager, _frame));
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Handles column formating.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgPromotions_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string columnHeader = e.Column.Header.ToString();
            if (e.PropertyType == typeof(DateTime))
            {
                DataGridTextColumn col = e.Column as DataGridTextColumn;
                if (col != null)
                {
                    col.Binding.StringFormat = "MM/dd/yyyy";
                }
            }
            if (columnHeader.Equals("PromotionID"))
            {
                e.Column.Header = "Promotion ID";
            }
            else if (columnHeader.Equals("PromotionTypeID"))
            {
                e.Column.Header = "Discount Type";
            }
            else if (columnHeader.Equals("StartDate"))
            {
                e.Column.Header = "Start Date";
            }
            else if (columnHeader.Equals("EndDate"))
            {
                e.Column.Header = "End Date";
            }
            else if (columnHeader.Equals("Description"))
            {
                DataGridTextColumn col = e.Column as DataGridTextColumn;
                col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
            else if (columnHeader.Equals("Active"))
            {
                e.Column.Header = "Active";
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Allows for the viewing of promotion details.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void dgPromotions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgPromotions.SelectedItem != null)
            {
                _frame.Navigate(new pgAddEditViewPromotion(_promotionManager, _frame, (Promotion)dgPromotions.SelectedItem));
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Opens the window to edit a promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void btnEditPromotion_Click(object sender, RoutedEventArgs e)
        {
            if (dgPromotions.SelectedItem != null)
            {
                _frame.Navigate(new pgAddEditViewPromotion(_promotionManager, _frame, (Promotion)dgPromotions.SelectedItem, editMode: true));
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/04/07
        /// Approver: Rasha Mohammed
        /// 
        /// Changes button content depending on selected promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgPromotions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPromotions.SelectedItem != null)
            {
                Promotion promotion = dgPromotions.SelectedItem as Promotion;
                if (promotion.Active)
                {
                    btnTogglePromotionActive.Content = "Deactivate";
                }
                else
                {
                    btnTogglePromotionActive.Content = "Reactivate";
                }
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/07/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Switches the active status of seleceted promotion from datagrid.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        ///
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTogglePromotionActive_Click(object sender, RoutedEventArgs e)
        {
            if (dgPromotions.SelectedItem != null)
            {
                Promotion selectedPromotion = dgPromotions.SelectedItem as Promotion;
                switch (btnTogglePromotionActive.Content)
                {
                    case ("Deactivate"):
                        {
                            if (MessageBoxResult.Yes == MessageBox.Show("Deactivate selected promotion with ID: " + selectedPromotion.PromotionID
                                + "?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question))
                            {
                                try
                                {
                                    _promotionManager.TogglePromotionActive(selectedPromotion);
                                }
                                catch (Exception ex)
                                {
                                    WPFErrorHandler.ErrorMessage("Unable to deactivate promotion:\n\n" + ex.Message);
                                }
                            }
                            break;
                        }
                    case ("Reactivate"):
                        {
                            if (MessageBoxResult.Yes == MessageBox.Show("Reactivate selected promotion with ID: " + selectedPromotion.PromotionID
                                + "?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question))
                            {
                                try
                                {
                                    _promotionManager.TogglePromotionActive(selectedPromotion);
                                }
                                catch (Exception ex)
                                {
                                    WPFErrorHandler.ErrorMessage("Unable to reactivate promotion:\n\n" + ex.Message);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                _frame.Navigate(new pgPromotion(_frame));
            }
        }
    }
}
