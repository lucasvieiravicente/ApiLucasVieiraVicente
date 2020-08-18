using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ApiLucasVieiraVicente.Data.Context;
using ApiLucasVieiraVicente.Data.Repository;
using ApiLucasVieiraVicente.Data.Repository.Interfaces;
using ApiLucasVieiraVicente.Data.UoW;
using ApiLucasVieiraVicente.Data.UoW.Interfaces;
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

namespace ApiLucasVieiraVicente
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
            string stringConnection = Configuration["Sqlite:SqliteConnectionString"];

            services.AddDbContext<GameContext>(options =>
                options.UseSqlite(stringConnection)
            );

            services.AddSwaggerGen();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUoW, UoW>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Lucas",
                    Description = "A simple to create a mockup and study",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Vieira Vicente",
                        Email = "lucasvieiravicente1@gmail.com",
                        Url = new Uri("https://webresumelucas.azurewebsites.net/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT License",
                        Url = new Uri("https://www.mit.edu/~amini/LICENSE.md"),
                    }
                });
            });

            services.AddControllers();

            services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Lucas Vieira");
            }) ;
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
