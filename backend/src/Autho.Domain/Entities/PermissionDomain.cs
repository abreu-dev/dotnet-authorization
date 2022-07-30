using Autho.Domain.Entities.Base;

namespace Autho.Domain.Entities
{
    public class PermissionDomain : BaseDomain
    {
        public string Name { get; private set; }
        public string Code { get; private set; }

        public PermissionDomain()
        {
        }

        public PermissionDomain(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
