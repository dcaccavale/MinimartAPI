using AutoMapper;
using Core;
using Core.Interfaces;
using Core.Services;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Minimart_API
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
            services.AddDbContext<MinimarketDataContext>(options => options.UseSqlServer("Data Source=LAPTOP-L7FH2BKE\\SQLDARIO;Initial Catalog=Minimart;User Id=sa; Password=dario1234"));

            ///Configure Ioc Services
            IoCServices.AddDependency(services);





            services.AddAutoMapper(typeof(DomainProfile));
            services.AddLogging();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minimart_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerfactory)
        {

            loggerfactory.CreateLogger<Startup>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimart_API v1"));
            }

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
