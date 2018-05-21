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
        public string Id { get;  set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Desc { get; set; }

        public Status Status { get; set; }

        public Team Team { get; set; }

        public Universe Universe { get; set; }


        public HeroJson() { }

       
    }
}
