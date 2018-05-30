using GalaSoft.MvvmLight.Messaging;
using MarvelFlow.Classes;
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
        public Hero Hero { get; private set; }

        public HeroMessage(Hero hero, string status) : base()
        {
            Hero = hero;
            Status = status;
        }

        public HeroMessage(object sender, Hero hero, string status) : base(sender)
        {
            Hero = hero;
            Status = status;
        }

        public HeroMessage(object sender, object target, Hero hero, string status): base(sender, target)
        {
            Hero = hero;
            Status = status;
        }
        
    }
}
