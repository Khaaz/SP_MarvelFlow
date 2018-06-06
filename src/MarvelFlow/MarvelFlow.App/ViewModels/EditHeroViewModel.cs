using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class EditHeroViewModel : ViewModelBase
    {
        public RelayCommand<Hero> DisplayHeroCommand { get; private set; }
        public RelayCommand HeroResetCommand { get; private set; }

        public RelayCommand DeleteHeroCommand { get; private set; }

        public RelayCommand ValidateCommand { get; private set; }

        private Hero _CurrentHero;
        public Hero CurrentHero
        {
            get
            {
                return _CurrentHero;
            }
            set
            {
                if (_CurrentHero == value)
                    return;
                _CurrentHero = value;
                RaisePropertyChanged(() => CurrentHero);
                ValidateCommand.RaiseCanExecuteChanged();
                DeleteHeroCommand.RaiseCanExecuteChanged();
            }
        }

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

        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id == value)
                    return;
                _Id = value;
                RaisePropertyChanged(() => Id);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged(() => Name);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Image;
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
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (_Description == value)
                    return;
                _Description = value;
                RaisePropertyChanged(() => Description);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        public Array EnumUniverse { get; set; }

        private Universe _SelectedUniverse;
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
            }
        }

        public Array EnumStatus { get; set; }

        private Status _SelectedStatus;
        public Status SelectedStatus
        {
            get
            {
                return _SelectedStatus;
            }
            set
            {
                if (_SelectedStatus == value)
                    return;
                _SelectedStatus = value;
                RaisePropertyChanged(() => SelectedStatus);
            }
        }

        public Array EnumTeam { get; set; }

        private Team _SelectedTeam;
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
            }
        }


        public EditHeroViewModel()
        {
            CurrentHero = null;
            this.DisplayHeroCommand = new RelayCommand<Hero>(this.DisplayHero, h => CanDisplayMessage());
            this.HeroResetCommand = new RelayCommand(this.ResetDisplayHero, CanDisplayMessage);
            this.DeleteHeroCommand = new RelayCommand(this.DeleteHero, CanDeleteHero);
            this.ValidateCommand = new RelayCommand(this.Validate, CanValidate);

            // Init values
            this.ListHerosView = new ObservableCollection<Hero>(ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().OrderBy(h => h.Name).ToList());
            EnumUniverse = Enum.GetValues(typeof(Universe));
            EnumStatus = Enum.GetValues(typeof(Status));
            EnumTeam = Enum.GetValues(typeof(Team));
        }

        // Commands Methods
        public bool CanDisplayMessage()
        {
            return true;
        }

        // display hero binding (lisview)

        /// <summary>
        /// Update the view with value of the selected element in List View
        /// </summary>
        /// <param name="hero"></param>
        public void DisplayHero(Hero hero)
        {
            CurrentHero = hero;
            Id = hero.Id;
            Name = hero.Name;
            Image = Util.FormatPathHero(hero.Image);
            Description = hero.Desc;
            SelectedStatus = hero.Status;
            SelectedTeam = hero.Team;
            SelectedUniverse = hero.Universe;

        }

        /// <summary>
        /// Reset view - all fields to null
        /// Allow editing a new Hero
        /// </summary>
        public void ResetDisplayHero()
        {
            CurrentHero = null;
            string empty = "";
            Id = empty;
            Name = empty;
            Image = empty;
            Description = empty;
            SelectedStatus = Status.Neutre;
            SelectedTeam = Team.Aucun;
            SelectedUniverse = Universe.MCU;
        }

        /// <summary>
        /// Can delete a Hero if it is one existing
        /// (CurrentHero binded)
        /// </summary>
        /// <returns></returns>
        public bool CanDeleteHero()
        {
            if (CurrentHero == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Delete the hero in general List
        /// Refresh View and update List
        /// </summary>
        public void DeleteHero()
        {
            // DELETE HERO
            bool val = ServiceLocator.Current.GetInstance<ManagerJson>().RemoveHero(CurrentHero);
            if (val)
            {
                this.ResetDisplayHero();
                this.RefreshList();
            }
        }

        public bool CanValidate()
        {
            return !CheckChampEmptyOrWhiteSpace();
        }

        /// <summary>
        /// Check if all fields respect validity (no null, no empty, no whitespace)
        /// Can Execute Validate Command
        /// </summary>
        /// <returns></returns>
        public bool CheckChampEmptyOrWhiteSpace()
        {
            if (string.IsNullOrEmpty(Id) || string.IsNullOrWhiteSpace(Id))
            {
                return true;
            }
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                return true;
            }
            if (string.IsNullOrEmpty(Image) || string.IsNullOrWhiteSpace(Image))
            {
                return true;
            }
            if (string.IsNullOrEmpty(Description) || string.IsNullOrWhiteSpace(Description))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check Validity of all fields
        /// </summary>
        /// <returns></returns>
        public bool IsChampValid()
        {
            string notV = "Not Valid";
            if (Util.ContainsQuotes(Id) || !AppUtils.IsIdHeroValid(Id))
            {
                
                Id = notV;
                return false;
            }
            if (Util.ContainsQuotes(Name) || !AppUtils.ValidNameHero(Name))
            {
                Name = notV;
                return false;
            }
            if (Util.ContainsQuotes(Image) || !Util.IsPathHero(Image))
            {
                Image = notV;
                return false;
            }
            if (Util.ContainsQuotes(Description))
            {
                Description = notV;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Add Or Update a Hero
        /// IF Respect validity
        /// </summary>
        public void Validate()
        {
            if (IsChampValid())
            {
                if (CurrentHero == null)
                {
                    this.CreateHero();
                }
                else
                {
                    int res = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().FindIndex(h => h.Id == Id);
                    
                    if (res == -1 || ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes()[res] == CurrentHero)
                    {
                        this.EditHero();
                    }
                    else
                    {
                        Id = "Already Used";
                        return;
                    }   
                }
            }
        }

        /// <summary>
        /// Create a hero
        /// </summary>
        public void CreateHero()
        {
            if (ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().Any(h => h.Id == Id))
            {
                Id = "Already Used";
                return;
            }

            //CREER NOUVEAU HERO
            Hero hero = new Hero(Id, Name, Image, Description, SelectedStatus, SelectedTeam, SelectedUniverse);

            bool val = ServiceLocator.Current.GetInstance<ManagerJson>().AddHero(hero);
            if (val)
            {
                this.ResetDisplayHero();
                this.RefreshList();
            }
        }

        /// <summary>
        /// Edit hero
        /// Update by giving old and new film
        /// </summary>
        public void EditHero()
        {
            //EDIT HERO
            Hero hero = new Hero(Id, Name, Image, Description, SelectedStatus, SelectedTeam, SelectedUniverse);
            bool val = ServiceLocator.Current.GetInstance<ManagerJson>().UpdateHero(hero, CurrentHero);

            if (val)
            {
                this.ResetDisplayHero();
                this.RefreshList();
            }
            return;
        }

        /// <summary>
        /// Refresh Current List View
        /// </summary>
        public void RefreshList()
        {
            List<Hero> temp = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().OrderBy(h => h.Name).ToList();
            this.ListHerosView.Clear();
            foreach(Hero h in temp)
            {
                this.ListHerosView.Add(h);
            }
        }
    }
}
