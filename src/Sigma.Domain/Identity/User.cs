using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Domain.Identity
{
    public class User : IPrincipal, IEntity
    {
        public virtual Role Role { get; set; }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string AssociateId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }

        public string FullName
        {
            get
            {
                return string.Concat(LastName, ", ", FirstName);
            }
        }

        public virtual IIdentity Identity
        {
            get
            {
                bool isAuthenticated = true; // Role.Name != Role.Guest.Name;
                return new Identity(isAuthenticated, Name);
            }
        }

        //public virtual bool IsInRole(string role)
        //{
        //    if (Role.Description.ToLower() == role.ToLower())
        //        return true;
        //    foreach (Right right in Role.Rights)
        //    {
        //        if (right.Description.ToLower() == role.ToLower())
        //            return true;
        //    }
        //    return false;
        //}

        public bool IsInRole(string role)
        {
            return Role.Name == role;
        }
    }
}
