using System.Collections.Generic;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Gabi L, Ethan H
    /// This is a data object class for Volunteer Records
    /// contains the attributes of what a volunteer "is"
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED: 
    /// </remarks>
    public class Volunteer
    {
        public int VolunteerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OtherNotes { get; set; }
        public bool Active { get; set; }
        public List<string> Skills { get; set; }
    }
}
