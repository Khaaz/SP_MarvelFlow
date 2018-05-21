using MarvelFlow.App.Views;
using MarvelFlow.Classes;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
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

namespace MarvelFlow.App
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public FrameworkElement CurrentControl { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            CurrentControl = new UcHome();


            List<Hero> heros = new List<Hero>();
            heros.Add(new Hero("IM", "Iron Man", "source/image", "description", Team.Avengers));
            heros.Add(new Hero("SM", "Spider Man", "image/spiderman", "description", Team.Avengers));


            string filePath = ConfigurationManager.AppSettings["jsonPathHero"];

            ManagerJson.InitJsonDB();

            //List<Hero> HeroList = JsonConvert.DeserializeObject<List<Hero>>(File.ReadAllText(filePath));

            //Console.WriteLine("HELLO WORLD");

            //Hero IM = HeroList.SingleOrDefault(h => h.HId == "IM");

            //IEnumerable<Hero> SM = HeroList.Where(h => h.HId == "SM");

            //Console.WriteLine(IM.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;

        /* private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentControl = new TextBlock { Text = "string" };
            PropertyChanged.Invoke(this,new PropertyChangedEventArgs("CurrentControl"));
        }
        */
    }
}
