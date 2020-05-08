using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/19/2020
    /// CHECKED BY: Michael Thompson
    /// 
    /// contains manager methods that interact with adoption application objects
    /// </summary>
    public class AdoptionApplicationManager : IAdoptionApplicationManager
    {
        IAdoptionApplicationAccessor _adoptionApplicationAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Default constructor
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionApplicationManager()
        {
            _adoptionApplicationAccessor = new AdoptionApplicationAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Constructor used for tests
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionApplicationManager(IAdoptionApplicationAccessor adoptionApplicationAccessor)
        {
            _adoptionApplicationAccessor = adoptionApplicationAccessor;
        }

        public bool AddAdoptionApplication(Application application)
        {
            try
            {
                return 1 == _adoptionApplicationAccessor.InsertAdoptionApplication(application);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/22/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Deactivates an adoption application by id
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        public bool DeactivateAdoptionApplication(int adoptionApplicationID)
        {
            try
            {
                return 1 == _adoptionApplicationAccessor.DeactivateAdoptionApplication(adoptionApplicationID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Adoption application was not deactivated", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/11/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Retrieves adoption application by ID from the data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        public ApplicationVM RetrieveAdoptionApplicationByID(int adoptionApplicationID)
        {
            try
            {
                return _adoptionApplicationAccessor.SelectAdoptionApplicationByID(adoptionApplicationID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Retrieves adoption application by active
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<ApplicationVM> RetrieveAdoptionApplicationsByActive(bool active = true)
        {
            try
            {
                return _adoptionApplicationAccessor.SelectAdoptionApplicationsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/4/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Retrieves adoption application by active
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<ApplicationNameVM> RetrieveAdoptionApplicationsByActiveWithName(bool active)
        {
            try
            {
                return _adoptionApplicationAccessor.SelectAdoptionApplicationsByActiveWithName(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Retrieves adoption applications by email from the data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<ApplicationVM> RetrieveAdoptionApplicationsByEmailAndActive(string email, bool active = true)
        {
            try
            {
                return _adoptionApplicationAccessor.SelectAdoptionApplicationsByEmail(email, active = true);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Updates an adoption application
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="oldApplication"></param>
        /// <param name="newApplication"></param>
        /// <returns></returns>
        public bool UpdateAdoptionApplication(Application oldApplication, Application newApplication)
        {
            try
            {
                return 1 == _adoptionApplicationAccessor.UpdateAdoptionApplication(oldApplication, newApplication);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found", ex);
            }
        }
    }
}
