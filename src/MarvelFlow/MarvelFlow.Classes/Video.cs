using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MarvelFlow.Classes
{
    public abstract class Video
    {
        private string Vid { get; set; }

        private string Titre { get; set; }

        private string SourceAffiche { get; set; }

        private string Real { get; set; }

        private DateTime Date { get; set; }

        private float Popularite { get; set; }

        private List<Hero> ListHeros { get; }

        private List<Commentaire> ListCom { get; }

    }
}
