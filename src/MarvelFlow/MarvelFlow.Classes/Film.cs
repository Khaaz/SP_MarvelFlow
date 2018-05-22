using MarvelFlow.Classes.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public class Film : Movie, IEnumerableMovie
    {
        public string Id { get; private set; }

        public Universe Universe { get; private set; }

        private List<Hero> listHeroes { get; set; }

        /// <summary>
        /// Default constructor Film
        /// Extends Movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="affiche"></param>
        /// <param name="desc"></param>
        /// <param name="productor"></param>
        /// <param name="real"></param>
        /// <param name="date"></param>
        public Film(string id, string title, string affiche, string desc, string real, string date, Universe universe) 
            : base(title, affiche, desc, real, date)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id du film null", nameof(id));
            }

            this.Id = id;
            this.Universe = Universe;
        }

        public string GetId()
        {
            return Id;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetAffiche()
        {
            return Affiche;
        }

        public Universe GetUniverse()
        {
            return Universe;
        }

        // Custom //
    }
}
