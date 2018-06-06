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
        
        public List<string> EnumUniverse { get; set; } // Enum to show in combobox
        public List<string> EnumTeam { get; set; } // Enum to show in combobox

        private string _SelectedUniverse; // Selected Item in Universe Combobox
        public string SelectedUniverse
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

        private string _SelectedTeam; // Selected Item in Team Combobox
        public string SelectedTeam
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
            this.ListHerosView = new ObservableCollection<Hero>(ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().OrderBy(h => h.Name).ToList());

            // Init misc
            Array arrUniverse = Enum.GetValues(typeof(Universe));
            Array arrTeam = Enum.GetValues(typeof(Team));

            EnumUniverse = new List<string>();
            EnumUniverse.Add("Select a Universe");
            foreach (Universe u in arrUniverse)
            {
                EnumUniverse.Add(u.ToString());
            }

            EnumTeam = new List<string>();
            EnumTeam.Add("Select a Team");
            foreach (Team t in arrTeam)
            {
                EnumTeam.Add(t.ToString());
            }
        }

        /// <summary>
        /// Method associated with search bar
        /// Filter View List with the input string to match
        /// </summary>
        /// <param name="input"></param>
        public void FindByString(string input)
        {
            List<Hero> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes()
                .Where(h => h.Name.ToLower().StartsWith(input.ToLower()))
                .OrderBy(h => h.Name)
                .ToList();
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
        public void FindEnumUniverse(string u)
        {

            if (u.Equals("Select a Universe"))
            {
                ResetListView();
            }
            else
            {
                List<Hero> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes()
                    .Where(h => h.Universe.ToString() == u)
                    .OrderBy(h => h.Name)
                    .ToList();
                this.ListHerosView.Clear();
                foreach (Hero h in tempList)
                {
                    this.ListHerosView.Add(h);
                }
            }
        }

        /// <summary>
        /// Method associated with combo box
        /// Filter View List with the input Team to match
        /// </summary>
        /// <param name="t"></param>
        public void FindEnumTeam(string t)
        {
            if (t.Equals("Select a Team"))
            {
                ResetListView();
            }
            else
            {
                List<Hero> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes()
                    .Where(h => h.Team.ToString() == t)
                    .OrderBy(h => h.Name)
                    .ToList();
                this.ListHerosView.Clear();
                foreach (Hero h in tempList)
                {
                    this.ListHerosView.Add(h);
                }
            }
        }

        /// <summary>
        /// Reset List View to default values (all list)
        /// </summary>
        public void ResetListView()
        {
            List<Hero> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().OrderBy(h => h.Name).ToList();
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
