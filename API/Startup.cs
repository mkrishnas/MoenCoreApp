// <copyright file="Startup.cs" company="Yash Technologies Pvt Ltd.">
// Copyright (c) Yash Technologies Pvt Ltd.. All rights reserved.
// </copyright>

namespace API
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using API.Logging;
    using AutoMapper;
    using Common;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using Models.Models;
    using NLog;
    using NLog.Extensions.Logging;
    using Operations;
    using Operations.IOperations;
    using Repository;
    using Repository.IRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="Startup"/> class.
    /// </summary>
    /// <param name="configuration">Start Up.</param>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Start Up.</param>
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure Services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureLoggerService();
            services.AddControllers();
            services.AddLogging((config) =>
            {
                config.AddNLog();
            });

            services.AddDbContext<MOENPCMContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<GlobalExceptionFilter>();
            services.AddScoped<GlobalExceptionHandler>();
            services.AddScoped<ISupplierOperations, SupplierOperations>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IPCMRequestOperations, PCMRequestOperations>();
            services.AddScoped<IPCMRequestRepository, PCMRequestRepository>();
            services.AddScoped<IProductMetadataOperations, ProductMetadataOperations>();
            services.AddScoped<IProductMetadataRepository, ProductMetadataRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        /// <summary>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">app.</param>
        /// <param name="env">env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
