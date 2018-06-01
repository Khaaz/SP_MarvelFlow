using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarvelFlow.App.Views
{
    public partial class WindowsBandeAnnonce : Form
    {
        
        public WindowsBandeAnnonce(string PathBA)
        {
            InitializeComponent();
            TeaserMediaPlayer.URL = PathBA;

            TeaserMediaPlayer.Ctlcontrols.play();
        }
    }
}
