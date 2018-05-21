using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MarvelFlow.Classes;

namespace MarvelFlow.Service.Data
{
    public class SerieJson
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        public Productor Productor { get; set; }

        public int NumberSeason { get; set; }

        public List<SeasonJson> ListSeasons { get; set; }

        public bool isOver { get; set; }


        public SerieJson() { }
    }
}
