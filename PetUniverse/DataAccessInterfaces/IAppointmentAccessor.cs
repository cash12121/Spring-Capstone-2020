using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 2020/02/06
    /// Approver: Awaab Elamin
    /// 
    /// This interface class is used as an interface for the Accessor Layer
    /// </summary>
    public interface IAppointmentAccessor
    {
        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/02/06
        /// Approver: Awaab Elamin
        /// This method selects all appointments
        /// </summary>        
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments. 
        ///  And updated the date format. 
        /// </remarks>
        /// <returns>A list of active appointments</returns>
        List<AppointmentLocationVM> SelectAllActiveAppointments();

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/04/12
        /// Approver: Michael Thompson
        /// This method selects an appointment by its id
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments.
        /// And updated the date format. 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns> An appointment by appointment ID</returns>
        AppointmentLocationVM SelectAppointmentByID(int id);

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/04/12
        /// Approver: Michael Thompson
        /// 
        /// This method deactivates an appointment
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments.
        /// And updated the date format. 
        /// </remarks>
        /// <param name="appointment"></param>
        /// <returns>rows count</returns>
        int DeactivateAppointment(Appointment appointment);

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created:2020/04/12
        /// Approver: Michael Thompson
        /// 
        /// This method inserts an appointment
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments.
        /// updated the date format .
        /// </remarks>
        /// <param name="appointment"></param>
        /// <param name=""></param>
        /// <returns>rows count</returns>
        int InsertAppointment(Appointment appointment);

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created:2020/04/12
        /// Approver: Michael Thompson
        /// 
        /// This method updates an appointment
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments.
        /// And  updated the date format. 
        /// </remarks>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        /// <returns>rows count</returns>
        int UpdateAppointment(Appointment oldAppointment, Appointment newAppointment);
    }
}