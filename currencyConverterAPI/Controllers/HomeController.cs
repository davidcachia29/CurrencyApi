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

namespace APIConsume.Controllers
{
    public class HomeController : Controller
    {

        string apiResponse;
        //JObject json;

        public async Task<IActionResult> Index()
        {
            Reservation reservationList = new Reservation ();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://api.exchangeratesapi.io/v1/latest?access_key=24398c31c37c2d91d8afd8153e00160e&format=1"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(apiResponse);

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Reservation));

                    byte[] byteArray = Encoding.UTF8.GetBytes(apiResponse);
                    
                    MemoryStream stream = new MemoryStream(byteArray);

                    reservationList = (Reservation)deserializer.ReadObject(stream);
                    
                }
            }
            return View(reservationList);
        }

        

        public ViewResult GetReservation() => View();
        
    }
}