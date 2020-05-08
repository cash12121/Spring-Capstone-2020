using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig    
    ///     DATE: 2020-03-09
    ///     CHECKED BY: Zoey McDonald
    ///     Class for managing medicine
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class MedicineManager : IMedicineManager
    {
        private IMedicineAccessor _accessor;

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        public MedicineManager(IMedicineAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        public MedicineManager()
        {
            _accessor = new MedicineAccessor();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicine">The ID of the Medicine to check in</param>
        /// <returns>The number of rows affected</returns>
        public int CheckMedicineIn(Medicine medicine)
        {
            try
            {
                return _accessor.InsertMedicine(medicine);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Record not inserted", ex);
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicineID">The ID of the Medicine to check out</param>
        /// <returns>The number of rows affected</returns>
        public int CheckMedicineOut(int medicineID)
        {
            try
            {
                return _accessor.DeleteMedicine(medicineID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        public List<Medicine> ReturnAllMedicine()
        {
            try
            {
                return _accessor.SelectAllMedicines();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }
    }
}
