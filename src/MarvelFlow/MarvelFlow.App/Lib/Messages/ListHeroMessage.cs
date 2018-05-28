using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.Lib.Messages
{
    public class ListHeroMessage : MessageBase
    {
        public string Status { get; private set; }

        public ListHeroMessage(string status) : base()
        {
            Status = status;
        }

        public ListHeroMessage(object sender, string status) : base(sender)
        {
            Status = status;
        }

        public ListHeroMessage(object sender, object target, string status): base(sender, target)
        {
            Status = status;
        }
        
    }
}
