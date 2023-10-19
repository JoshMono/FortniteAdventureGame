using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AdventureGame.InventoryModel;

namespace AdventureGame
{
    public partial class FightingMinigame : Form
    {
        int playerX;
        int playerY;

        bool foward = false;
        bool back = false;
        bool left = false;
        bool right = false;

        public List<PictureBox> slotsList = new List<PictureBox>();

        public FightingMinigame(List<InventoryModel.InventorySlot> inventorySlots)
        {
            InitializeComponent();
            playerX = player.Location.X;
            playerY = player.Location.Y;

            slotsList.Add(slot1);
            slotsList.Add(slot2);
            slotsList.Add(slot3);
            slotsList.Add(slot4);
            slotsList.Add(slot5);
            slotsList.Add(slot6);

            Console.WriteLine("Test");

            InventoryModel.InventorySlot gun1 = inventorySlots[1];
            Console.WriteLine(gun1.gun);

            InventoryModel.RefreshInventory(slotsList, inventorySlots);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            if (foward && gameBoxPicture.Location.Y < playerY)
            {
                playerY = playerY - 2;
                player.Location = new Point(player.Location.X, playerY);
                Console.WriteLine("a");
            }
            if (left && gameBoxPicture.Location.X < playerX)
            {
                playerX = playerX - 2;
                player.Location = new Point(playerX, player.Location.Y);
                Console.WriteLine("a");
            }
            if (back && playerY < gameBoxPicture.Height - 50)
            {
                playerY = playerY + 2;
                player.Location = new Point(player.Location.X, playerY);
            }
            if (right && playerX < gameBoxPicture.Width + 150)
            {
                playerX = playerX + 2;
                player.Location = new Point(playerX, player.Location.Y);
            }

        }

        private void FightingMinigame_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*Console.WriteLine("sadsa");
            if (e)
            {
                player.Location = new Point(playerX + 10, player.Location.Y);
                Console.WriteLine("Test");
            }*/
        }

        private void FightingMinigame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.W)
            {
                foward = true;
            }
            if (e.KeyValue == (char)Keys.A)
            {
                left = true;
            }
            if (e.KeyValue == (char)Keys.S)
            {
                back = true;
            }
            if (e.KeyValue == (char)Keys.D)
            {
                right = true;
            }


        }

        private void FightingMinigame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.W)
            {
                foward = false;
            }
            if (e.KeyValue == (char)Keys.A)
            {
                left = false;
            }
            if (e.KeyValue == (char)Keys.S)
            {
                back = false;
            }
            if (e.KeyValue == (char)Keys.D)
            {
                right = false;
            }
        }
    }
}