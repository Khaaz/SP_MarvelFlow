using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public class Film : Movie
    {
        private string id { get; set; }

        private Productor productor { get; set; }

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
        public Film(string id, string title, string affiche, string desc, Productor productor, string real, string date) 
            : base(title, affiche, desc, real, date)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id du film null", nameof(id));
            }

            this.id = id;
            this.productor = productor;
            
        }

        // Custom //
    }
}
