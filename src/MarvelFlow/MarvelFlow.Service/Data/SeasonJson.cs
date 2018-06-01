using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MarvelFlow.Service.Data
{
    public class SeasonJson
    {
        public int SeasonNumber { get; set; }

        public int NumberEpisodes { get; set; }

        public List<EpisodeJson> ListEpisodes { get; set; }


        public SeasonJson() { }

        public SeasonJson(int seasonNumber, int numberEpisodes, List<EpisodeJson> listEpisodes)
        {
            SeasonNumber = seasonNumber;
            NumberEpisodes = numberEpisodes;
            ListEpisodes = listEpisodes;
        }
    }
}
