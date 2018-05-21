using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MarvelFlow.Classes;

namespace MarvelFlow.Service.Data
{
    public class FilmJson : Moviejson
    {
        public string Id { get; set; }

        public Productor Productor { get; set; }


        public FilmJson() { }
    }
}
