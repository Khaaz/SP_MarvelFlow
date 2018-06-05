using CommonServiceLocator;
using GalaSoft.MvvmLight;
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
    public class EditHeroViewModel : ViewModelBase
    {

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

            this.ListHerosView = new ObservableCollection<Hero>(ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes());
            EnumUniverse = Enum.GetValues(typeof(Universe));
            EnumStatus = Enum.GetValues(typeof(Status));
            EnumTeam = Enum.GetValues(typeof(Team));
        }
        /* ListChosen.Clear();
                 List<Hero> ListTemp = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes();
                 foreach (Hero h in ListTemp)
                 {
                     ListChosen.Add((IEditable) h);
                 } */

    }
}
