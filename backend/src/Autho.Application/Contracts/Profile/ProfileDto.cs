using Autho.Application.Contracts.Permission;

namespace Autho.Application.Contracts.Profile
{
    public class ProfileDto
    {
        public string Name { get; set; }

        public virtual ICollection<PermissionDto> Permissions { get; set; }
    }
}
