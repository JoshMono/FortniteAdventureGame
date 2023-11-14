﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing.Configuration;
using System.Runtime.CompilerServices;
using System.Diagnostics.Tracing;

namespace AdventureGame
{
    public class InventoryModel
    {
        public int Health { get; set; }
        public int Shield { get; set; }
        public int Materials { get; set; }
        public int ZBucks { get; set; }
        public Image Skin { get; set; }
        public int Ammo { get; set; }
        public Player Player { get; set; }



        public InventoryModel(int Health, int Shield, int ZBucks, Image Skin, int Materials, int Ammo, Player player)
        {
            this.Health = Health;
            this.Shield = Shield;
            this.ZBucks = ZBucks;
            this.Skin = Skin;
            this.Materials = Materials;
            this.Ammo = Ammo;
            Player = player;
        }

        public class Gun
        {
            public string Name { get; set; }
            public string Rarity { get; set; }
            public int Damage { get; set; }
            public int Speed { get; set; }
            public Image? Icon { get; set; }

            public Gun(string name, string rarity, int damage, int speed, Image? icon)
            {
                Name = name;
                Rarity = rarity;
                Damage = damage;
                Speed = speed;
                Icon = icon;
            }
        }

        public class Item
        {
            public string Name { get; set; }
            public int Heal { get; set; }
            public int Shield { get; set; }
            public int Speed { get; set; }
            public Image? Icon { get; set; }

            public Item(string Name, int Heal, int Shield, int Speed, Image Icon)
            {
                this.Name = Name;
                this.Heal = Heal;
                this.Shield = Shield;
                this.Speed = Speed;
                this.Icon = Icon;
            }
        }

        public class InventorySlot
        {
            public int slot { get; set; }
            public Gun? gun { get; set; }

            public Item? item { get; set; }

            public InventorySlot(int slot, Gun? gun, Item? item)
            {
                this.slot = slot;
                this.gun = gun;
                this.item = item;
            }

            public bool hasGun()
            {
                if (gun == null) return false; return true;
            }

            public bool hasItem()
            {
                if (item == null) return false; return true;
            }

        }   

        public Item GetItem()
        {
            Dictionary<int, Item> itemDict = new Dictionary<int, Item>();
            itemDict.Add(1, new Item("Mini", 0, 25, 3, (Image)Properties.Resources.miniIcon));
            Random rand = new Random();
            int itemId = rand.Next(1, 2);
            return itemDict[itemId];
        }

        public Gun GetGun()
        {
            Dictionary<int, Gun> gunsDict = new Dictionary<int, Gun>();
            gunsDict.Add(1, new Gun("Scar", "Gold", 40, 5, (Image)Properties.Resources.scarIcon));
            gunsDict.Add(2, new Gun("Bolt", "Blue", 50, 10, (Image)Properties.Resources.boltIcon));
            gunsDict.Add(3, new Gun("Pistol", "Gray", 10, 5, (Image)Properties.Resources.pistolIcon));
            gunsDict.Add(4, new Gun("Pump", "Blue", 80, 3,(Image)Properties.Resources.pumpIcon));

            Random rand = new Random();
            int gunId = rand.Next(1, 5);
            return gunsDict[gunId];
        }

        public static void RefreshInventory(List<PictureBox> slotslist, List<InventoryModel.InventorySlot> inventorySlots)
        {
            for (int i = 0; i < slotslist.Count; i++)
            {

                if (inventorySlots[i].gun != null)
                {

                    slotslist[i].BackgroundImage = inventorySlots[i].gun.Icon;
                }
                else if (inventorySlots[i].item != null)
                {
                    slotslist[i].BackgroundImage = inventorySlots[i].item.Icon;
                }
                else
                {
                    slotslist[i].BackColor = Color.White;
                }
            }
        }

    }

    public class Player
    {
       
        public int Health { get; set; }
        public int Shield { get; set; }
        public int Ammo { get; set; }
        public PictureBox Target { get; set; }
        public PictureBox enemy { get; set;}

        public Enemy(int health, int ammo, PictureBox Target ,PictureBox enemy)
        {
            Health = health;
            Ammo = ammo;
            this.enemy = enemy;
            this.Target = Target;
        }
    }

    public class Wall
    {
        public int Health;
        public string Material { get; set;}
        public bool Alive {  get; set;}
        public PictureBox formWall {  get; set;}

        public Wall(int Health, string material, bool alive, PictureBox wall)
        {
            this.Material = material;
            this.Health = Health;
            Alive = alive;
            formWall = wall;
        }

    }

    public class MapLocation
    {
        public string locationName { get; set; }
        public int playersLanding;
        public bool hasChest;

        public MapLocation(string locationName)
        {
            playersLanding = PlayersLandingChance();
            Random rand = new Random();
            float oddsOfChestFloat = playersLanding * 0.7F;
            int oddsOfChest = (int)oddsOfChestFloat;
            int hasChestNum = rand.Next(0, oddsOfChest);
            if (hasChestNum == 0) 
            {
                hasChest = true;
                    
            } 
            else 
            {
                hasChest = false;
            }
            this.locationName = locationName;

        }

        public int PlayersLandingChance()
        {
            Random rand = new Random();
            playersLanding = rand.Next(0, 11);
            return playersLanding;
        }


    }

    public class Bullet
    {
        public string facingDirection {  get; set; }
        public int bulletLeft { get; set; }
        public int bulletTop { get; set;}
        public int speed { get; set;}
        public int damage { get; set; }
        public int ammo { get; set; }
        public bool hitWall { get; set; }
        public List<PictureBox> enemyList { get; set; }
        public PictureBox gameBoxPicture { get; set; }
        public PictureBox player { get; set; }
        public PictureBox topGap { get; set; }
        public PictureBox sideGap { get; set; }

