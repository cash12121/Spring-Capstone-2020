using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Timothy Lickteig    
    /// Created: 02/09/2020
    /// Approver: Zoey McDonald
    /// 
    /// Class for emulating an actual data access class for viewing medicine
    /// </summary>
    /// <remarks>
    /// Updater: N/A
    /// Updated: N/A
    /// Update: N/A
    /// </remarks>
    public class FakeMedicineAccessor : IMedicineAccessor
    {
        private List<Medicine> _medicineList = new List<Medicine>()
        {
            new Medicine()
            {
                MedicineID = 0,
                MedicineDescription = "This is the description",
                MedicineDosage = "This is the dosage",
                MedicineName = "This is the name"
            }
        };

        /// <summary>
        /// Creator: Timothy Lickteig    
        /// Created: 02/09/2020
        /// Approver: Zoey McDonald
        /// 
        /// This method removes a medicine
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="medicineID">The ID of the Medicine to delete</param>
        /// <returns>The number of rows affected</returns>
        public int DeleteMedicine(int medicineID)
        {
            int rows = 0;
            Medicine tempMed = new Medicine();

            foreach (Medicine medicine in _medicineList)
            {
                if (medicine.MedicineID == medicineID)
                {
                    tempMed = medicine;
                    rows++;
                }
            }

            _medicineList.Remove(tempMed);

            return rows;
        }

        /// <summary>
        /// Creator: Timothy Lickteig    
        /// Created: 02/09/2020
        /// Approver: Zoey McDonald
        /// 
        /// This method adds a medicine
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="medicine">The medicine to enter</param>
        /// <returns>The number of rows affected</returns>
        public int InsertMedicine(Medicine medicine)
        {
            _medicineList.Add(medicine);
            return 1;
        }

        /// <summary>
        /// Creator: Timothy Lickteig    
        /// Created: 02/09/2020
        /// Approver: Zoey McDonald
        /// 
        /// This method selects all medicine
        /// </summary>
        /// /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <returns>List of medicine</returns>
        public List<Medicine> SelectAllMedicines()
        {
            return _medicineList;
        }
    }
}
