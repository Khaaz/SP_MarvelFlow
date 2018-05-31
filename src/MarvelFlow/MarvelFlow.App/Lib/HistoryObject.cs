using GalaSoft.MvvmLight;
using MarvelFlow.App.ViewModels;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.Lib
{
    public class HistoryObject
    {
        public string NomVM { get; set; }

        public Hero Hero { get; set; }

        public ISearchableMovie Movie { get; set; }

        public HistoryObject(string NomVM)
        {
            this.NomVM = NomVM;
            this.Hero = null;
            this.Movie = null;
        }

        public HistoryObject(ViewModelBase Source)
        {
            this.NomVM = Source.GetType().Name;
            this.Hero = this.NomVM == "HeroViewModel" ? ((HeroViewModel)Source).Hero : null;
            this.Movie = this.NomVM == "MovieViewModel" ? ((MovieViewModel)Source).Movie : null;
        }

        public HistoryObject(string NomVM, Hero Hero)
        {
            this.NomVM = NomVM;
            this.Hero = Hero;
            this.Movie = null;
        }

        public HistoryObject(string NomVM, ISearchableMovie Movie)
        {
            this.NomVM = NomVM;
            this.Hero = null;
            this.Movie = Movie;
        }
    }
}
