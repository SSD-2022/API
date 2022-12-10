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
using Newtonsoft.Json.Serialization;
using WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApp
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
            services.AddCors(options =>
            {
                // Current policy allows users for anywhere or any origin to connect can be changed later to improve 
                //security
                options.AddPolicy("AllowOrigin", c =>
                {
                    c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });

            });


            services.AddControllersWithViews().AddNewtonsoftJson(Options =>
            Options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
            .Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
                options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddControllers();

            services.AddDbContext<DbContext_dpal>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("dpal")));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            // if (env.IsDevelopment())
            // {
            app.UseDeveloperExceptionPage();
            // }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
