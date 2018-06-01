using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class ListHeroViewModel : ViewModelBase
    {
        public RelayCommand<Hero> NavigateHeroCommand { get; private set; }
        public RelayCommand ReturnBackCommand { get; private set; }

        private ObservableCollection<Hero> _ListHerosView;
        public ObservableCollection<Hero> ListHerosView
        {
            get
            {
                return _ListHerosView;
            }
            set
            {
                if (_ListHerosView == value)
                    return;
                _ListHerosView = value;
                RaisePropertyChanged(() => ListHerosView);
            }
        }

        private string _SearchBar;
        public string SearchBar
        {
            get
            {
                return _SearchBar;
            }
            set
            {
                if (_SearchBar == value)
                    return;
                _SearchBar = value;
                RaisePropertyChanged(() => SearchBar);
                FindByString(SearchBar);
            }
        }

        public ListHeroViewModel()
        {
            // Commands
            this.NavigateHeroCommand = new RelayCommand<Hero>(this.SendNavigateHero, CanDisplayMessage());
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);
        }

        public void FindByString(string input)
        {
            List<Hero> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().Where(h => h.Name.ToLower().StartsWith(input.ToLower())).ToList();
            this.ListHerosView.Clear();
            foreach(Hero h in tempList)
            {
                this.ListHerosView.Add(h);
            }
        }

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendNavigateHero(Hero hero)
        {
            MessengerInstance.Send<HeroMessage>(new HeroMessage(this, hero, "Navigate Hero Message"));
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }
    }
}
