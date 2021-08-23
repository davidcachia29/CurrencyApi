using currencyConverterAPI.Interfaces;
using currencyConverterAPI.Services;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace currencyConverterAPI
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();           

            services.AddSwaggerGen();
            //services.ConfigureSwaggerGen();

            //services.AddSingleton<ICurrencyData, Data>();
            services.addMyData();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;                
            });


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("https://api.exchangeratesapi.io/v1/latest?access_key=24398c31c37c2d91d8afd8153e00160e&format=1", "Data");                
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see http://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
