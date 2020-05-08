using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;

namespace WPFPresentationLayer.PersonnelPages
{
	/// <summary>
	/// CREATED BY: Matt Deaton
	/// DATE CREATED: 2020-04-07
	/// APPROVED BY: Steve Coonrod
	/// 
	/// Class that is used with the InterviewApplicant Page
	/// 
	/// </summary>
	/// <remarks>
	/// UPDATED BY:
	/// UPDATED:
	/// CHANGE:
	/// </remarks>
	public partial class InterviewApplicant : Page
	{
		// Class variables used for methods in this class.
		private ApplicantVM _applicant = null;
		private IApplicantManager _applicantManager;

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Constructor for initializing and applicant and applicant manager object.
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		/// <param name="applicant"></param>
		/// <param name="applicantManager"></param>
		public InterviewApplicant(ApplicantVM applicant, IApplicantManager applicantManager)
		{
			InitializeComponent();
			_applicant = applicant;
			_applicantManager = applicantManager;
		}// End Constructor

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Method used for populating the ApplicationStatusComboBox
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		private void setApplicationStatusComboBox()
		{
			string[] status = new string[5]
			{
				"Approved",
				"Declined",
				"Pending Home Check",
				"Pending Interview",
				"Check Notes"
			};
			cboApplicationStatus.ItemsSource = status;
		}// End setApplicationStatusComboBox()

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Method used for loading all of the applicants information
		/// into the page.
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			// Populate Application Combo Box
			setApplicationStatusComboBox();

			// Date, Postion, APplication Number Labels
			lblInterviewDate.Content = DateTime.UtcNow;  // Gets the current Date to show when interview took place. 
			lblPositionName.Content = _applicant.ApplicationPostion.ToString();
			lblApplicationID.Content = _applicant.ApplicationID.ToString();

			// Interview Notes
			txtInterviewNotes.Text = _applicant.InterviewNotes.ToString();

			// Calendar will only appear if a Foster Home Check is needed to be scheduled
			// by using the Position Name of "Foster"
			if (lblPositionName.Content.ToString() == "Foster")
			{
				calHomeCheck.Visibility = Visibility.Visible;
				txtHomeCheckDate.Visibility = Visibility.Visible;
				lblHomeCheckDate.Visibility = Visibility.Visible;
				// Home Check Date
				txtHomeCheckDate.Text = _applicant.HomeCheckDate.Value.ToShortDateString();
				calHomeCheck.SelectedDate = _applicant.HomeCheckDate;
			}
			else
			{
				calHomeCheck.Visibility = Visibility.Hidden;
				txtHomeCheckDate.Visibility = Visibility.Hidden;
				lblHomeCheckDate.Visibility = Visibility.Hidden;
			}

			// Contact Information
			txtFirstName.Text = _applicant.FirstName.ToString();
			txtLastName.Text = _applicant.LastName.ToString();
			txtMiddleName.Text = _applicant.MiddleName.ToString();
			txtAddress.Text = _applicant.AddressLineOne.ToString() + " " + _applicant.AddressLineTwo.ToString();
			txtCity.Text = _applicant.City.ToString();
			txtState.Text = _applicant.State.ToString();
			txtEmail.Text = _applicant.Email.ToString();
			txtPhone.Text = _applicant.PhoneNumber.ToString();
			txtZip.Text = _applicant.Zipcode.ToString();

			// Education Information
			txtSchoolOneName.Text = _applicant.SchoolName.ToString();
			txtSchoolOneLevel.Text = _applicant.SchoolLevel.ToString();
			txtSchoolOneCity.Text = _applicant.SchoolCity.ToString();
			txtSchoolOneState.Text = _applicant.SchoolState.ToString();

			// References
			txtReferenceOneName.Text = _applicant.ReferenceName.ToString();
			txtReferenceOneRelationship.Text = _applicant.ReferenceNameRelationship.ToString();
			txtReferenceOneEmail.Text = _applicant.ReferenceNameEmail.ToString();
			txtReferenceOnePhone.Text = _applicant.ReferenceNamePhoneNumber.ToString();

