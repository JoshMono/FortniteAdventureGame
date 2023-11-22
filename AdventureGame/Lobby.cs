using AdventureGame.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Net.NetworkInformation;
using System.Numerics;

namespace AdventureGame
{
    public partial class Lobby : Form
    {
        Settings settings;
        Locker locker;
        public InventoryModel Player;

        public Lobby(InventoryModel player)
        {
            InitializeComponent();

            // Sets the zBucks label to the players ammount of zBucks
            zBucksLabel.Text = player.ZBucks.ToString();


            Player = player;

            // Sets the avatar to the players avatar
            skinAvaterIMG.BackgroundImage = Player.Skin;

            // Creates a new pannel with the settings form inside of it
            settings = new Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            settings.FormBorderStyle = FormBorderStyle.None;
            this.settingsPannel.Controls.Add(settings);

            // Creates a new pannel with the locker form inside of it
            locker = new Locker(Player) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            locker.FormBorderStyle = FormBorderStyle.None;
            this.lockerPannel.Controls.Add(locker);

            // Sets the wins label to the players amount of wins
            winsLabel.Text = player.Wins.ToString();


        }

        bool settingsOn = false;

        // On click either makes the settings pannel visible or not
        private void settingsBTN_Click(object sender, EventArgs e)
        {

            if (settingsOn == false)
            {

                settings.Show();
                settingsPannel.Show();
                settingsOn = true;
            }
            else
            {
                settingsPannel.Hide();
                settingsOn = false;
            }

        }

        // Loads the form Map and closes this form
        private void playBTN_Click(object sender, EventArgs e)
        {
            Map map = new Map(Player);
            this.Close();
            map.Show();
        }

        // On click shows the locker pannel, makes the buttons a new colour and hides the avatar
        private void lockerBTN_Click(object sender, EventArgs e)
        {
            locker.Show();
            lockerPannel.Show();
            lobbyBTN.BackColor = Color.Transparent;
            lockerBTN.BackColor = Color.FromArgb(255, 255, 128);
            BackgroundImage = (Image)Properties.Resources.download__2_;
            skinAvaterIMG.Hide();
        }

        // On click shows the lobby pannel, makes the buttons a new colour and hides the avatar
        private void lobbyBTN_Click(object sender, EventArgs e)
        {
            lockerPannel.Hide();
            lobbyBTN.BackColor = Color.FromArgb(255, 255, 128);
            lockerBTN.BackColor = Color.Transparent;
            BackgroundImage = (Image)Properties.Resources.lobbyBG;

            skinAvaterIMG.BackgroundImage = Player.Skin;
            skinAvaterIMG.Show();
        }

        /*
                private void shopBTN_Click(object sender, EventArgs e)
                {
                    itemShopPannel.Hide();
                    lobbyBTN.BackColor = Color.FromArgb(255, 255, 128);
                    shopBTN.BackColor = Color.Transparent;
                    BackgroundImage = (Image)Properties.Resources.lobbyBG;
                }*/

    }
}
