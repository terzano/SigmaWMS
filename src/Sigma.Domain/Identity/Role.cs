using System.Collections.Generic;

namespace Sigma.Domain.Identity
{
    public class Role : INamedEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        private IList<User> _users = new List<User>();

        public virtual IList<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
