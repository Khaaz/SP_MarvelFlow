using MarvelFlow.Classes.Lib.ExceptionFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public class Season
    {
        public int SeasonNumber { get; private set; }

        public int NumberEpisodes { get; private set; }

        public Dictionary<int, Episode> ListEpisodes { get; private set; }


        /// <summary>
        /// default constructor
        /// 
        /// listEpisodes is a dictionnary = numeroEpisode => Episode
        /// </summary>
        /// <param name="seasonNumber"></param>
        /// <param name="numberEpisodes"></param>
        /// <param name="listEpisodes"></param>
        public Season(int seasonNumber, int numberEpisodes, Dictionary<int, Episode> listEpisodes)
        {
            this.SeasonNumber = seasonNumber;
            this.NumberEpisodes = numberEpisodes;
            this.ListEpisodes = listEpisodes;
        }

        /// <summary>
        /// Constructor called mainly by the json init
        /// Create the Season with a List of episode
        /// </summary>
        /// <param name="seasonNumber"></param>
        /// <param name="numberEpisodes"></param>
        /// <param name="listEpisodes"></param>
        public Season(int seasonNumber, int numberEpisodes, List<Episode> listEpisodes)
        {
            this.SeasonNumber = seasonNumber;
            this.NumberEpisodes = numberEpisodes;

            this.ListEpisodes = new Dictionary<int, Episode>();
            foreach(Episode e in listEpisodes)
            {
                this.ListEpisodes.Add(e.EpisodeNumber, e);
            }
        }

        /// <summary>
        /// Add an episode (to the end) to the list with correct episode number
        /// update number of episodes
        /// 
        /// error if the episode number doesn't match the id in the Dicionnary
        /// </summary>
        /// <param name="episode"></param>
        /// <exception cref="Exception">Episode number and key doesn't match</exception>
        /// <returns>Updated Dictionary of Episodes</returns>
        public Dictionary<int, Episode> AddEpisode(Episode episode)
        {
            checkEpNumberIndex(episode.EpisodeNumber, NumberEpisodes + 1);

            ListEpisodes.Add(episode.EpisodeNumber, episode);
            NumberEpisodes += 1;
            return ListEpisodes;
        }

        /// <summary>
        /// Surcharge addEpisode allowing to add an episode with the episode number wanted
        /// 
        /// return an error if the key already exist
        /// error if the episode number doesn't match the id in the Dicionnary
        /// </summary>
        /// <param name="index"></param>
        /// <param name="episode"></param>
        /// <exception cref="Exception">Episode number and key doesn't match</exception>
        /// <exception cref="Exception">The episode already exist</exception>
        /// <returns>Updated Dictionary of Episodes</returns>
        public Dictionary<int, Episode> AddEpisode(int index, Episode episode)
        {
            checkEpNumberIndex(episode.EpisodeNumber, index);

            if (ListEpisodes.ContainsKey(index))
            {
                throw new SeasonException(SeasonEnum.EXIST);
            }
            ListEpisodes.Add(index, episode);
            NumberEpisodes += 1;
            return ListEpisodes;
        }

        /// <summary>
        /// Edit an episode by passing the index of the episode
        /// 
        /// return an error if the episode doesn't exist
        /// error if the episode number doesn't match the id in the Dicionnary
        /// </summary>
        /// <param name="index"></param>
        /// <param name="episode"></param>
        /// <exception cref="Exception">Episode number and key doesn't match</exception>
        /// <exception cref="Exception">The episode doesn't exist</exception>
        /// <returns>Updated Dictionary of Episodes</returns>
        public Dictionary<int, Episode> EditEpisode(int index, Episode episode)
        {
            checkEpNumberIndex(episode.EpisodeNumber, index);

            if (!ListEpisodes.ContainsKey(index))
            {
                throw new SeasonException(SeasonEnum.NOTEXIST);
            }

            ListEpisodes[index] = episode;
            return ListEpisodes;
        }

        /// <summary>
        /// Check if the episode number match the id insert id in the dictionnary
        /// Raise an Exception if it's not the case
        /// </summary>
        /// <param name="epNbr"></param>
        /// <param name="index"></param>
        /// <exception cref="SeasonException">NOTMATCH</exception>
        private void checkEpNumberIndex(int epNbr, int index)
        {
            if (epNbr != index)
            {
                throw new SeasonException(SeasonEnum.NOTMATCH);
            }
        }
    }
}
