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
            
            var resp = api.source.list();
            Console.WriteLine("Hello World!");
            foreach(var source in resp)
            {
                Console.WriteLine("-------------");
                Console.WriteLine(String.Format("name: {0}", source.name));
                Console.WriteLine(String.Format("source_id: {0}", source.source_id));
                Console.WriteLine(String.Format("type: {0}", source.type));
                Console.WriteLine(String.Format("archive: {0}", source.archive));
                Console.WriteLine(String.Format("count_source: {0}", source.count_source));
                Console.WriteLine(String.Format("date_creation: {0}", source.date_creation));
            }
            Console.WriteLine(resp);
        }
    }
}
