using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        public Stack<string> History { get; set; } // Historique

        private ViewModelBase _CurrentVM;

        public RelayCommand NavigateUserWindowCommand { get; private set; }

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
            this.History = new Stack<string>();

            this._CurrentVM = ServiceLocator.Current.GetInstance<HomeViewModel>();

            // Init Messaging
            MessengerInstance.Register<HomeMessage>(this, (HomeMessage obj) => Navigator((ViewModelBase)obj.Sender, "HomeViewModel"));
            MessengerInstance.Register<HeroMessage>(this, (HeroMessage obj) => Navigator((ViewModelBase)obj.Sender, "HeroViewModel"));
            MessengerInstance.Register<MovieMessage>(this, (MovieMessage obj) => Navigator((ViewModelBase)obj.Sender, "MovieViewModel"));
            MessengerInstance.Register<ProfileMessage>(this, (ProfileMessage obj) => Navigator((ViewModelBase)obj.Sender, "ProfileViewModel"));
            MessengerInstance.Register<ListHeroMessage>(this, (ListHeroMessage obj) => Navigator((ViewModelBase)obj.Sender, "ListHeroViewModel"));
            MessengerInstance.Register<ListMovieMessage>(this, (ListMovieMessage obj) => Navigator((ViewModelBase)obj.Sender, "ListMovieViewModel"));
            
            MessengerInstance.Register<HistoryMessage>(this, (HistoryMessage obj) => Navigator((ViewModelBase)obj.Sender, ""));

            // Commands
            this.NavigateUserWindowCommand = new RelayCommand(this.OpenUserWindow, CanDisplayMessage);

            // Init Data
            List<Hero> ListHeros = ManagerJson.GetHeroes();
            List<Film> ListFilms = ManagerJson.GetFilms();
            List<Serie> ListSerie = ManagerJson.GetSeries();
        }

        public void Navigator(ViewModelBase source, string dest)
        {
            string pageName = string.IsNullOrEmpty(dest) ? this.History.Pop() : dest; // call the history or the ViewModel Name - (get the class name as string)

            this.History.Push(source.GetType().Name); // push the source ViewModel in History (as his className string)

            switch (pageName)
            {
                case "HomeViewModel":
                    this.CurrentVM = ServiceLocator.Current.GetInstance<HomeViewModel>();
                    this.History.Clear(); // Clear history
                    break;
                case "HeroViewModel":
                    this.CurrentVM = ServiceLocator.Current.GetInstance<HeroViewModel>();
                    break;
                case "MovieViewModel":
                    this.CurrentVM = ServiceLocator.Current.GetInstance<MovieViewModel>();
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
                    Console.WriteLine("this doesn't work");
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
            Navigator((ViewModelBase) obj.Sender, "HeroViewModel");
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

        public void OpenUserWindow()
        {
            ServiceLocator.Current.GetInstance<WindowUserViewModel>();
        }
    }
}