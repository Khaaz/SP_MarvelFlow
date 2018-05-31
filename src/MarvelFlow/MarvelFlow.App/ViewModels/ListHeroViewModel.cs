using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class ListHeroViewModel : ViewModelBase
    {
        public RelayCommand<Hero> NavigateHeroCommand { get; private set; }
        public RelayCommand ReturnBackCommand { get; private set; }

        public List<Hero> ListHeros { get; set; }

        private ObservableCollection<Hero> _ListHerosView;
        public ObservableCollection<Hero> ListHerosView
        {
            get
            {
                return _ListHerosView;
            }
            set
            {
                if (_ListHerosView == value)
                    return;
                _ListHerosView = value;
                RaisePropertyChanged(() => ListHerosView);
            }
        }

        private string _SearchBar;
        public string SearchBar
        {
            get
            {
                return _SearchBar;
            }
            set
            {
                if (_SearchBar == value)
                    return;
                _SearchBar = value;
                RaisePropertyChanged(() => SearchBar);
                SortName(SearchBar);
            }
        }

        public ListHeroViewModel()
        {
            // Commands
            this.NavigateHeroCommand = new RelayCommand<Hero>(this.SendNavigateHero, CanDisplayMessage());
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);

            // List (get List from Json DB - order by name - int in the Observable Collection
            this.ListHeros = ManagerJson.GetHeroes().OrderBy(h => h.Name).ToList();
            this.ListHerosView = new ObservableCollection<Hero>(this.ListHeros);


            // temp (bind)
            ListHeros = new List<Hero>();

            Hero Im = new Hero("IM", "IronMan", "ImagesHero/ironMan.png", "voici ironMan", Team.Avengers);
            Hero Sm = new Hero("SM", "SpiderMan", "ImagesHero/spiderMan.png", "voici SpiderMan", Team.Avengers);
            Hero Ds = new Hero("Ds", "Doctor Strange", "ImagesHero/doctorStrange.png", "voici Doctor Strange", Team.Avengers);
            Hero Hu = new Hero("HK", "Hulk", "ImagesHero/hulk.png", "voici Hulk le géant vert", Team.Avengers);
            Hero Vi = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.BlackOrder);
            Hero Vi1 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.BlackOrder);
            Hero Vi2 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi3 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi4 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi5 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi6 = new Hero("VN", "Vision", "ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);

            Film f1 = new Film("AV3", "Avengers Infinity Wars", "ImagesMovie/Avengers3.jpg", "film Avengers 3 avec plein de gens dedans", "Frères Russo", "25/04/18", Universe.MCU);
            Film f2 = new Film("AM", "AntMan", "ImagesMovie/Antman2.jpg", "film homme fourmi", "Payton Reed", "14/07/15", Universe.MCU);
            Film f3 = new Film("IM1", "IronMan", "ImagesMovie/IronMan.jpg", "film homme de fer", "Jon Favreau", "30/04/08", Universe.MCU);

            List<Movie> ListMovies = new List<Movie>();
            ListMovies.Add(f1);
            ListMovies.Add(f2);
            ListMovies.Add(f3);

            Im.ListMovies = ListMovies;

            ListHeros.Add(Im);
            ListHeros.Add(Sm);
            ListHeros.Add(Ds);
            ListHeros.Add(Hu);
            ListHeros.Add(Vi);
            ListHeros.Add(Vi1);
            ListHeros.Add(Vi2);
            ListHeros.Add(Vi3);
            ListHeros.Add(Vi4);
            ListHeros.Add(Vi5);
            ListHeros.Add(Vi6);

            ListHerosView = new ObservableCollection<Hero>(this.ListHeros);

        }

        public void SortName(string input)
        {
            List<Hero> tempList = this.ListHeros.Where(h => h.Name.ToLower().StartsWith(input.ToLower())).ToList();
            this.ListHerosView.Clear();
            this.ListHerosView = new ObservableCollection<Hero>(tempList);
        }

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendNavigateHero(Hero hero)
        {
            MessengerInstance.Send<HeroMessage>(new HeroMessage(this, hero, "Navigate Hero Message"));
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }
    }
}
