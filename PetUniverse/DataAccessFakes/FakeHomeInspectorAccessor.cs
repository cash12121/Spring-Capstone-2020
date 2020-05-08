using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/05
    /// Approver: Austin Gee, 2020/02/07
    /// This Class for creation a fake Adoption Applictions which will used 
    /// for testing Logic layer methodes.
    /// </summary>
    public class FakeAdoptionApplicationAccessor : IHomeInspectorAccessor
    {

        private List<AdoptionApplication> adoptionApplications = null;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// This is a Constructor method which has fake Adoption Application list. 
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        public FakeAdoptionApplicationAccessor()
        {
            adoptionApplications = new List<AdoptionApplication>()
            {
                new AdoptionApplication()
                {
                AdoptionApplicationID = 10001,
                CustomerEmail = "Romaine",
                AnimalName = "Pepe",
                Status = "inHomeInspection",
                RecievedDate = DateTime.Now,

                },

                new AdoptionApplication()
                {
                AdoptionApplicationID = 10002,
                CustomerEmail = "Jarvis",
                AnimalName = "Pete",
                Status = "facilitator",
                RecievedDate = DateTime.Now
                },

                new AdoptionApplication()
                {
                AdoptionApplicationID = 10007,
                CustomerEmail = "Jane",
                AnimalName = "Kadeeesa",
                Status = "inHomeInspection",
                RecievedDate = DateTime.Now
                },
            };
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// This is a  fake  Select Adoption Applications By Statusmethod. 
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <returns>fake list of Adoption Applications</returns>
        List<AdoptionApplication> IHomeInspectorAccessor.SelectAdoptionApplicationsByStatus()
        {

            return (from AdoptionApplication in adoptionApplications
                    where AdoptionApplication.Status == "inHomeInspection"
                    select AdoptionApplication).ToList();
        }
    }
}
