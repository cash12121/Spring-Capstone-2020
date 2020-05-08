using System;

namespace DataTransferObjects
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-02-05
    ///     CHECKED BY: Zoey McDonald
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class VolunteerShift
    {
        public int VolunteerShiftID { get; set; }

        public int VolunteerID { get; set; }

        public string ShiftTitle { get; set; }

        public bool IsSpecialEvent { get; set; }

        public DateTime VolunteerShiftDate { get; set; }

        public int ScheduleID { get; set; }

        public string ShiftNotes { get; set; }

        public int VolunteerTaskID { get; set; }

        public string Recurrance { get; set; }

        public string ShiftDescription { get; set; }

        public TimeSpan ShiftStartTime { get; set; }

        public TimeSpan ShiftEndTime { get; set; }
    }
}
