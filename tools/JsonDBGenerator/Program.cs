using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDBGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //csv list to json array


            var items = System.IO.File.ReadLines(args[0]);

            var jsonArray = Newtonsoft.Json.JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText("output.json", jsonArray);

        }
    }
}
