using APIConsume.Controllers;
using APIConsume.Models;
using currencyConverterAPI.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace currencyConverterAPI.Services
{
    public static class DependencyInjectionRegistory
    {
        public static IServiceCollection addMyData(this IServiceCollection services)
        {
            services.AddSingleton<ICurrencyData, Data>();
            return services;
        }
    }
}
