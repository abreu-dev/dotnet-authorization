using Autho.Domain.Entities;
using Autho.Domain.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Entities;
using AutoMapper;

namespace Autho.Infra.Data.Repositories
{
    public class PermissionRepository : Repository<PermissionDomain, PermissionData>, IPermissionRepository
    {
        public PermissionRepository(IAuthoContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
