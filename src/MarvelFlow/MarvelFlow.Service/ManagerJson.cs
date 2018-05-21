using MarvelFlow.Classes;
using MarvelFlow.Service.Data;
using MarvelFlow.Service.Factory;
using Newtonsoft.Json;
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
    public class ManagerJson
    {
        public static List<Hero> InitJsonDB()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathHero"];

            string jsonAsString = File.ReadAllText(filePath);

            List<HeroJson> HeroList = JsonConvert.DeserializeObject<List<HeroJson>>(jsonAsString);

            List<Hero> listHero = HeroList.ToListHero().ToList();
                
            return listHero;
        }      
    }
}
