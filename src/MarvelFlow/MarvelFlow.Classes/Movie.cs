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
        private string mId { get; set; }

        private string titre { get; set; }

        private string affiche { get; set; }

        private string real { get; set; }

        private bool sortie { get; }

        private DateTime dateSortie { get; set; }

        private readonly List<Hero> listHeros1;

        
        protected Movie(string mId, string titre, string affiche, string real, DateTime dateSortie, List<Hero> listHeros)
        {
            this.mId = mId;
            this.titre = titre;
            this.affiche = affiche;
            this.real = real;
            this.sortie = true;
            this.dateSortie = dateSortie;
            bool testSortie = dateSortie < DateTime.Now;
            if (testSortie)
            {
                this.sortie = false ;
            }
            this.listHeros1 = listHeros;
        }

        private List<Hero> GetlistHeros()
        {
            return listHeros1;
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
