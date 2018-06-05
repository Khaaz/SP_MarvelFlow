using MarvelFlow.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarvelFlow.App.Lib
{
    public static class AppUtils
    {
        public static bool ValidMail(string mail)
        {
            Regex r = new Regex(@".*@.*\..*", RegexOptions.IgnoreCase);

            return r.IsMatch(mail);
        }

        public static bool ValidName(string input)
        {
            Regex r = new Regex(@"[A-Z][a-z]*[a-z -][A-Za-z][a-z]*");

            return r.IsMatch(input);
        }
    }
}
