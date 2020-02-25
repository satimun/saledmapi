using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace kkfmisservice
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
                options.AddPolicy("AllowCors", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .WithOrigins("http://localhost:8080", "https://kkfmisapi.kkfnets.com", "http://kkfmisapi.kkfnets.com")
                    //.WithMethods("GET", "PUT", "POST", "DELETE")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders("x-custom-header");
                });
            });

            //services.AddWebSocketManager();

            //services.AddHostedService<JobService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //--set config                 
                Ado.Mssql.Base.conString = Configuration["MssqlDev"];
                //Core.Recaptha.Recaptha.secret = Configuration["RecaptchaSecretKeyDev"];
            }
            else
            {
                app.UseHsts();
                //--set config 
                if (Configuration["ProdMode"] == "Y")
                {
                    Ado.Mssql.Base.conString = Configuration["MssqlProd"];
                }
                else
                {
                    Ado.Mssql.Base.conString = Configuration["MssqlDev"];
                }

                // Core.Recaptha.Recaptha.secret = Configuration["RecaptchaSecretKeyProd"];
            }

            //Ado.Oracel.Base.conString = Configuration["Oracel"];
            //StaticValue.GetInstant().LoadInstantAll();

            app.UseCors("AllowCors");
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
