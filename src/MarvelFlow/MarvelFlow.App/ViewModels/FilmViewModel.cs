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
        public RelayCommand ReturnBackCommand { get; private set; } // history command
        public RelayCommand<Hero> NavigateHeroCommand { get; private set; } // navigate to next Movie binded (ListView)
        public RelayCommand<string> PlayTeaserCommand { get; private set; } // BA Command (show the teaser)

        public ISearchableMovie _Movie; // Mobie binded to show (Film)
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
            this.NavigateHeroCommand = new RelayCommand<Hero>(this.SendNavigateHero, h => CanDisplayMessage());
            this.PlayTeaserCommand = new RelayCommand<string>(this.OpenTeaser, s => CanDisplayMessage());
        }

        // Commands methods

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

        /// <summary>
        /// Open Tease view (new windows - Winform)
        /// </summary>
        /// <param name="pathBA"></param>
        public void OpenTeaser(string pathBA)
        {
            WindowsBandeAnnonce TeaserWindow = new WindowsBandeAnnonce(pathBA);
            TeaserWindow.Show();
        }
    }
}
