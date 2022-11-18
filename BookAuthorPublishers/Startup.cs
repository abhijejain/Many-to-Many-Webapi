using BookAuthorPublishers.BusineesLogic.AuthorService;
using BookAuthorPublishers.BusineesLogic.PublisherService;
using BookAuthorPublishers.BusinessLayer.BooksService;
using BookAuthorPublishers.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers
{
    public class Startup
    {
       // public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            //ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
           
            //Configure DBContext with SQL
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            //  Configuration.GetConnectionString("ConnectionStrings")));
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddTransient<IBooksBusinees, BooksBusinees>(); 
            services.AddTransient<IAuthorBusinees, AuthorBusinees>();
            services.AddTransient<IPublisherBusiness,PublisherBusiness>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "my_books", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "my_books v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           // AppInitializer.Seed(app);
        }
    }
}
