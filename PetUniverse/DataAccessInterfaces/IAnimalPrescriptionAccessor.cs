using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020
    /// 
    /// An interface for the Animal Prescriptions accessor
    /// </summary>
    public interface IAnimalPrescriptionsAccessor
    {

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
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
        bool CreateAnimalPrescriptionRecord(AnimalPrescriptionVM animalPrescription);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Selects all animal prescription records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal prescriptions</returns>
        List<AnimalPrescriptionVM> SelectAllAnimalPrescriptionRecords();

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Updates an existing animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalPrescription">Existing record</param>
        /// <param name="newAnimalPrescription">Record to replace the existing one</param>
        /// <returns>Update successful</returns>
        bool UpdateAnimalPrescriptionRecord(AnimalPrescriptionVM oldAnimalPrescription,
            AnimalPrescriptionVM newAnimalPrescription);

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
        /// <returns>Rows updated</returns>
        int DeleteAnimalPrescriptionRecord(AnimalPrescriptionVM animalPrescription);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Changes the active status of an animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">Record to be updated</param>
        /// <param name="active">Active status</param>
        /// <returns>Update successful</returns>
        int ChangeAnimalPrescriptionRecordActive(AnimalPrescription animalPrescription, bool active);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/26/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Selects animal prescriptions by active/inactive status
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active">Active status</param>
        /// <returns>List of animal prescriptions</returns>
        List<AnimalPrescriptionVM> SelectAnimalPrescriptionsByActive(bool active);
    }
}