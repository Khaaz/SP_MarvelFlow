using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MarvelFlow.Service.Data
{
    public class MovieJson
    {
        public string MId { get; set; }

        public string Titre { get; set; }

        public string Affiche { get; set; }

        public string Real { get; set; }

        public bool Sortie { get; }

        public string Description { get; set; }

        public DateTime DateSortie { get; set; }

        public MovieJson() { }
    }
}
