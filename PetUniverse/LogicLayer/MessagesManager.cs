using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 03/16/2020
    /// Approver: Steven Cardona
    ///
    /// Class to manage messages implements the IMessagesManager Interface
    /// </summary>
    public class MessagesManager : IMessagesManager
    {

        private IMessagesAccessor _messagesAccessor;

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Default constructor for the Messages Manager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public MessagesManager()
        {
            _messagesAccessor = new MessagesAcessor();
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Fakes constructor for the Messages Manager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="MessagesAccessor"></param>
        public MessagesManager(IMessagesAccessor MessagesAccessor)
        {
            _messagesAccessor = MessagesAccessor;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/01/2020
        /// Approver: Steven Cardona
        /// 
        /// Logic to get messages by recipient
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
            List<Messages> results = new List<Messages>();

            {
                try
                {
                    results = _messagesAccessor.GetMessagesByRecipient(RecipientID);
                }
                catch (Exception ex)
                {
                    throw new Exception("Messages not found", ex);
                }
            }
            return results;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager Method to retrieve users similar to the provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<string> GetUsersLikeInput(string Input)
        {
            List<string> results = new List<string>();

            if (Input != "")
            {
                try
                {
                    results = _messagesAccessor.GetUsersLikeInput(Input);
                }
                catch (Exception ex)
                {
                    throw new Exception("Users not found", ex);
                }
            }
            return results;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager Method to retrieve deaprtments similar to the provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<string> RetrieveDepartmentsLikeInput(string Input)
        {
            List<string> results = new List<string>();

            if (Input != "")
            {
                try
                {
                    results = _messagesAccessor.GetDepartmentsLikeInput(Input);
                }
                catch (Exception ex)
                {
                    throw new Exception("Departments not found", ex);
                }
            }
            return results;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager Method to insert message
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
        /// <returns>boolean value if sendEmail returns true</returns>
        public bool sendEmail(string content, string subject, int senderID, int recieverID)
        {
            bool sent = false;

            try
            {
                sent = _messagesAccessor.sendEmail(content, subject, senderID, recieverID);
            }
            catch (Exception ex)
            {
                throw new Exception("Message could not be sent", ex);
            }
            return sent;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/01/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager Method to set a message as seen
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="MessageID"></param>
        /// <returns></returns>
        public bool setMessageSeen(int MessageID)
        {
            bool seen = false;

            try
            {
                seen = _messagesAccessor.setMessageSeen(MessageID);
            }
            catch (Exception ex)
            {
                throw new Exception("Message could not be marked as seen", ex);
            }
            return seen;
        }
    }
}
