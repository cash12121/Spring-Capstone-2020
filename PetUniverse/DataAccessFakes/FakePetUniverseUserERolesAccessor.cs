using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Chase Schulte
    /// Created: 02/29/2020
    /// Approver: Jordan Lindo
    /// 
    /// Fake Eroles class for testing
    /// </summary>
    public class FakePetUniverseUserERolesAccessor : IPetUniverseUserERolesAccessor
    {

        List<ERole> userERoles = null;
        List<ERole> availableERoles = null;
        List<ERole> availablePUUsers = null;

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// Populate the role and department list 
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 04/10/2020
        /// Update: Changed functionality to inherit ERole
        /// Approver: Kaleb Bachert
        /// </remarks>
        public FakePetUniverseUserERolesAccessor()
        {
            //Fake data for EroleAcessor
            userERoles = new List<ERole>()
            {
                new ERole()
                {
                    PUUserID=100000,
                    ERoleID="Manager"
                },

                new ERole()
                {
                    PUUserID=100001,
                    ERoleID="Cashier"
                },

                new ERole()
                {
                    PUUserID=100001,
                    ERoleID="Event Organizer"
                }
            };

            availableERoles = new List<ERole>()
            {
                new ERole()
                {
                    ERoleID="Manager"
                },

                new ERole()
                {
                    ERoleID="Cashier"
                },

                new ERole()
                {
                    ERoleID="Event Organizer"
                },

                new ERole()
                {
                    ERoleID="Event Manager"
                }
            };
            availablePUUsers = new List<ERole>()
            {
                new ERole()
                {
                    PUUserID=100000
                },

                new ERole()
                {
                    PUUserID=100001
                },

                new ERole()
                {
                    PUUserID=100002
                }
            };
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo 
        /// 
        /// Test Delete userERole and department list 
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 04/10/2020
        /// Update: Changed functionality to inherit ERole
        /// Approver: Kaleb Bachert
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int DeletePetUniverseUserERole(int userID, string eRoleID)
        {
            bool userRoleFound = false;

            //Find userID and eRoleID
            if (userERoles.Find(r => r.ERoleID == eRoleID && r.PUUserID == userID) != null)
            {
                userRoleFound = true;
            }

            //Fail if user and role can't be found
            if (!userRoleFound)
            {
                throw new Exception();
            }

            //Simulate deletion
            eRoleID = null;
            userID = 0;

            //Make sure it's deleted
            if (eRoleID == null && userID == 0)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Insert UserERole 
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 04/10/2020
        /// Update: Changed functionality to inherit ERole
        /// Approver: Kaleb Bachert
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int InsertPetUniverseUserERole(int userID, string eRoleID)
        {
            bool userFound = false;
            bool roleFound = false;

            //Make sure UserID exists
            if (availablePUUsers.Find(r => r.PUUserID == userID) != null)
            {
                userFound = true;
            }

            //Fail if user and can't be found
            if (!userFound)
            {
                throw new Exception();
            }

            //Make sure ERole is real
            if (availableERoles.Find(r => r.ERoleID == eRoleID) != null)
            {
                roleFound = true;
            }

            //fail if role can't be found
            if (!roleFound)
            {
                throw new Exception();
            }

            //make sure eRoleID doesn't already belong to that user
            if (userERoles.Find(r => r.ERoleID == eRoleID && r.PUUserID == userID) != null)
            {
                throw new Exception();
            }

            //Add new user into list
            userERoles.Add(new ERole() { PUUserID = userID, ERoleID = eRoleID });

            //Make sure it was added
            if (userERoles.Find(r => r.ERoleID == eRoleID && r.PUUserID == userID) != null)
            {
                return 1;
            }

            //Add failed
            throw new Exception();
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Select UserERole by PUUserID 
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 04/10/2020
        /// Update: Changed functionality to inherit ERole
        /// Approver: Kaleb Bachert
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<string> SelectPetUniverseUserERoleByPetUniverseUser(int userID)
        {
            bool userFound = false;
            List<string> roles = new List<string>();

            //Find userID
            if (availablePUUsers.Find(r => r.PUUserID == userID) != null)
            {
                userFound = true;
            }
            //Fail if user doesn't exist
            if (!userFound)
            {
                throw new Exception();
            }
            //loop through and get all userEroles
            foreach (var user in userERoles)
            {
                if (user.PUUserID == userID)
                {
                    if (user.ERoleID != null)
                    {
                        roles.Add(user.ERoleID.ToString());
                    }
                    else if (user.ERoleID == null)
                    {
                        return roles;
                    }
                }
            }
            return roles;
        }
    }
}
