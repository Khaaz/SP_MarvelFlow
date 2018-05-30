using GalaSoft.MvvmLight.Messaging;
using MarvelFlow.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.Lib.Messages
{
    public class MovieMessage : MessageBase
    {
        public string Status { get; private set; }

        public Movie Movie { get; private set; }

        public MovieMessage(Movie movie, string status) : base()
        {
            Movie = movie;
            Status = status;
        }

        public MovieMessage(object sender, Movie movie, string status) : base(sender)
        {
            Movie = movie;
            Status = status;
        }

        public MovieMessage(Movie movie, object sender, object target, string status): base(sender, target)
        {
            Movie = movie;
            Status = status;
        }
        
    }
}
