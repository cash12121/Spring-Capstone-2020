using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Timothy Lickteig        
    /// Created: 04/27/2020
    /// Approver: Zoey McDonald
    /// 
    /// Class for emulating a database
    /// </summary>
    public class FakeFosterAppointmentAccessor : IFosterAppointmentAccessor
    {
        private List<FosterAppointment> appointments = 
            new List<FosterAppointment>();

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for deleting foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="fosterAppointmentID">The ID of the record to delete</param>
        /// <returns>The number of rows affected</returns>
        public int DeleteFosterAppointment(int fosterAppointmentID)
        {
            int rows = 0;
            FosterAppointment toDelete = new FosterAppointment()
            {
                FosterAppointmentID = 0
            };

            foreach (FosterAppointment appt in appointments)
            {
                if (appt.FosterAppointmentID == fosterAppointmentID)
                {
                    toDelete = appt;
                }
            }

            if (toDelete.FosterAppointmentID != 0)
            {
                rows = 1;
                appointments.Remove(toDelete);
            }

            return rows;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for inserting foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="appointment">The record to insert</param>
        /// <returns>The number of rows affected</returns>
        public int InsertFosterAppointment(FosterAppointment appointment)
        {            
            appointments.Add(appointment);
            return 1;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for selecting all foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>        
        /// <returns>The list of appointment records</returns>
        public List<FosterAppointmentVM> SelectAllFosterAppointments()
        {
            List<FosterAppointmentVM> appts = new List<FosterAppointmentVM>();

            foreach (FosterAppointment appointment in appointments)
            {
                appts.Add(new FosterAppointmentVM()
                {
                    VolunteerID = appointment.VolunteerID,
                    StartTime = appointment.StartTime,
                    EndTime = appointment.EndTime,
                    Description = appointment.Description
                });
            }

            return appts;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for updating foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="oldAppt">The old record</param>
        /// <param name="newAppt">The new record</param>
        /// <returns>The number of rows affected</returns>
        public int UpdateFosterAppointment(FosterAppointment oldAppt, FosterAppointment newAppt)
        {
            int rows = 0;
            int index = 0;

            foreach (FosterAppointment tempAppt in appointments)
            {
                if (tempAppt.FosterAppointmentID == oldAppt.FosterAppointmentID)
                {
                    rows = 1;
                    break;
                }
                index++;
            }

            if (rows == 1)
            {
                appointments[index] = newAppt;
            }
            return rows;
        }
    }
}
