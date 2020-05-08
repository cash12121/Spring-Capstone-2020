using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 03/16/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Interface that defines method for user manager
    /// </summary>
    public interface IMessagesManager
    {

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona 
        ///
        /// Retrieves Departments like provided text
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="Input"></param>
        /// <returns></returns>
        List<string> RetrieveDepartmentsLikeInput(string Input);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        ///
        /// Retrieves users like provided text
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="Input"></param>
        /// <returns></returns>
        List<string> GetUsersLikeInput(string Input);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        ///
        /// Inserts messages
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="content"></param>
        /// <param name="subject"></param>
        /// <param name="senderID"></param>
        /// <param name="recieverID"></param>
        /// <returns></returns>
        bool sendEmail(string content, string subject, int senderID, int recieverID);


        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/27/2020
        /// Approver: Steven Cardona
        ///
        /// Get all messages for a recipient
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        List<Messages> GetMessagesByRecipient(int RecipientID);


        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/30/2020
        /// Approver: Steven Cardona
        /// 
        /// Logic to set message as viewed
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>  
        /// <param name="MessageID"></param>
        /// <returns>Boolean value of sent message</returns>
        bool setMessageSeen(int MessageID);

    }
}
