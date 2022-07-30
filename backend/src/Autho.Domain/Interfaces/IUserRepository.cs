using Autho.Domain.Entities;

namespace Autho.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserDomain>
    {
        IEnumerable<UserDomain> GetAllUsers();
        UserDomain GetByName(string name);
    }
}
