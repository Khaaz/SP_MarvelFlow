using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.App.Lib.Messages
{
    public class ProfileMessage : MessageBase
    {
        public string Status { get; private set; }

        public ProfileMessage(string status) : base()
        {
            Status = status;
        }

        public ProfileMessage(object sender, string status) : base(sender)
        {
            Status = status;
        }

        public ProfileMessage(object sender, object target, string status): base(sender, target)
        {
            Status = status;
        }
        
    }
}
