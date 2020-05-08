using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
	/// <summary>
	///CREATED BY: Matt Deaton
	///DATE CREATED: 2020-04-16
	///APPROVED BY:
	///
	/// The ApplicantVM that adds fields to the Applicant class to 
	/// be called when interviewing someone and any other processes 
	/// that deal with the application.
	///
	/// </summary>
	public class ApplicantVM : Applicant
	{
		public int ApplicationID { get; set; }
		public string InterviewNotes { get; set; }
		public DateTime? HomeCheckDate { get; set; }
		public string SchoolName { get; set; }
		public string SchoolLevel { get; set; }
		public string SchoolCity { get; set; }
		public string SchoolState { get; set; }
		public string ReferenceName { get; set; }
		public string ReferenceNameRelationship { get; set; }
		public string ReferenceNamePhoneNumber { get; set; }
		public string ReferenceNameEmail { get; set; }
		public string PreviousWorkName { get; set; }
		public string PreviousWorkType { get; set; }
		public string PreviousWorkCity { get; set; }
		public string PreviousWorkState { get; set; }
		public string ApplicantSkills { get; set; }
		public string ResumePath { get; set; }

	}// End class ApplicantVM : Applicant
}
