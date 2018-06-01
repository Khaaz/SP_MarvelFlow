using MarvelFlow.Classes;
using System;
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

        public FilmJson(string title, string affiche, string desc, string real, DateTime date, string id, Universe universe, string bA, List<string> listHeros) :
            base(title, affiche, desc, real, date)
        {
            Id = id;
            Universe = universe;
            BA = bA;
            ListHeros = listHeros;
        }
    }
}
