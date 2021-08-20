using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  APIConsume.Models
{
    public class CurrencyData
    {
        public bool success { get; set; }        
        public string timestamp { get; set; }                
        public string @base { get; set; }                
        public string date { get; set; }        
        public List<String> rates { get; set; }
        


    }
}