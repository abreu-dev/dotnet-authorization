using Autho.Domain.Entities.Base;

namespace Autho.Domain.Entities
{
    public class ProfileDomain : BaseDomain
    {
        public string Name { get; private set; }

        public virtual ICollection<PermissionDomain> Permissions { get; private set; }

        public ProfileDomain()
        {
        }

        public ProfileDomain(string name)
        {
            Name = name;
            Permissions = new List<PermissionDomain>();
        }

        public ProfileDomain(string name, ICollection<PermissionDomain> permissions) : this(name)
        {
            Permissions = permissions;
        }

        public void AddPermissions(ICollection<PermissionDomain> permissions)
        {
            permissions.ToList().ForEach(permissions =>
            {
                if (!PermissionExists(permissions))
                {
                    Permissions.Add(permissions);
                }
            });
        }

        public bool PermissionExists(PermissionDomain permission)
        {
            return Permissions.Any(x => x.Code == permission.Code);
        }
    }
}
