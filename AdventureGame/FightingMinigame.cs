using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Reflection;
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

        bool hitWallL = false;
        bool hitWallR = false;
        bool hitWallU = false;
        bool hitWallD = false;

        public List<InventoryModel.InventorySlot> InventorySlotsList;

        public string direction = "right";

        public List<PictureBox> slotsList = new List<PictureBox>();

        public InventoryModel Player;



        Wall[,] verticalWall = new Wall[8, 6];
        Wall[,] horizontalWall = new Wall[9, 5];


        public List<Control> allWalls = new List<Control>();

        public int Health;
        public int Shield;
        public int Materials;
        public int Ammo;
        public int Magazine;

        public Player currentPlayer;

        public FightingMinigame(List<InventoryModel.InventorySlot> inventorySlots, InventoryModel players, int PlayersLanding)
        {
            InitializeComponent();
            Player = players;

            currentPlayer = Player.Player;
            currentPlayer.Alive = true;
            currentPlayer.PlayerBox = player;
            currentPlayer.isClient = true;
            currentPlayer.healthBar = healthBar;
            currentPlayer.shieldBar = shieldBar;

            Materials = currentPlayer.Materials;

            materialLabel.Text = Materials.ToString();
            ammoLabel.Text = Ammo.ToString();

            shieldBar.ForeColor = Color.Blue;
            healthBar.ForeColor = Color.Blue;

            shieldBar.SetState(3);

            shieldBar.Value = currentPlayer.Shield;
            healthBar.Value = currentPlayer.Health;

            playerX = player.Location.X;
            playerY = player.Location.Y;
            slot1.BackColor = Color.SkyBlue;

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

            Ammo = players.Player.Ammo;

            if (InventorySlotsList[activeSlot].gun.Magazine > Ammo)
            {
                int x = InventorySlotsList[activeSlot].gun.Magazine - Ammo;
                Magazine = Ammo;
                Ammo = 0;
            }
            else
            {
                Ammo = Ammo - InventorySlotsList[activeSlot].gun.Magazine;
                Magazine = inventorySlots[activeSlot].gun.Magazine;
            }



            ammoLabel.Text = $"{Magazine}/{Ammo}";

            MakeEnemy(PlayersLanding);

            allTargets.Add(currentPlayer);

            InventoryModel.RefreshInventory(slotsList, inventorySlots);
            player.BackgroundImage = Player.Skin;


            Wall posR0x0 = new Wall(100, "Wood", false, R0x0);
            Wall posR1x0 = new Wall(100, "Wood", false, R1x0);
            Wall posR2x0 = new Wall(100, "Wood", false, R2x0);
            Wall posR3x0 = new Wall(100, "Wood", false, R3x0);
            Wall posR4x0 = new Wall(100, "Wood", false, R4x0);
            Wall posR5x0 = new Wall(100, "Wood", false, R5x0);
            Wall posR6x0 = new Wall(100, "Wood", false, R6x0);
            Wall posR7x0 = new Wall(100, "Wood", false, R7x0);

            Wall posR0x1 = new Wall(100, "Wood", false, R0x1);
            Wall posR1x1 = new Wall(100, "Wood", false, R1x1);
            Wall posR2x1 = new Wall(100, "Wood", false, R2x1);
            Wall posR3x1 = new Wall(100, "Wood", false, R3x1);
            Wall posR4x1 = new Wall(100, "Wood", false, R4x1);
            Wall posR5x1 = new Wall(100, "Wood", false, R5x1);
            Wall posR6x1 = new Wall(100, "Wood", false, R6x1);
            Wall posR7x1 = new Wall(100, "Wood", false, R7x1);

            Wall posR0x2 = new Wall(100, "Wood", false, R0x2);
            Wall posR1x2 = new Wall(100, "Wood", false, R1x2);
            Wall posR2x2 = new Wall(100, "Wood", false, R2x2);
            Wall posR3x2 = new Wall(100, "Wood", false, R3x2);
            Wall posR4x2 = new Wall(100, "Wood", false, R4x2);
            Wall posR5x2 = new Wall(100, "Wood", false, R5x2);
            Wall posR6x2 = new Wall(100, "Wood", false, R6x2);
            Wall posR7x2 = new Wall(100, "Wood", false, R7x2);

            Wall posR0x3 = new Wall(100, "Wood", false, R0x3);
            Wall posR1x3 = new Wall(100, "Wood", false, R1x3);
            Wall posR2x3 = new Wall(100, "Wood", false, R2x3);
            Wall posR3x3 = new Wall(100, "Wood", false, R3x3);
            Wall posR4x3 = new Wall(100, "Wood", false, R4x3);
            Wall posR5x3 = new Wall(100, "Wood", false, R5x3);
            Wall posR6x3 = new Wall(100, "Wood", false, R6x3);
            Wall posR7x3 = new Wall(100, "Wood", false, R7x3);

            Wall posR0x4 = new Wall(100, "Wood", false, R0x4);
            Wall posR1x4 = new Wall(100, "Wood", false, R1x4);
            Wall posR2x4 = new Wall(100, "Wood", false, R2x4);
            Wall posR3x4 = new Wall(100, "Wood", false, R3x4);
            Wall posR4x4 = new Wall(100, "Wood", false, R4x4);
            Wall posR5x4 = new Wall(100, "Wood", false, R5x4);
            Wall posR6x4 = new Wall(100, "Wood", false, R6x4);
            Wall posR7x4 = new Wall(100, "Wood", false, R7x4);

            Wall posR0x5 = new Wall(100, "Wood", false, R0x5);
            Wall posR1x5 = new Wall(100, "Wood", false, R1x5);
            Wall posR2x5 = new Wall(100, "Wood", false, R2x5);
            Wall posR3x5 = new Wall(100, "Wood", false, R3x5);
            Wall posR4x5 = new Wall(100, "Wood", false, R4x5);
            Wall posR5x5 = new Wall(100, "Wood", false, R5x5);
            Wall posR6x5 = new Wall(100, "Wood", false, R6x5);
            Wall posR7x5 = new Wall(100, "Wood", false, R7x5);

            Wall posL0x0 = new Wall(100, "Wood", false, L0x0);
            Wall posL1x0 = new Wall(100, "Wood", false, L1x0);
            Wall posL2x0 = new Wall(100, "Wood", false, L2x0);
            Wall posL3x0 = new Wall(100, "Wood", false, L3x0);
            Wall posL4x0 = new Wall(100, "Wood", false, L4x0);
            Wall posL5x0 = new Wall(100, "Wood", false, L5x0);
            Wall posL6x0 = new Wall(100, "Wood", false, L6x0);
            Wall posL7x0 = new Wall(100, "Wood", false, L7x0);
            Wall posL8x0 = new Wall(100, "Wood", false, L8x0);

            Wall posL0x1 = new Wall(100, "Wood", false, L0x1);
            Wall posL1x1 = new Wall(100, "Wood", false, L1x1);
            Wall posL2x1 = new Wall(100, "Wood", false, L2x1);
            Wall posL3x1 = new Wall(100, "Wood", false, L3x1);
            Wall posL4x1 = new Wall(100, "Wood", false, L4x1);
            Wall posL5x1 = new Wall(100, "Wood", false, L5x1);
            Wall posL6x1 = new Wall(100, "Wood", false, L6x1);
            Wall posL7x1 = new Wall(100, "Wood", false, L7x1);
            Wall posL8x1 = new Wall(100, "Wood", false, L8x1);

            Wall posL0x2 = new Wall(100, "Wood", false, L0x2);
            Wall posL1x2 = new Wall(100, "Wood", false, L1x2);
            Wall posL2x2 = new Wall(100, "Wood", false, L2x2);
            Wall posL3x2 = new Wall(100, "Wood", false, L3x2);
            Wall posL4x2 = new Wall(100, "Wood", false, L4x2);
            Wall posL5x2 = new Wall(100, "Wood", false, L5x2);
            Wall posL6x2 = new Wall(100, "Wood", false, L6x2);
            Wall posL7x2 = new Wall(100, "Wood", false, L7x2);
            Wall posL8x2 = new Wall(100, "Wood", false, L8x2);

            Wall posL0x3 = new Wall(100, "Wood", false, L0x3);
            Wall posL1x3 = new Wall(100, "Wood", false, L1x3);
            Wall posL2x3 = new Wall(100, "Wood", false, L2x3);
            Wall posL3x3 = new Wall(100, "Wood", false, L3x3);
            Wall posL4x3 = new Wall(100, "Wood", false, L4x3);
            Wall posL5x3 = new Wall(100, "Wood", false, L5x3);
            Wall posL6x3 = new Wall(100, "Wood", false, L6x3);
            Wall posL7x3 = new Wall(100, "Wood", false, L7x3);
            Wall posL8x3 = new Wall(100, "Wood", false, L8x3);

            Wall posL0x4 = new Wall(100, "Wood", false, L0x4);
            Wall posL1x4 = new Wall(100, "Wood", false, L1x4);
            Wall posL2x4 = new Wall(100, "Wood", false, L2x4);
            Wall posL3x4 = new Wall(100, "Wood", false, L3x4);
            Wall posL4x4 = new Wall(100, "Wood", false, L4x4);
            Wall posL5x4 = new Wall(100, "Wood", false, L5x4);
            Wall posL6x4 = new Wall(100, "Wood", false, L6x4);
            Wall posL7x4 = new Wall(100, "Wood", false, L7x4);
            Wall posL8x4 = new Wall(100, "Wood", false, L8x4);

            verticalWall[0, 0] = posR0x0;
            verticalWall[1, 0] = posR1x0;
            verticalWall[2, 0] = posR2x0;
            verticalWall[3, 0] = posR3x0;
            verticalWall[4, 0] = posR4x0;
            verticalWall[5, 0] = posR5x0;
            verticalWall[6, 0] = posR6x0;
            verticalWall[7, 0] = posR7x0;

            verticalWall[0, 1] = posR0x1;
            verticalWall[1, 1] = posR1x1;
            verticalWall[2, 1] = posR2x1;
            verticalWall[3, 1] = posR3x1;
            verticalWall[4, 1] = posR4x1;
            verticalWall[5, 1] = posR5x1;
            verticalWall[6, 1] = posR6x1;
            verticalWall[7, 1] = posR7x1;

            verticalWall[0, 2] = posR0x2;
            verticalWall[1, 2] = posR1x2;
            verticalWall[2, 2] = posR2x2;
            verticalWall[3, 2] = posR3x2;
            verticalWall[4, 2] = posR4x2;
            verticalWall[5, 2] = posR5x2;
            verticalWall[6, 2] = posR6x2;
            verticalWall[7, 2] = posR7x2;

            verticalWall[0, 3] = posR0x3;
            verticalWall[1, 3] = posR1x3;
            verticalWall[2, 3] = posR2x3;
            verticalWall[3, 3] = posR3x3;
            verticalWall[4, 3] = posR4x3;
            verticalWall[5, 3] = posR5x3;
            verticalWall[6, 3] = posR6x3;
            verticalWall[7, 3] = posR7x3;

            verticalWall[0, 4] = posR0x4;
            verticalWall[1, 4] = posR1x4;
            verticalWall[2, 4] = posR2x4;
            verticalWall[3, 4] = posR3x4;
            verticalWall[4, 4] = posR4x4;
            verticalWall[5, 4] = posR5x4;
            verticalWall[6, 4] = posR6x4;
            verticalWall[7, 4] = posR7x4;

            verticalWall[0, 5] = posR0x5;
            verticalWall[1, 5] = posR1x5;
            verticalWall[2, 5] = posR2x5;
            verticalWall[3, 5] = posR3x5;
            verticalWall[4, 5] = posR4x5;
            verticalWall[5, 5] = posR5x5;
            verticalWall[6, 5] = posR6x5;
            verticalWall[7, 5] = posR7x5;
            //
            horizontalWall[0, 0] = posL0x0;
            horizontalWall[1, 0] = posL1x0;
            horizontalWall[2, 0] = posL2x0;
            horizontalWall[3, 0] = posL3x0;
            horizontalWall[4, 0] = posL4x0;
            horizontalWall[5, 0] = posL5x0;
            horizontalWall[6, 0] = posL6x0;
            horizontalWall[7, 0] = posL7x0;
            horizontalWall[8, 0] = posL8x0;

            horizontalWall[0, 1] = posL0x1;
            horizontalWall[1, 1] = posL1x1;
            horizontalWall[2, 1] = posL2x1;
            horizontalWall[3, 1] = posL3x1;
            horizontalWall[4, 1] = posL4x1;
            horizontalWall[5, 1] = posL5x1;
            horizontalWall[6, 1] = posL6x1;
            horizontalWall[7, 1] = posL7x1;
            horizontalWall[8, 1] = posL8x1;

            horizontalWall[0, 2] = posL0x2;
            horizontalWall[1, 2] = posL1x2;
            horizontalWall[2, 2] = posL2x2;
            horizontalWall[3, 2] = posL3x2;
            horizontalWall[4, 2] = posL4x2;
            horizontalWall[5, 2] = posL5x2;
            horizontalWall[6, 2] = posL6x2;
            horizontalWall[7, 2] = posL7x2;
            horizontalWall[8, 2] = posL8x2;

            horizontalWall[0, 3] = posL0x3;
            horizontalWall[1, 3] = posL1x3;
            horizontalWall[2, 3] = posL2x3;
            horizontalWall[3, 3] = posL3x3;
            horizontalWall[4, 3] = posL4x3;
            horizontalWall[5, 3] = posL5x3;
            horizontalWall[6, 3] = posL6x3;
            horizontalWall[7, 3] = posL7x3;
            horizontalWall[8, 3] = posL8x3;

            horizontalWall[0, 4] = posL0x4;
            horizontalWall[1, 4] = posL1x4;
            horizontalWall[2, 4] = posL2x4;
            horizontalWall[3, 4] = posL3x4;
            horizontalWall[4, 4] = posL4x4;
            horizontalWall[5, 4] = posL5x4;
            horizontalWall[6, 4] = posL6x4;
            horizontalWall[7, 4] = posL7x4;
            horizontalWall[8, 4] = posL8x4;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /* private PictureBox randomOponent(Enemy enemy)
         {
             enemyList.Remove(enemy);
             int enemys = enemyList.Count;
             int target = random.Next(0, enemys+1);
             if (target == enemys + 1)
             {
                 enemy = player;
             }
             else
             {
                 enemy = enemyList[target].enemy;
             }
             return enemy;

         }*/

        private void ShootBullet(string direction, int Speed, int damage)
        {
            Bullet bullet = new Bullet();
            bullet.facingDirection = direction;
            bullet.speed = Speed;
            bullet.bulletLeft = player.Left + player.Width / 2;
            bullet.bulletTop = player.Top + player.Height / 2 - 10;
            bullet.gameBoxPicture = gameBoxPicture;
            bullet.player = player;
            bullet.damage = damage;
            bullet.horizontalWall = horizontalWall;
            bullet.verticalWall = verticalWall;
            bullet.hitWall = bulletHitWall;
            bullet.enemyList = allTargets;
            bullet.playerShooter = currentPlayer;

            bullet.MakeBullet(this);
            bullet.bullet.BringToFront();
        }

        private void ShootEnemyBullet(string direction, int Speed, int damage, PictureBox enemy, Player shooterPlayer)
        {
            Bullet bullet = new Bullet();
            bullet.facingDirection = direction;
            bullet.speed = Speed;
            bullet.bulletLeft = enemy.Left + enemy.Width / 2;
            bullet.bulletTop = enemy.Top + enemy.Height / 2;
            bullet.gameBoxPicture = gameBoxPicture;
            bullet.player = enemy;
            bullet.damage = damage;
            bullet.horizontalWall = horizontalWall;
            bullet.verticalWall = verticalWall;
            bullet.hitWall = bulletHitWall;
            bullet.enemyList = allTargets;
            bullet.playerShooter = shooterPlayer;
            bullet.MakeBullet(this);
            bullet.bullet.BringToFront();
        }

        private void checkAliveWalls()
        {
            if (buildingOn)
            {


                for (int k = 0; k < verticalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < verticalWall.GetLength(1); c++)
                    {

                        if (verticalWall[k, c].Alive == false)
                        {

                            // Left
                            if (direction == "left" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "SA" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "WA" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom)
                            {
                                if (player.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= player.Right && player.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= player.Bottom)
                                {

                                    verticalWall[k, c].formWall.Visible = false;

                                }
                                else
                                {

                                    verticalWall[k, c].formWall.Visible = true;
                                    verticalWall[k, c].formWall.BackColor = Color.Blue;
                                    verticalWall[k, c].formWall.BringToFront();
                                }
                            }


                            // Right
                            else if (direction == "right" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "SD" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "WD" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom)
                            {
                                if (player.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= player.Right && player.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= player.Bottom)
                                {

                                    verticalWall[k, c].formWall.Visible = false;
                                }
                                else
                                {

                                    verticalWall[k, c].formWall.Visible = true;
                                    verticalWall[k, c].formWall.BackColor = Color.Blue;
                                }
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

                            /*if (direction == "right" && visionBoxR.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "WD" && visionBoxR.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "SD" && visionBoxR.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxR.Bottom)
                            {
                                horizontalWall[k, c].formWall.BackColor = Color.Blue;
                                horizontalWall[k, c].formWall.Visible = true;
                            }
                            else if (direction == "left" && visionBoxL.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "WA" && visionBoxL.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "SA" && visionBoxL.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxL.Bottom)
                            {
                                horizontalWall[k, c].formWall.BackColor = Color.Blue;
                                horizontalWall[k, c].formWall.Visible = true;
                            }*/

                            // Up
                            if (direction == "up" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WA" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WD" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom)
                            {
                                if (player.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= player.Right && player.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= player.Bottom)
                                {

                                    horizontalWall[k, c].formWall.Visible = false;

                                }
                                else
                                {

                                    horizontalWall[k, c].formWall.Visible = true;
                                    horizontalWall[k, c].formWall.BackColor = Color.Blue;
                                    horizontalWall[k, c].formWall.BringToFront();
                                }
                            }


                            // Down
                            else if (direction == "down" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SA" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SD" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom)
                            {
                                if (player.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= player.Right && player.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= player.Bottom)
                                {

                                    horizontalWall[k, c].formWall.Visible = false;
                                }
                                else
                                {

                                    horizontalWall[k, c].formWall.Visible = true;
                                    horizontalWall[k, c].formWall.BackColor = Color.Blue;
                                }
                            }
                            else
                            {
                                horizontalWall[k, c].formWall.Visible = false;
                            }

                        }
                        else if (horizontalWall[k, c].Alive)
                        {

                        }
                    }
                }
            }
            else
            {
                for (int k = 0; k < verticalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < verticalWall.GetLength(1); c++)
                    {

                        if (verticalWall[k, c].Alive == false)
                        {


                            verticalWall[k, c].formWall.Visible = false;

                        }
                    }
                }
                for (int k = 0; k < horizontalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < horizontalWall.GetLength(1); c++)
                    {

                        if (horizontalWall[k, c].Alive == false)
                        {


                            horizontalWall[k, c].formWall.Visible = false;

                        }
                    }
                }
            }
        }


        public bool shotBullet = false;
        public bool bulletHitWall = false;

        public bool noHitWall = true;

        public int Testtstst;
        private void movePlayer()
        {
            // Move Back

            checkAliveWalls();

            if (back && playerY <= gameBoxPicture.Location.Y + gameBoxPicture.Height - player.Height - 1)
            {
                for (int k = 0; k < horizontalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < horizontalWall.GetLength(1); c++)
                    {

                        if (horizontalWall[k, c].Alive)
                        {

                            if (player.Bottom + 1 == horizontalWall[k, c].formWall.Top && player.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= player.Right)
                            {

                                hitWallD = true;

                            }
                        }
                    }
                }

                for (int k = 0; k < verticalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < verticalWall.GetLength(1); c++)
                    {

                        if (verticalWall[k, c].Alive)
                        {

                            if (player.Bottom + 1 == verticalWall[k, c].formWall.Top && player.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= player.Right)
                            {

                                hitWallD = true;

                            }
                        }
                    }
                }

                if (!hitWallD)
                {

                    playerY = playerY + 1;

                    yVisionD = yVisionD + 1;
                    yVisionU = yVisionU + 1;
                    yVisionL = yVisionL + 1;
                    yVisionR = yVisionR + 1;

                    visionBoxD.Location = new Point(visionBoxD.Location.X, yVisionD);
                    visionBoxU.Location = new Point(visionBoxU.Location.X, yVisionU);
                    visionBoxL.Location = new Point(visionBoxL.Location.X, yVisionL);
                    visionBoxR.Location = new Point(visionBoxR.Location.X, yVisionR);

                    player.Location = new Point(player.Location.X, playerY);
                }
                else
                {
                    hitWallD = false;
                }



            }

            // Move Foward

            if (foward && playerY >= gameBoxPicture.Location.Y + 1)
            {

                for (int k = 0; k < horizontalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < horizontalWall.GetLength(1); c++)
                    {

                        if (horizontalWall[k, c].Alive)
                        {

                            if (player.Top - 1 == horizontalWall[k, c].formWall.Bottom && player.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= player.Right)
                            {

                                hitWallU = true;

                            }

                        }
                    }
                }
                for (int k = 0; k < verticalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < verticalWall.GetLength(1); c++)
                    {

                        if (verticalWall[k, c].Alive)
                        {

                            if (player.Top - 1 == verticalWall[k, c].formWall.Bottom && player.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= player.Right)
                            {

                                hitWallU = true;

                            }

                        }
                    }
                }

                if (!hitWallU)
                {

                    playerY = playerY - 1;

                    yVisionD = yVisionD - 1;
                    yVisionU = yVisionU - 1;
                    yVisionL = yVisionL - 1;
                    yVisionR = yVisionR - 1;

                    visionBoxD.Location = new Point(visionBoxD.Location.X, yVisionD);
                    visionBoxU.Location = new Point(visionBoxU.Location.X, yVisionU);
                    visionBoxL.Location = new Point(visionBoxL.Location.X, yVisionL);
                    visionBoxR.Location = new Point(visionBoxR.Location.X, yVisionR);

                    player.Location = new Point(player.Location.X, playerY);
                }
                else
                {
                    hitWallU = false;
                }



            }


            // Move Left

            if (left && playerX >= gameBoxPicture.Location.X + 1)
            {

                for (int k = 0; k < horizontalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < horizontalWall.GetLength(1); c++)
                    {

                        if (horizontalWall[k, c].Alive)
                        {

                            if (player.Left - 1 == horizontalWall[k, c].formWall.Right && player.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= player.Bottom)
                            {
                                hitWallL = true;

                            }


                        }
                    }
                }
                for (int k = 0; k < verticalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < verticalWall.GetLength(1); c++)
                    {

                        if (verticalWall[k, c].Alive)
                        {

                            if (player.Left - 1 == verticalWall[k, c].formWall.Right && player.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= player.Bottom)
                            {
                                hitWallL = true;

                            }


                        }
                    }
                }


                if (!hitWallL)
                {
                    playerX = playerX - 1;

                    xVisionD = xVisionD - 1;
                    xVisionU = xVisionU - 1;
                    xVisionL = xVisionL - 1;
                    xVisionR = xVisionR - 1;


                    visionBoxD.Location = new Point(xVisionD, visionBoxD.Location.Y);
                    visionBoxU.Location = new Point(xVisionU, visionBoxU.Location.Y);
                    visionBoxL.Location = new Point(xVisionL, visionBoxL.Location.Y);
                    visionBoxR.Location = new Point(xVisionR, visionBoxR.Location.Y);

                    player.Location = new Point(playerX, player.Location.Y);
                }
                else
                {
                    hitWallL = false;
                }

            }

            // Move Right

            if (right && playerX <= gameBoxPicture.Location.X + gameBoxPicture.Width - player.Width - 1)
            {
                for (int k = 0; k < horizontalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < horizontalWall.GetLength(1); c++)
                    {

                        if (horizontalWall[k, c].Alive)
                        {

                            if (player.Right + 1 == horizontalWall[k, c].formWall.Left && player.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= player.Bottom)
                            {
                                hitWallR = true;

                            }


                        }
                    }
                }

                for (int k = 0; k < verticalWall.GetLength(0); k++)
                {
                    for (int c = 0; c < verticalWall.GetLength(1); c++)
                    {

                        if (verticalWall[k, c].Alive)
                        {

                            if (player.Right + 1 == verticalWall[k, c].formWall.Left && player.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= player.Bottom)
                            {
                                hitWallR = true;

                            }


                        }
                    }
                }


                if (!hitWallR)
                {
                    playerX = playerX + 1;

                    xVisionD = xVisionD + 1;
                    xVisionU = xVisionU + 1;
                    xVisionL = xVisionL + 1;
                    xVisionR = xVisionR + 1;


                    visionBoxD.Location = new Point(xVisionD, visionBoxD.Location.Y);
                    visionBoxU.Location = new Point(xVisionU, visionBoxU.Location.Y);
                    visionBoxL.Location = new Point(xVisionL, visionBoxL.Location.Y);
                    visionBoxR.Location = new Point(xVisionR, visionBoxR.Location.Y);

                    player.Location = new Point(playerX, player.Location.Y);
                }
                else
                {
                    hitWallR = false;
                }


            }

        }



        private void mainGameTimerEvent(object sender, EventArgs e)
        {

            movePlayer();


        }


        private void FightingMinigame_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        public bool buildingOn = false;

        public int activeSlot = 0;

        private void FightingMinigame_KeyDown(object sender, KeyEventArgs e)
        {

            

            if (InventorySlotsList[activeSlot].gun.Magazine == 0)
            {
                if (InventorySlotsList[activeSlot].gun.Magazine > Ammo)
                {
                    int x = InventorySlotsList[activeSlot].gun.Magazine - Ammo;
                    Ammo = Ammo - x;
                }
                else
                {
                    Ammo = Ammo - InventorySlotsList[activeSlot].gun.Magazine;
                }
            }

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

            // Active Slot

            if (e.KeyValue == (char)Keys.D1 || activeSlot == 0)
            {
                activeSlot = 0;
                slot1.BackColor = Color.SkyBlue;
            }

            if (e.KeyValue == (char)Keys.D2)
            {
                activeSlot = 1;
                slot2.BackColor = Color.SkyBlue;
            }

            if (e.KeyValue == (char)Keys.D3)
            {
                activeSlot = 2;
                slot3.BackColor = Color.SkyBlue;
            }

            if (e.KeyValue == (char)Keys.D4)
            {
                activeSlot = 3;
                slot4.BackColor = Color.SkyBlue;
            }

            if (e.KeyValue == (char)Keys.D5)
            {
                activeSlot = 4;
                slot5.BackColor = Color.SkyBlue;
            }

            if (e.KeyValue == (char)Keys.D6)
            {
                activeSlot = 5;
                slot6.BackColor = Color.SkyBlue;
            }

            if (activeSlot != 0)
            {
                slot1.BackColor = Color.White;
            }
            if (activeSlot != 1)
            {
                slot2.BackColor = Color.White;
            }

            if (activeSlot != 2)
            {
                slot3.BackColor = Color.White;
            }

            if (activeSlot != 3)
            {
                slot4.BackColor = Color.White;
            }

            if (activeSlot != 4)
            {
                slot5.BackColor = Color.White;
            }

            if (activeSlot != 5)
            {
                slot6.BackColor = Color.White;
            }

            if (e.KeyValue == (char)Keys.Q)
            {

                /*if (buildingOn)
                {
                    buildingOn = false;
                    buildingIcon.Visible = false;
                    buildingIconBlank.Visible = true;
                }
                else
                {
                    buildingOn = true;
                    buildingIcon.Visible = true;
                    buildingIconBlank.Visible = false;
                }*/


            }


            if (e.KeyValue == (char)Keys.Space)
            {

            }
            if (e.KeyValue == (char)Keys.Up)
            {
                direction = "up";

            }
            if (e.KeyValue == (char)Keys.Down)
            {
                direction = "down";

            }
            if (e.KeyValue == (char)Keys.Left)
            {
                direction = "left";

            }
            if (e.KeyValue == (char)Keys.Right)
            {
                direction = "right";

            }
            if (e.KeyValue == (char)Keys.Up && e.KeyValue == (char)Keys.Right)
            {
                direction = "WD";

            }
            if (e.KeyValue == (char)Keys.Up && e.KeyValue == (char)Keys.Left)
            {
                direction = "WA";

            }
            if (e.KeyValue == (char)Keys.Down && e.KeyValue == (char)Keys.Right)
            {
                direction = "SD";

            }
            if (e.KeyValue == (char)Keys.Down && e.KeyValue == (char)Keys.Left)
            {
                direction = "SA";

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
            if (e.KeyValue == (char)Keys.Q)
            {

                if (buildingOn)
                {
                    buildingOn = false;
                    buildingIcon.Visible = false;
                    buildingIconBlank.Visible = true;
                }
                else
                {
                    buildingOn = true;
                    buildingIcon.Visible = true;
                    buildingIconBlank.Visible = false;
                }

            }
            if (e.KeyValue == (char)Keys.Up)
            {
                if (!buildingOn && currentPlayer.Ammo > 0)
                {
                    if (InventorySlotsList[activeSlot].gun != null)
                    {
                        ShootBullet(direction, InventorySlotsList[activeSlot].gun.Speed, InventorySlotsList[activeSlot].gun.Damage);
                        currentPlayer.Ammo--;
                    }
                }

            }
            else if (e.KeyValue == (char)Keys.Right)
            {
                if (!buildingOn && currentPlayer.Ammo > 0)
                {
                    if (InventorySlotsList[activeSlot].gun != null)
                    {
                        ShootBullet(direction, InventorySlotsList[activeSlot].gun.Speed, InventorySlotsList[activeSlot].gun.Damage);
                        currentPlayer.Ammo--;
                    }
                }

            }
            else if (e.KeyValue == (char)Keys.Left)
            {
                if (!buildingOn && currentPlayer.Ammo > 0)
                {
                    if (InventorySlotsList[activeSlot].gun != null)
                    {
                        ShootBullet(direction, InventorySlotsList[activeSlot].gun.Speed, InventorySlotsList[activeSlot].gun.Damage);
                        currentPlayer.Ammo--;
                    }
                }

            }
            else if (e.KeyValue == (char)Keys.Down)
            {
                if (!buildingOn && currentPlayer.Ammo > 0)
                {
                    if (InventorySlotsList[activeSlot].gun != null)
                    {
                        ShootBullet(direction, InventorySlotsList[activeSlot].gun.Speed, InventorySlotsList[activeSlot].gun.Damage);
                        currentPlayer.Ammo--;
                    }
                }

            }

            if (e.KeyValue == (char)Keys.Space)
            {
                if (!buildingOn)
                {
                    if (InventorySlotsList[activeSlot].gun != null)
                    {
                        ShootBullet(direction, InventorySlotsList[activeSlot].gun.Speed, InventorySlotsList[activeSlot].gun.Damage);
                    }
                    else
                    {

                    }
                }
                else if (buildingOn && Materials >= 10)
                {

                    for (int k = 0; k < verticalWall.GetLength(0); k++)
                    {
                        for (int c = 0; c < verticalWall.GetLength(1); c++)
                        {

                            if (verticalWall[k, c].Alive == false)
                            {

                                if (direction == "right" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "WD" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom || direction == "SD" && visionBoxR.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxR.Right && visionBoxR.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxR.Bottom)
                                {
                                    if (player.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= player.Right && player.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= player.Bottom)
                                    {



                                    }
                                    else if (Materials >= 10)
                                    {

                                        verticalWall[k, c].formWall.BackColor = Color.Olive;
                                        verticalWall[k, c].formWall.Visible = true;
                                        verticalWall[k, c].Alive = true;
                                        verticalWall[k, c].Health = 100;
                                        Materials = Materials - 10;
                                        materialLabel.Text = Materials.ToString();

                                    }
                                }
                                else if (direction == "left" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "SA" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom || direction == "WA" && visionBoxL.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= visionBoxL.Right && visionBoxL.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= visionBoxL.Bottom)
                                {
                                    if (player.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= player.Right && player.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= player.Bottom)
                                    {



                                    }
                                    else if (Materials >= 10)
                                    {
                                        verticalWall[k, c].formWall.BackColor = Color.Olive;
                                        verticalWall[k, c].formWall.Visible = true;
                                        verticalWall[k, c].Alive = true;
                                        verticalWall[k, c].Health = 100;
                                        Materials = Materials - 10;
                                        materialLabel.Text = Materials.ToString();
                                    }
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

                                if (direction == "up" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WA" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom || direction == "WD" && visionBoxU.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxU.Right && visionBoxU.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxU.Bottom)
                                {
                                    if (player.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= player.Right && player.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= player.Bottom)
                                    {



                                    }
                                    else if (Materials >= 10)
                                    {

                                        horizontalWall[k, c].formWall.BackColor = Color.Olive;
                                        horizontalWall[k, c].formWall.Visible = true;
                                        horizontalWall[k, c].Alive = true;
                                        horizontalWall[k, c].Health = 100;
                                        Materials = Materials - 10;
                                        materialLabel.Text = Materials.ToString();
                                    }
                                }
                                else if (direction == "down" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SA" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom || direction == "SD" && visionBoxD.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= visionBoxD.Right && visionBoxD.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= visionBoxD.Bottom)
                                {
                                    if (player.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= player.Right && player.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= player.Bottom)
                                    {



                                    }
                                    else if (Materials >= 10)
                                    {
                                        horizontalWall[k, c].formWall.BackColor = Color.Olive;
                                        horizontalWall[k, c].formWall.Visible = true;
                                        horizontalWall[k, c].Alive = true;
                                        horizontalWall[k, c].Health = 100;
                                        Materials = Materials - 10;
                                        materialLabel.Text = Materials.ToString();
                                    }
                                }
                                else
                                {
                                    horizontalWall[k, c].formWall.Visible = false;
                                }
                            }
                        }
                    }
                }
                


            }
        }



        public bool EhitWallL;
        public bool EhitWallR;
        public bool EhitWallU;
        public bool EhitWallD;

        Random random = new Random();

        public List<Player> allTargets = new List<Player>();
        public List<Player> winningList = new List<Player>();

        ///
        // Gives all players a target
        ///

        private void GivePlayersTargets()
        {

            foreach (Player player in allTargets)
            {
                List<Player> targetList = new List<Player>(allTargets);
                targetList.Remove(player);
                player.Target = targetList[random.Next(0, targetList.Count)];

            }
        }


        ///
        // Gives new a new target
        ///

        private void GiveNewTarget(Player player)
        {
            List<Player> targetList = new List<Player>(allTargets);
            targetList.Remove(player);
            player.Target = targetList[random.Next(0, targetList.Count)];
        }

        ////
        ///
        // Make Enemy
        ///
        ////

        private void MakeEnemy(int number)
        {
            for (int i = 0; i < number; i++)
            {
                PictureBox player = new PictureBox();
                player.Tag = "enemy";
                player.Left = random.Next(gameBoxPicture.Location.X, gameBoxPicture.Location.X + gameBoxPicture.Width - player.Width);
                player.Top = random.Next(gameBoxPicture.Location.Y, gameBoxPicture.Location.Y + gameBoxPicture.Height - player.Height);
                player.Size = new Size(10, 10);
                player.Image = Properties.Resources.ammoIcon;
                this.Controls.Add(player);

                ProgressBar health = new ProgressBar();
                health.Value = 100;
                health.Visible = true;
                health.Maximum = 100;
                health.Top = player.Top - player.Height - 5;
                health.Left = player.Left;
                health.Size = new Size(20, 5);

                this.Controls.Add(health);

                int chance = random.Next(0, 4);
                int shieldChance;
                if (chance == 0)
                {
                    shieldChance = 0;

                }
                else if (chance == 1)
                {
                    shieldChance = 25;
                }
                else if (chance == 2)
                {
                    shieldChance = 50;
                }
                else if (chance == 3)
                {
                    shieldChance = 75;
                }
                else
                {
                    shieldChance = 100;
                }

                ProgressBar shield = new ProgressBar();
                shield.Value = shieldChance;
                shield.Visible = true;
                shield.Maximum = 100;
                shield.Top = health.Top - health.Height - 1;
                shield.Left = health.Left;
                shield.Size = new Size(20, 5);
                shield.SetState(3);

                this.Controls.Add(shield);

                health.BringToFront();
                shield.BringToFront();

                player.BringToFront();


                Player enemyPlayer = new Player(100, shieldChance, 10, null, true, player, 30, false, true, health, shield);

                winningList.Add(enemyPlayer);
                allTargets.Add(enemyPlayer);
            }
            enemyTimer.Enabled = true;

        }

        ////
        ///
        // Enemy Movement Timer
        ///
        ////

        private void enemyTimer_Tick(object sender, EventArgs e)
        {

            foreach (Player x in allTargets)
            {
                if (x.Target == null)
                {
                    GivePlayersTargets();
                    break;
                }
                if (!x.Target.Alive)
                {
                    GiveNewTarget(x);

                }
                if (x.Alive && x.Target.Alive && !x.isClient)
                {





                    ///
                    // Check if target is left
                    ///
                    if (x.PlayerBox.Left > x.Target.PlayerBox.Left)
                    {
                        // Left Enemy Move
                        for (int k = 0; k < horizontalWall.GetLength(0); k++)
                        {
                            for (int c = 0; c < horizontalWall.GetLength(1); c++)
                            {

                                if (horizontalWall[k, c].Alive)
                                {

                                    if (x.PlayerBox.Left - 1 == horizontalWall[k, c].formWall.Right && x.PlayerBox.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= x.PlayerBox.Bottom)
                                    {
                                        EhitWallL = true;

                                    }


                                }
                            }
                        }
                        for (int k = 0; k < verticalWall.GetLength(0); k++)
                        {
                            for (int c = 0; c < verticalWall.GetLength(1); c++)
                            {

                                if (verticalWall[k, c].Alive)
                                {

                                    if (x.PlayerBox.Left - 1 == verticalWall[k, c].formWall.Right && x.PlayerBox.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= x.PlayerBox.Bottom)
                                    {
                                        EhitWallL = true;

                                    }


                                }
                            }
                        }

                        if (!EhitWallL)
                        {
                            x.PlayerBox.Left -= 1;
                            x.healthBar.Left -= 1;
                            x.shieldBar.Left -= 1;

                        }
                        else
                        {
                            EhitWallL = false;
                        }



                    }

                    ///
                    // Check if target is Right
                    ///
                    if (x.PlayerBox.Left < x.Target.PlayerBox.Left)
                    {
                        // Right Enemy Move

                        for (int k = 0; k < horizontalWall.GetLength(0); k++)
                        {
                            for (int c = 0; c < horizontalWall.GetLength(1); c++)
                            {

                                if (horizontalWall[k, c].Alive)
                                {

                                    if (x.PlayerBox.Right + 1 == horizontalWall[k, c].formWall.Left && x.PlayerBox.Top <= horizontalWall[k, c].formWall.Bottom && horizontalWall[k, c].formWall.Top <= x.PlayerBox.Bottom)
                                    {
                                        EhitWallR = true;

                                    }


                                }
                            }
                        }

                        for (int k = 0; k < verticalWall.GetLength(0); k++)
                        {
                            for (int c = 0; c < verticalWall.GetLength(1); c++)
                            {

                                if (verticalWall[k, c].Alive)
                                {

                                    if (x.PlayerBox.Right + 1 == verticalWall[k, c].formWall.Left && x.PlayerBox.Top <= verticalWall[k, c].formWall.Bottom && verticalWall[k, c].formWall.Top <= x.PlayerBox.Bottom)
                                    {
                                        EhitWallR = true;

                                    }


                                }
                            }
                        }

                        if (!EhitWallR)
                        {

                            x.PlayerBox.Left += 1;
                            x.healthBar.Left += 1;
                            x.shieldBar.Left += 1;
                        }
                        else
                        {
                            EhitWallR = false;
                        }


                    }

                    ///
                    // Check if target is Down
                    ///
                    if (x.PlayerBox.Top > x.Target.PlayerBox.Top)
                    {
                        // Up Enemy Move
                        for (int k = 0; k < horizontalWall.GetLength(0); k++)
                        {
                            for (int c = 0; c < horizontalWall.GetLength(1); c++)
                            {

                                if (horizontalWall[k, c].Alive)
                                {

                                    if (x.PlayerBox.Top - 1 == horizontalWall[k, c].formWall.Bottom && x.PlayerBox.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= x.PlayerBox.Right)
                                    {

                                        EhitWallU = true;

                                    }

                                }
                            }
                        }
                        for (int k = 0; k < verticalWall.GetLength(0); k++)
                        {
                            for (int c = 0; c < verticalWall.GetLength(1); c++)
                            {

                                if (verticalWall[k, c].Alive)
                                {

                                    if (x.PlayerBox.Top - 1 == verticalWall[k, c].formWall.Bottom && x.PlayerBox.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= x.PlayerBox.Right)
                                    {

                                        EhitWallU = true;

                                    }

                                }
                            }
                        }

                        if (!EhitWallU)
                        {
                            x.PlayerBox.Top -= 1;
                            x.healthBar.Top -= 1;
                            x.shieldBar.Top -= 1;
                        }
                        else
                        {
                            EhitWallU = false;
                        }

                    }

                    ///
                    // Check if target is Up
                    ///
                    if (x.PlayerBox.Top < x.Target.PlayerBox.Top)
                    {
                        // Down Enemy Move

                        for (int k = 0; k < horizontalWall.GetLength(0); k++)
                        {
                            for (int c = 0; c < horizontalWall.GetLength(1); c++)
                            {

                                if (horizontalWall[k, c].Alive)
                                {

                                    if (x.PlayerBox.Bottom + 1 == horizontalWall[k, c].formWall.Top && x.PlayerBox.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= x.PlayerBox.Right)
                                    {

                                        EhitWallD = true;

                                    }
                                }
                            }
                        }

                        for (int k = 0; k < verticalWall.GetLength(0); k++)
                        {
                            for (int c = 0; c < verticalWall.GetLength(1); c++)
                            {

                                if (verticalWall[k, c].Alive)
                                {

                                    if (x.PlayerBox.Bottom + 1 == verticalWall[k, c].formWall.Top && x.PlayerBox.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= x.PlayerBox.Right)
                                    {

                                        EhitWallD = true;

                                    }
                                }
                            }
                        }

                        if (!EhitWallD)
                        {
                            x.PlayerBox.Top += 1;
                            x.healthBar.Top += 1;
                            x.shieldBar.Top += 1;
                        }
                        else
                        {
                            EhitWallD = false;
                        }


                    }


                }

            }
        }

        private void enemyReload_Tick(object sender, EventArgs e)
        {
            ///
            // Check if has ammo
            ///

            foreach (Player x in allTargets)
            {

                if (x.PlayerBox.Bounds.IntersectsWith(x.Target.PlayerBox.Bounds) && x.Alive)
                {

                }

                else if (x.Ammo > 0 && x.Alive && !x.isClient)
                {
                    if (x.PlayerBox.Location.X <= x.Target.PlayerBox.Location.X && x.PlayerBox.Location.Y == x.Target.PlayerBox.Location.Y || x.PlayerBox.Location.X >= x.Target.PlayerBox.Location.X && x.PlayerBox.Location.Y == x.Target.PlayerBox.Location.Y || EhitWallR || EhitWallL)
                    {

                        if (x.PlayerBox.Left > x.Target.PlayerBox.Left || EhitWallL)
                        {
                            ShootEnemyBullet("left", 5, 20, x.PlayerBox, x);

                            x.Ammo--;
                        }
                        else if (x.PlayerBox.Left < x.Target.PlayerBox.Left || EhitWallR)
                        {
                            ShootEnemyBullet("right", 5, 20, x.PlayerBox, x);
                            x.Ammo--;
                        }
                    }

                    if (x.PlayerBox.Location.Y <= x.Target.PlayerBox.Location.Y && x.PlayerBox.Location.X == x.Target.PlayerBox.Location.X || x.PlayerBox.Location.Y >= x.Target.PlayerBox.Location.Y && x.PlayerBox.Location.X == x.Target.PlayerBox.Location.X || EhitWallU || EhitWallD)
                    {
                        Console.WriteLine("asdahsdhabdhj");
                        if (x.PlayerBox.Top > x.Target.PlayerBox.Top || EhitWallU)
                        {
                            ShootEnemyBullet("up", 5, 30, x.PlayerBox, x);
                            x.Ammo--;
                        }
                        else if (x.PlayerBox.Top < x.Target.PlayerBox.Top || EhitWallD)
                        {
                            ShootEnemyBullet("down", 5, 30, x.PlayerBox, x);
                            x.Ammo--;
                        }
                    }

                }
            }
        }

        private void enemyPickaxe_Tick(object sender, EventArgs e)
        {
            foreach (Player x in allTargets)
            {

                List<Player> list = new List<Player>();
                foreach (Player xw in allTargets)
                {
                    if (xw.Alive)
                    {

                        list.Add(xw);
                    }
                }
                Console.WriteLine(list.Count);
                if (x.PlayerBox.Bounds.IntersectsWith(x.Target.PlayerBox.Bounds) && x.Alive)
                {
                    if (x.Target.Shield >= 50)
                    {
                        x.Target.Shield = x.Target.Shield - 50;
                        x.Target.shieldBar.Value = x.Target.Shield;
                    }
                    else if (x.Target.Shield < 50 && x.Target.Shield != 0)
                    {
                        x.Target.Health = x.Target.Health + x.Target.Shield;
                        x.Target.Health = x.Target.Health - 50;
                        x.Target.shieldBar.Value = 0;
                        x.Target.Shield = 0;

                        x.Target.healthBar.Value = x.Target.Health;
                    }
                    else if (x.Target.Health > 50)
                    {
                        x.Target.Health = x.Target.Health - 50;
                        x.Target.healthBar.Value = x.Target.Health;
                    }
                    else if (x.Target.Health <= 50)
                    {
                        x.Target.Alive = false;
                        x.Target.PlayerBox.Visible = false;
                        x.Target.shieldBar.Visible = false;
                        x.Target.healthBar.Visible = false;

                        x.Target.shieldBar.Value = 0;
                        x.Target.Shield = 0;

                        x.Target.healthBar.Value = 0;
                        x.Target.Health = 0;

                    }
                    else if (x.Target.Shield == 0)
                    {
                        x.Target.shieldBar.Value = 0;
                        x.Target.Shield = 0;
                    }
                }
            }

        }
    }
}