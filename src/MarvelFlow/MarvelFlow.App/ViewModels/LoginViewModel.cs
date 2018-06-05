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
    public class LoginViewModel : ViewModelBase
    {
        public RelayCommand ReturnBackCommand { get; private set; } // history command
        public RelayCommand ConnexionCommand { get; private set; }
        public RelayCommand InscriptionCommand { get; private set; }

        // Connexion
        private string _LoginCon;
        public string LoginCon
        {
            get
            {
                return _LoginCon;
            }
            set
            {
                if (_LoginCon == value)
                    return;
                _LoginCon = value;
                RaisePropertyChanged(() => LoginCon);
            }
        }

        private string _PasswordCon;
        public string PasswordCon
        {
            get
            {
                return _PasswordCon;
            }
            set
            {
                if (_PasswordCon == value)
                    return;
                _PasswordCon = value;
                RaisePropertyChanged(() => PasswordCon);
            }
        }

        // Inscription
        private string _LoginIns;
        public string LoginIns
        {
            get
            {
                return _LoginIns;
            }
            set
            {
                if (_LoginIns == value)
                    return;
                _LoginIns = value;
                RaisePropertyChanged(() => LoginIns);
            }
        }

        private string _PasswordIns;
        public string PasswordIns
        {
            get
            {
                return _PasswordIns;
            }
            set
            {
                if (_PasswordIns == value)
                    return;
                _PasswordIns = value;
                RaisePropertyChanged(() => PasswordIns);
            }
        }

        private string _MailIns;
        public string MailIns
        {
            get
            {
                return _MailIns;
            }
            set
            {
                if (_MailIns == value)
                    return;
                _MailIns = value;
                RaisePropertyChanged(() => MailIns);
            }
        }

        private string _NomIns;
        public string NomIns
        {
            get
            {
                return _NomIns;
            }
            set
            {
                if (_NomIns == value)
                    return;
                _NomIns = value;
                RaisePropertyChanged(() => NomIns);
            }
        }

        private string _PrenomIns;
        public string PrenomIns
        {
            get
            {
                return _PrenomIns;
            }
            set
            {
                if (_PrenomIns == value)
                    return;
                _PrenomIns = value;
                RaisePropertyChanged(() => PrenomIns);
            }
        }



        public LoginViewModel()
        {
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);
            this.ConnexionCommand = new RelayCommand(this.Inscription, CanDisplayMessage);
            this.InscriptionCommand= new RelayCommand(this.Connexion, CanDisplayMessage);
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

        public void Inscription()
        {
        }

        public void Connexion()
        {
        }
    }
}
