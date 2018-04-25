using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public class Hero
    {
        private string Hid { get; set; }
        private string NomHero { get; set; }

        private string NomReel { get; set; }

        private string Desc { get; set; }

        private string Pouvoir { get; set; }

        private List<Movie> ListMovies { get;}

        private DateTime DateCrea { get; set; }

        private float Popularité { get; set; }
    }
}
