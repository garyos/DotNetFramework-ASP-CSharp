using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Models;
using MusicLibrary.Repositories;
namespace MusicLibrary
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
            services.AddDbContext<ApplicationDbContext>(Option =>
           Option.UseSqlServer(
               Configuration["Data:MusicLibraryProducts:ConnectionString"]));

            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ISongAlbumRepository, SongAlbumRepository>();
            services.AddTransient<ISongGenreRepository, SongGenreRepository>();
            services.AddTransient<ICollectiveRepository, CollectiveRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Song}/{action=List}/{id?}");
            });
            InitialData.EnusrePopulated(app);
           
        }
    }
    
}
