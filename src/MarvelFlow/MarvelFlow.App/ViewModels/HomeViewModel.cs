using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public RelayCommand NavigateListHeroCommand { get; private set; } // Navigate to ListHeros
        public RelayCommand NavigateListMovieCommand { get; private set; } // Navigate to ListMovies
        public RelayCommand NavigateProfileCommand { get; private set; } // Navigate to Profile

        public HomeViewModel()
        {
            this.NavigateListHeroCommand = new RelayCommand(this.SendNavigateListHero, CanDisplayMessage);
            this.NavigateListMovieCommand = new RelayCommand(this.SendNavigateListMovie, CanDisplayMessage);
            this.NavigateProfileCommand = new RelayCommand(this.SendNavigateProfile, CanDisplayMessage);
        }

        // Commands methods

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendNavigateListHero()
        {
            MessengerInstance.Send<ListHeroMessage>(new ListHeroMessage(this, "Navigate List Hero Message"));
        }

        public void SendNavigateListMovie()
        {
            MessengerInstance.Send<ListMovieMessage>(new ListMovieMessage(this, "Navigate List Movie Message"));
        }

        public void SendNavigateProfile()
        {
            MessengerInstance.Send<ProfileMessage>(new ProfileMessage(this, "Navigate Profile Message"));
        }
    }
}
