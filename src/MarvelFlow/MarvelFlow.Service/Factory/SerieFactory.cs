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
        // Factory Serie
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

        ////////////

        // Factory Json Serie
        public static List<SerieJson> ToJsonListSerie(this List<Serie> l)
        {
            List<SerieJson> NewList = new List<SerieJson>();
            foreach (Serie s in l)
            {
                SerieJson sjson = s.ToJsonSerie();
                if (sjson.CheckValidity())
                {
                    NewList.Add(sjson);
                }
            }
            return NewList;
        }

        public static SerieJson ToJsonSerie(this Serie s)
        {
           SerieJson NewSerie = new SerieJson(s.Title, s.Affiche, s.Desc, s.Real, s.Date, s.Id, s.Universe, s.NumberSeasons, s.ListSeasons.ToJsonListSeason(), s.IsOver, s.ListHeroString);

            return NewSerie;
        }

        // Factory Json Season
        public static List<SeasonJson> ToJsonListSeason(this Dictionary<int, Season> l)
        {
            List<SeasonJson> NewList = new List<SeasonJson>();

            foreach(Season s in l.Values) {
                NewList.Add(s.ToJsonSeason());
            }

            return NewList;
        }
        
        public static SeasonJson ToJsonSeason(this Season s)
        {
            SeasonJson NewSeason = new SeasonJson(s.SeasonNumber, s.NumberEpisodes, s.ListEpisodes.ToJsonListEpisode());

            return NewSeason;
        }

        // Factory Json Episode
        public static List<EpisodeJson> ToJsonListEpisode(this Dictionary<int, Episode> l)
        {
            List<EpisodeJson> NewList = new List<EpisodeJson>();

            foreach (Episode e in l.Values)
            {
                NewList.Add(e.ToJsonEpisode());
            }

            return NewList;
        }

        public static EpisodeJson ToJsonEpisode(this Episode e)
        {
            EpisodeJson NewEpisode = new EpisodeJson(e.Title, e.Affiche, e.Desc, e.Real, e.Date, e.EpisodeNumber);

            return NewEpisode;
        }
    }
}
