using MarvelFlow.Classes;
using System.Collections.Generic;

namespace MarvelFlow.Service.Data
{
    public class FilmJson : MovieJson
    {
        public string Id { get; set; }

        public Universe Universe { get; set; }

        public string BA { get; set; }

        public List<string> ListHeros { get; set; }


        public FilmJson() : base() { }
    }
}
