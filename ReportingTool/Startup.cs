using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReportingTool.Models;

namespace Reportingtool
{
    public class Startup
    {

        public IConfiguration configuration { get; }

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddMvc(option => option.EnableEndpointRouting = false);

            var connection = configuration.GetConnectionString("CVXDevDb");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));


        }

     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
            
        }
    }
}
