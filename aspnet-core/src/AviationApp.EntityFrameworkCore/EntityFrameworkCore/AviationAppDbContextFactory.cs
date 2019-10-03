using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AviationApp.Configuration;
using AviationApp.Web;

namespace AviationApp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AviationAppDbContextFactory : IDesignTimeDbContextFactory<AviationAppDbContext>
    {
        public AviationAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AviationAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AviationAppDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AviationAppConsts.ConnectionStringName));

            return new AviationAppDbContext(builder.Options);
        }
    }
}
