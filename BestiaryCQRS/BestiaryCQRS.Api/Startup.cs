using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using BestiaryCQRS.Api.Filters;
using BestiaryCQRS.Api.Tools;
using BestiaryCQRS.BestiaryCQRS.Domain.Handlers;
using BestiaryCQRS.BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.BestiaryCQRS.Infra.Migrations;
using BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.Domain.Core.Utils;
using BestiaryCQRS.Domain.Handlers;
using BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Infra.Mappings;
using BestiaryCQRS.Infra.Repositories;
using FluentMigrator.Runner;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace BestiaryCQRS.Api
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
            services.AddControllers().AddNewtonsoftJson();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            var connectionString = Configuration["ConnectionString"];

            var _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(
                    Assembly.GetAssembly(typeof(WeaponMap))
                ))
                .BuildSessionFactory();

            var serviceProvider = CreateServices(connectionString);

            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            services.AddSingleton(factory =>
            {
                return _sessionFactory.OpenSession();
            });

            services.AddControllers(opt =>
            {
                opt.Filters.Add<NHibernateSessionFilter>();
                opt.Filters.Add<NotificationFilter>();
            });

            services.AddMvc().AddFluentValidation(f =>
               f.RegisterValidatorsFromAssemblyContaining<CreateWeaponCommandValidator>()
            );

            services.AddScoped<IWeaponRepository, WeaponRepository>();
            services.AddScoped<ICreateWeaponHandler, CreateWeaponHandler>();
            services.AddScoped<IUpdateWeaponHandler, UpdateWeaponHandler>();
            services.AddScoped<IDeleteWeaponHandler, DeleteWeaponHandler>();
            services.AddScoped<IFilterByNameWeaponHandler, FilterByNameWeaponHandler>();
            services.AddScoped<NotificationContext>();


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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices(string conn)
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(conn)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(AddLogTable).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}


