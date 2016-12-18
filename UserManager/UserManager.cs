using System;
using System.Collections.Generic;

namespace UserManager
{
    public class UserManager : IUserManager
    {
        public UserManager()
        {

        }

        public void AddRole(string Name)
        {
            throw new NotImplementedException();
        }

        public void AddUser(string firstName, string lastName, string userName, string email)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(string userName)
        {
            throw new NotImplementedException();
        }

        public bool Authorize(User user, List<Role> roles, bool requireAllRoles)
        {
            throw new NotImplementedException();
        }
    }
}
