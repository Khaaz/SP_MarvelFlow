using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class ListMovieViewModel : ViewModelBase
    {
        public RelayCommand<Movie> NavigateMovieCommand { get; private set; }
        public RelayCommand ReturnBackCommand { get; private set; }

        private ObservableCollection<ISearchableMovie> _ListMovies;
        public ObservableCollection<ISearchableMovie> ListMovies {
            get
            {
                return _ListMovies;
            }
            set
            {
                if (_ListMovies == value)
                    return;
                _ListMovies = value;
                RaisePropertyChanged(() => _ListMovies);
            }
        }

        public ListMovieViewModel()
        {
            this.NavigateMovieCommand = new RelayCommand<Movie>(this.SendNavigateMovie, CanDisplayMessage());
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);


            ListMovies = new ObservableCollection<ISearchableMovie>();


            Film f1 = new Film("AV3", "Avengers Infinity Wars", "ImagesMovie/Avengers3.jpg", "film Avengers 3 avec plein de gens dedans", "Frères Russo", "25/04/18", Universe.MCU);
            Film f2 = new Film("AM", "AntMan", "ImagesMovie/Antman2.jpg", "film homme fourmi", "Payton Reed", "14/07/15", Universe.MCU);
            Film f3 = new Film("IM1", "IronMan", "ImagesMovie/IronMan.jpg", "film homme de fer", "Jon Favreau", "30/04/08", Universe.MCU);

            ListMovies.Add(f1);
            ListMovies.Add(f2);
            ListMovies.Add(f3);
        }

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendNavigateMovie(Movie movie)
        {
            MessengerInstance.Send<MovieMessage>(new MovieMessage(this, movie, "Navigate Movie Message"));
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }
    }
}
