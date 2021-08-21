using APIConsume.Models;
using currencyConverterAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace currencyConverterAPI
{
    public class Data : ICurrencyData
    {
        public CurrencyData reservationList;

        public async Task<CurrencyData> ConvertDataAsync(string from, string to, int amount)
        {
            reservationList = new CurrencyData();

            //string url = "http://api.exchangeratesapi.io/v1/convert?access_key=24398c31c37c2d91d8afd8153e00160e&from="+ from + "&to="+ to +"&amount=" + amount;
            string url = "http://api.exchangeratesapi.io/v1/latest?access_key=24398c31c37c2d91d8afd8153e00160e&symbols=" + to + "&Base=" + from + "&format=1";

            string To;
            string From;

            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("From", from),
                    new KeyValuePair<string, string>("To", to),
                    new KeyValuePair<string, string>("Amount", amount.ToString())
                };

            HttpContent q = new FormUrlEncodedContent(queries);

            string[] dataNeeded;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url,q))
                {
                    using (HttpContent content = response.Content)
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

        public async Task<CurrencyData> DisplayDataAsync()
        {
            reservationList = new CurrencyData();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.exchangeratesapi.io/v1/latest?access_key=24398c31c37c2d91d8afd8153e00160e&format=1"))
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

       public async Task<CurrencyData> DisplayTargetDataAsync(string target)
        {
            reservationList = new CurrencyData();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://api.exchangeratesapi.io/v1/latest?access_key=24398c31c37c2d91d8afd8153e00160e&format=1&Base=" + target))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(apiResponse);

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(CurrencyData));

                    byte[] byteArray = Encoding.UTF8.GetBytes(apiResponse);

                    MemoryStream stream = new MemoryStream(byteArray);


                    reservationList = (CurrencyData)deserializer.ReadObject(stream);
                    reservationList.@base = target;                    

                    foreach (var val in json.Last.First)
                    {
                        if (json.First.ToString().Contains("false"))
                        {
                            return (reservationList);
                        }
                        else
                        {
                            reservationList.rates.Add(val.ToString());
                        }
                        
                    }


                }
            }
            return (reservationList);
        }
    }
}
