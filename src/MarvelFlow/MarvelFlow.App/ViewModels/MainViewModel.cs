using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MarvelFlow.App.Lib;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MarvelFlow.App.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public Stack<HistoryObject> History { get; set; } // Historique

        public RelayCommand NavigateHomeCommand { get; private set; }
        public RelayCommand NavigateUserWindowCommand { get; private set; }

        private ViewModelBase _CurrentVM;
        public ViewModelBase CurrentVM
        {
            get
            {
                return _CurrentVM;
            }
            set
            {
                if (_CurrentVM == value)
                    return;
                _CurrentVM = value;
                RaisePropertyChanged(() => CurrentVM);
            }
        }

        public List<Hero> ListHeros { get; set; }
        public List<ISearchableMovie> ListMovies { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            // MAIN
            this.History = new Stack<HistoryObject>();

            this._CurrentVM = ServiceLocator.Current.GetInstance<HomeViewModel>();

            // Init Messaging
            MessengerInstance.Register<HomeMessage>(this, (HomeMessage obj) => Navigator(obj, "HomeViewModel"));

            MessengerInstance.Register<HeroMessage>(this, (HeroMessage obj) => Navigator(obj, "HeroViewModel"));
            MessengerInstance.Register<MovieMessage>(this, (MovieMessage obj) => Navigator(obj, "MovieViewModel"));

            MessengerInstance.Register<ProfileMessage>(this, (ProfileMessage obj) => Navigator(obj, "ProfileViewModel"));
            MessengerInstance.Register<ListHeroMessage>(this, (ListHeroMessage obj) => Navigator(obj, "ListHeroViewModel"));
            MessengerInstance.Register<ListMovieMessage>(this, (ListMovieMessage obj) => Navigator(obj, "ListMovieViewModel"));
            
            MessengerInstance.Register<HistoryMessage>(this, (HistoryMessage obj) => Navigator(obj, string.Empty));

            // Commands
            this.NavigateUserWindowCommand = new RelayCommand(this.OpenUserWindow, CanDisplayMessage);
            this.NavigateHomeCommand = new RelayCommand(this.DisplayHome, CanDisplayMessage);

            // Init datas
            this.InitData();

            // Init Data (Hardcode - test)

            List<string> stringheros = new List<string>
            {
                "Im",
                "SM"
            };

            Film f1 = new Film("AV3", "Avengers Infinity Wars", "ImagesMovie/Avengers3.jpg", "film Avengers 3 avec plein de gens dedans", "Frères Russo", "25/04/18", Universe.MCU, "/ba/im", stringheros);
            Film f2 = new Film("AM", "AntMan", "ImagesMovie/Antman2.jpg", "film homme fourmi", "Payton Reed", "14/07/15", Universe.MCU, "/ba/im", stringheros);
            Film f3 = new Film("IM1", "IronMan", "ImagesMovie/IronMan.jpg", "film homme de fer", "Jon Favreau", "30/04/08", Universe.MCU, "/ba/im", stringheros);

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

            f1.ListHeroes.Add(Im);
            f1.ListHeroes.Add(Sm);
            f1.ListHeroes.Add(Ds);

            this.ListMovies.Add(f1);
            this.ListMovies.Add(f2);
            this.ListMovies.Add(f3);

            List<Movie> ListMoviesTemp = new List<Movie>();
            ListMoviesTemp.Add(f1);
            ListMoviesTemp.Add(f2);
            ListMoviesTemp.Add(f3);

            Im.ListMovies = ListMoviesTemp;

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

        }

        public void InitData()
        {
            // Init Data from Json
            this.ListHeros = ManagerJson.GetHeroes().OrderBy(h => h.Name).ToList(); // Sort by Name Default

            List<ISearchableMovie> ListFilms = new List<ISearchableMovie>(ManagerJson.GetFilms()); // ISearchaBleMovie instead of Movie
            this.ListMovies = ListFilms.Concat(ManagerJson.GetSeries()).OrderBy(m => m.GetTitle()).ToList(); // Sort by Title default

            // Init heros per movies
            foreach (ISearchableMovie m in this.ListMovies)
            {
                foreach (string h in m.GetHeroString())
                {
                    m.AddListHero(ListHeros.Find(hero => hero.Id == h));
                }

            }

            // init movies per heroes
            foreach (Hero h in this.ListHeros)
            {
                foreach(Movie m in this.ListMovies)
                {
                    if (m.GetListHeros().Contains(h))
                    {
                        h.ListMovies.Add(m);
                    }
                }
            }
        }

        public void Navigator(MessageBase obj, string dest)
        {
            ViewModelBase Source = (ViewModelBase)obj.Sender;

            HistoryObject HistoryObject = null;
            string pageName;
            if (string.IsNullOrEmpty(dest)) // call the history or the ViewModel Name - (get the class name as string)
            {
                HistoryObject = this.History.Pop();
                pageName = HistoryObject.NomVM;
            }
            else
            {
                pageName = dest;
                this.History.Push(new HistoryObject(Source)); // push the source ViewModel in History (as his className string)
            }

            switch (pageName)
            {
                case "HomeViewModel":
                    this.CurrentVM = ServiceLocator.Current.GetInstance<HomeViewModel>();
                    this.History.Clear(); // Clear history
                    break;
                case "HeroViewModel":
                    if (HistoryObject == null && ((HeroMessage)obj).Hero == null)
                    {
                        this.CurrentVM = ServiceLocator.Current.GetInstance<HomeViewModel>();
                        this.History.Clear(); // Clear history
                    }
                    else
                    {
                        HeroViewModel tempHeroVM = ServiceLocator.Current.GetInstance<HeroViewModel>();
                        tempHeroVM.Hero = HistoryObject != null ? HistoryObject.Hero : ((HeroMessage)obj).Hero;
                        this.CurrentVM = tempHeroVM;
                    }
                    break;
                case "MovieViewModel":
                    if (HistoryObject == null && ((MovieMessage)obj).Movie == null)
                    {
                        this.CurrentVM = ServiceLocator.Current.GetInstance<HomeViewModel>();
                        this.History.Clear(); // Clear history
                    }
                    else
                    {
                        MovieViewModel tempMovieVM = ServiceLocator.Current.GetInstance<MovieViewModel>();
                        tempMovieVM.Movie = HistoryObject != null ? HistoryObject.Movie : ((MovieMessage)obj).Movie;
                        this.CurrentVM = tempMovieVM;
                    }
                    break;
                case "ProfileViewModel":
                    this.CurrentVM = ServiceLocator.Current.GetInstance<ProfileViewModel>();
                    break;
                case "ListHeroViewModel":
                    ListHeroViewModel tempListHVM = ServiceLocator.Current.GetInstance<ListHeroViewModel>();
                    if (tempListHVM.ListHeros == null)
                    {
                        tempListHVM.ListHeros = this.ListHeros;
                        tempListHVM.ListHerosView = new ObservableCollection<Hero>(this.ListHeros);
                    }
                    this.CurrentVM = tempListHVM;
                    break;
                case "ListMovieViewModel":
                    ListMovieViewModel tempListMVM = ServiceLocator.Current.GetInstance<ListMovieViewModel>();
                    if (tempListMVM.ListMovies == null)
                    {
                        tempListMVM.ListMovies = this.ListMovies;
                        tempListMVM.ListMoviesView = new ObservableCollection<ISearchableMovie>(this.ListMovies);
                    }
                    this.CurrentVM = tempListMVM;
                    break;
                default:
                    this.CurrentVM = ServiceLocator.Current.GetInstance<HomeViewModel>();
                    this.History.Clear(); // Clear history
                    break;
            }
        }

        /*
        public void LoadHomePage(HomeMessage obj)
        {
            Navigator((ViewModelBase)obj.Sender, "HomeViewModel");
        }
        
        public void LoadHeroPage(HeroMessage obj)
        {
            HeroViewModel tempVM = (HeroViewModel)Navigator((ViewModelBase) obj.Sender, "HeroViewModel");
            tempVM.Hero = obj.Hero;
        }

        public void LoadMoviePage(MovieMessage obj)
        {
            Navigator((ViewModelBase)obj.Sender, "MovieViewModel");
        }
        
        public void LoadProfilePage(ProfileMessage obj)
        {
            Navigator((ViewModelBase)obj.Sender, "ProfileViewModel");
        }

        public void LoadListHeroPage(ListHeroMessage obj)
        {
            Navigator((ViewModelBase)obj.Sender, "ListHeroViewModel");
        }

        public void LoadListMoviePage(ListMovieMessage obj)
        {
            Navigator((ViewModelBase)obj.Sender, "ListMovieViewModel");
        }
        
        private void LoadPageFromHistory(HistoryMessage obj)
        {
            Navigator((ViewModelBase)obj.Sender, "");
        }
        */

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void DisplayHome()
        {
            Navigator(new HomeMessage(this, "Navigate Home"), "HomeViewModel");
        }

        public void OpenUserWindow()
        {
            ServiceLocator.Current.GetInstance<WindowUserViewModel>();
        }
    }
}