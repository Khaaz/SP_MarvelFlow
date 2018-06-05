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
        public RelayCommand HeroReset { get; private set; }

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
        public Array EnumStatus { get; set; }
        public Array EnumTeam { get; set; }

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
            this.HeroReset = new RelayCommand(this.ResetDisplayHero, CanDisplayMessage);
            this.DeleteHeroCommand = new RelayCommand(this.DeleteHero, CanDeleteMovie);
            this.ValidateCommand = new RelayCommand(this.Validate, CanValidate);

            this.ListHerosView = new ObservableCollection<Hero>(ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes());
            EnumUniverse = Enum.GetValues(typeof(Universe));
            EnumStatus = Enum.GetValues(typeof(Status));
            EnumTeam = Enum.GetValues(typeof(Team));
        }


        public bool CanDisplayMessage()
        {
            return true;
        }

        
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

        public void DeleteHero()
        {
            // DELETE HERO
            ResetDisplayHero();
        }

        public bool CanDeleteMovie()
        {
            if(CurrentHero == null)
            {
                return false;
            }
            return true;
        }

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

        public void Validate()
        {
            if (IsChampValid())
            {
                if (CurrentHero == null)
                {
                    //CREER NOUVEAU HERO
                }
                else
                {
                    //EDIT HERO
                }
            }
        }

        public bool CanValidate()
        {
            return !CheckChampEmptyOrWhiteSpace();
        }
    }
}
