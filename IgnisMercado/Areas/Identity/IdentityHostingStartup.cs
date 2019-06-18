using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using IgnisMercado.Data;
using IgnisMercado.Areas.Identity.Data;

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
                    .AddEntityFrameworkStores<ApplicationDbContext>();

                // services.AddDbContext<IgnisIdentityContext>(options =>
                //     options.UseSqlite(
                //         context.Configuration.GetConnectionString("IgnisContext")));

                // services.AddDefaultIdentity<ApplicationUser>()
                //     .AddEntityFrameworkStores<IgnisIdentityContext>();

            });
        }
    }
}