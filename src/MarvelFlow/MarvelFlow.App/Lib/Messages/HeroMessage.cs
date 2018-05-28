using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.Lib.Messages
{
    public class HeroMessage : MessageBase
    {
        public string Status { get; private set; }

        public HeroMessage(string status) : base()
        {
            Status = status;
        }

        public HeroMessage(object sender, string status) : base(sender)
        {
            Status = status;
        }

        public HeroMessage(object sender, object target, string status): base(sender, target)
        {
            Status = status;
        }
        
    }
}
