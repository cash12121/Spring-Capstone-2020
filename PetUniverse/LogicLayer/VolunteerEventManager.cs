using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Zoey McDonald
    /// DATE: 2/7/2020
    /// CHECKED BY: Ethan Holmes
    /// 
    /// This is a manager class for the volunteer manager to work with volunteer events. 
    /// 
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATED DATE: N/A
    /// WHAT WAS CHANGED: N/A
    /// </remarks>
    public class VolunteerEventManager : IVolunteerEventManager
    {
        IVolunteerEventAccessor _accessor;

        public VolunteerEventManager()
        {
            _accessor = new VolunteerEventAccessor();
        }

        public VolunteerEventManager(IVolunteerEventAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is a method for the volunteer event manager to insert a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public int InsertVolunteerEvent(VolunteerEventVM volunteerEvent)
        {
            int rows = 0;
            try
            {
                rows = _accessor.InsertVolunteerEvent(volunteerEvent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is a method for the volunteer event manager to update a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public int UpdateVolunteerEvent(VolunteerEvent oldVolunteerEvent, VolunteerEvent newVolunteerEvent)
        {
            int rows = 0;
            try
            {
                rows = _accessor.UpdateVolunteerEvent(oldVolunteerEvent, newVolunteerEvent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is a method for the volunteer event manager to remove a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public int RemoveVolunteerEvent(int volunteerEventID)
        {
            int rows = 0;
            try
            {
                rows = _accessor.RemoveVolunteerEvent(volunteerEventID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is a method for the volunteer event manager to return all volunteer events.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public List<VolunteerEvent> ReturnAllVolunteerEvents()
        {
            List<VolunteerEvent> volunteerEvents = new List<VolunteerEvent>();

            try
            {
                volunteerEvents = _accessor.SelectAllEvents();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return volunteerEvents;
        }
    }
}
