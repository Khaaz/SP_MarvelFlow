using MarvelFlow.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Service.Data
{

    public class HeroJson
    {
        
        public string HId { get;  set; }

        public string NomHero { get; set; }

        public string Image { get; set; }

        public string Desc { get; set; }

        public Statut Status { get; set; }

        public Team Team { get; set; }

        public Universe Universe { get; set; }


        public HeroJson() { }

       
    }
}
