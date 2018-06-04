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

        private ObservableCollection<Hero> _ListHerosView; // List to show in the View
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

        private string _SearchBar; // Textbox content - trigger filtering the view list
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
        
        public Array EnumUniverse { get; set; } // Enum to show in combobox
        public Array EnumTeam { get; set; } // Enum to show in combobox

        private Universe _SelectedUniverse; // Selected Item in Universe Combobox
        public Universe SelectedUniverse
        {
            get
            {
                return _SelectedUniverse;
            }
            set
            {
                if (_SelectedUniverse == value)
                    return;
                _SelectedUniverse = value;
                RaisePropertyChanged(() => SelectedUniverse);
                FindEnumUniverse(SelectedUniverse);
            }
        }

        private Team _SelectedTeam; // Selected Item in Team Combobox
        public Team SelectedTeam
        {
            get
            {
                return _SelectedTeam;
            }
            set
            {
                if (_SelectedTeam == value)
                    return;
                _SelectedTeam = value;
                RaisePropertyChanged(() => SelectedTeam);
                FindEnumTeam(_SelectedTeam);
            }
        }


        public ListHeroViewModel()
        {
            // Commands
            this.NavigateHeroCommand = new RelayCommand<Hero>(this.SendNavigateHero, h => CanDisplayMessage());
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);

            // Init ObservableCollection when creatingthe instance
            this.ListHerosView = new ObservableCollection<Hero>(ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes());

            // Init misc
            EnumUniverse = Enum.GetValues(typeof(Universe));
            EnumTeam = Enum.GetValues(typeof(Team));
        }

        /// <summary>
        /// Method associated with search bar
        /// Filter View List with the input string to match
        /// </summary>
        /// <param name="input"></param>
        public void FindByString(string input)
        {
            List<Hero> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().Where(h => h.Name.ToLower().StartsWith(input.ToLower())).ToList();
            this.ListHerosView.Clear();
            foreach(Hero h in tempList)
            {
                this.ListHerosView.Add(h);
            }
        }

        /// <summary>
        /// Method associated with combo box
        /// Filter View List with the input Universe to match
        /// </summary>
        /// <param name="u"></param>
        public void FindEnumUniverse(Universe u)
        {
            
            List<Hero> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().Where(h => h.Universe == u).ToList();
            this.ListHerosView.Clear();
            foreach (Hero h in tempList)
            {
                this.ListHerosView.Add(h);
            }
        }

        /// <summary>
        /// Method associated with combo box
        /// Filter View List with the input Team to match
        /// </summary>
        /// <param name="t"></param>
        public void FindEnumTeam(Team t)
        {
            List<Hero> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().Where(h => h.Team == t).ToList();
            this.ListHerosView.Clear();
            foreach (Hero h in tempList)
            {
                this.ListHerosView.Add(h);
            }
        }

        // Commands methods
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
