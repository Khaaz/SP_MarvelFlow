using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.App.Views;
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
    public class FilmViewModel : ViewModelBase
    {
        public RelayCommand ReturnBackCommand { get; private set; }
        public RelayCommand<Hero> NavigateHeroCommand { get; private set; }
        public RelayCommand<string> PlayTeaserCommand { get; private set; }

        public ISearchableMovie _Movie;
        public ISearchableMovie Movie
        {
            get
            {
                return _Movie;
            }
            set
            {
                if (_Movie == value)
                    return;
                _Movie = value;
                RaisePropertyChanged(() => Movie);
            }
        }

        public FilmViewModel()
        {
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);
            this.NavigateHeroCommand = new RelayCommand<Hero>(this.SendNavigateHero, CanDisplayMessage());
            this.PlayTeaserCommand = new RelayCommand<string>(this.OpenTeaser, CanDisplayMessage());
        }

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }

        public void SendNavigateHero(Hero hero)
        {
            MessengerInstance.Send<HeroMessage>(new HeroMessage(this, hero, "Navigate Hero Message"));
        }

        public void OpenTeaser(string pathBA)
        {
            WindowsBandeAnnonce TeaserWindow = new WindowsBandeAnnonce(pathBA);
            TeaserWindow.Show();
        }
    }
}
