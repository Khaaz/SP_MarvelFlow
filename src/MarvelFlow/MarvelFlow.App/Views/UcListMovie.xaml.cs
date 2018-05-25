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
    /// Logique d'interaction pour UcListMovie.xaml
    /// </summary>
    public partial class UcListMovie : UserControl
    {
        public UcListMovie()
        {
            InitializeComponent();


            this.DataContext = new ListMovieViewModel();

            List<Film> lfilm = new List<Film>();


            Film f1 = new Film("AV3", "Avengers Infinity Wars", "pack://application:,,,/MarvelFlow.App;component/ImagesMovie/Avengers3.jpg", "film Avengers 3 avec plein de gens dedans" ,"Frères Russo" ,"25/04/18", Universe.MCU);
            Film f2 = new Film("AM", "AntMan", "pack://application:,,,/MarvelFlow.App;component/ImagesMovie/Antman.jpg" ,"film homme fourmi", "Payton Reed" ,"14/07/15", Universe.MCU);
            Film f3 = new Film ("IM1" ,"IronMan" ,"pack://application:,,,/MarvelFlow.App;component/ImagesMovie/IronMan.jpg", "film homme de fer" ,"Jon Favreau" ,"30/04/08", Universe.MCU);

            lfilm.Add(f1);
            lfilm.Add(f2);
            lfilm.Add(f3);

            ListViewHero.ItemsSource = lfilm;

        }
    }
}
