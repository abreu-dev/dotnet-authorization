using Autho.Infra.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection;

namespace Autho.Infra.Data.Context
{
    public class AuthoContext : DbContext, IAuthoContext
    {
        public AuthoContext(DbContextOptions<AuthoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<TBaseData> GetDbSet<TBaseData>() where TBaseData : BaseData
        {
            return Set<TBaseData>();
        }

        public EntityEntry<TBaseData> GetDbEntry<TBaseData>(TBaseData entity) where TBaseData : BaseData
        {
            return Entry(entity);
        }

        public IQueryable<TBaseData> Query<TBaseData>() where TBaseData : BaseData
        {
            return Set<TBaseData>().AsQueryable();
        }

        public void AddData<TBaseData>(TBaseData entity) where TBaseData : BaseData
        {
            Add(entity);
        }

        public void UpdateData<TBaseData>(TBaseData entity) where TBaseData : BaseData
        {
            Update(entity);
        }

        public void DeleteData<TBaseData>(TBaseData entity) where TBaseData : BaseData
        {
            Remove(entity);
        }

        public void Complete()
        {
            SaveChanges();
        }
    }
}
