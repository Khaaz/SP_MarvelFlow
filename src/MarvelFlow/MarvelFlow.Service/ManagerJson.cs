using MarvelFlow.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Service
{
    class ManagerJson
    {
        public static List<Hero> InitJsonDB()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathHero"];

            string jsonAsString = File.ReadAllText(filePath);

            Object tempListHero = JObject.Parse(jsonAsString);
            Console.WriteLine(tempListHero);

            return new List<Hero>();
            //https://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
        }
    }
}
