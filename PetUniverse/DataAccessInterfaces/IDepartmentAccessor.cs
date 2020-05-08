using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 2/6/2020
    /// Approver: Alex Diers
    /// 
    /// This is a DataAccessInterface that all data access classes should be based on.
    /// </summary>
    public interface IDepartmentAccessor
    {

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/14/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method for inserting a department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA    
        /// </remarks>
        /// 
        /// <param name="departmentId"></param>
        /// <param name="description"></param>
        /// <returns>int</returns>
        int InsertDepartment(string departmentId, string description);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/14/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method selecting all active departments.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA    
        /// </remarks>
        /// 
        /// <returns>List<Department></DepartmentsV></returns>
        List<Department> SelectAllDepartments();

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/14/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method for selecting a department by id
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA    
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <returns>Department</returns>
        Department SelectDepartmentByID(string departmentId);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/14/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method for updating a department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA    
        /// </remarks>
        /// 
        /// <param name="oldDepartment"></param>
        /// <param name="newDepartment"></param>
        /// <returns>int</returns>
        int UpdateDepartment(Department oldDepartment, Department newDepartment);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver:
        /// 
        /// This is an interface method for changing the active value of a department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA    
        /// </remarks>
        /// 
        /// <param name="departmentID"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        int UpdateDepartmentActive(string departmentID, bool active);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method selecting all inactive departmentIDs.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA    
        /// </remarks>
        /// 
        /// <returns>List<Department></DepartmentsV></returns>
        List<string> SelectDeactivatedDepartments();
    }
}