using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MarvelFlow.Classes;
using System.Configuration;
using System.IO;

namespace MarvelFlow.Service.Data
{
    public class SerieJson : MovieJson
    {
        public string Id { get; set; }

        public Universe Universe { get; set; }

        public int NumberSeason { get; set; }

        public List<SeasonJson> ListSeasons { get; set; }

        public bool IsOver { get; set; }

        public List<string> ListHeros { get; set; }


        public SerieJson() : base() { }

        public SerieJson(string title, string affiche, string desc, string real, string date, string id, Universe universe, int numberSeason, List<SeasonJson> listSeasons, bool isOver, List<string> listHeros) :
            base(title, affiche, desc, real, date)
        {
            Id = id;
            Universe = universe;
            NumberSeason = numberSeason;
            ListSeasons = listSeasons;
            IsOver = isOver;
            ListHeros = listHeros;
        }

        public SerieJson(string title, string affiche, string desc, string real, DateTime date, string id, Universe universe, int numberSeason, List<SeasonJson> listSeasons, bool isOver, List<string> listHeros) :
            base(title, affiche, desc, real, date)
        {
            Id = id;
            Universe = universe;
            NumberSeason = numberSeason;
            ListSeasons = listSeasons;
            IsOver = isOver;
            ListHeros = listHeros;
        }

        /// <summary>
        /// Check if the Object respect all checker
        /// True if yes | false if not
        /// </summary>
        /// <returns>boolean</returns>
        public bool CheckValidity()
        {
            foreach (var p in this.GetType().GetProperties()) // All prop
            {
                var prop = p.GetValue(this, null);
                if (prop == null) // prop null
                {
                    return false;
                }

                if (prop.GetType() == typeof(string) && (string.IsNullOrEmpty((string)prop) || string.IsNullOrWhiteSpace((string)prop) || Util.ContainsQuotes((string)prop))) // string null, Empty, Space, contains doublequote
                {
                    return false;
                }
            }

            if (Util.IsPathTeaser(Affiche)) // path affiche
            {
                string path = ConfigurationManager.AppSettings["AffichePath"] + Affiche;
                if (!File.Exists(path)) // the file exist
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (!Util.IsValidDate(Date)) // Date format
            {
                return false;
            }

            if (ListHeros.Count < 1) // heros in the list
            {
                return false;
            }
            else
            {
                foreach (string h in ListHeros) // List validity
                {
                    if (string.IsNullOrEmpty(h) || string.IsNullOrWhiteSpace(h) || Util.ContainsQuotes(h)) // string null, empty, space, contains quote
                    {
                        return false;
                    }
                }
            }

            if (ListSeasons.Count < 1 || NumberSeason != ListSeasons.Count) // List seasons accuracy
            {
                return false;
            }

            for (int i = 0; i < ListSeasons.Count; i++) // Seasons validity
            {
                SeasonJson s = ListSeasons[i];
                if (s.SeasonNumber != i + 1 || !s.CheckValidity())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
