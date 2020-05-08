using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/1/2020
    /// Approver:
    /// 
    /// This is a data accessor calss for simulating failed database connection.
    /// </summary>
    public class FakeDepartmentAccessorFailedConnection : IDepartmentAccessor
    {

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This throws an exception.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public int InsertDepartment(string departmentId, string description)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This throws an exception.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<Department> SelectAllDepartments()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This throws an exception.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<string> SelectDeactivatedDepartments()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This throws an exception.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public Department SelectDepartmentByID(string departmentId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This throws an exception.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="oldDepartment"></param>
        /// <param name="newDepartment"></param>
        /// <returns></returns>
        public int UpdateDepartment(Department oldDepartment, Department newDepartment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This throws an exception.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public int UpdateDepartmentActive(string departmentID, bool active)
        {
            throw new NotImplementedException();
        }
    }
}
