using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
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
            }
        }

        public ProfileViewModel()
        {
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);
            this.NavigateAdminCommand = new RelayCommand(this.SendNavigateAdmin, CanOpenAdmin);
            this.CurrentUser = null;
        }

        // Commands methods
        public bool CanDisplayMessage()
        {
            return true;
        }

        public bool CanOpenAdmin()
        {
            if (!CurrentUser.IsAdmin)
            {
                return false;
            }
            return true;
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }

        public void SendNavigateAdmin()
        {
            MessengerInstance.Send<AdminMessage>(new AdminMessage(this, "Navigate Admin Panel"));
        }

    }
}
