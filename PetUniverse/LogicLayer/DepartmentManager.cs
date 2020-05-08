using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 2/6/2020
    /// Approver: Alex Diers
    /// 
    /// This is the Logic layer Department Manager for interacting between the Presentation and the Data Access.
    /// </summary>
    public class DepartmentManager : IDepartmentManager
    {

        private IDepartmentAccessor _departmentAccessor;


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the no argument constructor.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        public DepartmentManager()
        {
            _departmentAccessor = new DepartmentAccessor();
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This constructor requires an IDepartmentAccessor.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentAccessor"></param>
        public DepartmentManager(IDepartmentAccessor departmentAccessor)
        {
            _departmentAccessor = departmentAccessor;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to add a department.
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: Added reactivation and update description.
        /// Updated: Standarized exception handling.
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool AddDepartment(string departmentId, string description)
        {
            bool added = false;


            if (null != departmentId && ValidateERole.checkDepartmentID(departmentId) && ValidateERole.checkDescription(description))
            {

                try
                {
                    Department department = _departmentAccessor.SelectDepartmentByID(departmentId);

                    if (null == department)
                    {
                        if (_departmentAccessor.InsertDepartment(departmentId, description) == 1)
                        {
                            added = true;
                        }
                    }
                    else if (_departmentAccessor.SelectDeactivatedDepartments().Contains(departmentId))
                    {
                        if (EditDepartmentActive(departmentId, true))
                        {
                            Department aDepartment = new Department
                            {
                                DepartmentID = departmentId,
                                Description = description
                            };
                            if (EditDepartment(department, aDepartment))
                            {
                                added = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new ApplicationException("Department Not Added.", ex);
                }
            }
            return added;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to retrieve all departments.
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: Standardized exception handling.
        /// Approver: Alex Diers
        /// 
        /// </remarks>
        public List<Department> RetrieveAllDepartments()
        {

            try
            {
                return _departmentAccessor.SelectAllDepartments();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Departments Data Not Found.", ex);
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to select a department by id.
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: Standardized exception handling.
        /// Approver: Alex Diers
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public Department RetrieveDepartmentByID(string departmentId)
        {
            Department department;
            try
            {
                department = _departmentAccessor.SelectDepartmentByID(departmentId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Department Data Not Found", ex);
            }
            return department;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to update a department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="oldDepartmentId"></param>
        /// <param name="newDepartmentId"></param>
        /// <returns></returns>
        public bool EditDepartment(Department oldDepartment, Department newDepartment)
        {
            bool result = false;

            if (oldDepartment.DepartmentID.Equals(newDepartment.DepartmentID)
                && ValidateERole.checkDepartmentID(oldDepartment.DepartmentID)
                && ValidateERole.checkDepartmentID(newDepartment.DepartmentID)
                && ValidateERole.checkDescription(oldDepartment.Description)
                && ValidateERole.checkDescription(newDepartment.Description))
            {
                List<Department> departments = RetrieveAllDepartments();
                foreach (Department department in departments)
                {
                    if (department.DepartmentID == oldDepartment.DepartmentID && department.Description == oldDepartment.Description)
                    {
                        try
                        {
                            result = (1 == _departmentAccessor.UpdateDepartment(oldDepartment, newDepartment));
                        }
                        catch (Exception ex)
                        {

                            throw new ApplicationException("Department Data Not Found", ex);
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to update a department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <param name="active"></param>
        /// <returns>A boolean representing the success of the edit.</returns>
        public bool EditDepartmentActive(string departmentID, bool active)
        {
            List<string> departmentIDs;
            List<Department> departments;
            bool result = false;
            try
            {
                if (active)
                {
                    departmentIDs = _departmentAccessor.SelectDeactivatedDepartments();
                }
                else
                {
                    departments = _departmentAccessor.SelectAllDepartments();
                    departmentIDs = new List<string>();
                    foreach (var department in departments)
                    {
                        departmentIDs.Add(department.DepartmentID);
                    }
                }
                if (departmentIDs.Contains(departmentID))
                {
                    result = (1 == _departmentAccessor.UpdateDepartmentActive(departmentID, active));
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Department Data Not Found", ex);
            }
            return result;
        }
    }
}
