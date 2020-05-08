namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Zoey McDonald
    /// DATE: 2/7/2020
    /// CHECKED BY: Ethan Holmes
    /// 
    /// This is a class for instantiating a volunteer event object.
    /// 
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATED DATE: N/A
    /// WHAT WAS CHANGED: N/A
    /// </remarks>
    public class VolunteerEvent
    {
        public int VolunteerEventID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public bool Active { get; set; }
    }
}
