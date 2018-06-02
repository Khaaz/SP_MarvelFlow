using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
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

        public ProfileViewModel()
        {
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);
            this.NavigateAdminCommand = new RelayCommand(this.SendNavigateAdmin, CanDisplayMessage);
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

        public void SendNavigateAdmin()
        {
            MessengerInstance.Send<AdminMessage>(new AdminMessage(this, "Navigate Admin Panel"));
        }

    }
}
