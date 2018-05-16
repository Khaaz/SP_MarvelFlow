using MarvelFlow.App.controls;
using MarvelFlow.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            List < Hero > heros = new List<Hero>();
            heros.Add(new Hero("IM", "Iron Man", "source/image", "description", Team.Avengers));
            heros.Add(new Hero("SM", "Spider Man", "image/spiderman", "description", Team.Avengers));

            Console.WriteLine("HELLO WORLD");
            foreach(Hero h in heros)
            {
                Console.WriteLine($"\n {h}");
            }

            List <Hero> HeroList = new List<Hero>();


            string filePath = "C:\\Users\\AM\\Documents\\GIT\\marvelflow\\src\\MarvelFlow\\MarvelFlow.App\\DBLocal\\Hero.json";

            
            string res = "";

            using (StreamReader r = new StreamReader(filePath))
            {
                var jSon = r.ReadToEnd();
                Console.WriteLine(jSon);
                var jObj = JObject.Parse(jSon);
                Console.WriteLine(jObj);
            };
            
          

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
