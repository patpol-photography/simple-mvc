namespace RazorWeb
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Piranha;
    using Piranha.AspNetCore.Identity.SQLite;
    using Piranha.AttributeBuilder;
    using Piranha.Cache;
    using Piranha.Manager.Binders;
    using RazorWeb.Models;
    using RazorWeb.Models.Blocks;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config => { config.ModelBinderProviders.Insert(0, new AbstractModelBinderProvider()); });
            services.AddPiranhaApplication();
            services.AddPiranhaFileStorage();
            services.AddPiranhaImageSharp();
            services.AddPiranhaEF(options =>
                options.UseSqlite("Filename=./piranha.razorweb.db"));
            services.AddPiranhaIdentityWithSeed<IdentitySQLiteDb>(options =>
                options.UseSqlite("Filename=./piranha.razorweb.db"));
            services.AddPiranhaManager();
            services.AddMemoryCache();
            services.AddPiranhaMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApi api)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            App.Init(api);

            // Configure cache level
            App.CacheLevel = CacheLevel.Basic;

            // Custom components
            App.Blocks.Register<SeparatorBlock>();

            // Build content types
            var pageTypeBuilder = new PageTypeBuilder(api)
                .AddType(typeof(BlogArchive))
                .AddType(typeof(StandardPage))
                .AddType(typeof(TeaserPage));
            pageTypeBuilder.Build()
                .DeleteOrphans();
            var postTypeBuilder = new PostTypeBuilder(api)
                .AddType(typeof(BlogPost));
            postTypeBuilder.Build()
                .DeleteOrphans();

            // Register middleware
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UsePiranha();
            app.UsePiranhaManager();
            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute",
                    "{area:exists}/{controller}/{action}/{id?}",
                    new {controller = "Home", action = "Index"});
            });

            Seed.RunAsync(api).GetAwaiter().GetResult();
        }
    }
}