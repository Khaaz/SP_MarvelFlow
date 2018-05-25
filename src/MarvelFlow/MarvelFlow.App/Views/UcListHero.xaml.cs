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
using MarvelFlow.Classes;

namespace MarvelFlow.App.Views
{
    /// <summary>
    /// Logique d'interaction pour UcListHero.xaml
    /// </summary>
    public partial class UcListHero : UserControl
    {
        public UcListHero()
        {
            InitializeComponent();
            List<Hero> test = new List<Hero>();
            Hero Im = new Hero("IM", "IronMan", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/ironMan.png", "voici ironMan", Team.Avengers);
            Hero Sm = new Hero("SM", "SpiderMan", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/spiderMan.png", "voici SpiderMan", Team.Avengers);
            Hero Ds = new Hero("Ds", "Doctor Strange", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/doctorStrange.png", "voici Doctor Strange", Team.Avengers);
            Hero Hu = new Hero("HK", "Hulk", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/hulk.jpg", "voici Hulk le géant vert", Team.Avengers);
            test.Add(Im);
            test.Add(Sm);
            test.Add(Ds);
            test.Add(Hu);

            ListViewHero.ItemsSource = test;
            //this.DataContext = new ListHeroViewModel();
        }
    }
}
