using Autho.Domain.Entities.Base;

namespace Autho.Domain.Interfaces
{
    public interface IRepository<TBaseDomain> where TBaseDomain : BaseDomain
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<TBaseDomain> GetAll();
        TBaseDomain GetById(Guid id);

        void Add(TBaseDomain entity);
        void Update(TBaseDomain entity);
        void Delete(Guid id);
    }
}
