using System.Collections.Generic;

namespace UserManager
{
    public interface IUserManager
    {
        /// <summary>
        /// Add a user to the UserManager
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="userName">
        ///     Username for the user
        ///     This must be a unique value
        ///     Username can only contain uppercase and lowercase letters, hyphens, underscores and numbers
        /// </param>
        /// <param name="email">
        ///     Email for the user
        ///     This must be a unique value
        /// </param>
        /// <exception cref="">Thrown if the username already exists</exception>
        /// <exception cref="">Thrown if the username does not match the formatting requirements</exception>
        /// <exception cref="">Thrown if the email is not unique</exception>
        /// <exception cref="">Thrown if the email is not valid</exception>
        void AddUser(string firstName, string lastName, string userName, string email);

        /// <summary>
        /// Add a role to the UserManager
        /// </summary>
        /// <param name="Name">
        ///     Name for the role
        ///     This must be a unique value
        /// </param>
        /// <exception cref="">Thrown if name is not a unique value</exception>
        void AddRole(string Name);

        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="userName">username of the user that has to be authenticated</param>
        /// <returns>
        ///     true if the authentication is successful
        ///     false if the authentication has failed
        /// </returns>
        /// <exception cref="">Raised if username is not valid</exception>
        bool Authenticate(string userName);

        /// <summary>
        /// Authorize if a user has rights to the part of the application
        /// where this method is used.
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="roles">
        ///     A list of roles that are allowed to use the application
        /// </param>
        /// <param name="requireAllRoles">
        ///     If this is true, then the user must have permission for all the roles in the roles list
        /// </param>
        /// <returns>
        ///     true if the user is allowed to use the part of the application
        ///     false if the user is not allowed to use the part of the application
        /// </returns>
        bool Authorize(User user, List<Role> roles, bool requireAllRoles);
    }
}
