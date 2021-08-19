using APIConsume.Models;
using currencyConverterAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace currencyConverterAPI
{
    public class Data : ICurrencyData
    {
        public CurrencyData reservationList;
        public async Task<CurrencyData> DisplayDataAsync()
        {
            reservationList = new CurrencyData();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://api.exchangeratesapi.io/v1/latest?access_key=24398c31c37c2d91d8afd8153e00160e&format=1"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(apiResponse);

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(CurrencyData));

                    byte[] byteArray = Encoding.UTF8.GetBytes(apiResponse);

                    MemoryStream stream = new MemoryStream(byteArray);


                    reservationList = (CurrencyData)deserializer.ReadObject(stream);

                    foreach (var val in json.Last.First)
                    {
                        reservationList.rates.Add(val.ToString());
                    }


                }
            }           
            return (reservationList);
        }                
    }
}
