using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Zach
    /// Created: 03/16/2020
    /// Approver: Steven Cardona
    /// 
    /// Data Access Fake for Accessing Messages
    /// </summary>
    public class FakeMessageAccessor : IMessagesAccessor
    {

        private List<string> _departments = new List<string>();
        private List<string> _users = new List<string>();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Constructor for FakeMessageAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>                 
        public FakeMessageAccessor()
        {
            _departments.Add("Test1");
            _users.Add("Test1");
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Fake logic to get departments like provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>   
        public List<string> GetDepartmentsLikeInput(string Input)
        {
            List<string> emptyList = new List<string>();
            if (Input != null)
            {
                return _departments;
            }
            else
            {
                return emptyList;
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Fake logic to get messages for a user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="RecipientID"></param>
        /// <returns></returns>
        public List<Messages> GetMessagesByRecipient(int RecipientID)
        {
            List<Messages> _messages = new List<Messages>();

            Messages messageToAdd = new Messages()
            {
                MessageID = 100000,
                MessageBody = "Test",
                MessageSubject = "Test",
                SenderID = 100000,
                RecipientID = 100001,
                Seen = false
            };

            if (RecipientID >= 100000)
            {
                _messages.Add(messageToAdd);
            }

            return _messages;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Fake logic to get users like provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="Input"></param>
        /// <returns>List of user like the input</returns>
        public List<string> GetUsersLikeInput(string Input)
        {
            List<string> emptyList = new List<string>();
            if (Input != null)
            {
                return _users;
            }
            else
            {
                return emptyList;
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Fake logic to Send Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="content"></param>
        /// <param name="subject"></param>
        /// <param name="senderID"></param>
        /// <param name="recieverID"></param>
        /// <returns>Boolean value of email being sent</returns>
        public bool sendEmail(string content, string subject, int senderID, int recieverID)
        {
            if (content != "" && subject != "" && senderID != 0 && recieverID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Set a message seen
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="MessageID"></param>
        /// <returns>Boolean value of setting message seen</returns>
        public bool setMessageSeen(int MessageID)
        {
            if (MessageID >= 10000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
