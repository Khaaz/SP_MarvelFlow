using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Service.Data
{
    public abstract class Moviejson
    {
        public string Title { get; set; }

        public string Affiche { get; set; }

        public string Desc { get; set; }

        public string Real { get; set; }

        public DateTime Date { get; set; }


        public Moviejson() { }
    }
}
