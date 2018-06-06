using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using MarvelFlow.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.ViewModels
{
    public class ListMovieViewModel : ViewModelBase
    {
        public RelayCommand<Movie> NavigateMovieCommand { get; private set; }
        public RelayCommand ReturnBackCommand { get; private set; }

        public RelayCommand SortByNameCommand { get; private set; }
        public RelayCommand SortByDateCommand { get; private set; }


        private ObservableCollection<ISearchableMovie> _ListMoviesView; // List to show in the View
        public ObservableCollection<ISearchableMovie> ListMoviesView {
            get
            {
                return _ListMoviesView;
            }
            set
            {
                if (_ListMoviesView == value)
                    return;
                _ListMoviesView = value;
                RaisePropertyChanged(() => ListMoviesView);
            }
        }

        private string _SearchBar; // Textbox content - trigger filtering the view list
        public string SearchBar
        {
            get
            {
                return _SearchBar;
            }
            set
            {
                if (_SearchBar == value)
                    return;
                _SearchBar = value;
                RaisePropertyChanged(() => SearchBar);
                FindByString(SearchBar);
            }
        }

        public List<string> EnumUniverse { get; set; } // Enum to show in combobox

        private string _SelectedUniverse; // Selected Item in Universe Combobox
        public string SelectedUniverse
        {
            get
            {
                return _SelectedUniverse;
            }
            set
            {
                if (_SelectedUniverse == value)
                    return;
                _SelectedUniverse = value;
                RaisePropertyChanged(() => SelectedUniverse);
                FindEnumUniverse(SelectedUniverse);
            }
        }

        public ListMovieViewModel()
        {
            // Command
            this.NavigateMovieCommand = new RelayCommand<Movie>(this.SendNavigateMovie, m => CanDisplayMessage());
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);

            this.SortByNameCommand = new RelayCommand(this.SortByName, CanDisplayMessage);
            this.SortByDateCommand = new RelayCommand(this.SortByDate, CanDisplayMessage);

            // Init ObservableCollection when creatingthe instance
            this.ListMoviesView = new ObservableCollection<ISearchableMovie>(ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies().OrderBy(m => m.GetTitle()).ToList()); // Sorted by title

            // Init misc
            Array arrUniverse = Enum.GetValues(typeof(Universe));
            EnumUniverse = new List<string>();
            EnumUniverse.Add("Select a Universe");
            foreach(Universe u in arrUniverse)
            {
                EnumUniverse.Add(u.ToString());
            }
            
        }

        /// <summary>
        /// Method associated with search bar
        /// Filter View List with the input string to match
        /// </summary>
        /// <param name="input"></param>
        public void FindByString(string input)
        {
            List<ISearchableMovie> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies()
                .Where(m => m.GetTitle().ToLower().StartsWith(input.ToLower()))
                .OrderBy(m => m.GetTitle())
                .ToList();
            this.ListMoviesView.Clear();
            foreach (ISearchableMovie m in tempList)
            {
                this.ListMoviesView.Add(m);
            }
        }

        /// <summary>
        /// Method associated with combo box
        /// Filter View List with the input Universe to match
        /// </summary>
        /// <param name="u"></param>
        public void FindEnumUniverse(string u)
        {
            if(u.Equals("Select a Universe")) 
            {
                List<ISearchableMovie> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies().OrderBy(m => m.GetTitle()).ToList();
                this.ListMoviesView.Clear();
                foreach (ISearchableMovie m in tempList)
                {
                    this.ListMoviesView.Add(m);
                }
            }
            else
            {
                List<ISearchableMovie> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies()
                    .Where(m => m.GetUniverse().ToString() == u)
                    .OrderBy(m => m.GetTitle())
                    .ToList();
                this.ListMoviesView.Clear();
                foreach (ISearchableMovie m in tempList)
                {
                    this.ListMoviesView.Add(m);
                }
            }
            
        }

        /// <summary>
        /// Sort View List by Name (alphabetical order)
        /// </summary>
        public void SortByName()
        {
            List<ISearchableMovie> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies().OrderBy(m => m.GetTitle()).ToList();
            this.ListMoviesView.Clear();
            foreach (ISearchableMovie m in tempList)
            {
                this.ListMoviesView.Add(m);
            }
        }

        /// <summary>
        /// Sort View List by Date (older to newer)
        /// </summary>
        public void SortByDate()
        {
            List<ISearchableMovie> tempList = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies().OrderBy(m => m.GetDate()).ToList();
            this.ListMoviesView.Clear();
            foreach (ISearchableMovie m in tempList)
            {
                this.ListMoviesView.Add(m);
            }
        }

        //Commands methods
        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendNavigateMovie(ISearchableMovie movie)
        {
            MessengerInstance.Send<MovieMessage>(new MovieMessage(this, movie, "Navigate Movie Message"));
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }
    }
}
