using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.Lib.Messages
{
    public class HomeMessage : MessageBase
    {
        public string Status { get; private set; }

        public HomeMessage(object sender, string status) : base(sender)
        {
            Status = status;
        }

        public HomeMessage(object sender, object target, string status): base(sender, target)
        {
            Status = status;
        }
        
    }
}
