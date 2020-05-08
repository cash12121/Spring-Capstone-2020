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
	public class ApplicationEducation
	{
		public int ApplicationID { get; set; }
		public string SchoolName { get; set; }
		public string SchoolType { get; set; }
		public string City { get; set; }
		public string State { get; set; }
	}
}
