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
        /// <summary>
        /// Init List Heroes with a Json DB.
        /// Use a temp public class to init
        /// </summary>
        /// <returns>List Heroes</returns>
        public static List<Hero> GetHeroes()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathHero"];

            string jsonAsString = File.ReadAllText(filePath);

            List<HeroJson> HeroList = JsonConvert.DeserializeObject<List<HeroJson>>(jsonAsString);

            List<Hero> listHero = HeroList.ToListHero().ToList();

            return listHero;
        }

        /// <summary>
        /// Init List Films with a Json DB.
        /// Use a temp public class to init
        /// </summary>
        /// <returns>List Films</returns>
        public static List<Film> GetFilms()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathFilm"];

            string jsonAsString = File.ReadAllText(filePath);

            List<FilmJson> FilmList = JsonConvert.DeserializeObject<List<FilmJson>>(jsonAsString);

            List<Film> listFilms = FilmList.ToListFilm().ToList();

            return listFilms;
        }

        /// <summary>
        /// Init List Series with a Json DB.
        /// Use a temp public class to init
        /// </summary>
        /// <returns>List Series</returns>
        public static List<Serie> GetSeries()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathSerie"];

            string jsonAsString = File.ReadAllText(filePath);

            List<SerieJson> SerieList = JsonConvert.DeserializeObject<List<SerieJson>>(jsonAsString);

            List<Serie> listSeries = SerieList.ToListSerie().ToList();

            return listSeries;
        }
    }
}
