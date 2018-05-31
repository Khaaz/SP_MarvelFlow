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
        
        public List<ISearchableMovie> ListMovies { get; set; }

        private ObservableCollection<ISearchableMovie> _ListMoviesView;
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

        private string _SearchBar;
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
                SortName(SearchBar);
            }
        }

        public ListMovieViewModel()
        {
            // Command
            this.NavigateMovieCommand = new RelayCommand<Movie>(this.SendNavigateMovie, CanDisplayMessage());
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);

            this.SortByNameCommand = new RelayCommand(this.SortByName, CanDisplayMessage);
            this.SortByDateCommand = new RelayCommand(this.SortByDate, CanDisplayMessage);
        }

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendNavigateMovie(Movie movie)
        {
            MessengerInstance.Send<MovieMessage>(new MovieMessage(this, movie, "Navigate Movie Message"));
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }

        public void SortName(string input)
        {
            List<ISearchableMovie> tempList = this.ListMovies.Where(m => m.GetTitle().ToLower().StartsWith(input.ToLower())).ToList();
            this.ListMoviesView.Clear();
            this.ListMoviesView = new ObservableCollection<ISearchableMovie>(tempList);
        }

        public void SortByName()
        {
            this.ListMoviesView = new ObservableCollection<ISearchableMovie>(this.ListMovies.OrderBy(h => h.GetTitle()).ToList() );
        }

        public void SortByDate()
        {
            this.ListMoviesView = new ObservableCollection<ISearchableMovie>(this.ListMovies.OrderBy(h => h.GetDate()).ToList());
        }
    }
}
