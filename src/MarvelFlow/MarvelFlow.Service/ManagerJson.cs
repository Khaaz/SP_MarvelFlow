using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
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

        private List<Hero> ListHeros { get; set; }

        private List<ISearchableMovie> ListMovies { get; set; }

        public ManagerJson()
        {
            // Init Data from Json
            this.ListHeros = this.GetHeroes().OrderBy(h => h.Name).ToList(); // Sort by Name Default

            this.ListMovies = this.GetMovies().OrderBy(m => m.GetTitle()).ToList(); // Sort by Title Default

            // Init heros per movies
            foreach (ISearchableMovie m in this.ListMovies)
            {
                foreach (string h in m.GetHeroString())
                {
                    m.AddListHero(ListHeros.Find(hero => hero.Id == h));
                }

            }

            // Init movies per heroes
            foreach (Hero h in this.ListHeros)
            {
                foreach (Movie m in this.ListMovies)
                {
                    if (m.GetListHeros().Contains(h))
                    {
                        h.ListMovies.Add(m);
                    }
                }
            }

            // Init Data (Hardcode - test)

            List<string> stringheros = new List<string>
            {
                "Im",
                "SM"
            };

            Film f1 = new Film("AV3", "Avengers Infinity Wars", "ImagesMovie/Avengers3.jpg", "film Avengers 3 avec plein de gens dedans", "Frères Russo", "25/04/18", Universe.MCU, "/ba/im", stringheros);
            Film f2 = new Film("AM", "AntMan", "ImagesMovie/Antman2.jpg", "film homme fourmi", "Payton Reed", "14/07/15", Universe.MCU, "/ba/im", stringheros);
            Film f3 = new Film("IM1", "IronMan", "ImagesMovie/IronMan.jpg", "film homme de fer", "Jon Favreau", "30/04/08", Universe.MCU, "/ba/im", stringheros);

            Hero Im = new Hero("IM", "IronMan", "ImagesHero/ironMan.png", "voici ironMan", Team.Avengers);
            Hero Sm = new Hero("SM", "SpiderMan", "ImagesHero/spiderMan.png", "voici SpiderMan", Team.Avengers);
            Hero Ds = new Hero("Ds", "Doctor Strange", "ImagesHero/doctorStrange.png", "voici Doctor Strange", Team.Avengers);
            Hero Hu = new Hero("HK", "Hulk", "ImagesHero/hulk.png", "voici Hulk le géant vert", Team.Avengers);
            Hero Vi = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.BlackOrder);
            Hero Vi1 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.BlackOrder);
            Hero Vi2 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi3 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi4 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi5 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi6 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);

            f1.ListHeroes.Add(Im);
            f1.ListHeroes.Add(Sm);
            f1.ListHeroes.Add(Ds);

            this.ListMovies.Add(f1);
            this.ListMovies.Add(f2);
            this.ListMovies.Add(f3);

            List<Movie> ListMoviesTemp = new List<Movie>();
            ListMoviesTemp.Add(f1);
            ListMoviesTemp.Add(f2);
            ListMoviesTemp.Add(f3);

            Im.ListMovies = ListMoviesTemp;

            ListHeros.Add(Im);
            ListHeros.Add(Sm);
            ListHeros.Add(Ds);
            ListHeros.Add(Hu);
            ListHeros.Add(Vi);
            ListHeros.Add(Vi1);
            ListHeros.Add(Vi2);
            ListHeros.Add(Vi3);
            ListHeros.Add(Vi4);
            ListHeros.Add(Vi5);
            ListHeros.Add(Vi6);

        }

        /// <summary>
        /// Init List Heroes with a Json DB.
        /// Use a temp public class to init
        /// </summary>
        /// <returns>List Heroes</returns>
        public List<Hero> GetHeroes()
        {
            if (this.ListHeros != null)
            {
                return ListHeros;
            }
            string filePath = ConfigurationManager.AppSettings["jsonPathHero"];

            string jsonAsString = File.ReadAllText(filePath);

            List<HeroJson> HeroList = JsonConvert.DeserializeObject<List<HeroJson>>(jsonAsString);

            List<Hero> listHero = HeroList.ToListHero().ToList();

            return listHero;
        }

        public List<ISearchableMovie> GetMovies()
        {
            if (this.ListMovies != null)
            {
                return this.ListMovies;
            }

            List<ISearchableMovie> TempList = new List<ISearchableMovie>(this.GetFilms()); // ISearchaBleMovie instead of Movie
            return TempList.Concat(this.GetSeries()).ToList(); ;
 
        }

        /// <summary>
        /// Init List Films with a Json DB.
        /// Use a temp public class to init
        /// </summary>
        /// <returns>List Films</returns>
        public List<Film> GetFilms()
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
        public List<Serie> GetSeries()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathSerie"];

            string jsonAsString = File.ReadAllText(filePath);

            List<SerieJson> SerieList = JsonConvert.DeserializeObject<List<SerieJson>>(jsonAsString);

            List<Serie> listSeries = SerieList.ToListSerie().ToList();

            return listSeries;
        }

        public void SaveHero(Hero h)
        {
            HeroJson Hero = h.ToJsonHero();
        }

        public void SaveFilm(Film f)
        {
            FilmJson Film = f.ToJsonFilm();
        }

        public void SaveSerie(Serie s)
        {

        }
        
    }
}
