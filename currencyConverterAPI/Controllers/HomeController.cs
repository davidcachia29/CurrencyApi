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
        public async Task<IActionResult> IndexAsync()
        {
            ICurrencyData data = new Data();


            return View(await data.DisplayTargetDataAsync("BLABLA"));
           
            
        }
    }
}



        
