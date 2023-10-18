using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame
{
    public partial class Settings : Form
    {
        public bool musicChecked;

        private SoundPlayer Player = null;
        public Settings()
        {
            InitializeComponent();
            Player = new SoundPlayer(Properties.Resources.LobbyMusic);
            musicOn_CheckedChanged(null, null);
            
        }


        private void musicOn_CheckedChanged(object sender, EventArgs e)
        {
            if (musicOn.Checked == true)
            {
                Player.Play();

            }
            else
            {
                Player.Stop();
            }
        }
    }
}
