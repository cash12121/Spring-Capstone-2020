using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 03/16/2020
    /// Approver: Steven Cardona
    /// 
    /// Data Access Fake for Accessing Users
    /// </summary>
    public interface IMessagesAccessor
    {

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Logic to get departments like provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>   
        List<string> GetDepartmentsLikeInput(string Input);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Logic to get users like provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        List<string> GetUsersLikeInput(string Input);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Logic to send message
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        bool sendEmail(string content, string subject, int senderID, int recieverID);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/27/2020
        /// Approver: 
        /// 
        /// Logic to view messa
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>        
        List<Messages> GetMessagesByRecipient(int RecipientID);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/30/2020
        /// Approver: 
        /// 
        /// Logic to set message as viewed
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>  
        /// <param name="MessageID"></param>
        /// <returns>Boolean value to determine if message is viewed</returns>
        bool setMessageSeen(int MessageID);
    }
}
