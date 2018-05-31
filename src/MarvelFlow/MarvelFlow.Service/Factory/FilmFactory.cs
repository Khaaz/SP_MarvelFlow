using MarvelFlow.Classes;
using MarvelFlow.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Service.Factory
{
    public static class FilmFactory
    {
        public static IEnumerable<Film> ToListFilm(this IEnumerable<FilmJson> l)
        {
            foreach (FilmJson f in l)
            {
                yield return f.ToFilm();
            }
        }

        public static Film ToFilm(this FilmJson f)
        {
            Film NewFilm = new Film(f.Id, f.Title, f.Affiche, f.Desc, f.Real, f.Date, f.Universe, f.BA, f.ListHeros);

            return NewFilm;
        }

        /*
        public static HeroJson ToJsonHero(this Hero h)
        {
           Hero NewHero = new Hero();

           return NewHero
        } 
        */
    }
}
