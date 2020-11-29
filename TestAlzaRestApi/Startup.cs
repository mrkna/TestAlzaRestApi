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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestAlzaRestApi.Controllers;
using TestAlzaRestApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestAlzaRestApi
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
            services.AddDbContext<ProductContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AlzaConnectionString")));

            services.AddControllers(option =>
            {
                option.Conventions.Add(new GroupingByNamespaceConvention());

            });

            services.AddSwaggerGen(c =>
            {
                string titleBase = "TestAlzaRestApi";
                string description = "REST API service providing all available products of an eshop and enabling the partial update of one product";
                OpenApiContact contact = new OpenApiContact()
                {
                    Name = "Zdeněk Dumbrovský",
                    Email = "dumbrovsky²seznam.cz",
                };

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = titleBase + " v1",
                    Version = "v1",
                    Description = description,
                    Contact = contact

                });

                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "TestAlzaRestApi",
                    Version = "v2",
                    Description = description,
                    Contact = contact
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestAlzaRestApi v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "TestAlzaRestApi v2");
                });
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
