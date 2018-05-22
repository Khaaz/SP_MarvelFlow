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
        public string Title { get; private set; }

        public string Affiche { get; private set; } // image

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
        public Movie(string title, string affiche, string desc, string real, string date)
        {

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Titre du film null", nameof(title));
            }

            this.Title = title;
            this.Affiche = affiche;
            this.desc = string.IsNullOrEmpty(desc) ? "desc" : desc;
            this.real = real;

            DateTime tmpDate = Convert.ToDateTime(date);

            this.date = tmpDate;
            this.isOut = tmpDate < DateTime.Now ? false : true;
        }

        public override string ToString()
        {
            return Title + " - " + date;
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
