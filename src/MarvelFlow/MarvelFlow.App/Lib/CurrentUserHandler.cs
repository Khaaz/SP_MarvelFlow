using MarvelFlow.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.Lib
{
    public class CurrentUserHandler
    {
        private User CurrentUser { get; set; }


        public CurrentUserHandler()
        {
            CurrentUser = null;
        }


        public User GetUser()
        {
            return CurrentUser;
        }

        public void EditUser(User u)
        {
            CurrentUser = u;
        }
    }
}
