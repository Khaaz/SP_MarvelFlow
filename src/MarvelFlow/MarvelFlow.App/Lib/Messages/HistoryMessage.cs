using GalaSoft.MvvmLight.Messaging;
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

        public HistoryMessage(string status) : base()
        {
            Status = status;
        }

        public HistoryMessage(object sender, string status) : base(sender)
        {
            Status = status;
        }

        public HistoryMessage(object sender, object target, string status): base(sender, target)
        {
            Status = status;
        }
        
    }
}
