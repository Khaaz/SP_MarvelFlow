using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes.Lib
{
    public interface ISearchableMovie
    {
        string GetId();
        string GetTitle();
        string GetAffiche();
        Universe GetUniverse();
        List<string> GetHeroString();
        List<Hero> GetListHeros();
        void AddListHero(Hero h);
        void SortListHeros();
        bool RemoveListHero(Hero h);
        DateTime GetDate();
    }
}
