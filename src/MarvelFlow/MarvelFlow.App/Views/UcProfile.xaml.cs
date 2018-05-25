using MarvelFlow.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarvelFlow.App.Views
{
    /// <summary>
    /// Logique d'interaction pour UcProfile.xaml
    /// </summary>
    public partial class UcProfile : UserControl
    {
        public UcProfile()
        {
            InitializeComponent();
            this.DataContext = new ProfileViewModel();
        }
    }
}
