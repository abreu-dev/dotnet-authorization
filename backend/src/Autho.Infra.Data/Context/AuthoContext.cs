using Microsoft.EntityFrameworkCore;
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
    }
}
