using System;
using System.Collections.Generic;
using Riminder;
using Newtonsoft.Json;

namespace csharp_riminder_api
{
    class Program
    {
        static void Main(string[] args)
        {
            var lo = JsonConvert.DeserializeObject<Dictionary<string, object>>("{\"zap\":[]}");
            var api = new Riminder.Riminder("ask_4b7fa33174a7113fbd16d806dbd21c07");
            
            var resp = api.filter.get(filter_reference:"12345");
            Console.WriteLine(JsonConvert.SerializeObject(resp, Formatting.Indented));
        }
    }
}
