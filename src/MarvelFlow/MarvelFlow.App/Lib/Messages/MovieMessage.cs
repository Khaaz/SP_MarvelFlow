using GalaSoft.MvvmLight.Messaging;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
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

        public ISearchableMovie Movie { get; private set; }

        public MovieMessage(ISearchableMovie movie, string status) : base()
        {
            Movie = movie;
            Status = status;
        }

        public MovieMessage(object sender, ISearchableMovie movie, string status) : base(sender)
        {
            Movie = movie;
            Status = status;
        }

        public MovieMessage(ISearchableMovie movie, object sender, object target, string status): base(sender, target)
        {
            Movie = movie;
            Status = status;
        }
        
    }
}
