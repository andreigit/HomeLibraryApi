﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi
{
    using Models;
    using Repositories;

    sealed class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            var connectionString = this.Configuration.GetConnectionString("BookLibraryContext");
            services.AddDbContext<BookLibraryContext>(
                options => options.UseSqlServer(
                    connectionString,
                    optionsBuilder => optionsBuilder.MigrationsAssembly("BookLibraryApi")));
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<AuthorsRepository>();
            services.AddSingleton<EditionsRepository>();
            services.AddSingleton<GenresRepository>();
            services.AddSingleton<VolumesRepository>();
            services.AddSingleton<VolumeExemplarsRepository>();
            services.AddSingleton<WorksRepository>();
            services.AddSingleton<WorkKindsRepository>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureDbContext(services);

            this.ConfigureRepositories(services);

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
