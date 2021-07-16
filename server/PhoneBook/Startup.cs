using PhoneBook.Infrastructure.Extension;
using PhoneBook.Persistence;
using PhoneBook.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
namespace PhoneBook
{
    public class Startup
    {
        private readonly IConfigurationRoot configRoot;
        public Startup(IConfiguration configuration)
        {            
            Configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configRoot = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddController();

            services.AddDbContext(Configuration, configRoot);

            services.AddAutoMapper();

            services.AddAddScopedServices();

            services.AddSwaggerOpenAPI();

            services.AddMediatorCQRS();

            services.AddVersion();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log, IServiceProvider service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureCustomExceptionMiddleware();

            app.ConfigureSwagger();
            
            app.UseCors(options =>
               options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            RunMigrations(service);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RunMigrations(IServiceProvider service)
        {
            // This returns the context.
            using var context = service.GetService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
