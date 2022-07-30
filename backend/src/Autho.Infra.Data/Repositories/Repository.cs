using Autho.Domain.Entities.Base;
using Autho.Domain.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Entities.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Autho.Infra.Data.Repositories
{
    public abstract class Repository<TBaseDomain, TBaseData> : IRepository<TBaseDomain>
        where TBaseDomain : BaseDomain
        where TBaseData : BaseData
    {
        protected readonly IAuthoContext _context;
        protected readonly IMapper _mapper;

        private readonly DbSet<TBaseData> _dbSet;

        public IUnitOfWork UnitOfWork => _context;

        protected Repository(IAuthoContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            _dbSet = _context.GetDbSet<TBaseData>();
        }

        public IEnumerable<TBaseDomain> GetAll()
        {
            return _mapper.Map<IEnumerable<TBaseDomain>>(_dbSet);
        }

        public TBaseDomain GetById(Guid id)
        {
            return _mapper.Map<TBaseDomain>(_dbSet.Find(id));
        }

        public void Add(TBaseDomain entity)
        {
            var data = _mapper.Map<TBaseData>(entity);
            _context.AddData(data);
        }

        public void Update(TBaseDomain entity)
        {
            var data = _mapper.Map<TBaseData>(entity);
            _context.UpdateData(data);

            var entry = _context.GetDbEntry(data);
            if (entry != null)
            {
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedDate).IsModified = false;
            }
        }

        public void Delete(Guid id)
        {
            var data = _dbSet.Find(id);

            if (data != null)
                _context.DeleteData(data);
        }
    }
}
