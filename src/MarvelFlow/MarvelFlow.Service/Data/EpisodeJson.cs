using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MarvelFlow.Service.Data
{
    public class EpisodeJson : MovieJson
    {
        public int EpisodeNumber { get; set; }


        public EpisodeJson() : base() { }
    }
}
