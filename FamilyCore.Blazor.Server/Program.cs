using System.Reflection;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.DesignTime;
using DevExpress.ExpressApp.Blazor.Services;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.Utils;
using FamilyCore.Module.BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace FamilyCore.Blazor.Server;

public class Program : IDesignTimeApplicationFactory {
    private static bool ContainsArgument(string[] args, string argument) {
        return args.Any(arg => arg.TrimStart('/').TrimStart('-').ToLower() == argument.ToLower());
    }
    public static int Main(string[] args) {
        
        MigrateDb();
        
        if(ContainsArgument(args, "help") || ContainsArgument(args, "h")) {
            Console.WriteLine("Updates the database when its version does not match the application's version.");
            Console.WriteLine();
            Console.WriteLine($"    {Assembly.GetExecutingAssembly().GetName().Name}.exe --updateDatabase [--forceUpdate --silent]");
            Console.WriteLine();
            Console.WriteLine("--forceUpdate - Marks that the database must be updated whether its version matches the application's version or not.");
            Console.WriteLine("--silent - Marks that database update proceeds automatically and does not require any interaction with the user.");
            Console.WriteLine();
            Console.WriteLine($"Exit codes: 0 - {DBUpdaterStatus.UpdateCompleted}");
            Console.WriteLine($"            1 - {DBUpdaterStatus.UpdateError}");
            Console.WriteLine($"            2 - {DBUpdaterStatus.UpdateNotNeeded}");
        }
        else {
            DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.Latest;
            IHost host = CreateHostBuilder(args).Build();
            if(ContainsArgument(args, "updateDatabase")) {
                using(var serviceScope = host.Services.CreateScope()) {
                    return serviceScope.ServiceProvider.GetRequiredService<DevExpress.ExpressApp.Utils.IDBUpdater>().Update(ContainsArgument(args, "forceUpdate"), ContainsArgument(args, "silent"));
                }
            }
            else {
                host.Run();
            }
        }
        return 0;
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            });
    XafApplication IDesignTimeApplicationFactory.Create() {
        IHostBuilder hostBuilder = CreateHostBuilder(Array.Empty<string>());
        return DesignTimeApplicationFactoryHelper.Create(hostBuilder);
    }

    public static void MigrateDb()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("ConnectionString");

        var optionsBuilder = new DbContextOptionsBuilder<FamilyCoreEFCoreDbContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        using (var context = new FamilyCoreEFCoreDbContext(optionsBuilder.Options))
        {
            context.Database.Migrate();
        }
    }
}
