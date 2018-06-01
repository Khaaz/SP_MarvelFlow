using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public class User
    {

        public string UserID { get; private set; }

        public string Mail { get; private set; }

        public string Login { get; private set; }

        public string Pswd { get; private set; }

        public DateTime DateInsc { get; private set; }

        public string Nom { get; private set; }

        public string Prenom { get; private set; }

        public bool IsAdmin { get; private set; }


        public User(string userID, string mail, string login, string pswd, DateTime dateInsc, string nom, string prenom, bool isAdmin)
        {
            this.UserID = userID;
            this.Mail = mail;
            this.Login = login;
            this.Pswd = pswd;
            this.DateInsc = dateInsc;
            this.Nom = nom;
            this.Prenom = prenom;
            this.IsAdmin = isAdmin;
        }
    }
}
