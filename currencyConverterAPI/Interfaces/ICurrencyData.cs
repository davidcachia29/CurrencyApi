using APIConsume.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace currencyConverterAPI.Interfaces
{
    public interface ICurrencyData
    {
        Task<CurrencyData> DisplayDataAsync();
        Task<CurrencyData> DisplayTargetDataAsync(string target);
        Task<CurrencyData> ConvertDataAsync(string from, string to, float amount);
        Task<CurrencyData> ConvertDateAsync(int date);
    }
}
