using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 2/6/2020
    /// Approver: Alex Diers
    /// 
    /// This is a DataAccessFake used for unit testing.
    /// </summary>
    public class FakeDepartmentAccessor : IDepartmentAccessor
    {

        private List<Department> _departments;
        private List<string> _deactivatedDepartmentIDs;

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a DataAccessFake constructor used for unit testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public FakeDepartmentAccessor()
        {
            _departments = new List<Department>()
            {
                new Department()
                {
                    DepartmentID ="Fake Department",
                    Description ="Fake Description"
                }
            };

            _deactivatedDepartmentIDs = new List<string>
            {
                "DeactivatedID1",
                "DeactivatedID2",
                "DeactivatedID3"
            };
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a DataAccessFake change active used for unit testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <param name="active"></param>
        /// <returns> An int of rows effected.</returns>
        public int UpdateDepartmentActive(string departmentID, bool active = false)
        {
            return 1;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the data access fake for adding a department to the table.
        /// </summary>
        /// <remarks>
        /// Updater: Alex Diers
        /// Updated: 5/5/2020
        /// Update: Added param and returns tags
        /// 
        /// </remarks>
        /// /// <param name="departmentId"></param>
        /// <param name="description"></param>
        /// <returns> An int of rows effected.</returns>
        public int InsertDepartment(string departmentId, string description)
        {
            int rows = 0;
            Department department = new Department()
            {
                DepartmentID = departmentId,
                Description = description
            };

            _departments.Add(department);

            if (_departments.Contains(department))
            {
                rows = 1;
            }
            return rows;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the data access fake for selecting all departments.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<Department> SelectAllDepartments()
        {
            return _departments;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the data access fake for selecting a department by id.
        /// </summary>
        /// <remarks>
        /// Updater: Alex Diers
        /// Updated: 5/5/2020
        /// Update: Added param and returns tags 
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public Department SelectDepartmentByID(string departmentId)
        {
            Department department = null;
            foreach (var aDepartment in _departments)
            {
                if (aDepartment.DepartmentID.Equals(departmentId))
                {
                    department = aDepartment;
                }
            }
            return department;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/18/2020
        /// Approver: Alex Diers
        /// 
        /// This is the data access fake for update department
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="oldDepartment"></param>
        /// <param name="newDepartment"></param>
        /// <returns>Number of rows affected</returns>
        public int UpdateDepartment(Department oldDepartment, Department newDepartment)
        {
            return 1;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is the data access fake for selecting deactivated departments
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<string> SelectDeactivatedDepartments()
        {
            return _deactivatedDepartmentIDs;
        }
    }
}
