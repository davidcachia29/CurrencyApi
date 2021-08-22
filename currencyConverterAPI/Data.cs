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
        public CurrencyData finalData;       

        //Task 1 To display basic data
        public async Task<CurrencyData> DisplayDataAsync()
        {
            finalData = new CurrencyData();
            
            //Using the HTTP Client
            using (var httpClient = new HttpClient())
            {
                //Setting the api link
                using (var response = await httpClient.GetAsync("https://api.exchangeratesapi.io/v1/latest?access_key=24398c31c37c2d91d8afd8153e00160e&format=1"))
                {
                    //Method to deserialise the json response of the api
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(apiResponse);
                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(CurrencyData));
                    byte[] byteArray = Encoding.UTF8.GetBytes(apiResponse);
                    MemoryStream stream = new MemoryStream(byteArray);

                    //The Final deserialised data
                    finalData = (CurrencyData)deserializer.ReadObject(stream);

                    //Looping through all the data to save the results individualy
                    foreach (var val in json.Last.First)
                    {
                        finalData.rates.Add(val.ToString());
                    }


                }
            }     
            //Return the final data
            return (finalData);
        }
        //Task 2 To display data with a chosen target
        public async Task<CurrencyData> DisplayTargetDataAsync(string target)
        {
            finalData = new CurrencyData();

            //Using the HTTP Client
            using (var httpClient = new HttpClient())
            {
                //Setting the api link
                using (var response = await httpClient.GetAsync("http://api.exchangeratesapi.io/v1/latest?access_key=24398c31c37c2d91d8afd8153e00160e&format=1&Base=" + target))
                {
                    //Method to deserialise the json response of the api
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(apiResponse);
                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(CurrencyData));
                    byte[] byteArray = Encoding.UTF8.GetBytes(apiResponse);
                    MemoryStream stream = new MemoryStream(byteArray);

                    //The Final deserialised data
                    finalData = (CurrencyData)deserializer.ReadObject(stream);
                    //Populating the "target" data
                    finalData.@base = target;                    

                    //Checking if the data returned is not an error
                    foreach (var val in json.Last.First)
                    {
                        //Return final data which contains error
                        if (json.First.ToString().Contains("error"))
                        {
                            return (finalData);
                        }
                        else
                        //Add the data
                        {
                            finalData.rates.Add(val.ToString());
                        }                        
                    }
                }
            }
            //Return the data to the view
            return (finalData);
        }
        //Task 3 To display the result of two currencies
        public async Task<CurrencyData> ConvertDataAsync(string from, string to, float amount)
        {

            finalData = new CurrencyData();

            //Can automaticly get result but following requirements and calculating it manually
            //string url = "http://api.exchangeratesapi.io/v1/convert?access_key=24398c31c37c2d91d8afd8153e00160e&from="+ from + "&to="+ to +"&amount=" + amount;

            //Setting the Api
            string url = "http://api.exchangeratesapi.io/v1/latest?access_key=24398c31c37c2d91d8afd8153e00160e&symbols=" + to + "&Base=" + from + "&format=1";

            //Setting the values for the HTTP Post
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("From", from),
                    new KeyValuePair<string, string>("To", to),
                    new KeyValuePair<string, string>("Amount", amount.ToString())
                };

            //^ Setting the Encoded Content with the valuse created above ^
            HttpContent q = new FormUrlEncodedContent(queries);

            //Using the HTTP Client
            using (HttpClient client = new HttpClient())
            {
                //Using PostRequest
                using (HttpResponseMessage response = await client.PostAsync(url, q))
                {
                    using (HttpContent content = response.Content)
                    {
                        //Method to deserialise the json response of the api
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(apiResponse);
                        DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(CurrencyData));
                        byte[] byteArray = Encoding.UTF8.GetBytes(apiResponse);
                        MemoryStream stream = new MemoryStream(byteArray);

                        //The Final deserialised data
                        finalData = (CurrencyData)deserializer.ReadObject(stream);
                        //Showing the converstion
                        finalData.@base = "From " + from + " To " + to;

                        //Error Proofing the Results
                        foreach (var val in json.Last.First)
                        {
                            if (json.First.ToString().Contains("invalid"))
                            {
                                //Showing data inputed is incorrect
                                finalData.result = "Invalid Currency";
                                return (finalData);
                            }
                            else
                            {
                                float total = (float)val.Last;

                                //Showing that data is left out
                                if (amount.ToString() == "0")
                                {
                                    finalData.result = "Amount Left Empty Or 0";
                                    return (finalData);
                                }
                                //If everything is inputed correctly
                                else
                                {
                                    //Add correct data
                                    finalData.result = (amount * total).ToString();
                                }
                            }
                        }
                    }
                }
                //Return Data To View
                return (finalData);
            }
        }
        //Task 4 To display the data of x days ago
        public async Task<CurrencyData> ConvertDateAsync(int days)
        {            
            finalData = new CurrencyData();

            //Setting The Date Variable
            DateTime thisDay = DateTime.Today;
            DateTime reducedDate = DateTime.Now.AddDays(-days);
            string month , day;

            //Making the data returned readable by the Api By adding a dd-mm-yyyy Format
            if (reducedDate.Month <= 9)
            {
                month = "0" + reducedDate.Month.ToString();
            }
            else
            {
                month = reducedDate.Month.ToString();
            }
            if (reducedDate.Day <= 9)
            {
                day = "0" + reducedDate.Day.ToString();
            }
            else
            {
                day = reducedDate.Day.ToString();
            }

            //Saving the correct reduced date
            string date = reducedDate.Year.ToString() + "-" + month + "-" + day  ;

            //Using the HTTP Client
            using (var httpClient = new HttpClient())
            {
                //Setting the api link
                using (var response = await httpClient.GetAsync("https://api.exchangeratesapi.io/v1/" + date + "?access_key=24398c31c37c2d91d8afd8153e00160e&base=EUR"))
                {
                    //Method to deserialise the json response of the api
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(apiResponse);
                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(CurrencyData));
                    byte[] byteArray = Encoding.UTF8.GetBytes(apiResponse);
                    MemoryStream stream = new MemoryStream(byteArray);

                    //The Final deserialised data
                    finalData = (CurrencyData)deserializer.ReadObject(stream);

                    //Making data error proof
                    foreach (var val in json.Last.First)
                    {
                        //If data shows error
                        if (json.First.ToString().Contains("false"))
                        {
                            //Show that an error occured
                            return (finalData);
                        }
                        else
                        {
                            //Add the data
                            finalData.rates.Add(val.ToString());
                        }
                    }
                }
            }
            //Return The data to the view
            return (finalData);
        }
    }
}
