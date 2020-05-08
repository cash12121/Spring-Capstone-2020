using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/13
    /// Approver: Cash Carlson
    /// 
    /// Fakes information for testing PromotionManager.
    /// </summary>
    public class FakePromotionAccessor : IPromotionAccessor
    {

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/04/07
        /// Approver: Rashsa Mohammed
        /// 
        /// Fake deactivates an active promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public int DeactivatePromo(Promotion promotion)
        {
            int rows = 0;

            if (promotion.Active == true)
            {
                rows++;
                promotion.Active = false;
            }

            return rows;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/13
        /// Approver: Cash Carlson
        /// 
        /// Fake inserts a new promotion.
        /// </summary>
        /// <param name="promotion"></param>
        /// <returns></returns>
        public int InsertNewPromotion(Promotion promotion)
        {
            int rows = 0;
            List<Promotion> promotions = new List<Promotion>();
            promotions.Add(promotion);
            if (promotions.Contains(promotion))
            {
                rows++;
            }
            return rows;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/04/07
        /// Approver: Rasha Mohammed
        /// 
        /// Fake reactivates a deactivated promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public int ReactivatePromo(Promotion promotion)
        {
            int rows = 0;

            if (promotion.Active == false)
            {
                rows++;
                promotion.Active = true;
            }

            return rows;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Fakes getting all of the promotions stored in the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public List<Promotion> SelectAllPromotions(bool onlyActive = true)
        {
            List<Promotion> promotions = new List<Promotion>();

            promotions.Add(new Promotion()
            {
                PromotionID = "TESTPROMO",
                PromotionTypeID = "Test Promo Type",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1D),
                Discount = .35M,
                Description = "Test promotion description.",
                Active = true,
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductID = "TESTPRODUCT",
                        ItemID = 100000,
                        Category = "Test Category",
                        Type = "Test Type",
                        Brand = "Test Brand",
                        Name = "Test Product",
                        Description = "Test product description",
                        Price = 1.00M,
                        Taxable = true
                    }
                }
            });

            return promotions;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/13
        /// Approver: Cash Carlson
        /// 
        /// Returns a list of fake promotion types.
        /// </summary>
        /// <returns></returns>
        public List<string> SelectAllPromotionTypes()
        {
            List<string> list = new List<string>();
            list.Add("Test Type");
            return list;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Fakes updating a promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="oldPromotion"></param>
        /// <param name="newPromotion"></param>
        /// <returns></returns>
        public int UpdatePromotion(Promotion oldPromotion, Promotion newPromotion)
        {
            int rows = 0;
            List<Promotion> promotions = new List<Promotion>();

            promotions.Add(oldPromotion);

            for (int i = 0; i < promotions.Count; i++)
            {
                if (promotions[i].PromotionID == oldPromotion.PromotionID
                    && promotions[i].PromotionTypeID == oldPromotion.PromotionTypeID
                    && promotions[i].StartDate == oldPromotion.StartDate
                    && promotions[i].EndDate == oldPromotion.EndDate
                    && promotions[i].Discount == oldPromotion.Discount
                    && promotions[i].Description == oldPromotion.Description
                    && promotions[i].Active == oldPromotion.Active)
                {
                    promotions[i] = newPromotion;
                    rows++;
                }
            }

            return rows;
        }


    }
}
