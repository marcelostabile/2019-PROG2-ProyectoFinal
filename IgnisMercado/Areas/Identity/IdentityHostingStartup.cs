using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models;

[assembly: HostingStartup(typeof(IgnisMercado.Areas.Identity.IdentityHostingStartup))]
namespace IgnisMercado.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { 
                services.AddDefaultIdentity<ApplicationUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationContext>();

                // services.AddDbContext<IgnisIdentityContext>(options =>
                //     options.UseSqlite(
                //         context.Configuration.GetConnectionString("IgnisContext")));

                // services.AddDefaultIdentity<ApplicationUser>()
                //     .AddEntityFrameworkStores<IgnisIdentityContext>();

            });
        }
    }
}