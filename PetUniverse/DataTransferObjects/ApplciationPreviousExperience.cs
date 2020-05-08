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
	public class ApplicationPreviousExperience
	{
		public int ApplicationID { get; set; }
		public string LocationName { get; set; }
		public string City { get; set; }
		public string State { get; set; }
	}
}
