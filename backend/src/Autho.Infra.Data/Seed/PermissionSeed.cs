using Autho.Domain.Entities;
using Autho.Domain.Interfaces;
using Autho.Infra.Data.Enums;

namespace Autho.Infra.Data.Seed
{
    public static class PermissionSeed
    {
        public static void SeedData(IPermissionRepository repository)
        {
            var existingPermissions = repository.GetAll().ToList();

            foreach (var item in Enum.GetValues(typeof(Permission)))
            {
                var itemEnum = (Permission)item;

                var name = itemEnum.GetEnumDisplayName();
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException(name);
                }

                var code = itemEnum.GetEnumDisplayDescription();
                if (string.IsNullOrEmpty(code))
                {
                    throw new ArgumentNullException(name);
                }

                if (!existingPermissions.Any(x => x.Code == code)) 
                {
                    var newPermission = new PermissionDomain(name, code);
                    repository.Add(newPermission);
                }
            }

            repository.UnitOfWork.Complete();
        }
    }
}
