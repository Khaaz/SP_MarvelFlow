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

        public static FilmJson ToJsonFilm(this Film f)
        {
            FilmJson NewFilm = new FilmJson(f.Title, f.Affiche, f.Desc, f.Real, f.Date, f.Id, f.Universe, f.BA, f.ListHeroString);

            return NewFilm;
        }

    }
}
