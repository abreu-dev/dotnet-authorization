using Autho.Domain.Entities;
using Autho.Domain.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Autho.Infra.Data.Repositories
{
    public class UserRepository : Repository<UserDomain, UserData>, IUserRepository
    {
        public UserRepository(IAuthoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<UserDomain> GetAllUsers()
        {
            var users = _context.Query<UserData>()
                .Include(x => x.Profiles)
                .ThenInclude(x => x.Profile)
                .ThenInclude(x => x.Permissions)
                .ThenInclude(x => x.Permission)
                .ToList();

            return _mapper.Map<IEnumerable<UserDomain>>(users);
        }

        public UserDomain GetByName(string name)
        {
            return _mapper.Map<UserDomain>(
                _context.Query<UserData>()
                    .Include(x => x.Profiles)
                    .ThenInclude(x => x.Profile)
                    .FirstOrDefault(x => x.Name == name)
            );
        }
    }
}
