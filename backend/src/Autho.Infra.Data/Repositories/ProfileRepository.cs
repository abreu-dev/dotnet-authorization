using Autho.Domain.Entities;
using Autho.Domain.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Entities;
using AutoMapper;

namespace Autho.Infra.Data.Repositories
{
    public class ProfileRepository : Repository<ProfileDomain, ProfileData>, IProfileRepository
    {
        public ProfileRepository(IAuthoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public ProfileDomain GetByName(string name)
        {
            return _mapper.Map<ProfileDomain>(
                _context.Query<ProfileData>()
                    .FirstOrDefault(x => x.Name == name)
            );
        }
    }
}
