using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InvictusFC.BL;
using InvictusFC.Data.Context;
using InvictusFC.Data.Entities;
using InvictusFC.Data.Repositories;
using InvictusFC.Domain.Configuration;
using InvictusFC.Domain.Enums;
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
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Invicti Functional Combat API",
                    Description = "API to interact with Invictus Data",
                    //TermsOfService = new Uri("TDB"),
                    Contact = new OpenApiContact
                    {
                        Name = "Irving Ramirez",
                        Email = "Irvinzio.ram@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/irving-ramirez-847395a5/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "TBD",
                        //Url = new Uri("TDB"),
                    }
                });
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

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<InvictusContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.BranchOffices.Add(new BranchOffice { Name = "Invictus" });
                context.Users.Add(
                    new User {
                          Name = "poo",
                          LastName = "tito",
                          SurName = "gay",
                          Cellphone = "33123456",
                          Email = "pootito@gay.com",
                          UserType = 0,
                          BranchOfficeId= 1,
                          Identification = new Identification { Number = "hdsptm123", IdentificationType=0 },
                          Address = new Address {
                            StreetName = "Juan manuel",
                            InteriorNumber = "1380B",
                            ExteriorNumber = "",
                            County = "",
                            Colony = "santa teresita",
                            State = (int)StateEnum.Guadalajara,
                            Country = (int)CountryEnum.Mexico
                          }
                    });
                context.SaveChanges();
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
