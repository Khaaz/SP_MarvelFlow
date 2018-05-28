using GalaSoft.MvvmLight.Messaging;
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

        public MovieMessage(string status) : base()
        {
            Status = status;
        }

        public MovieMessage(object sender, string status) : base(sender)
        {
            Status = status;
        }

        public MovieMessage(object sender, object target, string status): base(sender, target)
        {
            Status = status;
        }
        
    }
}
