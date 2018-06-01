using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Service.Data
{
    public abstract class MovieJson
    {
        public string Title { get; set; }

        public string Affiche { get; set; }

        public string Desc { get; set; }

        public string Real { get; set; }

        public string Date { get; set; }


        public MovieJson() { }

        protected MovieJson(string title, string affiche, string desc, string real, DateTime date)
        {
            Title = title;
            Affiche = affiche;
            Desc = desc;
            Real = real;
            Date = date.ToString("dd/MM/yy");
        }
    }
}
