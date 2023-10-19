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

        public List<InventoryModel.InventorySlot> InventorySlotsList;

        public string direction = "right";

        public List<PictureBox> slotsList = new List<PictureBox>();

        public InventoryModel Player;

        public FightingMinigame(List<InventoryModel.InventorySlot> inventorySlots, InventoryModel players)
        {
            InitializeComponent();
            Player = players;

            playerX = player.Location.X;
            playerY = player.Location.Y;

            InventorySlotsList = inventorySlots;

            slotsList.Add(slot1);
            slotsList.Add(slot2);
            slotsList.Add(slot3);
            slotsList.Add(slot4);
            slotsList.Add(slot5);
            slotsList.Add(slot6);

            Console.WriteLine("Test");

            InventoryModel.InventorySlot gun1 = inventorySlots[1];

            InventoryModel.RefreshInventory(slotsList, inventorySlots);
            player.BackgroundImage = Player.Skin;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ShootBullet(string direction, int Speed)
        {
            Bullet bullet = new Bullet();
            bullet.facingDirection = direction;
            bullet.speed = Speed;
            bullet.bulletLeft = player.Left + player.Width / 2;
            bullet.bulletTop = player.Top + player.Height / 2;
            bullet.sideGap = sideGap;
            bullet.topGap = topGap;
            bullet.gameBoxPicture = gameBoxPicture;
            bullet.MakeBullet(this);
            bullet.bullet.BringToFront();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            if (foward && gameBoxPicture.Location.Y < playerY)
            {
                playerY = playerY - 2;
                player.Location = new Point(player.Location.X, playerY);

            }
            if (left && gameBoxPicture.Location.X < playerX)
            {
                playerX = playerX - 2;
                player.Location = new Point(playerX, player.Location.Y);

            }
            if (back && playerY + player.Height - topGap.Height < gameBoxPicture.Height)
            {
                playerY = playerY + 2;
                player.Location = new Point(player.Location.X, playerY);

            }
            if (right && playerX + player.Width - sideGap.Width < gameBoxPicture.Width)
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
                direction = "up";
            }
            if (e.KeyValue == (char)Keys.A)
            {
                left = true;
                direction = "left";
            }
            if (e.KeyValue == (char)Keys.S)
            {
                back = true;
                direction = "down";
            }
            if (e.KeyValue == (char)Keys.D)
            {
                right = true;
                direction = "right";
            }

            if (foward == true && left == true)
            {
                direction = "WA";
            }
            if (foward == true && right == true)
            {
                direction = "WD";
            }
            if (back == true && left == true)
            {
                direction = "SA";
            }
            if (back == true && right == true)
            {
                direction = "SD";
            }


            if (e.KeyValue == (char)Keys.Space)
            {
                ShootBullet(direction, InventorySlotsList[0].gun.Speed);

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
            if (e.KeyValue == (char)Keys.Space)
            {
                if (foward)
                {
                    direction = "up";
                }
                if (left)
                {
                    direction = "left";
                }
                if (back)
                {
                    direction = "down";
                }
                if (right)
                {
                    direction = "right";
                }
            }
        }
    }
}