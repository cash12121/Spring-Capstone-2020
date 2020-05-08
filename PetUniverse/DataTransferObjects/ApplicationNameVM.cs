using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/20/2020
    /// CHECKED BY: Michael Thompson
    /// 
    /// This data access class is used to access data that pertains to the Adoption Appointment.
    /// </summary>
    public class ApplicationNameVM : ApplicationVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
