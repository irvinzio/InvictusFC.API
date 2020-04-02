using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InvictusFC.BL;
using InvictusFC.Data.Context;
using InvictusFC.Data.Repositories;
using InvictusFC.Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace InvictusFC.API
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
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            var configBuilder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json", optional: true);
            var config = configBuilder.Build();

            services.Configure<DatabaseOptions>(Configuration.GetSection("Database"));

            services.AddDbContext<InvictusContext>(item =>{
                item.UseSqlServer(Configuration.GetSection("Database").GetSection("ConnectionString").Value);
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserManager, UserManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
