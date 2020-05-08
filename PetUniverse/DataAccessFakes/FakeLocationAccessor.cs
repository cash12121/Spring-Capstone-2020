using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/19/2020
    /// Approver: Micheal Thompson 
    /// 
    /// Location Data access Fake
    /// </summary>
    public class FakeLocationAccessor : ILocationAccessor
    {

        private List<Location> _locations;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/19/2020
        /// Approver: Micheal Thompson 
        /// 
        /// No arg constructor
        /// </summary>
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public FakeLocationAccessor()
        {
            _locations = new List<Location>()
            {
                new Location()
                {
                    LocationID = 000,
                    Name = "Fake",
                    Address1 = "Fake",
                    Address2 = "Fake",
                    City = "Fake",
                    State = "Fake",
                    Zip = "Fake"
                },

                new Location()
                {
                    LocationID = 001,
                    Name = "Fake",
                    Address1 = "Fake",
                    Address2 = "Fake",
                    City = "Fake",
                    State = "Fake",
                    Zip = "Fake"
                },

                new Location()
                {
                    LocationID = 002,
                    Name = "Fake",
                    Address1 = "Fake",
                    Address2 = "Fake",
                    City = "Fake",
                    State = "Fake",
                    Zip = "Fake"
                }
            };
        }

        //Adoptions needs to implement this method.
        public int DeleteLocation(Location location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/19/2020
        /// Approver: Micheal Thompson 
        /// 
        /// Inserts a location in the fakes
        /// </summary>
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int InsertLocation(Location location)
        {
            int result = 0;

            try
            {
                _locations.Add(location);
                result = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/19/2020
        /// Approver: Micheal Thompson 
        /// 
        /// Selects all locations
        /// </summary>
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Location> SelectAllLocations()
        {
            return _locations;
        }

        //Adoptions needs to implement this method.
        public Location SelectLocationByLocationID()
        {
            throw new NotImplementedException();
        }

        //Adoptions needs to implement this method.
        public int UpdateLocation(Location oldLocation, Location newLocation)
        {
            throw new NotImplementedException();
        }
    }
}
