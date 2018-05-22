using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes.Lib
{
    interface IEnumerableMovie
    {
        string GetId();
        string GetTitle();
        string GetAffiche();
        Universe GetUniverse();
    }
}
