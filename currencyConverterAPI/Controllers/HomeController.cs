using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System;
using Microsoft.AspNetCore.Http;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Runtime.Serialization.Json;
using currencyConverterAPI.Interfaces;
using currencyConverterAPI;

namespace APIConsume.Controllers
{
    public class HomeController : Controller

    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetData()
        {
            ICurrencyData data = new Data();

            return View(await data.DisplayDataAsync());
        }

        public async Task<IActionResult> GetTargetData(string Target)
        {
            ICurrencyData data = new Data();
            
            return View(await data.DisplayTargetDataAsync(Target));
        }

        public async Task<IActionResult> GetConvertData(string from, string to, float amount)
        {
            ICurrencyData data = new Data();

            return View(await data.ConvertDataAsync(from, to, amount));
        }

        public async Task<IActionResult> GetConvertDate(int date)
        {
            ICurrencyData data = new Data();

            return View(await data.ConvertDateAsync(date));
        }
    }
}



        
