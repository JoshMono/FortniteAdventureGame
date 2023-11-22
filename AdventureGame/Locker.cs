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
    public partial class Locker : Form
    {

        public InventoryModel Player;


        public Locker(InventoryModel player)
        {
            Player = player;
            InitializeComponent();

            // Sets background colour to blue too see active skin
            if (Player.Skin.PixelFormat == Properties.Resources.defaultSkin.PixelFormat)
            {
                defaultSkinBTN.BackColor = Color.CadetBlue;
            }
            else if (Player.Skin == Properties.Resources.skullTrooper)
            {
                skullTrooperBTN.BackColor = Color.CadetBlue;
            }


            if (Player.Wins >= 5)
            {
                skullTrooperBTN.Image = null;
                skullTrooperBTN.Text = null;
            }
        }

        // Sets the players skin to the deafult skin on click
        private void deafaultSkinBTN_Click(object sender, EventArgs e)
        {
            Player.Skin = Properties.Resources.defaultSkin;
            defaultSkinBTN.BackColor = Color.CadetBlue;
            skullTrooperBTN.BackColor = Color.Gray;
        }

        // Sets the players skin to the skull trooper skin on click
        private void skullTrooperBTN_Click(object sender, EventArgs e)
        {
            if (Player.Wins >= 5)
            {
                Player.Skin = Properties.Resources.skullTrooper;
                skullTrooperBTN.BackColor = Color.CadetBlue;
                defaultSkinBTN.BackColor = Color.Gray;
            }
        }
    }
}
