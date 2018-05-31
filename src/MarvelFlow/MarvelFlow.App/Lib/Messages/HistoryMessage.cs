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
    public class HistoryMessage : MessageBase
    {
        public string Status { get; private set; }

        public ISearchableMovie Movie { get; private set; }

        public Hero Hero { get; private set; }


        public HistoryMessage(string status) : base()
        {
            Hero = null;
            Movie = null;
            Status = status;
        }

        public HistoryMessage(Hero hero, string status) : base()
        {
            Hero = hero;
            Movie = null;
            Status = status;
        }

        public HistoryMessage(ISearchableMovie movie, string status) : base()
        {
            Hero = null;
            Movie = movie;
            Status = status;
        }

        //

        public HistoryMessage(object sender, string status) : base(sender)
        {
            Hero = null;
            Movie = null;
            Status = status;
        }

        public HistoryMessage(object sender, Hero hero, string status) : base(sender)
        {
            Hero = hero;
            Movie = null;
            Status = status;
        }

        public HistoryMessage(object sender, ISearchableMovie movie, string status) : base(sender)
        {
            Hero = null;
            Movie = movie;
            Status = status;
        }

        //

        public HistoryMessage(object sender, object target, string status): base(sender, target)
        {
            Hero = null;
            Movie = null;
            Status = status;
        }

        public HistoryMessage(object sender, object target, Hero hero, string status) : base(sender, target)
        {
            Hero = hero;
            Movie = null;
            Status = status;
        }

        public HistoryMessage(object sender, object target, ISearchableMovie movie, string status) : base(sender, target)
        {
            Hero = null;
            Movie = movie;
            Status = status;
        }

    }
}
