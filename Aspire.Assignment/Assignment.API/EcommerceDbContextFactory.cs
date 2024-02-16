// using System.IO;
// using Assignment.Migrations;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;

// namespace EcommerceApp.Persistence
// {
//     public class EcommerceDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
//     {
//         public DatabaseContext CreateDbContext(string[] args)
//         {
        
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//             .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Assignment.API"))
//             .AddJsonFile("appsettings.json")
//             .Build();

//             var builder = new DbContextOptionsBuilder<DatabaseContext>();
//             var connectionString = configuration.GetConnectionString("DefaultConnection");

//             builder.UseSqlite(connectionString);
//             return new DatabaseContext(builder.Options);
//         }
//     }
// }