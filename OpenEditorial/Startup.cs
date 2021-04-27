using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha;
using Piranha.AttributeBuilder;
using Piranha.Data.EF.SQLite;
using Piranha.Data.EF.SQLServer;
using OpenEditorial.Services;

namespace OpenEditorial
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddControllersWithViews();

            if (Env.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }


            services.AddPiranha(options =>
            {
                options.UseFileStorage(naming: Piranha.Local.FileStorageNaming.UniqueFolderNames);
                options.UseImageSharp();
                options.UseManager();
                options.UseTinyMCE();
                //options.UseMemoryCache();
                if (Env.IsDevelopment())
                {
                    options.UseEF<SQLiteDb>(db =>
                        db.UseSqlite(Configuration.GetConnectionString("CMSConnectionString")));
                }
                else
                {
                    options.UseEF<SQLServerDb>(db =>
                        db.UseSqlServer(Configuration.GetConnectionString("CMSConnectionString")));
                }
            });

            services.AddPiranhaSimpleSecurity(
                new Piranha.AspNetCore.SimpleUser(Piranha.Manager.Permission.All())
                {
                    UserName = "admin",
                    Password = "demopass"
                },
                new Piranha.AspNetCore.SimpleUser(Piranha.Manager.Permission.All())
                { 
                    UserName = "demo",
                    Password = "password"
                },
                new Piranha.AspNetCore.SimpleUser(new string[] { 
                    Piranha.Manager.Permission.Admin, 
                    Piranha.Manager.Permission.Comments,
                    Piranha.Manager.Permission.Content,
                    Piranha.Manager.Permission.ContentEdit,
                    Piranha.Manager.Permission.Media,
                    Piranha.Manager.Permission.Pages,
                    //Piranha.Manager.Permission.PagesAdd,
                    Piranha.Manager.Permission.PagesEdit,
                    Piranha.Manager.Permission.PagesPublish,
                    Piranha.Manager.Permission.PagesSave,
                    Piranha.Manager.Permission.Posts,
                    Piranha.Manager.Permission.PostsAdd,
                    Piranha.Manager.Permission.PostsDelete,
                    Piranha.Manager.Permission.PostsEdit,
                    Piranha.Manager.Permission.PostsPublish,
                    Piranha.Manager.Permission.PostsSave,
                    Piranha.Manager.Permission.SitesEdit,
                    Piranha.Manager.Permission.SitesSave

                })
                {
                    UserName = "demo2",
                    Password = "password"
                }
            );

            services.AddScoped<IUI, UI>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApi api)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });*/

            App.Init(api);
            new ContentTypeBuilder(api)
                .AddAssembly(typeof(Startup).Assembly)
                .Build()
                .DeleteOrphans();
            App.Hooks.OnGenerateSlug += (str) => { return OpenEditorial.Utils.SlugHook.OnGenerateSlug(str); };

            app.UsePiranha(options => {
                options.UseManager();
                options.UseTinyMCE();
                //options.UseIdentity();
            });

            App.Modules.Manager().Styles.Add("~/css/manager.css");
        }
    }
}
