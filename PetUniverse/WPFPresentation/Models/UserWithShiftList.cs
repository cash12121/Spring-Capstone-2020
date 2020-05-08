using DataTransferObjects;
using System.Collections.Generic;

namespace WPFPresentation.Models
{
    public class UserWithShiftList
    {
        public List<ShiftVM> UserShiftList { get; set; }

        public int UserID { get; set; }
    }
}