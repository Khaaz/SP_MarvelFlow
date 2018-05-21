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
        public string SeasonNumber { get; set; }

        public string NumberEpisodes { get; set; }

        public List<EpisodeJson> ListEpisodes { get; set; }

        public SeasonJson() { }
    }
}
