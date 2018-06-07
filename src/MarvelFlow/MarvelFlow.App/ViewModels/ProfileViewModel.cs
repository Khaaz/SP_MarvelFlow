using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using MarvelFlow.DataBase;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        public RelayCommand ReturnBackCommand { get; private set; } // history command
        public RelayCommand NavigateAdminCommand { get; private set; }
        public RelayCommand DeconnexionCommand { get; private set; }

        private ObservableCollection<Hero> _ListHeroesView;
        public ObservableCollection<Hero> ListHeroesView
        {
            get
            {
                return _ListHeroesView;
            }
            set
            {
                if (_ListHeroesView == value)
                    return;
                _ListHeroesView = value;
                RaisePropertyChanged(() => ListHeroesView);
            }
        }

        private ObservableCollection<ISearchableMovie> _ListMoviesView;
        public ObservableCollection<ISearchableMovie> ListMoviesView
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

        private User _CurrentUser;
        public User CurrentUser
        {
            get
            {
                return _CurrentUser;
            }
            set
            {
                if (_CurrentUser == value)
                    return;
                _CurrentUser = value;
                RaisePropertyChanged(() => CurrentUser);
                NavigateAdminCommand.RaiseCanExecuteChanged();

                this.SelectedHero = CurrentUser == null ? HeroList.FirstOrDefault() : HeroList.Find(h => h.Id == CurrentUser.HeroFav);
                this.Image = CurrentUser == null ? ConfigurationManager.AppSettings["AffichePath"] + "pdp2.png" : HeroList.Find(h => h.Id == CurrentUser.HeroFav).Image;
                this.ListHeroesView = CurrentUser == null ? new ObservableCollection<Hero>() : new ObservableCollection<Hero>(CurrentUser.ListHeros);
                this.ListMoviesView = CurrentUser == null ? new ObservableCollection<ISearchableMovie>() : new ObservableCollection<ISearchableMovie>(CurrentUser.ListMovie);
            }
        }

        public string _Image;
        public string Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (_Image == value)
                    return;
                _Image = value;
                RaisePropertyChanged(() => Image);
            }
        }

        public List<Hero> HeroList { get; set; }

        private Hero _SelectedHero;
        public Hero SelectedHero
        {
            get
            {
                return _SelectedHero;
            }
            set
            {
                if (_SelectedHero == value)
                    return;
                _SelectedHero = value;
                RaisePropertyChanged(() => SelectedHero);
                this.UpdateHeroFav(_SelectedHero);
            }
        }


        public ProfileViewModel()
        {
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);
            this.NavigateAdminCommand = new RelayCommand(this.SendNavigateAdmin, CanOpenAdmin);
            this.DeconnexionCommand = new RelayCommand(this.Deconnexion, CanDisplayMessage);

            this.CurrentUser = null;

            HeroList = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes();
        }

        public void UpdateHeroFav(Hero h)
        {
            ServiceLocator.Current.GetInstance<CurrentUserHandler>().EditUserHero(h.Id);
            this.CurrentUser = ServiceLocator.Current.GetInstance<CurrentUserHandler>().GetUser();
            this.Image = CurrentUser == null ? ConfigurationManager.AppSettings["AffichePath"] + "pdp2.png" : HeroList.Find(hero => hero.Id == CurrentUser.HeroFav).Image;
        }

        // Commands methods
        public bool CanDisplayMessage()
        {
            return true;
        }

        public bool CanOpenAdmin()
        {
            if (CurrentUser == null || (CurrentUser != null && !CurrentUser.IsAdmin))
            {
                return false;
            }
            return true;
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
            new UpdateDB().UpdateHeroFav(CurrentUser.Login, SelectedHero.Id);
        }

        public void SendNavigateAdmin()
        {
            MessengerInstance.Send<AdminMessage>(new AdminMessage(this, "Navigate Admin Panel"));
        }

        public void Deconnexion()
        {
            ServiceLocator.Current.GetInstance<CurrentUserHandler>().EditUser(null);
            MessengerInstance.Send<HomeMessage>(new HomeMessage(this, "Navigate Home Page"));
        }
    }
}
