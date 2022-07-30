using Autho.Domain.Entities;

namespace Autho.Domain.Interfaces
{
    public interface IProfileRepository : IRepository<ProfileDomain>
    {
        ProfileDomain GetByName(string name);
    }
}
