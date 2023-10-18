using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame
{
    public partial class Settings : Form
    {
        public bool musicChecked;
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();

        public Settings()
        {
            InitializeComponent();
            musicChecked = musicOn.Checked;

            music.SoundLocation = "C:\\Users\\joshm_xprw9gv\\Documents\\IST\\Programming\\Visual Studio Projects\\AdventureGame\\AdventureGame\\Resources\\LobbyMusic.wav";

            if (musicOn.Checked == true)
            {
                music.Play();
            }
        }

        private void musicOn_CheckedChanged(object sender, EventArgs e)
        {
            if (musicOn.Checked == true)
            {
                music.Play();
            }
            else
            {
                music.Stop();
            }
        }
    }
}
