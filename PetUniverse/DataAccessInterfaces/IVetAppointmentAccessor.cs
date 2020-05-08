using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/7/2020
    /// Approver: Carl Davis 2/14/2020
    /// Approver: Chuck Baxter 2/14/2020
    /// 
    /// An interface for the Vet Appointment Accessor
    /// </summary>
    public interface IVetAppointmentAccessor
    {

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Gets all animal vet appointment records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal vet appointment</returns>
        List<AnimalVetAppointment> SelectAllVetAppointments();

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Creates a vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalVetAppointment">An AnimalVetAppointment object</param>
        /// <returns>Insert succesful</returns>
        bool InsertVetAppointment(AnimalVetAppointment animalVetAppointment);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// 
        /// Updates an existing vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalVetAppointment">The existing record</param>
        /// <param name="newAnimalVetAppointment">The updated record</param>
        /// <returns>Insert succesful</returns>
        bool UpdateVetAppointment(AnimalVetAppointment oldAnimalVetAppointment,
            AnimalVetAppointment newAnimalVetAppointment);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/27/2020
        /// Approver:
        /// 
        /// Deletes an existing animal vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="vetAppointment">Record to be deleted</param>
        /// <returns>Rows affected</returns>
        int DeleteAnimalVetAppointment(AnimalVetAppointment vetAppointment);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Selects all vet appointments record by active/inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active">Active status</param>
        /// <returns>List of vet appointment</returns>
        List<AnimalVetAppointment> SelectVetAppointmentsByActive(bool active);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Sets vet appointment to active or inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="vetAppointment">Record to change</param>
        /// <param name="active">State to be changed to</param>
        /// <returns>Rows affected</returns>
        int SetVetAppointmentActiveStatus(AnimalVetAppointment vetAppointment, bool active);
    }
}