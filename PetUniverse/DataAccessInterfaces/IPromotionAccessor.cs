using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver: Cash Carlson
    /// 
    /// Interface for promotion accessor.
    /// </summary>
    public interface IPromotionAccessor
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Method to add a new promotion to the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="promotion">The promotion to be added.</param>
        /// <returns>Int number of rows affected (should be 1)</returns>
        int InsertNewPromotion(Promotion promotion);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Method to get all of the IDs of all PromotionTypes from the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// 
        /// </remarks>
        /// <returns>List of promotion types</returns>
        List<string> SelectAllPromotionTypes();

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Interface for a method to select all of the promotions in the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="onlyActive">Bool for whether or not to get deactivated promotions.</param>
        /// <returns></returns>
        List<Promotion> SelectAllPromotions(bool onlyActive = true);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Interface for a method to update a promotion.
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
        int UpdatePromotion(Promotion oldPromotion, Promotion newPromotion);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/04/07
        /// Approver: Rasha Mohammed
        /// 
        /// Interface for a method to deactivate a promo.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="promotion"></param>
        /// <returns></returns>
        int DeactivatePromo(Promotion promotion);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/04/07
        /// Approver: Rasha Mohammed
        /// 
        /// Interface for a method to reactivate a promo.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="promotion"></param>
        /// <returns></returns>
        int ReactivatePromo(Promotion promotion);
    }
}
