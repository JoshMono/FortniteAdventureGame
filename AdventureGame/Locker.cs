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
        }

        // Sets the players skin to the deafult skin on click
        private void deafaultSkinBTN_Click(object sender, EventArgs e)
        {
            Player.Skin = (Image)Properties.Resources.defaultSkin;
        }

        // Sets the players skin to the skull trooper skin on click
        private void skullTrooperBTN_Click(object sender, EventArgs e)
        {
            Player.Skin = (Image)Properties.Resources.skullTrooper;
        }
    }
}
