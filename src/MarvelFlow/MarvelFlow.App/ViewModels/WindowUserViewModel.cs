using GalaSoft.MvvmLight;
using MarvelFlow.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MarvelFlow.App.ViewModels
{
    public class WindowUserViewModel : ViewModelBase
    {
        public Window WindowUser { get; set; }

        public WindowUserViewModel()
        {
            WindowUser = new WindowUser();
            WindowUser.Show();
        }
    }
}
