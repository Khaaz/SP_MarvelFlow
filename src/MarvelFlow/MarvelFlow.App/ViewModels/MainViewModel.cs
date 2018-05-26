using CommonServiceLocator;
using GalaSoft.MvvmLight;
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

        //public Stack<int> History; // Historique
        //public NavigationHandler Navigator;

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

            this._CurrentVM = ServiceLocator.Current.GetInstance<ListMovieViewModel>();

            List<Hero> ListHeros = ManagerJson.GetHeroes();
            List<Film> ListFilms = ManagerJson.GetFilms();
            List<Serie> ListSerie = ManagerJson.GetSeries();

            //ListViewName.ItemSource = ListHeros

            Console.WriteLine("Hello WORLD");
        }
    }
}