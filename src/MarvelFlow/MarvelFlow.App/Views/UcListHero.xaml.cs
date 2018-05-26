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
            Hero Hu = new Hero("HK", "Hulk", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/hulk.png", "voici Hulk le géant vert", Team.Avengers);
            Hero Vi = new Hero("VN", "Vision", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi1 = new Hero("VN", "Vision", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi2 = new Hero("VN", "Vision", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi3 = new Hero("VN", "Vision", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi4 = new Hero("VN", "Vision", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi5 = new Hero("VN", "Vision", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);
            Hero Vi6 = new Hero("VN", "Vision", "pack://application:,,,/MarvelFlow.App;component/ImagesHero/vision.png", "Vision, provenant de Jarvis", Team.Avengers);

            test.Add(Im);
            test.Add(Sm);
            test.Add(Ds);
            test.Add(Hu);
            test.Add(Vi);
            test.Add(Vi1);
            test.Add(Vi2);
            test.Add(Vi3);
            test.Add(Vi4);
            test.Add(Vi5);
            test.Add(Vi6);

            ListViewHero.ItemsSource = test;

           
            //this.DataContext = new ListHeroViewModel();
        }


    }
}
