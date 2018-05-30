using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MarvelFlow.App.Lib;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
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

            // Init Data
            List<Hero> ListHeros = ManagerJson.GetHeroes();
            List<Film> ListFilms = ManagerJson.GetFilms();
            List<Serie> ListSerie = ManagerJson.GetSeries();
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
                    HeroMessage messHero = (HeroMessage)obj;
                    if (messHero.Hero == null)
                    {
                        this.CurrentVM = ServiceLocator.Current.GetInstance<HomeViewModel>();
                        this.History.Clear(); // Clear history
                    }
                    else
                    {
                        HeroViewModel tempHeroVM = ServiceLocator.Current.GetInstance<HeroViewModel>();
                        tempHeroVM.Hero = HistoryObject != null ? HistoryObject.Hero : messHero.Hero;
                        this.CurrentVM = tempHeroVM;
                    }
                    break;
                case "MovieViewModel":
                    MovieMessage messMovie = (MovieMessage)obj;
                    if (messMovie.Movie == null)
                    {
                        this.CurrentVM = ServiceLocator.Current.GetInstance<HomeViewModel>();
                        this.History.Clear(); // Clear history
                    }
                    else
                    {
                        MovieViewModel tempMovieVM = ServiceLocator.Current.GetInstance<MovieViewModel>();
                        tempMovieVM.Movie = HistoryObject != null ? HistoryObject.Movie : messMovie.Movie;
                        this.CurrentVM = tempMovieVM;
                    }
                    break;
                case "ProfileViewModel":
                    this.CurrentVM = ServiceLocator.Current.GetInstance<ProfileViewModel>();
                    break;
                case "ListHeroViewModel":
                    this.CurrentVM = ServiceLocator.Current.GetInstance<ListHeroViewModel>();
                    break;
                case "ListMovieViewModel":
                    this.CurrentVM = ServiceLocator.Current.GetInstance<ListMovieViewModel>();
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