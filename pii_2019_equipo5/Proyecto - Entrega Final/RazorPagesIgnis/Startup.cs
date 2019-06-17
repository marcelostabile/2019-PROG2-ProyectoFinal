using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using RazorPagesIgnis.Models;
using RazorPagesIgnis.Areas.Identity.Data;

namespace RazorPagesIgnis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Cookie policy.
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Databases contexts.
            services.AddDbContext<IgnisContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("IgnisContext")));

            services.AddDbContext<IgnisIdentityContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("IgnisContext")));

            // // services: defined role-based policies: pages access by role.
            // services.AddAuthorization(options => 
            // {
            //     options.AddPolicy("AdministradorPolicy", policy => 
            //     {
            //         policy.RequireRole("Administrador");
            //     } );

            //     options.AddPolicy("ClientePolicy", policy => 
            //     {
            //         policy.RequireRole("Cliente");
            //     } );    

            //     options.AddPolicy("TecnicoPolicy", policy => 
            //     {
            //         policy.RequireRole("Técnico");
            //     } );    
            // } );

            // MVC authenticate policy.
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            } ) 
                    .AddRazorPagesOptions(options =>
                    {
                        // // administrators.
                        // options.Conventions.AuthorizeFolder("/Index", "AdministradorPolicy")
                        //     .AuthorizeFolder("/administradores", "AdministradorPolicy")
                        //     .AuthorizeFolder("/clientes", "AdministradorPolicy")
                        //     .AuthorizeFolder("/tecnicos", "AdministradorPolicy")
                        //     .AuthorizeFolder("/proyectos", "AdministradorPolicy")
                        //     .AuthorizeFolder("/solicitudes", "AdministradorPolicy")
                        //     .AuthorizeFolder("/roles", "AdministradorPolicy");
                        // // clients.
                        // options.Conventions
                        //     .AuthorizeFolder("/Index", "ClientePolicy")
                        //     .AuthorizeFolder("/proyectos", "ClientePolicy")
                        //     .AuthorizeFolder("/solicitudes", "ClientePolicy");
                        // // technicians.
                        // options.Conventions
                        //     .AuthorizeFolder("/Index", "TecnicoPolicy")
                        //     .AuthorizeFolder("/roles", "TecnicoPolicy");
                        // anonymous.
                        options.Conventions
                            .AllowAnonymousToPage("/Index")
                            .AllowAnonymousToPage("/Privacy");
                    } )
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
