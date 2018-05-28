using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class ListHeroViewModel : ViewModelBase
    {
        public RelayCommand NavigateHeroCommand { get; private set; }
        public RelayCommand ReturnBackCommand { get; private set; }

        public List<Hero> ListHeros { get; set; }

        public ListHeroViewModel()
        {
            this.NavigateHeroCommand = new RelayCommand(this.SendNavigateHero, CanDisplayMessage);
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);

            ListHeros = new List<Hero>();

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

            ListHeros.Add(Im);
            ListHeros.Add(Sm);
            ListHeros.Add(Ds);
            ListHeros.Add(Hu);
            ListHeros.Add(Vi);
            ListHeros.Add(Vi1);
            ListHeros.Add(Vi2);
            ListHeros.Add(Vi3);
            ListHeros.Add(Vi4);
            ListHeros.Add(Vi5);
            ListHeros.Add(Vi6);
        }

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendNavigateHero()
        {
            MessengerInstance.Send<HeroMessage>(new HeroMessage(this, "Navigate Hero Message"));
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }
    }
}
