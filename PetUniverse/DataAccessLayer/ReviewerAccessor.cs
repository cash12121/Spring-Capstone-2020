using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
	/// Creator: Awaab Elamin
	/// Created: 2020/02/04
	/// Approver: Mohamed Elamin
	/// Class contains all reviewer Accessor
	/// </summary>
    public class ReviewerAccessor : IAdoptionAccessor
    {
        public ReviewerAccessor()
        {
        }

        /// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/04
		/// Approver: Mohamed Elamin
		/// Update stauts of addoption application
		/// to "Interviewer" or Deny
		/// According to Reviewer Decision 
		/// </summary>
		/// <remarks>
		/// Updater: Awaab Elamin 
		/// Updated: 2020/03/03 
		/// Update: Update the status of the adoption application to any status that include in the 
		/// AdoptionApplicationTable.
		/// </remarks>   
		/// <param name="adoptionApplicationID"></param>
		/// <param name="decision"></param>
		/// <returns>row count</returns>
        public int changeAdoptionApplicationStatus(int adoptionApplicationID, string decision)
        {
            int count = 0;
            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_update_adoption_application_status";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AdoptionApplicationID", SqlDbType.Int);
            cmd.Parameters.Add("@status", SqlDbType.NVarChar, 100);

            cmd.Parameters["@AdoptionApplicationID"].Value = adoptionApplicationID;


            cmd.Parameters["@status"].Value = decision;

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        /// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/15
		/// Approver: Mohamed Elamin
		/// Retrieve Adoption Application for a customer from Customer Questionnar table
		/// by his ID.
		/// </summary>
		/// <remarks>
		/// Updater: Mohamed Elamin 
		/// Updated: 2020/04/21 
		/// Update: Fixed comments format.
		/// </remarks>
		/// <param name="customerEmail"></param>
		/// <returns>adoptionApplication</returns>
        public AdoptionApplication getAdoptionApplicationByCustomerEmail(string customerEmail)
        {
            AdoptionApplication adoptionApplication = new AdoptionApplication();

            //	var conn = DBConnection.GetConnection();
            //	string cmdText = @"sp_get_Adoption_Application_By_CustomerID";
            //	var cmd = new SqlCommand(cmdText, conn);
            //	cmd.CommandType = CommandType.StoredProcedure;

            //	cmd.Parameters.Add("@customerID", SqlDbType.Int);
            //	cmd.Parameters["@customerID"].Value = customerID;

            //	try
            //	{
            //		conn.Open();
            //		SqlDataReader reader = cmd.ExecuteReader();
            //		if (reader.HasRows)
            //		{
            //			while (reader.Read())
            //			{

            //				adoptionApplication.AdoptionApplicationID = reader.GetInt32(0);
            //				adoptionApplication.CustomerName = getCustomerLastName(customerID);
            //				adoptionApplication.AnimalName = getAnimalName(reader.GetInt32(1));
            //				adoptionApplication.Status = reader.GetString(2);
            //				adoptionApplication.RecievedDate = reader.GetDateTime(3);
            //			}
            //			reader.Close();
            //		}
            //	}
            //	catch (Exception)
            //	{

            //		throw;
            //	}
            //	finally
            //	{
            //		conn.Close();
            //	}
            return adoptionApplication;
        }

        /// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/15
		/// Approver: Mohamed Elamin
		/// Method to get all Adoption Applications.
		/// </summary>
		/// <remarks>
		/// Updater: Mohamed Elamin 
		/// Updated: 2020/04/21 
		/// Update: Fixed comments format.
		/// </remarks>
		/// <returns>adoptionApplications</returns>
        public List<AdoptionApplication> getAllAdoptionApplication()
        {
            List<AdoptionApplication> adoptionApplications = new List<AdoptionApplication>();

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_get_Adoption_Application";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AdoptionApplication adoptionApplication = new AdoptionApplication();
                        adoptionApplication.AdoptionApplicationID = reader.GetInt32(0);
                        adoptionApplication.CustomerEmail = reader.GetString(1);
                        adoptionApplication.AnimalName = reader.GetString(2);
                        adoptionApplication.Status = reader.GetString(3);
                        adoptionApplication.RecievedDate = reader.GetDateTime(4);
                        adoptionApplications.Add(adoptionApplication);
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return adoptionApplications;

        }
        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// retrieve the animal name from the animal table.
        /// </summary>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed comments format.
        /// <param name="animalID"></param>
        /// <returns>animalName</returns>
        private string getAnimalName(int animalID)
        {
            string animalName = "";
            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_get_animal_by_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@animalId", SqlDbType.Int);
            cmd.Parameters["@animalId"].Value = animalID;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Animal animal = new Animal();
                    animal.AnimalID = reader.GetInt32(0);
                    animal.AnimalName = reader.GetString(1);
                    animal.Dob = reader.GetDateTime(2);
                    animal.AnimalBreed = reader.GetString(3);
                    animal.ArrivalDate = reader.GetDateTime(4);
                    animal.CurrentlyHoused = reader.GetBoolean(5);
                    animal.Adoptable = reader.GetBoolean(6);
                    animal.Active = reader.GetBoolean(7);
                    animal.AnimalSpeciesID = reader.GetString(8);

                    animalName = animal.AnimalName;

                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return animalName;
        }

        /// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/04
		/// Approver: Mohamed Elamin
		/// Retrieve Customer record from customer table by his last name.
		/// </summary>
		/// <remarks>
		/// Updater: Mohamed Elamin 
		/// Updated: 2020/04/21 
		/// Update: Fixed comments format.
		/// </remarks>
		/// <param name="customerLastName"></param>
		/// <returns>ourCustomer</returns>
        public AdoptionCustomer getCustomerByCustomerName(string customerLastName)
        {
            AdoptionCustomer ourCustomer = new AdoptionCustomer();
            //List<AdoptionCustomer> customers = new List<AdoptionCustomer>();
            //var conn = DBConnection.GetConnection();
            //string cmdText = @"sp_select_all_active_users";
            //var cmd = new SqlCommand(cmdText, conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //try
            //{
            //	conn.Open();
            //	SqlDataReader reader = cmd.ExecuteReader();
            //	if (reader.HasRows)
            //	{
            //		while (reader.Read())
            //		{
            //			AdoptionCustomer activeCustomer = new AdoptionCustomer();
            //			activeCustomer.CustomerID = reader.GetInt32(0);
            //			activeCustomer.FirstName = reader.GetString(1);
            //			activeCustomer.LastName = reader.GetString(2);
            //			activeCustomer.PhoneNumber = reader.GetString(3);
            //			activeCustomer.Email = reader.GetString(4);
            //			activeCustomer.Active = true;
            //			customers.Add(activeCustomer);
            //		}
            //		reader.Close();
            //	}
            //	foreach (AdoptionCustomer customer in customers)
            //	{
            //		if (customer.LastName == customerLastName)
            //		{
            //			int customerID = getCustomerID(customer.CustomerID);
            //			ourCustomer = customer;
            //			ourCustomer.CustomerID = customerID;
            //		}
            //	}
            //}
            //catch (Exception)
            //{

            //	throw;
            //}
            //finally
            //{
            //	conn.Close();
            //}
            return ourCustomer;
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/25
        /// Approver: Mohamed Elamin
        /// Retrieve Customer id from customer table by his userID
        /// </summary>
        /// <remarks>
        /// Updated by : Awaab Elamin
        /// Updated: 2020/03/16
        /// After Customer Table updated in DB, we don not need to below method
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>customerID</returns> 
        //private int getCustomerID(int userID)
        //{
        //	int customerID = 0;
        //	List<AdoptionCustomer> customers = new List<AdoptionCustomer>();
        //	var conn = DBConnection.GetConnection();
        //	string cmdText = @"sp_get_CustomerID_By_User_ID";
        //	var cmd = new SqlCommand(cmdText, conn);
        //	cmd.CommandType = CommandType.StoredProcedure;
        //	cmd.Parameters.Add("@UserID", SqlDbType.Int);
        //	cmd.Parameters["@UserID"].Value = userID;
        //	try
        //	{
        //		conn.Open();
        //		SqlDataReader reader = cmd.ExecuteReader();
        //		if (reader.HasRows)
        //		{
        //			while (reader.Read())
        //			{
        //				customerID = reader.GetInt32(0);
        //			}
        //			reader.Close();
        //		}

        //	}
        //	catch (Exception)
        //	{

        //		throw;
        //	}
        //	finally
        //	{
        //		conn.Close();
        //	}
        //	return customerID;
        //}

        /// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/04
		/// Approver: Mohamed Elamin
		/// Retrieve the customer full name "first and last
		/// </summary>
		/// <remarks>
		/// Updater: Mohamed Elamin 
		/// Updated: 2020/04/21 
		/// Update: Fixed comments format.
		/// </remarks>
		///  /// <remarks>
		/// Updated by : Awaab Elamin
		/// Date: 3/16/2020
		/// After Customer Table updated in DB, we don not need to below method
		/// </remarks>
		/// <param name="customerID"></param>
		/// <returns> FirstName + Last name</returns>
        public string getCustomerLastName(int customerID)
        {
            String customerName = null;

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_select_CustomerName_by_CustomerID";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@customerId", SqlDbType.Int);
            cmd.Parameters["@CustomerID"].Value = customerID;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    customerName = reader.GetString(1);

                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return customerName;

        }

        /// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/15
		/// Approver: Mohamed Elamin 
		/// Retrieve Qyestionnar syntax  from General Questionnair by its ID.
		/// </summary>
		/// <remarks>
		/// Updater: Mohamed Elamin 
		/// Updated: 2020/04/21 
		/// Update: Fixed comments format.
		/// </remarks>
		/// <param name="questionID"></param>
		/// <returns>questionDescription</returns>
        public string getQestionDescription(int questionID)
        {
            String questionDescription = null;

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_get_question_description_by_questionId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int);
            cmd.Parameters["@QuestionID"].Value = questionID;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    questionDescription = reader.GetString(0);

                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return questionDescription;
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/15
        /// Approver: Mohamed Elamin 
        /// retrieve Customer Questionnair record from customers Questionnairs table by his ID.
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed comments format. 
        /// </remarks>
        /// <param name="customerID"></param>
        /// <returns>customerQuestionnars</returns>
        public List<CustomerQuestionnar> getCustomerQuestionnair(string customerEmail)
        {
            List<CustomerQuestionnar> customerQuestionnars = new List<CustomerQuestionnar>();
            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_get_Customer_Answer_By_CustomrEmail";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerEmail", customerEmail);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerQuestionnar customerQuestionnar
                            = new CustomerQuestionnar();
                        customerQuestionnar.QuestionDescription = reader.GetString(0);
                        customerQuestionnar.Answer = reader.GetString(1);
                        customerQuestionnars.Add(customerQuestionnar);
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return customerQuestionnars;
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/15
        /// Approver: Mohamed Elamin 
        /// Retrieve Questionnaes general questions table
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed comments format. 
        /// </remarks>
        /// <returns>questions</returns>
        public List<string> getAllQuestions()
        {
            List<string> questions = new List<string>();
            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_get_all_General_Questions";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        questions.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return questions;
        }

        /// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/03/06
		/// Approver: Mohamed Elamin 
		/// Retrieve Questionnaes general questions table
		/// </summary>
		/// <remarks>
		/// Updater: Mohamed Elamin 
		/// Updated: 2020/04/21 
		/// Update: Fixed comments format. 
		/// </remarks>
		/// <param name="adoptionApplication"></param>
		/// <returns>questions</returns>
		/// <returns>True or false depending if the record was inserted</returns>
        public bool insertAdoptionApplication(AdoptionApplication adoptionApplication)
        {
            bool result = false;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_new_adoptionApplication", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerEmail", adoptionApplication.CustomerEmail);
            cmd.Parameters.AddWithValue("@RecievedDate", adoptionApplication.RecievedDate);
            cmd.Parameters.AddWithValue("@Status", adoptionApplication.Status);
            cmd.Parameters.AddWithValue("@AnimalID", adoptionApplication.AnimalID);
            try
            {
                conn.Open();
                if ((int)cmd.ExecuteNonQuery() == 1)
                {
                    result = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/03/06
        /// Approver: Mohamed Elamin 
        /// Insert Questionnair in customer questionnair table
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed comments format. 
        /// </remarks>
        /// <returns>questionnair</returns>
        /// <returns>True or false depending if the record was inserted</returns>
        public bool inserQuestionnair(Questionnair questionnair)
        {
            bool result = false;
            //1\Connect to data base
            var conn = DBConnection.GetConnection();

            //2\A-Create a sqol command
            var cmd = new SqlCommand("sp_add_customer_questionnair", conn);

            //2-B classify the command type
            cmd.CommandType = CommandType.StoredProcedure;

            //2-b determine the paramerters values
            cmd.Parameters.AddWithValue("@CustomerEmail", questionnair.CustomerEmail);
            cmd.Parameters.AddWithValue("@AdoptionApplicationID", questionnair.AdoptionApplicationID);

            cmd.Parameters.AddWithValue("@Question1", questionnair.Question1);
            cmd.Parameters.AddWithValue("@Question2", questionnair.Question2);
            cmd.Parameters.AddWithValue("@Question3", questionnair.Question3);
            cmd.Parameters.AddWithValue("@Question4", questionnair.Question4);
            cmd.Parameters.AddWithValue("@Question5", questionnair.Question5);
            cmd.Parameters.AddWithValue("@Question6", questionnair.Question6);
            cmd.Parameters.AddWithValue("@Question7", questionnair.Question7);
            cmd.Parameters.AddWithValue("@Question8", questionnair.Question8);
            cmd.Parameters.AddWithValue("@Question9", questionnair.Question9);
            cmd.Parameters.AddWithValue("@Question10", questionnair.Question10);

            cmd.Parameters.AddWithValue("@Answer1", questionnair.Answer1);
            cmd.Parameters.AddWithValue("@Answer2", questionnair.Answer2);
            cmd.Parameters.AddWithValue("@Answer3", questionnair.Answer3);
            cmd.Parameters.AddWithValue("@Answer4", questionnair.Answer4);
            cmd.Parameters.AddWithValue("@Answer5", questionnair.Answer5);
            cmd.Parameters.AddWithValue("@Answer6", questionnair.Answer6);
            cmd.Parameters.AddWithValue("@Answer7", questionnair.Answer7);
            cmd.Parameters.AddWithValue("@Answer8", questionnair.Answer8);
            cmd.Parameters.AddWithValue("@Answer9", questionnair.Answer9);
            cmd.Parameters.AddWithValue("@Answer10", questionnair.Answer10);

            //3 A-try to connect to the data base
            try
            {
                conn.Open();
                //3 B- run the command
                if ((int)cmd.ExecuteNonQuery() == 1)
                {
                    result = true;
                }
            }
            catch (Exception )
            {

                result = false;
            }
            finally
            {
                //4- close the connection
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created:  2020/04/15
        /// Approver: Mohamed Elamin
        /// 
        /// Get all Animals
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <return>Animals Medicals Records</return>
        public List<AnimalMedical> getAllAnimals()
        {
            List<AnimalMedical> animals = new List<AnimalMedical>();
            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_get__all_animals_medical_Record";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AnimalMedical animal = new AnimalMedical();
                    animal.AnimalMedicalInfoID = reader.GetInt32(0);
                    animal.AnimalName = reader.GetString(1);
                    animal.SpayedNeutered = reader.GetBoolean(2);
                    animal.Vaccinations = reader.GetString(3);
                    animal.MostRecentVaccinationDate = reader.GetDateTime(4);
                    animal.AdditionalNotes = reader.GetString(5);
                    animal.UserFirstName = reader.GetString(6);
                    animal.UseLastrName = reader.GetString(7);

                    animals.Add(animal);
                }

            }
            reader.Close();
        }
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				conn.Close();
			}
			return animals;
        }
    }
}
