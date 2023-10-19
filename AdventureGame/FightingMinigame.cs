using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        int xVisionR;
        int xVisionL;
        int xVisionU;
        int xVisionD;

        int yVisionR;
        int yVisionL;
        int yVisionU;
        int yVisionD;

        bool foward = false;
        bool back = false;
        bool left = false;
        bool right = false;

        public List<InventoryModel.InventorySlot> InventorySlotsList;

        public string direction = "right";

        public List<PictureBox> slotsList = new List<PictureBox>();

        public InventoryModel Player;



        Wall[,] verticalWall = new Wall[7, 5];
        Wall[,] horizontalWall = new Wall[8, 4];


        public List<Control> allWalls = new List<Control>();


        public FightingMinigame(List<InventoryModel.InventorySlot> inventorySlots, InventoryModel players)
        {
            InitializeComponent();
            Player = players;

            playerX = player.Location.X;
            playerY = player.Location.Y;

            xVisionR = visionBoxR.Location.X;
            xVisionL = visionBoxL.Location.X;
            xVisionU = visionBoxU.Location.X;
            xVisionD = visionBoxD.Location.X;

            yVisionR = visionBoxR.Location.Y;
            yVisionL = visionBoxL.Location.Y;
            yVisionU = visionBoxU.Location.Y;
            yVisionD = visionBoxD.Location.Y;

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


            Wall posR0x0 = new Wall(100, "Wood", false, R0x0);
            Wall posR1x0 = new Wall(100, "Wood", false, R1x0);
            Wall posR2x0 = new Wall(100, "Wood", false, R2x0);
            Wall posR3x0 = new Wall(100, "Wood", false, R3x0);
            Wall posR4x0 = new Wall(100, "Wood", false, R4x0);
            Wall posR5x0 = new Wall(100, "Wood", false, R5x0);
            Wall posR6x0 = new Wall(100, "Wood", false, R6x0);

            Wall posR0x1 = new Wall(100, "Wood", false, R0x1);
            Wall posR1x1 = new Wall(100, "Wood", false, R1x1);
            Wall posR2x1 = new Wall(100, "Wood", false, R2x1);
            Wall posR3x1 = new Wall(100, "Wood", false, R3x1);
            Wall posR4x1 = new Wall(100, "Wood", false, R4x1);
            Wall posR5x1 = new Wall(100, "Wood", false, R5x1);
            Wall posR6x1 = new Wall(100, "Wood", false, R6x1);

            Wall posR0x2 = new Wall(100, "Wood", false, R0x2);
            Wall posR1x2 = new Wall(100, "Wood", false, R1x2);
            Wall posR2x2 = new Wall(100, "Wood", false, R2x2);
            Wall posR3x2 = new Wall(100, "Wood", false, R3x2);
            Wall posR4x2 = new Wall(100, "Wood", false, R4x2);
            Wall posR5x2 = new Wall(100, "Wood", false, R5x2);
            Wall posR6x2 = new Wall(100, "Wood", false, R6x2);

            Wall posR0x3 = new Wall(100, "Wood", false, R0x3);
            Wall posR1x3 = new Wall(100, "Wood", false, R1x3);
            Wall posR2x3 = new Wall(100, "Wood", false, R2x3);
            Wall posR3x3 = new Wall(100, "Wood", false, R3x3);
            Wall posR4x3 = new Wall(100, "Wood", false, R4x3);
            Wall posR5x3 = new Wall(100, "Wood", false, R5x3);
            Wall posR6x3 = new Wall(100, "Wood", false, R6x3);

            Wall posR0x4 = new Wall(100, "Wood", false, R0x4);
            Wall posR1x4 = new Wall(100, "Wood", false, R1x4);
            Wall posR2x4 = new Wall(100, "Wood", false, R2x4);
            Wall posR3x4 = new Wall(100, "Wood", false, R3x4);
            Wall posR4x4 = new Wall(100, "Wood", false, R4x4);
            Wall posR5x4 = new Wall(100, "Wood", false, R5x4);
            Wall posR6x4 = new Wall(100, "Wood", false, R6x4);

            Wall posL0x0 = new Wall(100, "Wood", false, L0x0);
            Wall posL1x0 = new Wall(100, "Wood", false, L1x0);
            Wall posL2x0 = new Wall(100, "Wood", false, L2x0);
            Wall posL3x0 = new Wall(100, "Wood", false, L3x0);
            Wall posL4x0 = new Wall(100, "Wood", false, L4x0);
            Wall posL5x0 = new Wall(100, "Wood", false, L5x0);
            Wall posL6x0 = new Wall(100, "Wood", false, L6x0);
            Wall posL7x0 = new Wall(100, "Wood", false, L7x0);

            Wall posL0x1 = new Wall(100, "Wood", false, L0x1);
            Wall posL1x1 = new Wall(100, "Wood", false, L1x1);
            Wall posL2x1 = new Wall(100, "Wood", false, L2x1);
            Wall posL3x1 = new Wall(100, "Wood", false, L3x1);
            Wall posL4x1 = new Wall(100, "Wood", false, L4x1);
            Wall posL5x1 = new Wall(100, "Wood", false, L5x1);
            Wall posL6x1 = new Wall(100, "Wood", false, L6x1);
            Wall posL7x1 = new Wall(100, "Wood", false, L7x1);

            Wall posL0x2 = new Wall(100, "Wood", false, L0x2);
            Wall posL1x2 = new Wall(100, "Wood", false, L1x2);
            Wall posL2x2 = new Wall(100, "Wood", false, L2x2);
            Wall posL3x2 = new Wall(100, "Wood", false, L3x2);
            Wall posL4x2 = new Wall(100, "Wood", false, L4x2);
            Wall posL5x2 = new Wall(100, "Wood", false, L5x2);
            Wall posL6x2 = new Wall(100, "Wood", false, L6x2);
            Wall posL7x2 = new Wall(100, "Wood", false, L7x2);

            Wall posL0x3 = new Wall(100, "Wood", false, L0x3);
            Wall posL1x3 = new Wall(100, "Wood", false, L1x3);
            Wall posL2x3 = new Wall(100, "Wood", false, L2x3);
            Wall posL3x3 = new Wall(100, "Wood", false, L3x3);
            Wall posL4x3 = new Wall(100, "Wood", false, L4x3);
            Wall posL5x3 = new Wall(100, "Wood", false, L5x3);
            Wall posL6x3 = new Wall(100, "Wood", false, L6x3);
            Wall posL7x3 = new Wall(100, "Wood", false, L7x3);

            verticalWall[0, 0] = posR0x0;
            verticalWall[1, 0] = posR1x0;
            verticalWall[2, 0] = posR2x0;
            verticalWall[3, 0] = posR3x0;
            verticalWall[4, 0] = posR4x0;
            verticalWall[5, 0] = posR5x0;
            verticalWall[6, 0] = posR6x0;

            verticalWall[0, 1] = posR0x1;
            verticalWall[1, 1] = posR1x1;
            verticalWall[2, 1] = posR2x1;
            verticalWall[3, 1] = posR3x1;
            verticalWall[4, 1] = posR4x1;
            verticalWall[5, 1] = posR5x1;
            verticalWall[6, 1] = posR6x1;

            verticalWall[0, 2] = posR0x2;
            verticalWall[1, 2] = posR1x2;
            verticalWall[2, 2] = posR2x2;
            verticalWall[3, 2] = posR3x2;
            verticalWall[4, 2] = posR4x2;
            verticalWall[5, 2] = posR5x2;
            verticalWall[6, 2] = posR6x2;

            verticalWall[0, 3] = posR0x3;
            verticalWall[1, 3] = posR1x3;
            verticalWall[2, 3] = posR2x3;
            verticalWall[3, 3] = posR3x3;
            verticalWall[4, 3] = posR4x3;
            verticalWall[5, 3] = posR5x3;
            verticalWall[6, 3] = posR6x3;

            verticalWall[0, 4] = posR0x4;
            verticalWall[1, 4] = posR1x4;
            verticalWall[2, 4] = posR2x4;
            verticalWall[3, 4] = posR3x4;
            verticalWall[4, 4] = posR4x4;
            verticalWall[5, 4] = posR5x4;
            verticalWall[6, 4] = posR6x4;
            //
            horizontalWall[0, 0] = posL0x0;
            horizontalWall[1, 0] = posL1x0;
            horizontalWall[2, 0] = posL2x0;
            horizontalWall[3, 0] = posL3x0;
            horizontalWall[4, 0] = posL4x0;
            horizontalWall[5, 0] = posL5x0;
            horizontalWall[6, 0] = posL6x0;
            horizontalWall[7, 0] = posL7x0;

            horizontalWall[0, 1] = posL0x1;
            horizontalWall[1, 1] = posL1x1;
            horizontalWall[2, 1] = posL2x1;
            horizontalWall[3, 1] = posL3x1;
            horizontalWall[4, 1] = posL4x1;
            horizontalWall[5, 1] = posL5x1;
            horizontalWall[6, 1] = posL6x1;
            horizontalWall[7, 1] = posL7x1;

            horizontalWall[0, 2] = posL0x2;
            horizontalWall[1, 2] = posL1x2;
            horizontalWall[2, 2] = posL2x2;
            horizontalWall[3, 2] = posL3x2;
            horizontalWall[4, 2] = posL4x2;
            horizontalWall[5, 2] = posL5x2;
            horizontalWall[6, 2] = posL6x2;
            horizontalWall[7, 2] = posL7x2;

            horizontalWall[0, 3] = posL0x3;
            horizontalWall[1, 3] = posL1x3;
            horizontalWall[2, 3] = posL2x3;
            horizontalWall[3, 3] = posL3x3;
            horizontalWall[4, 3] = posL4x3;
            horizontalWall[5, 3] = posL5x3;
            horizontalWall[6, 3] = posL6x3;
            horizontalWall[7, 3] = posL7x3;
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

                yVisionD = yVisionD - 2;
                yVisionU = yVisionU - 2;
                yVisionL = yVisionL - 2;
                yVisionR = yVisionR - 2;

                visionBoxD.Location = new Point(visionBoxD.Location.X, yVisionD);
                visionBoxU.Location = new Point(visionBoxU.Location.X, yVisionU);
                visionBoxL.Location = new Point(visionBoxL.Location.X, yVisionL);
                visionBoxR.Location = new Point(visionBoxR.Location.X, yVisionR);

                player.Location = new Point(player.Location.X, playerY);

            }
            if (left && gameBoxPicture.Location.X < playerX)
            {
                playerX = playerX - 2;

                xVisionD = xVisionD - 2;
                xVisionU = xVisionU - 2;
                xVisionL = xVisionL - 2;
                xVisionR = xVisionR - 2;

                visionBoxD.Location = new Point(xVisionD, visionBoxD.Location.Y);
                visionBoxU.Location = new Point(xVisionU, visionBoxU.Location.Y);
                visionBoxL.Location = new Point(xVisionL, visionBoxL.Location.Y);
                visionBoxR.Location = new Point(xVisionR, visionBoxR.Location.Y);

                player.Location = new Point(playerX, player.Location.Y);

            }
            if (back && playerY + player.Height - topGap.Height < gameBoxPicture.Height)
            {
                playerY = playerY + 2;

                yVisionD = yVisionD + 2;
                yVisionU = yVisionU + 2;
                yVisionL = yVisionL + 2;
                yVisionR = yVisionR + 2;

                visionBoxD.Location = new Point(visionBoxD.Location.X, yVisionD);
                visionBoxU.Location = new Point(visionBoxU.Location.X, yVisionU);
                visionBoxL.Location = new Point(visionBoxL.Location.X, yVisionL);
                visionBoxR.Location = new Point(visionBoxR.Location.X, yVisionR);

                player.Location = new Point(player.Location.X, playerY);

            }
            if (right && playerX + player.Width - sideGap.Width < gameBoxPicture.Width)
            {
                playerX = playerX + 2;

                xVisionD = xVisionD + 2;
                xVisionU = xVisionU + 2;
                xVisionL = xVisionL + 2;
                xVisionR = xVisionR + 2;

                visionBoxD.Location = new Point(xVisionD, visionBoxD.Location.Y);
                visionBoxU.Location = new Point(xVisionU, visionBoxU.Location.Y);
                visionBoxL.Location = new Point(xVisionL, visionBoxL.Location.Y);
                visionBoxR.Location = new Point(xVisionR, visionBoxR.Location.Y);

                player.Location = new Point(playerX, player.Location.Y);
            }

            for (int k = 0; k < verticalWall.GetLength(0); k++)
            {
                for (int c = 0; c < verticalWall.GetLength(1); c++)
                {

                    if (verticalWall[k, c].Alive == false)
                    {

                        if (direction == "right" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "WD" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "SD" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom)
                        {
                            verticalWall[k, c].formWall.BackColor = Color.Blue;
                            verticalWall[k, c].formWall.Visible = true;
                        }
                        else if (direction == "left" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "WA" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "SA" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom)
                        {
                            verticalWall[k, c].formWall.BackColor = Color.Blue;
                            verticalWall[k, c].formWall.Visible = true;
                        }
                        else if (direction == "up" && visionBoxU.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WA" && visionBoxU.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WD" && visionBoxU.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxU.Bottom)
                        {
                            verticalWall[k, c].formWall.BackColor = Color.Blue;
                            verticalWall[k, c].formWall.Visible = true;
                        }
                        else if (direction == "down" && visionBoxD.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SA" && visionBoxD.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SD" && visionBoxD.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxD.Bottom)
                        {
                            verticalWall[k, c].formWall.BackColor = Color.Blue;
                            verticalWall[k, c].formWall.Visible = true;
                        }
                        else
                        {
                            verticalWall[k, c].formWall.Visible = false;
                        }
                    }
                }
            }

            for (int k = 0; k < horizontalWall.GetLength(0); k++)
            {
                for (int c = 0; c < horizontalWall.GetLength(1); c++)
                {

                    if (horizontalWall[k, c].Alive == false)
                    {

                        if (direction == "right" && visionBoxR.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "WD" && visionBoxR.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "SD" && visionBoxR.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxR.Bottom)
                        {
                            horizontalWall[k, c].formWall.BackColor = Color.Blue;
                            horizontalWall[k, c].formWall.Visible = true;
                        }
                        else if (direction == "left" && visionBoxL.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "WA" && visionBoxL.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "SA" && visionBoxL.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxL.Bottom)
                        {
                            horizontalWall[k, c].formWall.BackColor = Color.Blue;
                            horizontalWall[k, c].formWall.Visible = true;
                        }
                        else if (direction == "up" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WA" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WD" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom)
                        {
                            horizontalWall[k, c].formWall.BackColor = Color.Blue;
                            horizontalWall[k, c].formWall.Visible = true;
                        }
                        else if (direction == "down" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SA" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SD" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom)
                        {
                            horizontalWall[k, c].formWall.BackColor = Color.Blue;
                            horizontalWall[k, c].formWall.Visible = true;
                        }
                        else
                        {
                            horizontalWall[k, c].formWall.Visible = false;
                        }
                    }
                }
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

            if (e.KeyValue == (char)Keys.Q)
            {


                for (int k = 0; k < verticalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < verticalWall.GetLength(1); c++)
                    {
                        if (verticalWall[k, c].Alive == false)
                        {

                            if (direction == "right" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "WD" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "SD" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom)
                            {
                                verticalWall[k, c].formWall.BackColor = Color.Olive;
                                verticalWall[k, c].formWall.Visible = true;
                                verticalWall[k, c].Alive = true;
                            }
                            else if (direction == "left" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "WA" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "SA" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom)
                            {
                                verticalWall[k, c].formWall.BackColor = Color.Olive;
                                verticalWall[k, c].formWall.Visible = true;
                                verticalWall[k, c].Alive = true;
                            }
                            else if (direction == "up" && visionBoxU.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WA" && visionBoxU.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WD" && visionBoxU.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxU.Bottom)
                            {
                                verticalWall[k, c].formWall.BackColor = Color.Olive;
                                verticalWall[k, c].formWall.Visible = true;
                                verticalWall[k, c].Alive = true;
                            }
                            else if (direction == "down" && visionBoxD.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SA" && visionBoxD.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SD" && visionBoxD.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxD.Bottom)
                            {
                                verticalWall[k, c].formWall.BackColor = Color.Olive;
                                verticalWall[k, c].formWall.Visible = true;
                                verticalWall[k, c].Alive = true;
                            }
                        }
                    }


                }
                for (int k = 0; k < horizontalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < horizontalWall.GetLength(1); c++)
                    {

                        if (horizontalWall[k, c].Alive == false)
                        {

                            if (direction == "right" && visionBoxR.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "WD" && visionBoxR.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "SD" && visionBoxR.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxR.Bottom)
                            {
                                horizontalWall[k, c].formWall.BackColor = Color.Olive;
                                horizontalWall[k, c].formWall.Visible = true;
                                horizontalWall[k, c].Alive = true;
                            }
                            else if (direction == "left" && visionBoxL.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "WA" && visionBoxL.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "SA" && visionBoxL.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxL.Bottom)
                            {
                                horizontalWall[k, c].formWall.BackColor = Color.Olive;
                                horizontalWall[k, c].formWall.Visible = true;
                                horizontalWall[k, c].Alive = true;
                            }
                            else if (direction == "up" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WA" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WD" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom)
                            {
                                horizontalWall[k, c].formWall.BackColor = Color.Olive;
                                horizontalWall[k, c].formWall.Visible = true;
                                horizontalWall[k, c].Alive = true;
                            }
                            else if (direction == "down" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SA" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SD" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom)
                            {
                                horizontalWall[k, c].formWall.BackColor = Color.Olive;
                                horizontalWall[k, c].formWall.Visible = true;
                                horizontalWall[k, c].Alive = true;
                            }
                            else
                            {
                                horizontalWall[k, c].formWall.Visible = false;
                            }
                        }
                    }
                }

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