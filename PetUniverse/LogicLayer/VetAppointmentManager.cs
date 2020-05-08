using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/7/2020
    /// Approver: Carl Davis 2/14/2020
    /// Approver: Chuck Baxter 2/14/2020
    /// 
    /// The manager class for animal vet appointments
    /// </summary>
    public class VetAppointmentManager : IVetAppointmentManager
    {
        private IVetAppointmentAccessor _vetAppointmentAccessor;
        private List<AnimalVetAppointment> _vetAppointments;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// A no argument constructor that intializes the vet appointment
        /// accessor and retrieves a list of all vet appointments
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public VetAppointmentManager()
        {
            _vetAppointmentAccessor = new VetAppointmentAccessor();
            _vetAppointments = RetrieveVetAppointmentsByActive(true);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Full constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="vetAppointmentAccessor">An instance of vet appointment accessor</param>
        /// <param name="appointments">A list of animal vet appointments</param>
        public VetAppointmentManager(IVetAppointmentAccessor vetAppointmentAccessor, List<AnimalVetAppointment> appointments)
        {
            _vetAppointmentAccessor = vetAppointmentAccessor;
            _vetAppointments = appointments;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Single argument constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="vetAppointmentAccessor">An instance of vet appointment accessor</param>
        public VetAppointmentManager(IVetAppointmentAccessor vetAppointmentAccessor)
        {
            _vetAppointmentAccessor = vetAppointmentAccessor;
        }

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
        public List<AnimalVetAppointment> RetrieveAllVetAppointments()
        {
            try
            {
                return _vetAppointments = _vetAppointmentAccessor.SelectAllVetAppointments();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't fetch data", ex);
            }
        }

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
        public List<AnimalVetAppointment> RetrieveAppointmentsByAnimalName(string animalName)
        {
            return (from b in _vetAppointments
                    where b.AnimalName.ToLower() == animalName.ToLower()
                    select b).ToList();
        }

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
        public List<AnimalVetAppointment> RetrieveAppointmentsByClinicAddress(string clinicAddress)
        {
            return (from b in _vetAppointments
                    where b.ClinicAddress.ToLower() == clinicAddress.ToLower()
                    select b).ToList();
        }

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
        public List<AnimalVetAppointment> RetrieveAppointmentsByDateTime(DateTime appointmentDate)
        {
            return (from b in _vetAppointments
                    where b.AppointmentDateTime == appointmentDate
                    select b).ToList();
        }

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
        public List<AnimalVetAppointment> RetrieveAppointmentsByFollowUpDate(DateTime followUp)
        {
            return (from b in _vetAppointments
                    where b.FollowUpDateTime == followUp
                    select b).ToList();
        }

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
        public List<AnimalVetAppointment> RetrieveAppointmentsByVetName(string vetName)
        {
            return (from b in _vetAppointments
                    where b.VetName.ToLower() == vetName.ToLower()
                    select b).ToList();
        }

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
        public List<AnimalVetAppointment> RetrieveVetAppointmentsByAnimalID(int animalID)
        {
            return (from b in _vetAppointments
                    where b.AnimalID == animalID
                    select b).ToList();
        }

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
        public bool AddAnimalVetAppointmentRecord(AnimalVetAppointment animalVetAppointment)
        {
            try
            {
                return _vetAppointmentAccessor.InsertVetAppointment(animalVetAppointment);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add record: ", ex);
            }
        }

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
        public bool EditAnimalVetAppointmentRecord(AnimalVetAppointment oldVetAppointment, AnimalVetAppointment newVetAppointment)
        {
            try
            {
                return _vetAppointmentAccessor.UpdateVetAppointment(oldVetAppointment, newVetAppointment);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to update record", ex);
            }
        }

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
        public List<AnimalVetAppointment> RetrieveAppointmentsByPartialAnimalName(string animalName)
        {
            return (from b in _vetAppointments
                    where b.AnimalName.ToLower().IndexOf(animalName.ToLower()) > -1
                    select b).ToList();
        }

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
        public bool RemoveAnimalVetAppointment(AnimalVetAppointment vetAppointment)
        {
            try
            {
                return _vetAppointmentAccessor.DeleteAnimalVetAppointment(vetAppointment) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to delete", ex);
            }
        }

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
        public bool ActivateVetAppointment(AnimalVetAppointment vetAppointment)
        {
            try
            {
                return _vetAppointmentAccessor.SetVetAppointmentActiveStatus(vetAppointment, true) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to activate", ex);
            }
        }

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
        /// /// <param name="vetAppointment">Record to be updated</param>
        /// <returns>Update successful</returns>
        public bool DeactivateVetAppointment(AnimalVetAppointment vetAppointment)
        {
            try
            {
                return _vetAppointmentAccessor.SetVetAppointmentActiveStatus(vetAppointment, false) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to deactivate", ex);
            }
        }

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
        public List<AnimalVetAppointment> RetrieveVetAppointmentsByActive(bool active)
        {
            try
            {
                _vetAppointments = _vetAppointmentAccessor.SelectVetAppointmentsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to find records", ex);
            }
            return _vetAppointments;
        }
    }
}
