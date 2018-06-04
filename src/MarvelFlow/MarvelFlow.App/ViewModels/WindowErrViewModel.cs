using GalaSoft.MvvmLight;
using MarvelFlow.App.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MarvelFlow.App.ViewModels
{
    public class WindowErrViewModel : ViewModelBase
    {
        public string TypeError { get; set; }

        public string TextError { get; set; }

        public WindowErrViewModel(Exception error)
        {
            Window WindowErr = new WindowErr();
            

            if (error.GetType() == typeof(FileNotFoundException))
            {
                this.TypeError = "Path error";
            }
            else if (error.GetType() == typeof(JsonException))
            {
                this.TypeError = "Corrupted Json file";
            }
            else
            {
                this.TypeError = "Corrupted Json, No valid data found";
            }
            this.TextError = error.ToString();

            WindowErr.Show();
        }
    }
}