        public Wall[,] horizontalWall { get; set; }

        public Wall[,] verticalWall { get; set; }

        public Color colour = Color.FromArgb(138, 95, 43);
        public int colourG;
        public int colourB;

        

        public PictureBox bullet = new PictureBox();
        private System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();

        public void MakeBullet(Form form)
        {
            bullet.BackColor = Color.Black;
            bullet.Size = new Size(3, 3);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
            colourG = colour.G;
            colourB = colour.B;
            ammo = 0;

            
        }

        public void BulletStop(Form form)
        {
            bulletTimer.Stop();
            bulletTimer.Dispose();
            bullet.Dispose();
            bulletTimer = null;
            bullet = null;
        }        

        public List<PictureBox> ReturnList(List<PictureBox> EnemyList)
        {

            foreach (PictureBox x in EnemyList)
            {
                if (bullet.Bounds.IntersectsWith(x.Bounds))
                {
                    x.Visible = false;
                    EnemyList.Remove(x);
                    bulletTimer.Stop();
                    bulletTimer.Dispose();
                    bullet.Dispose();
                    break;

                }
            }
            return EnemyList;
        }

        private void BulletTimerEvent(object sender, EventArgs e)
        {
            if (facingDirection == "left")
            {
                bullet.Left -= speed;
            }
            if (facingDirection == "right")
            {
                bullet.Left += speed;
            }
            if (facingDirection == "up")
            {
                bullet.Top -= speed;
            }
            if (facingDirection == "down")
            {
                bullet.Top += speed;
            }
            if (facingDirection == "WD")
            {
                bullet.Top -= speed;
                bullet.Left += speed;
            }
            if (facingDirection == "WA")
            {
                bullet.Top -= speed;
                bullet.Left -= speed;
            }
            if (facingDirection == "SD")
            {
                bullet.Top += speed;
                bullet.Left += speed;
            }
            if (facingDirection == "SA")
            {
                bullet.Top += speed;
                bullet.Left -= speed;
            }


            for (int k = 0; k < horizontalWall.GetLength(0); k++)
            {
                for (int c = 0; c < horizontalWall.GetLength(1); c++)
                {
                    if (bullet.Left <= horizontalWall[k, c].formWall.Right && horizontalWall[k, c].formWall.Left <= bullet.Right && horizontalWall[k, c].formWall.Top <= bullet.Bottom && bullet.Top <= horizontalWall[k, c].formWall.Bottom)
                    {
                        if (horizontalWall[k, c].Alive)
                        {
                            horizontalWall[k, c].Health = horizontalWall[k, c].Health - damage;
                            ;
                            if (horizontalWall[k, c].Health <= 0)
                            {
                                horizontalWall[k, c].formWall.Visible = false;
                                horizontalWall[k, c].Alive = false;
                            }
                            else
                            {
                                if (horizontalWall[k, c].Health >= 80)
                                {

                                    horizontalWall[k, c].formWall.BackColor = Color.Gold;
                                }
                                else if (horizontalWall[k, c].Health >= 60)
                                {


                                    horizontalWall[k, c].formWall.BackColor = Color.Khaki;

                                }
                                else if (horizontalWall[k, c].Health >= 40)
                                {


                                    horizontalWall[k, c].formWall.BackColor = Color.PaleGoldenrod;

                                }
                                else if (horizontalWall[k, c].Health >= 20)
                                {


                                    horizontalWall[k, c].formWall.BackColor = Color.LemonChiffon;

                                }

                            }
                            Console.WriteLine(horizontalWall[k, c].Health);
                                
                            bulletTimer.Stop();
                            bulletTimer.Dispose();
                            bullet.Dispose();
                            

                        }
                    }
                
                            
                }
            }
            for (int k = 0; k < verticalWall.GetLength(0); k++)
            {
                for (int c = 0; c < verticalWall.GetLength(1); c++)
                {
                    if (bullet.Left <= verticalWall[k, c].formWall.Right && verticalWall[k, c].formWall.Left <= bullet.Right && verticalWall[k, c].formWall.Top <= bullet.Bottom && bullet.Top <= verticalWall[k, c].formWall.Bottom)
                    {
                        if (verticalWall[k, c].Alive)
                        {
                            verticalWall[k, c].Health = verticalWall[k, c].Health - damage;
                            if (verticalWall[k, c].Health <= 0)
                            {
                                verticalWall[k, c].formWall.Visible = false;
                                verticalWall[k, c].Alive = false;
                            }
                            else
                            {
                                if (verticalWall[k, c].Health >= 80)
                                {

                                    verticalWall[k, c].formWall.BackColor = Color.Gold;
                                }
                                else if (verticalWall[k, c].Health >= 60)
                                {


                                    verticalWall[k, c].formWall.BackColor = Color.Khaki;

                                }
                                else if (verticalWall[k, c].Health >= 40)
                                {


                                    verticalWall[k, c].formWall.BackColor = Color.PaleGoldenrod;

                                }
                                else if (verticalWall[k, c].Health >= 20)
                                {


                                    verticalWall[k, c].formWall.BackColor = Color.LemonChiffon;

                                }

                            }
                            bulletTimer.Stop();
                            bulletTimer.Dispose();
                            bullet.Dispose();


                        }
                    }


                }
            }

            ReturnList(enemyList);




            if (bullet.Location.Y >= gameBoxPicture.Location.Y + gameBoxPicture.Height - bullet.Height - 1 || bullet.Location.Y <= gameBoxPicture.Location.Y + 1 || bullet.Location.X <= gameBoxPicture.Location.X + 1 || bullet.Location.X >= gameBoxPicture.Location.X + gameBoxPicture.Width - bullet.Width - 1)
            {
                
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
                
            }
            

        }
    }

}
