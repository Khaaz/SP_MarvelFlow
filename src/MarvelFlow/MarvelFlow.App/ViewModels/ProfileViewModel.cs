using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.DataBase;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
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

                this.SelectedHero = _CurrentUser == null ? HeroList.FirstOrDefault() : HeroList.Find(h => h.Id == CurrentUser.HeroFav);
                this.Image = CurrentUser == null ? @"C:\Users\lbell\Desktop\DEVELOPEMENT\C#\marvelflow\src\MarvelFlow\MarvelFlow.App\Images/pdp2.png" : HeroList.Find(h => h.Id == CurrentUser.HeroFav).Image;
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
            this.Image = CurrentUser == null ? @"C:\Users\lbell\Desktop\DEVELOPEMENT\C#\marvelflow\src\MarvelFlow\MarvelFlow.App\Images/pdp2.png" : HeroList.Find(hero => hero.Id == CurrentUser.HeroFav).Image;
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
