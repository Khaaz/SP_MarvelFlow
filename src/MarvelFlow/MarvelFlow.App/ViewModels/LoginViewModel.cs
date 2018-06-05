using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.DataBase;
using MarvelFlow.Service;
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
                ConnexionCommand.RaiseCanExecuteChanged();
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
                ConnexionCommand.RaiseCanExecuteChanged();
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
                InscriptionCommand.RaiseCanExecuteChanged();
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
                InscriptionCommand.RaiseCanExecuteChanged();
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
                InscriptionCommand.RaiseCanExecuteChanged();
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
                InscriptionCommand.RaiseCanExecuteChanged();
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
                InscriptionCommand.RaiseCanExecuteChanged();
            }
        }



        public LoginViewModel()
        {
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);

            this.ConnexionCommand = new RelayCommand(this.Connexion, CanConnexion);
            this.InscriptionCommand= new RelayCommand(this.Inscription, CanInscription);
        }


        // Commands methods

        public bool CanDisplayMessage()
        {
            return true;
        }

        /// <summary>
        /// Check that all fields for connexion are already fieled with values (not null/not empty/ not whitespace)
        /// </summary>
        /// <returns>bool - can run connexion checkers or not</returns>
        public bool CanConnexion()
        {
            if (string.IsNullOrEmpty(LoginCon) || string.IsNullOrWhiteSpace(LoginCon))
            {
                return false;
            }
            if (string.IsNullOrEmpty(PasswordCon) || string.IsNullOrWhiteSpace(PasswordCon))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check that all fields for inscription are already fieled with values (not null/not empty/ not whitespace)
        /// </summary>
        /// <returns>bool - can run inscription checkers or not</returns>
        public bool CanInscription()
        {
            if (string.IsNullOrEmpty(LoginIns) || string.IsNullOrWhiteSpace(LoginIns))
            {
                return false;
            }
            if (string.IsNullOrEmpty(PasswordIns) || string.IsNullOrWhiteSpace(PasswordIns))
            {
                return false;
            }
            if (string.IsNullOrEmpty(MailIns) || string.IsNullOrWhiteSpace(MailIns))
            {
                return false;
            }
            if (string.IsNullOrEmpty(NomIns) || string.IsNullOrWhiteSpace(NomIns))
            {
                return false;
            }
            if (string.IsNullOrEmpty(PrenomIns) || string.IsNullOrWhiteSpace(PrenomIns))
            {
                return false;
            }

            return true;
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }

        public void Inscription()
        {
            if (Util.ContainsQuotes(LoginIns))
            {
                this.LoginIns = "Not Valid";
                return;
            }

            if (Util.ContainsQuotes(PasswordIns))
            {
                this.PasswordIns = "Not Valid";
                return;
            }

            if (Util.ContainsQuotes(MailIns) || !AppUtils.ValidMail(MailIns)) {
                this.MailIns = "Not Valid";
                return;
            }

            if (Util.ContainsQuotes(NomIns) || !AppUtils.ValidName(NomIns))
            {
                this.NomIns = "Not Valid";
                return;
            }

            if (Util.ContainsQuotes(PrenomIns) || !AppUtils.ValidName(PrenomIns))
            {
                this.PrenomIns = "Not Valid";
                return;
            }

            // Db check login existant
            bool updated = new SelectDB().CheckLogin(LoginIns);
            if (updated)
            {
                this.LoginIns = "Already taken";
                return;
            }

            string hero = PickRandomHero();
            User u = new User(LoginIns, PasswordIns, DateTime.Now.ToString("dd/MM/yyyy"), MailIns, NomIns, PrenomIns, false, hero);
            // DB call inscription
            new UpdateDB().Inscription(LoginIns, PasswordIns, DateTime.Now, MailIns, NomIns, PrenomIns, false, hero);

            ServiceLocator.Current.GetInstance<CurrentUserHandler>().EditUser(u);

            MessengerInstance.Send<ProfileMessage>(new ProfileMessage(this, "Navigate Profile Message"));
        }

        public void Connexion()
        {
            if (Util.ContainsQuotes(LoginCon))
            {
                this.LoginCon = "Not Valid";
                return;
            }

            if (Util.ContainsQuotes(PasswordCon))
            {
                this.PasswordCon = "Not Valid";
                return;
            }

            //DB check for existing match
            bool existing = new SelectDB().CheckConnexion(LoginCon, PasswordCon);
            if (!existing)
            {
                this.PasswordCon = "Invalid Password Or Login";
                return;
            }
            // get from DB , create User Update User
            User u = new SelectDB().SelectUser(LoginCon);

            ServiceLocator.Current.GetInstance<CurrentUserHandler>().EditUser(u);
            MessengerInstance.Send<ProfileMessage>(new ProfileMessage(this, "Navigate Profile Message"));
        }

        public string PickRandomHero()
        {
            List<Hero> listHeros = ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes();

            Random rnd = new Random();
            int indexH = rnd.Next(0, listHeros.Count);

            return listHeros[indexH].Id;
        }
    }
}
