using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/7/2020
    /// Approver: Carl Davis 2/14/2020
    /// Approver: Chuck Baxter 2/14/2020
    /// 
    /// Interface for the vet appointment manager
    /// </summary>
    public interface IVetAppointmentManager
    {
        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Gets a list of all animal vet appointments
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal vet appointments</returns>
        List<AnimalVetAppointment> RetrieveAllVetAppointments();

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Retrieves vet appointments by an animals unique identifier
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalID">Animal ID to search</param>
        /// <returns>List of animal vet appointments</returns>
        List<AnimalVetAppointment> RetrieveVetAppointmentsByAnimalID(int animalID);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Retrieves vet appointments at a specific clinic address
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="clinicAddress">Clinic address to search</param>
        /// <returns>List of animal vet appointments</returns>
        List<AnimalVetAppointment> RetrieveAppointmentsByClinicAddress(string clinicAddress);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Retrieves vet appointments with a specific follow up date
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="followUp">Follow up date to search</param>
        /// <returns>List of animal vet appointments</returns>
        List<AnimalVetAppointment> RetrieveAppointmentsByFollowUpDate(DateTime followUp);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Retrieves vet appointments schedule with a specific vet
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="vetName">Vet name to search</param>
        /// <returns>List of animal vet appointments</returns>
        List<AnimalVetAppointment> RetrieveAppointmentsByVetName(string vetName);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Retrieves vet appointments at a specific date/time
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="appointmentDate">Date/time to search</param>
        /// <returns>List of animal vet appointments</returns>
        List<AnimalVetAppointment> RetrieveAppointmentsByDateTime(DateTime appointmentDate);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Retrieves vet appointments by an animals name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalName">Animal name to search</param>
        /// <returns>List of animal vet appointments</returns>
        List<AnimalVetAppointment> RetrieveAppointmentsByAnimalName(string animalName);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Retrieves vet appointments that contain part
        /// of the supplied animal name. Used for searching
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalName">Animal name to search</param>
        /// <returns>List of animal vet appointments</returns>
        List<AnimalVetAppointment> RetrieveAppointmentsByPartialAnimalName(string animalName);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Creates aninmal vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalVetAppointment">Animal vet appointment to add</param>
        /// <returns>Insert successful</returns>
        bool AddAnimalVetAppointmentRecord(AnimalVetAppointment animalVetAppointment);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver: 
        /// 
        /// Edits an existing animal vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldVetAppointment">Existing vet appointment</param>
        /// <param name="newVetAppointment">Updated vet appointment</param>
        /// <returns>Edit successful</returns>
        bool EditAnimalVetAppointmentRecord(AnimalVetAppointment oldVetAppointment,
            AnimalVetAppointment newVetAppointment);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/27/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Deletes an existing vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="vetAppointment">Record to be deleted</param>
        /// <returns>Delete successful</returns>
        bool RemoveAnimalVetAppointment(AnimalVetAppointment vetAppointment);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Retrieves vet appointments by active status
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active">Actie status</param>
        /// <returns>List of vet appointments</returns>
        List<AnimalVetAppointment> RetrieveVetAppointmentsByActive(bool active);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Activates an inactive vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// /// <param name="vetAppointment">Record to be updated</param>
        /// <returns>Update successful</returns>
        bool ActivateVetAppointment(AnimalVetAppointment vetAppointment);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Deactivates an active vet appointment
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="vetAppointment">Record to be updated</param>
        /// <returns>Update successful</returns>
        bool DeactivateVetAppointment(AnimalVetAppointment vetAppointment);
    }
}
