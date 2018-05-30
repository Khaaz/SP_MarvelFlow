using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MarvelFlow.Classes.Lib;
using System.Configuration;

namespace MarvelFlow.Classes
{
    public abstract class Movie : ISearchableMovie
    {
        public string Title { get; private set; }

        public string Affiche { get; private set; } // image

        public string Desc { get; private set; }

        private string real { get; set; } // realisateur

        private bool isOut { get; set; }

        public DateTime Date { get; private set; } // date de sortie

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
            this.Affiche = ConfigurationManager.AppSettings["AffichePath"] + affiche;
            this.Desc = string.IsNullOrEmpty(desc) ? "desc" : desc;
            this.real = real;

            DateTime tmpDate = Convert.ToDateTime(date);

            this.Date = tmpDate;
            this.isOut = tmpDate < DateTime.Now ? false : true;
        }

        public override string ToString()
        {
            return Title + " - " + Date;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public abstract string GetId();

        public string GetTitle()
        {
            return Title;
        }

        public string GetAffiche()
        {
            return Affiche;
        }

        public abstract Universe GetUniverse();

        public DateTime GetDate()
        {
            return Date;
        }
    }
}
