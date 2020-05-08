using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/05
    /// Approver: Austin Gee, 2020/02/07
    /// This Class manage HomeInspector logic, and implements the 
    /// IHomeInspectorManager Interface
    /// </summary>
    public class HomeInspectorManager : IHomeInspectorManager
    {
        private IHomeInspectorAccessor _homeInspectorAccessor;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Austin Gee, 2020/02/07
        /// This is no argument Constructor method.
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format.
        /// </remarks> 
        public HomeInspectorManager()
        {
            _homeInspectorAccessor = new HomeInspectorAccessor();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/05
        /// Approver: Austin Gee, 2020/02/07
        /// This method is a constructor for the HomeInspectorManager. 
        /// Manager.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" IHomeInspectorAccessor"></param>
        /// <param name=" homeInspectorAccessor"></param>
        public HomeInspectorManager(IHomeInspectorAccessor homeInspectorAccessor)
        {
            _homeInspectorAccessor = homeInspectorAccessor;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/05
        /// Approver: Austin Gee, 2020/02/05
        /// This method for getting Adoption Applications by thier status, and 
        /// return a list of the Adoption Applications.
        /// </summary>
        /// <remarks>
        /// Updater : Mohamed Elamin
        /// Updated: 2020/04/22 
        /// Update: Fixed Comments format
        /// </remarks>    
        /// <returns>Adoption Applications list</returns>
        public List<AdoptionApplication> SelectAdoptionApplicationByStatus()
        {
            List<AdoptionApplication> adoptionApplications = null;
            try
            {
                adoptionApplications = _homeInspectorAccessor.SelectAdoptionApplicationsByStatus();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("List not Found", ex);
            }
            return adoptionApplications;
        }
    }
}
