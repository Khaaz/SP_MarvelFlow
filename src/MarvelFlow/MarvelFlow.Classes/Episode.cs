using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public class Episode : Movie
    {
        public int EpisodeNumber { get; private set; }

        /// <summary>
        /// Default constructor episode
        /// extends Movie
        /// </summary>
        /// <param name="episodeNumber"></param>
        /// <param name="title"></param>
        /// <param name="affiche"></param>
        /// <param name="desc"></param>
        /// <param name="real"></param>
        /// <param name="date"></param>
        public Episode(int episodeNumber, string title, string affiche, string desc, string real, string date)
            : base(title, affiche, desc, real, date)
        {
            this.EpisodeNumber = episodeNumber;
        }

        public override string GetId()
        {
            throw new NotImplementedException();
        }

        public override Universe GetUniverse()
        {
            throw new NotImplementedException();
        }

        public override List<Hero> GetListHeros()
        {
            throw new NotImplementedException();
        }
    }
}
