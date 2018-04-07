using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public class Movie : Video
    {
        private string Mid { get; set; }
        private string Titre { get; set; }

        private string Real { get; set; }

        private string Date { get; set; }

        private int AvisPublic { get; set; }

        private List<Hero> ListHeros { get; }

    }
}
