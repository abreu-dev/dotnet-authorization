using Autho.Domain.Interfaces;
using Autho.Infra.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Autho.Infra.Data.Context
{
    public interface IAuthoContext : IUnitOfWork
    {
        DbSet<TBaseData> GetDbSet<TBaseData>() where TBaseData : BaseData;
        EntityEntry<TBaseData> GetDbEntry<TBaseData>(TBaseData entity) where TBaseData : BaseData;
        IQueryable<TBaseData> Query<TBaseData>() where TBaseData : BaseData;

        void AddData<TBaseData>(TBaseData entity) where TBaseData : BaseData;
        void UpdateData<TBaseData>(TBaseData entity) where TBaseData : BaseData;
        void DeleteData<TBaseData>(TBaseData entity) where TBaseData : BaseData;
    }
}
