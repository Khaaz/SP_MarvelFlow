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
            Hero NewHero = new Hero(h.Id, h.Name, h.Image, h.Desc, h.Status, h.Team, h.Universe);

            return NewHero;
        }

        public static List<HeroJson> ToJsonListHero(this List<Hero> l)
        {
            List<HeroJson> NewList = new List<HeroJson>();
            foreach(Hero h in l)
            {
                HeroJson hjson = h.ToJsonHero();
                if (hjson.CheckValidity())
                {
                    NewList.Add(hjson);
                }
            }
            return NewList;
        }

        public static HeroJson ToJsonHero(this Hero h)
        {
            HeroJson NewHero = new HeroJson(h.Id, h.Name, h.Image, h.Desc, h.Status, h.Team, h.Universe);

            return NewHero;
        }
    }
}