			// Previous Experience
			txtPreviousWorkName.Text = _applicant.PreviousWorkName.ToString();
			txtPreviousWorkType.Text = _applicant.PreviousWorkType.ToString();
			txtPreviousWorkCity.Text = _applicant.PreviousWorkCity.ToString();
			txtPreviousWorkState.Text = _applicant.PreviousWorkState.ToString();

			// Skills
			txtSkills.Text = _applicant.ApplicantSkills.ToString();

			// Application Status
			cboApplicationStatus.Text = _applicant.ApplicantStatus;

			// Resume
			txtResumeFileName.Text = _applicant.ResumePath.ToString();

		}// End Page_Loaded

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Method used when the Save button is click. 
		/// Navigates back to ViewApplicants if all is saved correctly.
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (lblPositionName.Content.ToString() == "Foster")
				{
					editHomeCheckDate();
				}
				editInterviewNotes();
				if (cboApplicationStatus.Text == "Declined")
				{
					if (MessageBox.Show("Please call " + _applicant.FirstName + " " + _applicant.LastName +
						" at " + _applicant.PhoneNumber + "\nto inform them of job declined offer",
						"Decline Job Offer", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.Cancel)
					{
						return;
					};
				}
				if (cboApplicationStatus.Text == "Approved")
				{
					if (MessageBox.Show("Please call " + _applicant.FirstName + " " + _applicant.LastName +
						" at " + _applicant.PhoneNumber + "\nto inform them of APPROVAL for job!",
						"Approved Job Offer", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.Cancel)
					{
						return;
					};
				}
				editApplicationStatus();

				MessageBox.Show("Applicant Updated");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);
				return;
			}

			this.NavigationService?.Navigate(new ViewApplicants());
		}// End btnSave_Click()

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Method used for updating Home Check Date
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		private void editHomeCheckDate()
		{
			DateTime oldDate = _applicant.HomeCheckDate.Value;
			DateTime newDate = DateTime.Parse(calHomeCheck.SelectedDate.Value.ToShortDateString());

			try
			{
				_applicantManager.EditHomeCheckDate(_applicant.ApplicantID, oldDate, newDate);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
			}
		}// End editHomeCheckDate

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Method used for updating Interview Notes
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		private void editInterviewNotes()
		{
			string oldNotes = _applicant.InterviewNotes.ToString();
			string newNotes = txtInterviewNotes.Text.ToString();
			try
			{
				_applicantManager.EditInterviewNotes(_applicant.ApplicantID, oldNotes, newNotes);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
			}
		}// End editInterviewNotes()

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Method used for Updating the Application Status
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		private void editApplicationStatus()
		{
			string oldStatus = _applicant.ApplicantStatus.ToString();
			string newStatus = cboApplicationStatus.Text;
			try
			{
				_applicantManager.EditApplicationStatus(_applicant.ApplicantID, oldStatus, newStatus);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
			}
		}// End editApplicationStatus()

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Method used for getting the applicants resume.
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnViewResume_Click(object sender, RoutedEventArgs e)
		{
			// Create OpenFileDialog
			Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

			// Launch OpenFileDialog by calling ShowDialog method
			Nullable<bool> result = openFileDlg.ShowDialog();

			if (result == true)
			{
				string usersFilePath = openFileDlg.FileName;
				string shortFilePath = usersFilePath.Substring(usersFilePath.LastIndexOf('\\'));

				// Get the selected file name and display in a TextBox.
				txtResumeFileName.Text = shortFilePath;
			}
		}// End btnViewResume_Click()

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Method used highlighting the date on the calander.
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void calHomeCheck_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			DateTime selectedDate = calHomeCheck.SelectedDate.Value;

			txtHomeCheckDate.Text = selectedDate.ToShortDateString();
		}// End calHomeCheck_SelectedDatesChanged()

		/// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE CREATED: 2020-04-07
		/// APPROVED BY: Steve Coonrod
		/// 
		/// Method used for the cancel button, that navigates back to the ViewAplicants page.
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService?.Navigate(new ViewApplicants());
		}// End btnCancel_Click()

	}// End class InterviewApplicant

}// End namespace WPFPresentationLayer.PersonnelPages
