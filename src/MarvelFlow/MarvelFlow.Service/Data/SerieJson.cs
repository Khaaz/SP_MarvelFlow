using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MarvelFlow.Classes;

namespace MarvelFlow.Service.Data
{
    public class SerieJson : MovieJson
    {
        public string Id { get; set; }

        public Universe Universe { get; set; }

        public int NumberSeason { get; set; }

        public List<SeasonJson> ListSeasons { get; set; }

        public bool IsOver { get; set; }

        public List<string> ListHeros { get; set; }


        public SerieJson() : base() { }
    }
}
