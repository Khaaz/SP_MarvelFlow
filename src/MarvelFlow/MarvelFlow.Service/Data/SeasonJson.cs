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

        /// <summary>
        /// Check if the Object respect all checker
        /// True if yes | false if not
        /// </summary>
        /// <returns>boolean</returns>
        public bool CheckValidity()
        {
            if (ListEpisodes.Count < 1 || NumberEpisodes != ListEpisodes.Count) // List Episodes accuracy
            {
                return false;
            }

            for (int i = 0; i < ListEpisodes.Count; i++) // Episodes validity
            {
                EpisodeJson e = ListEpisodes[i];
                if (e.EpisodeNumber != i + 1 || !e.CheckValidity())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
