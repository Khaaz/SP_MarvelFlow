using MarvelFlow.Classes;

namespace MarvelFlow.Service.Data
{
    public class FilmJson : MovieJson
    {
        public string Id { get; set; }

        public Universe Universe { get; set; }


        public FilmJson() : base() { }
    }
}
