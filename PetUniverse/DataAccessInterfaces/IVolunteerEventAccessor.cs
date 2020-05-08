using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 2/7/2020
    /// Approver: Ethan Holmes
    /// 
    /// This is an interface class for the volunteer event accessor
    /// </summary>
    public interface IVolunteerEventAccessor
    {

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an accessor method for selecting all volunteer events.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        List<VolunteerEvent> SelectAllEvents();

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an accessor method for selecting volunteer events. NOT DONE YET.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        VolunteerEvent SelectEvent(int VolunteerEventID);

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an accessor method for inserting a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        int InsertVolunteerEvent(VolunteerEventVM volunteerEvent);

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an accessor method for removing a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        int RemoveVolunteerEvent(int volunteerEventID);

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an accessor method for updating a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        int UpdateVolunteerEvent(VolunteerEvent oldVolunteerEvent, VolunteerEvent newVolunteerEvent);
    }
}