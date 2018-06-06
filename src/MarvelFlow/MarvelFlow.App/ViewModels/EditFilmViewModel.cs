using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib;
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
    public class EditFilmViewModel : ViewModelBase
    {

        // COMMANDES //
        public RelayCommand<Film> DisplayMovieCommand { get; private set; }

        public RelayCommand FilmResetCommand { get; private set; }

        public RelayCommand DeleteMovieCommand { get; private set; }

        public RelayCommand ValidateCommand { get; private set; }

        private Film _CurrentMovie;
        public Film CurrentMovie
        {
            get
            {
                return _CurrentMovie;
            }
            set
            {
                if (_CurrentMovie == value)
                    return;
                _CurrentMovie = value;
                RaisePropertyChanged(() => CurrentMovie);
                ValidateCommand.RaiseCanExecuteChanged();
                DeleteMovieCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<Film> _ListMoviesView; // List to show in the View
        public ObservableCollection<Film> ListMoviesView
        {
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

        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id == value)
                    return;
                _Id = value;
                RaisePropertyChanged(() => Id);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (_Title == value)
                    return;
                _Title = value;
                RaisePropertyChanged(() => Title);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Affiche;
        public string Affiche
        {
            get
            {
                return _Affiche;
            }
            set
            {
                if (_Affiche == value)
                    return;
                _Affiche = value;
                RaisePropertyChanged(() => Affiche);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (_Description == value)
                    return;
                _Description = value;
                RaisePropertyChanged(() => Description);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Realisateur;
        public string Realisateur
        {
            get
            {
                return _Realisateur;
            }
            set
            {
                if (_Realisateur == value)
                    return;
                _Realisateur = value;
                RaisePropertyChanged(() => Realisateur);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Date;
        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                if (_Date == value)
                    return;
                _Date = value;
                RaisePropertyChanged(() => Date);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        public Array EnumUniverse { get; set; }

        private Universe _SelectedUniverse;
        public Universe SelectedUniverse
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
            }
        }

        private string _BA;
        public string BA
        {
            get
            {
                return _BA;
            }
            set
            {
                if (_BA == value)
                    return;
                _BA = value;
                RaisePropertyChanged(() => BA);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _ListHeroDisplay;
        public string ListHeroDisplay
        {
            get
            {
                return _ListHeroDisplay;
            }
            set
            {
                if (_ListHeroDisplay == value)
                    return;
                _ListHeroDisplay = value;
                RaisePropertyChanged(() => ListHeroDisplay);
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }

        public EditFilmViewModel()
        {
            CurrentMovie = null;
            this.DisplayMovieCommand = new RelayCommand<Film>(this.DisplayMovie, m => CanDisplayMessage());
            this.FilmResetCommand = new RelayCommand(this.ResetDisplayMovie,CanDisplayMessage);
            this.DeleteMovieCommand = new RelayCommand(this.DeleteMovie,CanDeleteMovie);
            this.ValidateCommand = new RelayCommand(this.Validate,CanValidate);

            ListMoviesView = new ObservableCollection<Film>();
            List<ISearchableMovie> ListTemp = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies().OrderBy(m => m.GetTitle()).ToList();
            foreach (ISearchableMovie m in ListTemp)
            {
                if (m.GetType() == typeof(Film))
                {
                    ListMoviesView.Add((Film)m);
                }
            }

            EnumUniverse = Enum.GetValues(typeof(Universe));
        }

        // Commands Methods

        public bool CanDisplayMessage()
        {
            return true;
        }

        /// <summary>
        /// Update the view with value of the selected element in List View
        /// </summary>
        /// <param name="movie"></param>
        public void DisplayMovie(Film movie)
        {
            CurrentMovie = movie;
            Id = movie.Id;
            Title = movie.Title;
            Affiche = Util.FormatPathMovie(movie.Affiche);
            Description = movie.Desc;
            Realisateur = movie.Real;
            Date = movie.Date.ToString("dd/MM/yyyy"); ;
            SelectedUniverse = movie.Universe;
            BA = Util.FormatPathTrailer(movie.BA);
            ListHeroDisplay = AppUtils.ConvertList(movie.GetListHeros());
        }

        /// <summary>
        /// Reset view - all fields to null
        /// Allow editing a new Film
        /// </summary>
        public void ResetDisplayMovie()
        {
            CurrentMovie = null;
            string empty = string.Empty;
            Id = empty;
            Title = empty;
            Affiche = empty;
            Description = empty;
            Realisateur = empty;
            Date = empty;
            SelectedUniverse = Universe.MCU;
            BA = empty;
            ListHeroDisplay = empty;
        }

        /// <summary>
        /// Can delete a Film if it is one existing
        /// (CurrentHero binded)
        /// </summary>
        /// <returns></returns>
        public bool CanDeleteMovie()
        {
            if (CurrentMovie == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Delete the Film in general List
        /// Refresh View and update List
        /// </summary>
        public void DeleteMovie()
        {
            // SUPPRIMER DANS MANAGER JSON LE FILM EN QUESTION
            bool val = ServiceLocator.Current.GetInstance<ManagerJson>().RemoveMovie(CurrentMovie);
            if (val)
            {
                this.ResetDisplayMovie();
                this.RefreshList();
            }
        }

        public bool CanValidate()
        {
            return !CheckChampEmptyOrWhiteSpace();
        }

        /// <summary>
        /// Check if all fields respect validity (no null, no empty, no whitespace)
        /// Can Execute Validate Command
        /// </summary>
        /// <returns></returns>
        public bool CheckChampEmptyOrWhiteSpace()
        {
            if (string.IsNullOrEmpty(Id) || string.IsNullOrWhiteSpace(Id))
            {
                return true;
            }
            if (string.IsNullOrEmpty(Title) || string.IsNullOrWhiteSpace(Title))
            {
                return true;
            }
            if (string.IsNullOrEmpty(Affiche) || string.IsNullOrWhiteSpace(Affiche))
            {
                return true;
            }
            if (string.IsNullOrEmpty(Description) || string.IsNullOrWhiteSpace(Description))
            {
                return true;
            }
            if (string.IsNullOrEmpty(Realisateur) || string.IsNullOrWhiteSpace(Realisateur))
            {
                return true;
            }
            if (string.IsNullOrEmpty(Date) || string.IsNullOrWhiteSpace(Date))
            {
                return true;
            }
            if (string.IsNullOrEmpty(BA) || string.IsNullOrWhiteSpace(BA))
            {
                return true;
            }
            if (string.IsNullOrEmpty(ListHeroDisplay) || string.IsNullOrWhiteSpace(ListHeroDisplay))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check Validity of all fields
        /// </summary>
        /// <returns></returns>
        public bool IsChampValid()
        {
            string notV = "Not Valid";

            if (Util.ContainsQuotes(Id) || !AppUtils.IsIdMovieValid(Id))
            {
                Id = notV;
                return false;
            }
            if (Util.ContainsQuotes(Title))
            {
                Title = notV;
                return false;
            }
            if (Util.ContainsQuotes(Affiche) || !Util.IsPathMovie(Affiche))
            {
                Affiche = notV;
                return false;
            }
            if (Util.ContainsQuotes(Description))
            {
                Description= notV;
                return false;
            }
            if (Util.ContainsQuotes(Realisateur))
            {
                Realisateur= notV;
                return false;
            }
            if (!Util.IsValidDate(Date))
            {
                Date = notV;
                return false;
            }
            if (!Util.IsPathTeaser(BA))
            {
                BA = notV;
                return false;
            }
            if (Util.ContainsQuotes(ListHeroDisplay) || !AppUtils.IsDisplayListValid(ListHeroDisplay))
            {
                ListHeroDisplay = notV;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Add Or Update a Film
        /// IF Respect validity
        /// </summary>
        public void Validate()
        {
            if (IsChampValid())
            {
                if (CurrentMovie == null)
                {
                    this.CreateMovie();
                }
                else
                {
                    int res = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies().FindIndex(m => m.GetId() == Id);

                    if (res == -1 || ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies()[res] == CurrentMovie)
                    {
                        this.EditMovie();
                    }
                    else
                    {
                        this.Id = "Already Used";
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Create a Movie
        /// </summary>
        public void CreateMovie()
        {
            if (ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies().Any(m => m.GetId() == Id))
            {
                this.Id = "Already Used";
                return;
            }

            //CREER NOUVEAU HERO
            List<string> listHero = AppUtils.ConvertStringToList(ListHeroDisplay);

            foreach (string h in listHero)
            {
                if (!ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().Any(hero => hero.Id == h))
                {
                    this.ListHeroDisplay = "Invalid ID";
                    return;
                }
            }

            ISearchableMovie movie = new Film(Id, Title, Affiche, Description, Realisateur, Date, SelectedUniverse, BA, listHero);

            bool val = ServiceLocator.Current.GetInstance<ManagerJson>().AddMovie(movie);
            if (val)
            {
                this.ResetDisplayMovie();
                this.RefreshList();
            }
        }

        /// <summary>
        /// Edit a film
        /// Update by giving old and new film
        /// </summary>
        public void EditMovie()
        {
            //EDIT HERO
            List<string> listHero = AppUtils.ConvertStringToList(ListHeroDisplay);

            foreach (string h in listHero)
            {
                if (!ServiceLocator.Current.GetInstance<ManagerJson>().GetHeroes().Any(hero => hero.Id == h))
                {
                    ListHeroDisplay = "Invalid ID";
                    return;
                }
            }

            ISearchableMovie movie = new Film(Id, Title, Affiche, Description, Realisateur, Date, SelectedUniverse, BA, listHero);

            bool val = ServiceLocator.Current.GetInstance<ManagerJson>().UpdateMovie(movie, CurrentMovie);
            if (val)
            {
                this.ResetDisplayMovie();
                this.RefreshList();
            }
            return;
        }

        /// <summary>
        /// Refresh Current List View
        /// </summary>
        public void RefreshList()
        {
            List<ISearchableMovie> temp = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies().OrderBy(m => m.GetTitle()).ToList();
            this.ListMoviesView.Clear();
            foreach (ISearchableMovie m in temp)
            {
                this.ListMoviesView.Add((Film)m);
            }
        }
    }
}
