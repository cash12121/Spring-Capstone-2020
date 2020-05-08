using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/12/2020
    /// Approver: Michael Thompson
    /// 
    /// Interface for Locations
    /// </summary>
    public interface ILocationAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Inserts a location into the database
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="location"></param>
        /// <returns></returns>
        int InsertLocation(Location location);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// selects all locations
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<Location> SelectAllLocations();

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Selects a location by its id
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        Location SelectLocationByLocationID();

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Updates a location
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="oldLocation"></param>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        int UpdateLocation(Location oldLocation, Location newLocation);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Deletes a location
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="location"></param>
        /// <returns></returns>
        int DeleteLocation(Location location);
    }
}
