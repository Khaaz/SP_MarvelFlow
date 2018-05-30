using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public class Hero
    {

        private string id { get;  set; }

        public string name { get; set; }

        public string image { get; set; }

        public string desc { get; set; }

        private Status status { get; set; }

        private Team team { get; set; }

        private Universe universe { get; set; }

        public List<Movie> listMovies { get; set; }

        private Boolean fav { get; set; }

        /// <summary>
        /// Default constructor. Status + universe default (neutral +  MCU)
        /// 
        /// fav is default to false
        /// desc if null default to "desc"
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="image"></param>
        /// <param name="desc"></param>
        /// <param name="team"></param>
        /// <exception cref="ArgumentException">id + name can't be null</exception>
        public Hero(string id, string name, string image , string desc, Team team)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id du hero null", nameof(id));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Nom du hero null", nameof(name));
            }

            this.id = id;
            this.name = name;
            this.image = image;
            this.desc = string.IsNullOrEmpty(desc) ? "desc" : desc;
            this.status = Status.Neutre;
            this.team = team;
            this.universe = Universe.MCU;
            this.fav = false;

            this.listMovies = new List<Movie>();
        }

        /// <summary>
        /// Extends the default constructor
        /// Adding custom value for status and universe
        ///
        /// fav is default to false
        /// desc if null default to "desc"
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="image"></param>
        /// <param name="desc"></param>
        /// <param name="status"></param>
        /// <param name="team"></param>
        /// <param name="universe"></param>
        /// <exception cref="ArgumentException">id + name can't be null</exception>
        public Hero(string id, string name, string image, string desc, Status status, Team team, Universe universe) 
            : this(id, name, image, desc, team)
        {
            this.status = status;
            this.universe = universe;
        }


        
        // Generic //

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        // Custom //
    }
}
