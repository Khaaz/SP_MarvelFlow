using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
using System.Windows.Documents;

namespace MarvelFlow.App.ViewModels
{
    public class AdminPanelViewModel : ViewModelBase
    {

        public List<string> MediaList { get; set; } // List to show in combobox

        private ViewModelBase _CurrentVM;
        public ViewModelBase CurrentVM
        {
            get
            {
                return _CurrentVM;
            }
            set
            {
                if (_CurrentVM == value)
                    return;
                _CurrentVM = value;
                RaisePropertyChanged(() => CurrentVM);
}
        }


        private string _SelectedMedia; // Selected Item in Media Combobox
        public string SelectedMedia
        {
            get
            {
                return _SelectedMedia;
            }
            set
            {
                if (_SelectedMedia == value)
                    return;
                _SelectedMedia = value;
                RaisePropertyChanged(() => SelectedMedia);
                if (SelectedMedia.Equals("Movie"))
                {
                    CurrentVM = ServiceLocator.Current.GetInstance<EditFilmViewModel>();
                }
                else if (SelectedMedia.Equals("Hero"))
                {
                    CurrentVM = ServiceLocator.Current.GetInstance<EditHeroViewModel>();
                }
            }
        }

        public RelayCommand ReturnBackCommand { get; private set; } // history command 


        public AdminPanelViewModel()
        {
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);

            MediaList = new List<string> { "Movie", "Hero" };

            CurrentVM = ServiceLocator.Current.GetInstance<EditHeroViewModel>();

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
    }
}
