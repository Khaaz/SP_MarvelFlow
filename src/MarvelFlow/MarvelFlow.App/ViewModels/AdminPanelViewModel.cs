using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarvelFlow.App.Lib.Messages;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using MarvelFlow.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace MarvelFlow.App.ViewModels
{
    public class AdminPanelViewModel : ViewModelBase
    {
        public RelayCommand ReturnBackCommand { get; private set; } // history command 
        public RelayCommand SaveCommand { get; private set; } // history command 

        public List<string> MediaList { get; set; } // List to show in combobox

        private ViewModelBase _CurrentVM;
        public ViewModelBase CurrentVM
        {
            get
            {
                return _CurrentVM;
            }
            set
            {
                if (_CurrentVM == value)
                    return;
                _CurrentVM = value;
                RaisePropertyChanged(() => CurrentVM);
            }
        }

        private string _SelectedMedia; // Selected Item in Media Combobox
        public string SelectedMedia
        {
            get
            {
                return _SelectedMedia;
            }
            set
            {
                if (_SelectedMedia == value)
                    return;
                _SelectedMedia = value;
                RaisePropertyChanged(() => SelectedMedia);
                if (SelectedMedia.Equals("Movie"))
                {
                    CurrentVM = ServiceLocator.Current.GetInstance<EditFilmViewModel>();
                }
                else if (SelectedMedia.Equals("Hero"))
                {
                    CurrentVM = ServiceLocator.Current.GetInstance<EditHeroViewModel>();
                }
            }
        }


        public AdminPanelViewModel()
        {
            this.ReturnBackCommand = new RelayCommand(this.SendReturnBack, CanDisplayMessage);
            this.SaveCommand = new RelayCommand(this.SaveData, CanDisplayMessage);

            MediaList = new List<string> { "Movie", "Hero" };

            CurrentVM = ServiceLocator.Current.GetInstance<EditHeroViewModel>();

        }

        // Commands methods

        public bool CanDisplayMessage()
        {
            return true;
        }

        public void SendReturnBack()
        {
            MessengerInstance.Send<HistoryMessage>(new HistoryMessage(this, "Navigate Back History"));
        }

        /// <summary>
        /// Save all datas (Current List etc in json file)
        /// handl eexceptionand print info box
        /// </summary>
        public void SaveData()
        {
            try
            {
                ServiceLocator.Current.GetInstance<ManagerJson>().SaveDatas();
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, "Path error:", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (JsonException e)
            {
                MessageBox.Show(e.Message, "Corrupted Json:", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "No Data:", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MessageBox.Show("Save Success", "SAVE:", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
