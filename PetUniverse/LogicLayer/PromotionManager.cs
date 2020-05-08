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
    /// Created: 2020/03/10
    /// Approver: Cash Carlson
    /// 
    /// Concrete implementation of a class for transfer of promotion data from the database to the presentation layer and vice versa.
    /// </summary>
    public class PromotionManager : IPromotionManager
    {
        private IPromotionAccessor _promotionAccessor;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Initializes object with real data.
        /// </summary>
        public PromotionManager()
        {
            _promotionAccessor = new PromotionAccessor();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Initializes object with alternative data source for testing.
        /// </summary>
        /// <param name="promotionAccessor"></param>
        public PromotionManager(IPromotionAccessor promotionAccessor)
        {
            _promotionAccessor = promotionAccessor;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Method to add a new promotion to the database.
        /// </summary>
        /// <param name="promotion">The promotion to add to the database</param>
        /// <returns>true if the accessor method returns 1 for rows affected</returns>
        public bool AddPromotion(Promotion promotion)
        {
            bool success = false;

            try
            {
                success = (1 == _promotionAccessor.InsertNewPromotion(promotion));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// SQLEXPRESS implementation of editing a promotion.
        /// </summary>
        /// <param name="oldPromotion"></param>
        /// <param name="newPromotion"></param>
        /// <returns></returns>
        public bool EditPromotion(Promotion oldPromotion, Promotion newPromotion)
        {
            bool success = false;

            try
            {
                success = (1 == _promotionAccessor.UpdatePromotion(oldPromotion, newPromotion));
            }
            catch (Exception)
            {
                throw;
            }

            return success;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Gets all active promotions from database, or all promotions is onlyActive = false.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <returns>List of promotions.</returns>
        public List<Promotion> GetAllPromotions(bool onlyActive = true)
        {
            List<Promotion> promotions = new List<Promotion>();

            try
            {
                promotions = _promotionAccessor.SelectAllPromotions(onlyActive);
            }
            catch (Exception)
            {
                throw;
            }

            return promotions;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Retrieves all promotions types.
        /// </summary>
        /// <returns>List of promotion types</returns>
        public List<string> GetAllPromotionTypes()
        {
            return _promotionAccessor.SelectAllPromotionTypes();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/04/07
        /// Approver: Rahsa Mohammed
        /// 
        /// Calls the appropriate Data Access layer method to activate/deactivate depending on the status of the promotion.
        /// </summary>
        /// <param name="promotion"></param>
        /// <returns></returns>
        public bool TogglePromotionActive(Promotion promotion)
        {
            bool success = false;

            try
            {
                if (promotion.Active)
                {
                    success = (1 == _promotionAccessor.DeactivatePromo(promotion));
                }
                else
                {
                    success = (1 == _promotionAccessor.ReactivatePromo(promotion));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return success;
        }
    }
}
