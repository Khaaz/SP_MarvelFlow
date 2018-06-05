using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using MarvelFlow.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MarvelFlow.App.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public RelayCommand NavigateListHeroCommand { get; private set; } // Navigate to ListHeros
        public RelayCommand NavigateListMovieCommand { get; private set; } // Navigate to ListMovies
        public RelayCommand NavigateProfileCommand { get; private set; } // Navigate to Profile
        public RelayCommand NavigateMovieCommand { get; private set; } //Navigate to HomeVideo


        private Film _HomeVideo;

        public Film HomeVideo
        {
            get
            {
                return _HomeVideo;
            }
            set
            {
                if (_HomeVideo == value)
                    return;
                _HomeVideo = value;
                RaisePropertyChanged(() => HomeVideo);
            }
        }

        public HomeViewModel()
        {
            FindLastVideo();
            this.NavigateListHeroCommand = new RelayCommand(this.SendNavigateListHero, CanDisplayMessage);
            this.NavigateListMovieCommand = new RelayCommand(this.SendNavigateListMovie, CanDisplayMessage);
            this.NavigateProfileCommand = new RelayCommand(this.SendNavigateProfile, CanDisplayMessage);

            this.NavigateMovieCommand = new RelayCommand(this.SendNavigateMovie,CanDisplayMessage);

            // Error Handling
            try
            {
                ServiceLocator.Current.GetInstance<ManagerJson>().LoadHero();
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, "Path error:", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Windows.Application.Current.Shutdown();
            }
            catch (JsonException e)
            {
                MessageBox.Show(e.Message, "Corrupted Json:", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Windows.Application.Current.Shutdown();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "No Data:", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Windows.Application.Current.Shutdown();
            }

        }

        public void FindLastVideo()
        {
            HomeVideo = (Film) ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies()
                .Where(m => m.GetType() == typeof(Film))
                .OrderBy(m => m.GetDate())
                .LastOrDefault();
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

        public void SendNavigateMovie()
        {
            MessengerInstance.Send<MovieMessage>(new MovieMessage(this, (ISearchableMovie) HomeVideo, "Navigate Movie Message"));
        }
    }
}
