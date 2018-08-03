using System;
using System.Collections.Generic;
using riminder;

namespace csharp_riminder_api
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new riminder.Riminder("ask_4b7fa33174a7113fbd16d806dbd21c07");
            var resp = api._client.get<List<riminder.response.SourceListElem>>("sources");
            Console.WriteLine("Hello World!");
            Console.WriteLine(resp);
        }
    }
}
