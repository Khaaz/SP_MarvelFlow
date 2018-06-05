using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class EditFilmViewModel : ViewModelBase
    {
        public RelayCommand<Film> NavigateMovieCommand { get; private set; }

        
        private ObservableCollection<Film> _ListMoviesView; // List to show in the View
        public ObservableCollection<Film> ListMoviesView
        {
            get
            {
                return _ListMoviesView;
            }
            set
            {
                if (_ListMoviesView == value)
                    return;
                _ListMoviesView = value;
                RaisePropertyChanged(() => ListMoviesView);
            }
        }

        public Array EnumUniverse { get; set; }


        private Universe _SelectedUniverse;
        public Universe SelectedUniverse
        {
            get
            {
                return _SelectedUniverse;
            }
            set
            {
                if (_SelectedUniverse == value)
                    return;
                _SelectedUniverse = value;
                RaisePropertyChanged(() => SelectedUniverse);
            }
        }

        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id == value)
                    return;
                _Id = value;
                RaisePropertyChanged(() => Id);
            }
        }



        public EditFilmViewModel()
        {
            this.NavigateMovieCommand = new RelayCommand<Film>(this.SendNavigateMovie, m => CanDisplayMessage());
            ListMoviesView = new ObservableCollection<Film>();

            List<ISearchableMovie> ListTemp = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies();
            foreach (ISearchableMovie m in ListTemp)
            {
                if (m.GetType() == typeof(Film))
                {
                    ListMoviesView.Add((Film)m);
                }

            }

            EnumUniverse = Enum.GetValues(typeof(Universe));
            


        }

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendNavigateMovie(ISearchableMovie movie)
        {
            MessengerInstance.Send<MovieMessage>(new MovieMessage(this, movie, "Navigate Movie Message"));
        }


    }
}
