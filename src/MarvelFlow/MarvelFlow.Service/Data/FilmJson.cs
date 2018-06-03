using MarvelFlow.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace MarvelFlow.Service.Data
{
    public class FilmJson : MovieJson
    {
        public string Id { get; set; }

        public Universe Universe { get; set; }

        public string BA { get; set; }

        public List<string> ListHeros { get; set; }


        public FilmJson() : base() { }

        public FilmJson(string title, string affiche, string desc, string real, string date, string id, Universe universe, string bA, List<string> listHeros) :
            base(title, affiche, desc, real, date)
        {
            Id = id;
            Universe = universe;
            BA = Util.FormatPathTrailer(bA);
            ListHeros = listHeros;
        }

        public FilmJson(string title, string affiche, string desc, string real, DateTime date, string id, Universe universe, string bA, List<string> listHeros) :
            base(title, affiche, desc, real, date)
        {
            Id = id;
            Universe = universe;
            BA = Util.FormatPathTrailer(bA);
            ListHeros = listHeros;
        }

        /// <summary>
        /// Check if the Object respect all checker
        /// True if yes | false if not
        /// </summary>
        /// <returns>boolean</returns>
        public bool CheckValidity()
        {
            foreach (var p in this.GetType().GetProperties()) // all prop
            {
                var prop = p.GetValue(this, null);
                if (prop == null) // prop null
                {
                    return false;
                }

                if (prop.GetType() == typeof(string) && (string.IsNullOrEmpty((string)prop) || string.IsNullOrWhiteSpace((string)prop) || Util.ContainsQuotes((string)prop))) // string null, empty, space, contains quote
                {
                    return false;
                }
            }

            if (Util.IsPathMovie(Affiche)) // path correct affiche
            {
                string path = ConfigurationManager.AppSettings["AffichePath"] + Affiche;
                if (!File.Exists(path)) // file exist
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (Util.IsPathTeaser(BA)) // path correct teaser
            {
                string path = ConfigurationManager.AppSettings["TeaserPath"] + BA;
                if (!File.Exists(path)) // file exist
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (!Util.IsValidDate(Date)) // date format
            {
                return false;
            }

            if (ListHeros.Count < 1) // List not empty
            {
                return false;
            }
            else
            {
                foreach (string h in ListHeros) // LIst validity
                {
                    if (string.IsNullOrEmpty(h) || string.IsNullOrWhiteSpace(h) || Util.ContainsQuotes(h)) // string null, empty, space, contains quote
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
