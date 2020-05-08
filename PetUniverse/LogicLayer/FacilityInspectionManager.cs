using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// Approver: 
    /// 
    /// Class to pass information from the Accessor to Presentation layer
    /// </summary>
    public class FacilityInspectionManager : IFacilityInspectionManager
    {

        public IFacilityInspectionAccessor _facilityInspectionAccessor;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver:
        /// 
        /// Constructor to instaniate instance variables
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityInspectionManager()
        {
            _facilityInspectionAccessor = new FacilityInspectionAccessor();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Constructor to instaniate instance variables to the parameter for the fake accessor
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionAccessor"></param>
        public FacilityInspectionManager(IFacilityInspectionAccessor facilityInspectionAccessor)
        {
            _facilityInspectionAccessor = facilityInspectionAccessor;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to add a FacilityInspectionRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspection"></param>
        /// <returns>true or false depending on if record was updated</returns>
        public bool AddFacilityInspectionRecord(FacilityInspection facilityInspection)
        {
            bool result = true;

            try
            {
                result = 1 == _facilityInspectionAccessor.InsertFacilityInspectionRecord(facilityInspection);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to create record!", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter, 3/18/2020
        /// 
        /// Method to Edit a facility inspection record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityInspection"></param>
        /// <param name="newFacilityInspection"></param>
        /// <returns>bool depending if record was successfully updated</returns>
        public bool EditFacilityInspection(FacilityInspection oldFacilityInspection, FacilityInspection newFacilityInspection)
        {
            bool result = false;

            try
            {
                result = 1 == _facilityInspectionAccessor.UpdateFacilityInspection(oldFacilityInspection, newFacilityInspection);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update Inspection Record Failed!", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to retrieve all FacilityInspection Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> RetrieveAllFacilityInspection(bool inspectionComplete)
        {
            try
            {
                return _facilityInspectionAccessor.SelectAllFacilityInspection(inspectionComplete);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to retrieve FacilityInspection Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionID"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> RetrieveFacilityInspectionByID(int facilityInspectionID, bool inspectionComplete)
        {
            try
            {
                return _facilityInspectionAccessor.SelectFacilityInspectionByID(facilityInspectionID, inspectionComplete);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to retrieve FacilityInspection Records by inspector name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="inspectorName"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> RetrieveFacilityInspectionByInspectorName(string inspectorName, bool inspectionComplete)
        {
            try
            {
                return _facilityInspectionAccessor.SelectFacilityInspectionByInspectorName(inspectorName, inspectionComplete);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to retrieve FacilityInspection Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> RetrieveFacilityInspectionByUserID(int userID, bool inspectionComplete)
        {
            try
            {
                return _facilityInspectionAccessor.SelectFacilityInspectionByUserID(userID, inspectionComplete);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }
    }
}
