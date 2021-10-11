using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Operations.IOperations;
using Operations;
using Repository.IRepository;
using Repository;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.SpaServices.AngularCli;
using System.Net;
using AutoMapper;
using Common;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace API
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
            services.AddLogging((config) =>
            {
                config.AddNLog();
            });
            services.AddDbContext<MOENPCMContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContextPool<MOENPCMContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OnlineBillingConnection")));
            //.AddEntityFrameworkStores<MOENPCMContext>();
            services.AddScoped<ISupplierOperations, SupplierOperations>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IPCMRequestOperations, PCMRequestOperations>();
            services.AddScoped<IPCMRequestRepository, PCMRequestRepository>();
            services.AddScoped<IProductMetadataOperations, ProductMetadataOperations>();
            services.AddScoped<IProductMetadataRepository, ProductMetadataRepository>();
            //services.AddAutoMapper(typeof(Startup));
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
