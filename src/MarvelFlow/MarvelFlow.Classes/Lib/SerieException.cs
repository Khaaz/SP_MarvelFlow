using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes.Lib
{
    public static class SerieEnum
    {
        public static readonly string EXIST = "This season already exist";
        public static readonly string NOTEXIST = "This season doesn't exist";
        public static readonly string NOTMATCH = "Season Number doesn't match rank/id in the Dicionnary";
    }

    class SerieException : Exception
    {
        public SerieException()
        {
        }

        public SerieException(string message)
            : base(message)
        {
        }

        public SerieException(string message, Exception inner) 
            : base(message, inner)
        {
        }
        
    }
}
