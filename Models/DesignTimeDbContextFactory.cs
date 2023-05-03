using DejiClinic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DejiClinic.Models
{
    public class RegistrarContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {

        AuthDbContext IDesignTimeDbContextFactory<AuthDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AuthDbContext>();

            builder.UseMySql(configuration["ConnectionStrings:AuthDbContextConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:AuthDbContextConnection"]));

            return new AuthDbContext(builder.Options);
        }
    }
}