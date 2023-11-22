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
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame
{
    public partial class Settings : Form
    {
        // DllImports winmm.dll
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        // DllImports winmm.dll
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);


        public bool musicChecked;

        // Sets soundplayer to null
        private SoundPlayer Player = null;
        public Settings()
        {

            InitializeComponent();
            Player = new SoundPlayer(Properties.Resources.LobbyMusic);

            musicOn_CheckedChanged(null, null);

            // By the default set the volume to 0
            uint CurrVol = 0;

            // CurrVol gets assigned the volume
            waveOutGetVolume(IntPtr.Zero, out CurrVol);

            // Calculate the volume
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);

            // Get the volume on a scale of 1 to 10 to fit the trackbar
            musicVolumeSlider.Value = CalcVol / (ushort.MaxValue / 10);

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

        private void musicVolumeSlider_Scroll(object sender, EventArgs e)
        {
            // Calculate the volume thats being set
            int NewVolume = ((ushort.MaxValue / 10) * musicVolumeSlider.Value);

            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));

            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }
    }
}
