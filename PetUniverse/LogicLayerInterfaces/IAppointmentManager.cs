using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 2020/02/06
    /// Approver: Awaab Elamin
    /// 
    /// This interface class is used as an interface for the logic layer
    /// </summary>
    public interface IAppointmentManager
    {
        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/02/06
        /// Approver: Awaab Elamin
        /// This method retrieves all appointments
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments. 
        /// </remarks>
        /// <returns>A list of active appointments</returns>
        List<AppointmentLocationVM> RetrieveAllActiveAppointments();

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/04/12
        /// Approver: Michael Thompson 
        /// This method retrieves an appointment by its id
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments. And updated date format. 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns> An appointment by appointment ID</returns>
        AppointmentLocationVM RetrieveAppointmentByID(int id);

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/04/12
        /// Approver: Michael Thompson
        /// This method removes an appointment
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments. And updated date format. 
        /// </remarks>
        /// <param name="appointment"></param>
        /// <returns>rows count</returns>
        int RemoveAppointment(Appointment appointment);


        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/04/12
        /// Approver: Michael Thompson
        /// 
        /// This method adds an appointment
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments. 
        /// </remarks>
        /// <param name="appointment"></param>
        /// <returns>rows count</returns>
        int AddAppointment(Appointment appointment);

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/15/2020
        /// Approver: Michael Thompson
        /// This method updates an appointment
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments.  And updated date format 
        /// </remarks>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        /// <returns>rows count</returns>
        int EditAppointment(Appointment oldAppointment, Appointment newAppointment);
    }
}
