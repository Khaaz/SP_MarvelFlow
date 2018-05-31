using MarvelFlow.Classes;
using MarvelFlow.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Service.Factory
{
    public static class SerieFactory
    {
        public static IEnumerable<Serie> ToListSerie(this IEnumerable<SerieJson> l)
        {
            foreach (SerieJson s in l)
            {
                yield return s.ToSerie();
            }
        }

        public static Serie ToSerie(this SerieJson f)
        {
            Serie NewSerie = new Serie(f.Id, f.Title, f.Affiche, f.Desc, f.Real, f.Date, f.Universe, f.NumberSeason, f.ListSeasons.ToListSeason().ToList(), f.IsOver, f.ListHeros);

            return NewSerie;
        }

        // Factory Season
        public static IEnumerable<Season> ToListSeason(this IEnumerable<SeasonJson> l)
        {
            foreach (SeasonJson s in l)
            {
                yield return s.ToSeason();
            }
        }

        public static Season ToSeason(this SeasonJson f)
        {
            Season NewSeason = new Season(f.SeasonNumber, f.NumberEpisodes, f.ListEpisodes.ToListEpisodes().ToList());

            return NewSeason;
        }

        // Factory Episode
        public static IEnumerable<Episode> ToListEpisodes(this IEnumerable<EpisodeJson> l)
        {
            foreach (EpisodeJson s in l)
            {
                yield return s.ToEpisode();
            }
        }

        public static Episode ToEpisode(this EpisodeJson f)
        {
            Episode NewEpisode = new Episode(f.EpisodeNumber, f.Title, f.Affiche, f.Desc, f.Real, f.Date);

            return NewEpisode;
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
