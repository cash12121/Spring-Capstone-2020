using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
	/// <summary>
	///CREATED BY: Derek Taylor
	///DATE CREATED: 4/28/2020
	///APPROVED BY:
	///
	/// The Job Application that contains the fields associated
	/// with an application.
	///
	/// </summary>
	public class ApplicationAvailability
	{
		public int ApplicationID { get; set; }
		public string DayOfWeek { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
	}
}
