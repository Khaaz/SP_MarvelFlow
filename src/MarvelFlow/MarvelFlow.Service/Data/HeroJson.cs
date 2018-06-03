using MarvelFlow.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarvelFlow.Service.Data
{
    public class HeroJson
    {
        public string Id { get;  set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Desc { get; set; }

        public Status Status { get; set; }

        public Team Team { get; set; }

        public Universe Universe { get; set; }


        public HeroJson() { }

        public HeroJson(string id, string name, string image, string desc, Status status, Team team, Universe universe)
        {
            Id = id;
            Name = name;
            Image = image;
            Desc = desc;
            Status = status;
            Team = team;
            Universe = universe;
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
           
            if (Util.IsPathHero(Image)) // correct path
            {
                string path = ConfigurationManager.AppSettings["AffichePath"] + Image;
                if (!File.Exists(path)) // file exist
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
