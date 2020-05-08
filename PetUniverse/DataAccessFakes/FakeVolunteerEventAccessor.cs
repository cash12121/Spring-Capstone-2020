using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 2/7/2020
    /// Approver: Ethan Holmes
    /// 
    /// This is a fake accessor class for a volunteer event.
    /// </summary>
    public class FakeVolunteerEventAccessor : IVolunteerEventAccessor
    {

        private List<VolunteerEvent> _volunteerEvents = new List<VolunteerEvent>();
        private List<VolunteerEventVM> _volunteerEventVMs = new List<VolunteerEventVM>();

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Apprvoer: Ethan Holmes
        /// 
        /// This is an fake accessor method for adding a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public FakeVolunteerEventAccessor()
        {
            _volunteerEvents.Add(new VolunteerEvent()
            {
                VolunteerEventID = 1,
                EventName = "Dog Party",
                EventDescription = "It's a dog party."
            });

            _volunteerEvents.Add(new VolunteerEvent()
            {
                VolunteerEventID = 2,
                EventName = "Cat Party",
                EventDescription = "It's a cat party."
            });


            _volunteerEvents.Add(new VolunteerEvent()
            {
                VolunteerEventID = 100000,
                EventName = "fake event",
                EventDescription = "YEET"
            });

            _volunteerEventVMs.Add(new VolunteerEventVM()
            {

                EventName = "fake event",
                EventDescription = "YEET",
                Active = true
            });
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an fake accessor method for inserting a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int InsertVolunteerEvent(VolunteerEventVM volunteerEvent)
        {
            _volunteerEventVMs.Add(volunteerEvent);
            return 1;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an fake accessor method for removing a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int RemoveVolunteerEvent(int volunteerEventID)
        {
            int rows = 0;

            VolunteerEvent eventToRemove = new VolunteerEvent();

            foreach (VolunteerEvent volunteerEvent in _volunteerEvents)
            {
                if (volunteerEventID == volunteerEvent.VolunteerEventID)
                {
                    eventToRemove = volunteerEvent;
                    rows++;
                }
            }
            _volunteerEvents.Remove(eventToRemove);
            return rows;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an fake accessor method for selecting all volunteer events.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<VolunteerEvent> SelectAllEvents()
        {
            return _volunteerEvents;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an fake accessor method for selecting a volunteer event. NOT DONE YET.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public VolunteerEvent SelectEvent(int VolunteerEventID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 2/7/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is an fake accessor method for updating a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int UpdateVolunteerEvent(VolunteerEvent oldVolunteerEvent, VolunteerEvent newVolunteerEvent)
        {
            int rows = 0;
            int index = 0;

            foreach (VolunteerEvent tempEvent in _volunteerEvents)
            {
                if (tempEvent.VolunteerEventID == oldVolunteerEvent.VolunteerEventID)
                {
                    rows = 1;
                    break;
                }
                index++;
            }

            if (rows == 1)
            {
                _volunteerEvents[index] = newVolunteerEvent;
            }

            return rows;
        }
    }
}
