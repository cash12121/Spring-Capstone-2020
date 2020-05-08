using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
	/// Creator: Chase Schulte
	/// Created: 02/07/2020
	/// Approver
	///
	/// Class for testing fake Role data
	/// </summary>
    public class FakeERoleAccessor : IERoleAccessor
    {

        // need a collection of eRoles
        List<ERole> eRoles = null;
        List<String> deptIDs = null;

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/07
        /// Approver: Kaleb Bachert
        /// 
        /// Populate the role and department list 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        public FakeERoleAccessor()
        {
            //Fake data for Departments
            deptIDs = new List<string>()
            {
                "A",
                "B",
                "C"
            };

            //Fake data for ERoles
            eRoles = new List<ERole>()
            {
                new ERole(){ERoleID="Manager",DepartmentID="A", Description="", EActive = false },
                new ERole(){ERoleID="Scheduler",DepartmentID="A", Description="", EActive = true },
                new ERole(){ERoleID="Planner",DepartmentID="A", Description="", EActive = true }
            };
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/09/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test fake activation for Roles
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int ActivateERole(string eRoleID)
        {
            ERole eRole = null;

            //Fail immediately if null
            if (eRoleID == null)
            {
                throw new Exception();
            }

            //Check that eRole is in list, if so assign it, else fail
            foreach (var r in eRoles)
            {
                if (eRoleID == r.ERoleID)
                {
                    eRole = r;
                }
            }

            //Throw exception if eRole isn't in list
            if (eRole == null || eRoleID != eRole.ERoleID)
            {
                throw new Exception();
            }

            //Activate it
            eRole.EActive = true;

            if (eRole.EActive == true)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/09/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test fake deactivation of role
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int DeactivateERole(string eRoleID)
        {
            ERole eRole = null;

            //Fail immediatly if null
            if (eRoleID == null)
            {
                throw new Exception();
            }

            //Check that eRole is in list, if so assign it, else fail
            foreach (var r in eRoles)
            {
                if (eRoleID == r.ERoleID)
                {
                    eRole = r;
                }
            }

            //Throw exception if eRole isn't in list
            if (eRole == null || eRoleID != eRole.ERoleID)
            {
                throw new Exception();
            }

            //Deactivate it
            eRole.EActive = false;

            if (eRole.EActive == false)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/09/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test fake deletion of role
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int DeleteERole(string eRoleID)
        {
            ERole eRole = null;

            //Check that eRole is in list, if so assign it, else fail
            foreach (var r in eRoles)
            {
                if (eRoleID == r.ERoleID)
                {
                    eRole = r;
                }
            }
            if (eRole == null)
            {
                throw new Exception();
            }

            //Simulate deletion
            eRole = null;
            if (eRole == null)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/09/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test fake insert Role 
        /// </summary>
        ///
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRole"></param>
        /// <returns></returns>
        public int InsertERole(ERole eRole)
        {
            //Check if new eRoleID is null
            if (eRole.ERoleID == null || eRole.ERoleID == "")
            {
                throw new Exception();
            }

            //Check if new eRole.DepartmentID is null
            if (eRole.DepartmentID == null)
            {
                throw new Exception();
            }

            //Check if eRole.ERoleID exceeds maximum length
            if (eRole.ERoleID.Length > 50)
            {
                throw new Exception();
            }

            //Check if eRole.DepartmentID exceeds maximum length
            if (eRole.DepartmentID.Length > 50)
            {
                throw new Exception();
            }

            //Check if eRole.Description exceeds maximum char length
            if (eRole.Description != null)
            {
                if (eRole.Description.Length > 200)
                {
                    throw new Exception();
                }
            }

            //Check if new eRoleID is a duplicate of pre-existing eRoleID
            if (eRoles.Find(r => r.ERoleID == eRole.ERoleID) != null)
            {
                throw new Exception();
            }

            //returns fake rows effected if it passed all tests
            return 1;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/09/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test select all fake roles
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns></returns>
        public List<ERole> SelectAllERoles()
        {
            //Return all ERoles
            return eRoles.ToList();
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/16/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test select all fake roles by active state
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<ERole> SelectAllERolesByActive(bool active = true)
        {
            List<ERole> newERoles = new List<ERole>();
            foreach (var role in eRoles)
            {
                if (role.EActive == active)
                {
                    newERoles.Add(role);
                }
            }
            return newERoles;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/16/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test update roles 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public int UpdateERole(ERole oldERole, ERole newERole)
        {
            bool eRoleTrue = false;
            bool deptTrue = false;

            //Fail immediatly if null
            if (oldERole == null)
            {
                throw new Exception();
            }

            //Check that eRole is in list, if so assign it, else fail
            foreach (var r in eRoles)
            {
                if (oldERole.ERoleID == r.ERoleID && oldERole.DepartmentID == r.DepartmentID && oldERole.Description == r.Description && r != null)
                {
                    eRoleTrue = true;
                }
            }

            //Throw exception if eRole isn't in list
            if (eRoleTrue == false)
            {
                throw new Exception();
            }

            //Make sure PK remains the same
            if (oldERole.ERoleID != newERole.ERoleID)
            {
                throw new Exception();
            }

            //Check if eRole.DepartmentID exceeds maximum length
            if (newERole.DepartmentID.Length > 50)
            {
                throw new Exception();
            }

            //Check if eRole.Description exceeds maximum char length
            if (newERole.Description != null)
            {
                if (newERole.Description.Length > 200)
                {
                    throw new Exception();
                }
            }

            //Check if the dept ID is invalid
            if (deptIDs.Find(dp => dp == newERole.DepartmentID) != null)
            {
                deptTrue = true;
            }

            //Throw exception if Dept isn't in list
            if (deptTrue == false)
            {
                throw new Exception();
            }

            //Update old ERole to newERole
            oldERole = newERole;

            //Make sure old eRole is updated
            if (oldERole == newERole)
            {
                return 1;
            }
            return 0;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a data fake for selecting roles by department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public List<ERole> SelectAllERolesByDepartment(string departmentID)
        {
            List<ERole> roles = new List<ERole>();

            foreach (ERole role in eRoles)
            {
                if (role.DepartmentID.Equals(departmentID))
                {
                    roles.Add(role);
                }
            }
            return roles;
        }
    }
}
