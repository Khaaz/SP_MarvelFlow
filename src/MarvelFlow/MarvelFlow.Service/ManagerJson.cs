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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarvelFlow.Service
{
    public class ManagerJson
    {

        private List<Hero> ListHeros { get; set; }

        private List<ISearchableMovie> ListMovies { get; set; }

        public ManagerJson()
        {
        }

        /// <summary>
        /// Init All list + dispatch exception
        /// </summary>
        public void LoadHero()
        {
            // Init Data from Json
            this.ListHeros = this.GetHeroes(); // No Sorted by Default

            this.ListMovies = this.GetMovies(); // Not Sorted by Default

            // Init heros per movies
            foreach (ISearchableMovie m in this.ListMovies)
            {
                foreach (string h in m.GetHeroString())
                {
                    m.AddListHero(ListHeros.Find(hero => hero.Id == h));
                }
                m.SortListHeros();
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
                h.SortListMovies();
            }
        }

        /// <summary>
        /// Init List Heroes with a Json DB.
        /// Use a temp public class to init
        /// 
        /// Remmove all Hero that doesn't pass validityCheck
        /// </summary>
        /// <returns>List Heroes</returns>
        /// <exception cref="FileNotFoundException">Incorrect path</exception>
        /// <exception cref="Exception">List Empty</exception>
        public List<Hero> GetHeroes()
        {
            if (this.ListHeros != null)
            {
                return ListHeros;
            }
            string filePath = ConfigurationManager.AppSettings["jsonPathHero"];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Incorrect Path to Hero.json");
            }

            string jsonAsString = File.ReadAllText(filePath);

            List<HeroJson> HeroList = JsonConvert.DeserializeObject<List<HeroJson>>(jsonAsString); // raise an exception - catch in caller

            List<HeroJson> HeroListValid = new List<HeroJson>();
            foreach (HeroJson h in HeroList) // Add valid heroes
            {
                if (h.CheckValidity())
                {
                    if(!HeroListValid.Any(o => o.Id == h.Id)) // Check that the ID is not taken
                    { 
                        HeroListValid.Add(h);
                    }
                }
            }

            if (HeroListValid.Count == 0) // List empty
            {
                throw new Exception("List Hero empty");
            }

            List<Hero> listHero = HeroListValid.ToListHero().ToList();

            return listHero;
        }

        /// <summary>
        /// Concat films and series in a new ISearchableMovie List
        /// </summary>
        /// <returns>List ISearchableMovie</returns>
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
        /// 
        /// Remmove all Film that doesn't pass validityCheck
        /// </summary>
        /// <returns>List Films</returns>
        /// <exception cref="FileNotFoundException">Incorrect path</exception>
        /// <exception cref="Exception">List Empty</exception>
        public List<Film> GetFilms()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathFilm"];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Incorrect Path to Film.json");
            }

            string jsonAsString = File.ReadAllText(filePath);

            List<FilmJson> FilmList = JsonConvert.DeserializeObject<List<FilmJson>>(jsonAsString); // raise an exception - catch in caller

            List<FilmJson> FilmListValid = new List<FilmJson>();
            foreach (FilmJson f in FilmList) // Add valid movies
            {
                if (f.CheckValidity())
                {
                    if (!FilmListValid.Any(o => o.Id == f.Id)) // Check that the ID is not taken
                    {
                        FilmListValid.Add(f);
                    }
                }
            }

            if (FilmListValid.Count < 1) // List empty
            {
                throw new Exception("List Film empty");
            }
            
            List<Film> listFilms = FilmListValid.ToListFilm().ToList();

            return listFilms;
        }

        /// <summary>
        /// Init List Series with a Json DB.
        /// Use a temp public class to init
        /// 
        /// Remmove all Series that doesn't pass validityCheck
        /// </summary>
        /// <returns>List Series</returns>
        /// <exception cref="FileNotFoundException">Incorrect path</exceptiony
        /// <exception cref="Exception">List Empty</exception>
        public List<Serie> GetSeries()
        {
            string filePath = ConfigurationManager.AppSettings["jsonPathSerie"];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Incorrect Path to Serie.json");
            }

            string jsonAsString = File.ReadAllText(filePath);

            List<SerieJson> SerieList = JsonConvert.DeserializeObject<List<SerieJson>>(jsonAsString); // raise an exception - catch in caller

            List<SerieJson> SerieListValid = new List<SerieJson>();
            foreach (SerieJson s in SerieList) // Add valid movies
            {
                if (s.CheckValidity())
                {
                    if (!SerieListValid.Any(o => o.Id == s.Id)) // Check that the ID is not taken
                    {
                        SerieListValid.Add(s);
                    }
                }
            }

            List<Serie> listSeries = SerieListValid.ToListSerie().ToList();

            return listSeries;
        }

        // ADD - REMOVE - UPDATE
        
        /// <summary>
        /// Update a Hero in the List
        /// Remove old + Add new
        /// makes sure it doesn't create not linked hero (because of ID changes etc)
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public bool UpdateHero(Hero heroNew, Hero heroOld)
        {
            RemoveHero(heroOld);
            AddHero(heroNew);
            return true;
        }
        
        /// <summary>
        /// Add a hero 
        /// Create references to all his movies by iterating through ListMovies
        /// Doesn't Create ref to this hero in movies (Only Movie handle ref to heroes)
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public bool AddHero(Hero hero)
        {
            foreach (Movie m in this.ListMovies)
            {
                if (m.GetHeroString().Any(h => h == hero.Id))
                {
                    m.AddListHero(hero);
                    hero.ListMovies.Add(m);
                }
                m.SortListHeros();
            }
            hero.SortListMovies();

            this.ListHeros.Add(hero);
            return true;
        }

        /// <summary>
        /// Remove a hero
        /// Clean allreferences to this hero in all movies
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public bool RemoveHero(Hero hero)
        {   
            foreach (Movie m in this.ListMovies)
            {
                if (m.GetListHeros().Any(h => h.Id == hero.Id))
                {
                    m.RemoveListHero(hero);
                }
            }

            this.ListHeros.Remove(hero);
            return true;
        }

        /// <summary>
        /// Update a Movie in the List
        /// Remove old + Add new 
        /// makes sure it doesn't create not linked movie (because of ID changes etc)
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public bool UpdateMovie(ISearchableMovie movieNew, ISearchableMovie movieOld)
        {
            RemoveMovie(movieOld);
            AddMovie(movieNew);
            return true;
        }

        /// <summary>
        /// Add a movie
        /// Create all references to this movie in all heroes
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public bool AddMovie(ISearchableMovie movie)
        {
            foreach(string hero in movie.GetHeroString())
            {
                int index = this.ListHeros.FindIndex(h => h.Id == hero);
                if (index != -1)
                {
                    movie.AddListHero(this.ListHeros[index]);
                    this.ListHeros[index].ListMovies.Add((Movie)movie);
                }
               
            }
            this.ListMovies.Add((ISearchableMovie)movie);

            return true;
        }

        /// <summary>
        /// Remove a Movie
        /// Remove all references to this movies in all heroes
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public bool RemoveMovie(ISearchableMovie movie)
        {
            foreach(Hero h in this.ListHeros)
            {
                int index = h.ListMovies.FindIndex(mov => mov.GetId() == movie.GetId());
                if (index != -1)
                {
                    h.ListMovies.RemoveAt(index);
                }
            }
            this.ListMovies.Remove(movie);
            return true;
        }


        // SAVE

        /// <summary>
        /// Save All datas (List) in jso files
        /// (split ListMovies in ListSeries/Listheroes)
        /// 
        /// Throw Exception higher ^
        /// </summary>
        /// <exception cref="FileNotFoundException">Path to json file inccorect</exception>
        /// <exception cref="JsonException">Error serialization</exception>
        public void SaveDatas()
        {
            SaveListHero(this.ListHeros);
            List<Film> ListFilms = new List<Film>();
            List<Serie> ListSeries = new List<Serie>();

            foreach(ISearchableMovie m in this.ListMovies)
            {
                if(m.GetType() == typeof(Film))
                {
                    ListFilms.Add((Film)m);
                }
                else
                {
                    ListSeries.Add((Serie)m);
                }
            }

            SaveListFilm(ListFilms);
            SaveListSerie(ListSeries);
        }

        /// <summary>
        /// Save ListHeroes in a json file
        /// Convert ListHero in ListHero JSON (remove all Hero that doesn't pass validity check)
        /// </summary>
        /// <param name="h"></param>
        /// <exception cref="FileNotFoundException">Path to json file inccorect</exception>
        /// <exception cref="JsonException">Error serialization</exception>
        public void SaveListHero(List<Hero> h)
        {
            List<HeroJson> listHero = h.ToJsonListHero();

            string filePath = ConfigurationManager.AppSettings["jsonPathHeroSave"];
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Incorrect Path to HeroSave.json");
            }

            string jsonString = JsonConvert.SerializeObject(listHero, Formatting.Indented);

            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Save ListFilms in a json file
        /// Convert ListFilms in ListFilms JSON (remove all Film that doesn't pass validity check)
        /// </summary>
        /// <param name="f"></param>
        /// <exception cref="FileNotFoundException">Path to json file inccorect</exception>
        /// <exception cref="JsonException">Error serialization</exception>
        public void SaveListFilm(List<Film> f)
        {
            List<FilmJson> listFilm = f.ToJsonListFilm();

            string filePath = ConfigurationManager.AppSettings["jsonPathFilmSave"];
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Incorrect Path to FilmSave.json");
            }

            string jsonString = JsonConvert.SerializeObject(listFilm, Formatting.Indented);

            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Save ListSeries in a json file
        /// Convert ListSeries in ListSeries JSON (remove all Serie that doesn't pass validity check)
        /// </summary>
        /// <param name="s"></param>
        /// <exception cref="FileNotFoundException">Path to json file inccorect</exception>
        /// <exception cref="JsonException">Error serialization</exception>
        public void SaveListSerie(List<Serie> s)
        {
            List<SerieJson> listSerie = s.ToJsonListSerie();

            string filePath = ConfigurationManager.AppSettings["jsonPathSerieSave"];
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Incorrect Path to SerieSave.json");
            }

            string jsonString = JsonConvert.SerializeObject(listSerie, Formatting.Indented);

            File.WriteAllText(filePath, jsonString);
        }
        
    }
}
