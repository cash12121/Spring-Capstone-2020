using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 2/6/2020
    /// Approver: Alex Diers
    /// 
    /// This is an interface method.
    /// </summary>

    public interface IDepartmentManager
    {
        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method for adding a department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <param name="description"></param>
        /// <returns>bool</returns>
        bool AddDepartment(string departmentId, string description);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method for getting a list of departments.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        List<Department> RetrieveAllDepartments();

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method getting a department by id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="DepartmentId"></param>
        /// <returns>Department</returns>
        Department RetrieveDepartmentByID(string DepartmentId);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method update a department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="oldDepartmentId"></param>
        /// <param name="newDepartmentId"></param>
        /// <returns>bool</returns>
        bool EditDepartment(Department oldDepartment, Department newDepartment);


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is an interface method update a department active field.
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
        bool EditDepartmentActive(string departmentID, bool active);
    }
}
