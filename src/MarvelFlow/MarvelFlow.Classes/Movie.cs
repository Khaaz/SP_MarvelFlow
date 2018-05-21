using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MarvelFlow.Classes
{
    public abstract class Movie
    {
        private string title { get; set; }

        private string affiche { get; set; } // image

        private string desc { get; set; }

        private string real { get; set; } // realisateur

        private bool isOut { get; set; }

        private DateTime date { get; set; } // date de sortie

        /// <summary>
        /// Default constructor Movie
        /// Abstract => Film or Serie.Season.Episode
        /// </summary>
        /// <param name="title"></param>
        /// <param name="affiche"></param>
        /// <param name="desc"></param>
        /// <param name="real"></param>
        /// <param name="date"></param>
        public Movie(string title, string affiche, string desc, string real, DateTime date)
        {

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Titre du film null", nameof(title));
            }

            this.title = title;
            this.affiche = affiche;
            this.desc = string.IsNullOrEmpty(desc) ? "desc" : desc;
            this.real = real;
            this.isOut = true;
            this.date = date;
            this.isOut = date < DateTime.Now ? false : true;
        }

        public override string ToString()
        {
            return title + " - " + date;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
