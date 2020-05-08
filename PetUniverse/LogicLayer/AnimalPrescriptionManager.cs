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
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020
    /// Approver:
    /// 
    /// Manager class for animal prescription records
    /// </summary>
    public class AnimalPrescriptionsManager : IAnimalPrescriptionManager
    {
        private IAnimalPrescriptionsAccessor _animalPrescriptionsAccessor;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Constructor that accepts an instance of the animal
        /// prescription accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescriptionsAccessor">An AnimalPrescription accessor</param>
        public AnimalPrescriptionsManager(IAnimalPrescriptionsAccessor animalPrescriptionsAccessor)
        {
            _animalPrescriptionsAccessor = animalPrescriptionsAccessor;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// No argument constructor that initializes an instance 
        /// of the animal prescriptions accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalPrescriptionsManager()
        {
            _animalPrescriptionsAccessor = new AnimalPrescriptionAccessor();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Creates an animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">An AnimalPrescription object</param>
        /// <returns>Creation succesful</returns>
        public bool AddAnimalPrescriptionRecord(AnimalPrescriptionVM animalPrescription)
        {
            try
            {
                return _animalPrescriptionsAccessor.CreateAnimalPrescriptionRecord(animalPrescription);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to create record", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Retrieves all animal prescription records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal prescriptions</returns>
        public List<AnimalPrescriptionVM> RetrieveAllAnimalPrescriptions()
        {
            try
            {
                return _animalPrescriptionsAccessor.SelectAllAnimalPrescriptionRecords();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Retrieves all animal prescription records for a
        /// specific animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal prescriptions</returns>
        public List<AnimalPrescriptionVM> RetrievePrescriptionsByAnimalName(string animalName)
        {
            try
            {
                return (from p in RetrieveAllAnimalPrescriptions()
                        where p.AnimalName.ToLower() == animalName.ToLower()
                        select p).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Edits an existing animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalPrescription">Existing record</param>
        /// <param name="newAnimalPrescription">Updated record</param>
        /// <returns>Edit successful</returns>
        public bool EditAnimalPrescriptionRecord(AnimalPrescriptionVM oldAnimalPrescription,
            AnimalPrescriptionVM newAnimalPrescription)
        {
            try
            {
                return _animalPrescriptionsAccessor.UpdateAnimalPrescriptionRecord(
                    oldAnimalPrescription, newAnimalPrescription);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to update record", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Deactivates an active animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">Record to be deactivated</param>
        /// <returns>Deactivate successful</returns>
        public bool DeactivateAnimalPrescriptionRecord(AnimalPrescription animalPrescription)
        {
            try
            {
                return _animalPrescriptionsAccessor.ChangeAnimalPrescriptionRecordActive(animalPrescription, false) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Record not deactivated", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Activates an inactive animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">Record to be activated</param>
        /// <returns>Activate successful</returns>
        public bool ActivateAnimalPrescriptionRecord(AnimalPrescription animalPrescription)
        {
            try
            {
                return _animalPrescriptionsAccessor.ChangeAnimalPrescriptionRecordActive(animalPrescription, true) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Record not activated", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Deletes an existing animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">Record to be deleted</param>
        /// <returns>Delete successful</returns>
        public bool DeleteAnimalPrescriptionRecord(AnimalPrescriptionVM animalPrescription)
        {
            try
            {
                return _animalPrescriptionsAccessor.DeleteAnimalPrescriptionRecord(animalPrescription) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Record not deleted", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/26/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Retrieves animal prescriptions by active status
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active">Active status</param>
        /// <returns>List of animal prescriptions</returns>
        public List<AnimalPrescriptionVM> RetrieveAnimalPrescriptionsByActive(bool active = true)
        {
            try
            {
                return _animalPrescriptionsAccessor.SelectAnimalPrescriptionsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to fetch records", ex);
            }
        }
    }
}
