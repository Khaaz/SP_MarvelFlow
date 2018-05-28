using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class ListMovieViewModel : ViewModelBase
    {
        public RelayCommand NavigateMovieCommand { get; private set; }
        public RelayCommand ReturnBackCommand { get; private set; }

        public List<ISearchableMovie> ListMovies { get; set; }

        public ListMovieViewModel()
        {
            this.NavigateMovieCommand = new RelayCommand(this.SendNavigateMovie, CanDisplayMessage);
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);


            ListMovies = new List<ISearchableMovie>();


            Film f1 = new Film("AV3", "Avengers Infinity Wars", "pack://application:,,,/MarvelFlow.App;component/ImagesMovie/Avengers3.jpg", "film Avengers 3 avec plein de gens dedans", "Frères Russo", "25/04/18", Universe.MCU);
            Film f2 = new Film("AM", "AntMan", "pack://application:,,,/MarvelFlow.App;component/ImagesMovie/Antman.jpg", "film homme fourmi", "Payton Reed", "14/07/15", Universe.MCU);
            Film f3 = new Film("IM1", "IronMan", "pack://application:,,,/MarvelFlow.App;component/ImagesMovie/IronMan.jpg", "film homme de fer", "Jon Favreau", "30/04/08", Universe.MCU);

            ListMovies.Add(f1);
            ListMovies.Add(f2);
            ListMovies.Add(f3);
        }

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendNavigateMovie()
        {
            MessengerInstance.Send<MovieMessage>(new MovieMessage(this, "Navigate Movie Message"));
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }
    }
}
