using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class HeroViewModel : ViewModelBase
    {
        public RelayCommand ReturnBackCommand { get; private set; }

        public List<Movie> ListMovies { get; set; }
        public Hero Im {get; set; }

        public HeroViewModel()
        {
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);

            ListMovies = new List<Movie>();
            Film f1 = new Film("AV3", "Avengers Infinity Wars", "pack://application:,,,/MarvelFlow.App;component/Images/ImagesMovie/Avengers3.jpg", "film Avengers 3 avec plein de gens dedans", "Frères Russo", "25/04/18", Universe.MCU);
            Film f3 = new Film("IM1", "Iron Man", "pack://application:,,,/MarvelFlow.App;component/Images/ImagesMovie/IronMan.jpg", "film homme de fer", "Jon Favreau", "30/04/08", Universe.MCU);
            ListMovies.Add(f1);
            ListMovies.Add(f3);

            Im = new Hero("IM", "IronMan", "pack://application:,,,/MarvelFlow.App;component/Images/ImagesHero/ironMan.png", "Voici IronMan,l'homme de fer", Status.Gentil, Team.Avengers, Universe.MCU);

            Im.listMovies = ListMovies;
            
        }

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }

        
    }
}
