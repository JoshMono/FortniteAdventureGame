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
        int zBucks;
        Settings settings;
        Locker locker;
        public InventoryModel Player;

        public Lobby(InventoryModel player)
        {
            InitializeComponent();
            zBucks = player.ZBucks;
            zBucksLabel.Text = Convert.ToString(zBucks);

            Player = player;
            skinAvaterIMG.BackgroundImage = Player.Skin;


            settings = new Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            settings.FormBorderStyle = FormBorderStyle.None;
            this.settingsPannel.Controls.Add(settings);

            locker = new Locker(Player) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            locker.FormBorderStyle = FormBorderStyle.None;
            this.lockerPannel.Controls.Add(locker);


        }
        bool settingsOn = false;

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zBucks = zBucks + 100;
            zBucksLabel.Text = Convert.ToString(zBucks);
        }

        private void playBTN_Click(object sender, EventArgs e)
        {
            Map map = new Map(Player);
            this.Hide();
            map.Show();
        }

        private void lockerBTN_Click(object sender, EventArgs e)
        {
            locker.Show();
            lockerPannel.Show();
            lobbyBTN.BackColor = Color.Transparent;
            lockerBTN.BackColor = Color.FromArgb(255, 255, 128);
            BackgroundImage = (Image)Properties.Resources.download__2_;
            skinAvaterIMG.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lobbyBTN_Click(object sender, EventArgs e)
        {
            lockerPannel.Hide();
            lobbyBTN.BackColor = Color.FromArgb(255, 255, 128);
            lockerBTN.BackColor = Color.Transparent;
            BackgroundImage = (Image)Properties.Resources.lobbyBG;

            skinAvaterIMG.BackgroundImage = Player.Skin;
            skinAvaterIMG.Show();

        }

        private void Lobby_Load(object sender, EventArgs e)
        {

        }

        private void itemShopPannel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void shopBTN_Click(object sender, EventArgs e)
        {
            itemShopPannel.Hide();
            lobbyBTN.BackColor = Color.FromArgb(255, 255, 128);
            shopBTN.BackColor = Color.Transparent;
            BackgroundImage = (Image)Properties.Resources.lobbyBG;
        }
    }
}
