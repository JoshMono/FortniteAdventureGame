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

        private void deafaultSkinBTN_Click(object sender, EventArgs e)
        {
            Player.Skin = (Image)Properties.Resources.defaultSkin;
        }

        private void skullTrooperBTN_Click(object sender, EventArgs e)
        {
            Player.Skin = (Image)Properties.Resources.skullTrooper;
        }
    }
}
