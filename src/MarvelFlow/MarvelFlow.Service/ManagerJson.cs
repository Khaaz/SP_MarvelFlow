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
        public static List<Hero> GetHeroes()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathHero"];

            string jsonAsString = File.ReadAllText(filePath);

            List<HeroJson> HeroList = JsonConvert.DeserializeObject<List<HeroJson>>(jsonAsString);

            List<Hero> listHero = HeroList.ToListHero().ToList();

            return listHero;
        }

        public static List<Film> getFilms()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathFilm"];

            string jsonAsString = File.ReadAllText(filePath);

            List<FilmJson> FilmList = JsonConvert.DeserializeObject<List<FilmJson>>(jsonAsString);

            List<Film> listFilms = FilmList.ToListFilm().ToList();

            return listFilms;
        }
    }
}
