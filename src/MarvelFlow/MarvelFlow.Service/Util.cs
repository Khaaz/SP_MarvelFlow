using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarvelFlow.Service
{
    public static class Util
    {
        public static bool ContainsQuotes(string input)
        {
            Regex r = new Regex(".*\".*", RegexOptions.IgnoreCase);

            return r.IsMatch(input);
        }

        public static bool IsPathHero(string input)
        {
            Regex r = new Regex(@"^ImagesHero\/.*\.(png|jpg|jpeg)$", RegexOptions.IgnoreCase);

            return r.IsMatch(input);
        }

        public static bool IsPathMovie(string input)
        {
            Regex r = new Regex(@"^ImagesMovie\/.*\.(png|jpg|jpeg)$", RegexOptions.IgnoreCase);

            return r.IsMatch(input);
        }

        public static bool IsPathTeaser(string input)
        {
            Regex r = new Regex(@"^.*\.mp4$", RegexOptions.IgnoreCase);

            return r.IsMatch(input);
        }

        public static bool IsValidDate(string date)
        {
            //string regexDate = @"^(0[1-9]|[1-2][0-9]|3[0-1])\/(0[1-9]|1[0-2])\/[0-9]{2}$";

            // Better regex that correctly match correct Date thx to almighty internet
            string regexDate = @"^(((0[1 - 9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$";

            Regex r = new Regex(regexDate, RegexOptions.IgnoreCase);

            return r.IsMatch(date);
        }
    }
}
