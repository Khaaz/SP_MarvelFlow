/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MarvelFlow.App"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MarvelFlow.App.ViewModels;
using MarvelFlow.DataBase;
using MarvelFlow.Service;
using Newtonsoft.Json;
using System;

namespace MarvelFlow.App.Lib
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            // Services
            SimpleIoc.Default.Register<ManagerJson>(); // Service - handler Json
            SimpleIoc.Default.Register<CurrentUserHandler>(); // Handler Current User
            
            // Service DB
            //SimpleIoc.Default.Register<SelectDB>();
            //SimpleIoc.Default.Register<UpdateDB>();

            // ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();

            SimpleIoc.Default.Register<HeroViewModel>();
            SimpleIoc.Default.Register<FilmViewModel>();
            SimpleIoc.Default.Register<SerieViewModel>();

            SimpleIoc.Default.Register<ProfileViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<AdminPanelViewModel>();
            SimpleIoc.Default.Register<EditFilmViewModel>();
            SimpleIoc.Default.Register<EditHeroViewModel>();

            SimpleIoc.Default.Register<ListHeroViewModel>();
            SimpleIoc.Default.Register<ListMovieViewModel>();

            SimpleIoc.Default.Register<WindowUserViewModel>();
            
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public HeroViewModel Hero
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HeroViewModel>();
            }
        }

        public FilmViewModel Film
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FilmViewModel>();
            }
        }

        public SerieViewModel Serie
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SerieViewModel>();
            }
        }

        public ProfileViewModel Profile
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProfileViewModel>();
            }
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public AdminPanelViewModel AdminPanel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AdminPanelViewModel>();
            }
        }

        public EditHeroViewModel EditHero
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditHeroViewModel>();
            }
        }

        public EditFilmViewModel EditFilm
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditFilmViewModel>();
            }
        }



        public ListHeroViewModel ListHero
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListHeroViewModel>();
            }
        }

        public ListMovieViewModel ListMovie
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListMovieViewModel>();
            }
        }

        public WindowUserViewModel WindowUser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WindowUserViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}