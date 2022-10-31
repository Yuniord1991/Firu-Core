using Firu_Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Firu.Services.Interfaces;
using Firu.Services.Services;
using AutoMapper;
using System.Reflection;

namespace Firu_Core
{
    public class Startup
    {
        private readonly string _MyCors = "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("FiruDatabase");
            services.AddDbContextPool<FiruDBContext>(options => options.UseSqlServer(connection));
            services.AddControllers();

            // Register CORS app
            services.AddCors(options => {
                options.AddPolicy(name: _MyCors, builder =>
                {
                    builder.SetIsOriginAllowed(_ => true);
                    builder.AllowCredentials();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });


            // Agregar Servicios junto con sus Interfaces
            services.AddScoped<IMascotaService, MascotaService>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddAutoMapper(Assembly.Load("Firu.Services"));

            // Register the Swagger generator, defining one or more Swagger documents
            AddSwagger(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(_MyCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            //AddCors(app);

        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Foo {groupName}",
                    Version = groupName,
                    Description = "Foo API",
                    Contact = new OpenApiContact
                    {
                        Name = "Foo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }

        //private static void AddCors(IApplicationBuilder app)
        //{
        //    app.UseCors(builder =>
        //    {
        //        builder.SetIsOriginAllowed(_ => true);
        //        builder.AllowCredentials();
        //        builder.AllowAnyHeader();
        //        builder.AllowAnyMethod();
        //    });
        //}
    }
}
