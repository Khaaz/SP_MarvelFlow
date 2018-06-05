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

        public RelayCommand FilmReset { get; private set; }

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

        public Array EnumUniverse { get; set; }


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
            this.FilmReset = new RelayCommand(this.ResetDisplayMovie,CanDisplayMessage);
            this.DeleteMovieCommand = new RelayCommand(this.DeleteMovie,CanDeleteMovie);
            this.ValidateCommand = new RelayCommand(this.Validate,CanValidate);

            ListMoviesView = new ObservableCollection<Film>();
            List<ISearchableMovie> ListTemp = ServiceLocator.Current.GetInstance<ManagerJson>().GetMovies();
            foreach (ISearchableMovie m in ListTemp)
            {
                if (m.GetType() == typeof(Film))
                {
                    ListMoviesView.Add((Film)m);
                }

            }

            EnumUniverse = Enum.GetValues(typeof(Universe));

        }

        public bool CanDisplayMessage()
        {
            return true;
        }

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

        public bool CanDeleteMovie()
        {
            if (CurrentMovie == null)
            {
                return false;
            }
            return true;
        }
        
        public void DeleteMovie()
        {
            // SUPPRIMER DANS MANAGER JSON LE FILM EN QUESTION
            ResetDisplayMovie();
        }

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

        public void Validate()
        {
            if (IsChampValid())
            {
                if(CurrentMovie == null)
                {
                    //CREER NOUVEAU FILM
                }
                else
                {
                   //EDIT FILM
                }
            }
        }

      

        public bool CanValidate()
        {
            return !CheckChampEmptyOrWhiteSpace();
        }
    }
}
