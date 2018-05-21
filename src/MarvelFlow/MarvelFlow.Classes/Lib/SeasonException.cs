using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes.Lib
{
    public static class SeasonEnum
    {
        public static readonly string EXIST = "This episode already exist";
        public static readonly string NOTEXIST = "This episode doesn't exist";
        public static readonly string NOTMATCH = "Episode Number doesn't match rank/id in the Dicionnary";
    }

    class SeasonException : Exception
    {
        public SeasonException()
        {
        }

        public SeasonException(string message)
            : base(message)
        {
        }

        public SeasonException(string message, Exception inner) 
            : base(message, inner)
        {
        }
        
    }
}
