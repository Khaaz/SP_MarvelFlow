using MarvelFlow.Classes;
using MarvelFlow.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Service.Factory
{
    public static class HeroFactory
    {

        public static IEnumerable<Hero> ToListHero (this IEnumerable<HeroJson> l)
        {
            foreach(HeroJson h in l)
            {
                yield return h.ToHero();
            }
        }

        public static Hero ToHero(this HeroJson h)
        {
            Hero NewHero = new Hero(h.HId, h.NomHero, h.Image, h.Desc, h.Status , h.Team, h.Universe);

            return NewHero;
        }

        /*
        public static HeroJson ToJsonHero(this Hero h)
        {
           Hero NewHero = new Hero();

           return NewHero
        } 
        */
    }
}
