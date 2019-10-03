using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AviationApp.Authorization.Roles;
using AviationApp.Authorization.Users;
using AviationApp.MultiTenancy;
using AviationApp.Aviation;

namespace AviationApp.EntityFrameworkCore
{
    public class AviationAppDbContext : AbpZeroDbContext<Tenant, Role, User, AviationAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public AviationAppDbContext(DbContextOptions<AviationAppDbContext> options)
            : base(options)
        {
        }
    }
}
