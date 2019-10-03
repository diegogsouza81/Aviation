using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AviationApp.EntityFrameworkCore
{
    public static class AviationAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AviationAppDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AviationAppDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
