using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Configuration;
using System.IO;

namespace MarvelFlow.Service.Data
{
    public class EpisodeJson : MovieJson
    {
        public int EpisodeNumber { get; set; }


        public EpisodeJson() : base() { }


        public EpisodeJson(string title, string affiche, string desc, string real, string date, int episodeNumber) :
            base(title, affiche, desc, real, date)
        {
            EpisodeNumber = episodeNumber;
        }

        public EpisodeJson(string title, string affiche, string desc, string real, DateTime date, int episodeNumber) :
            base(title, affiche, desc, real, date)
        {
            EpisodeNumber = episodeNumber;
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
                if (prop == null) // null
                {
                    return false;
                }

                if (prop.GetType() == typeof(string) && (string.IsNullOrEmpty((string)prop) || string.IsNullOrWhiteSpace((string)prop) || Util.ContainsQuotes((string)prop)))// string null, empty, space, contains quote
                {
                    return false;
                }
            }

            if (Util.IsPathMovie(Affiche)) // path correct
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


            if (!Util.IsValidDate(Date)) // date format
            {
                return false;
            }

            return true;
        }
    }
}
