using System;
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
using System.Runtime.InteropServices;

namespace AdventureGame
{
    

    public class InventoryModel
    {
        public int ZBucks { get; set; }
        public Image Skin { get; set; }
        public Player Player { get; set; }




        public InventoryModel(int zBucks ,Image skin, Player player)
        {
            ZBucks = zBucks;
            Skin = skin;
            Player = player;
        }

        public class Gun
        {
            public string Name { get; set; }
            public string Rarity { get; set; }
            public int Damage { get; set; }
            public int Speed { get; set; }
            public int Magazine { get; set; }
            public int Ammo { get; set; }
            public Image? Icon { get; set; }

            public Gun(string name, string rarity, int damage, int speed, int magazine, int ammo, Image? icon)
            {
                Name = name;
                Rarity = rarity;
                Damage = damage;
                Speed = speed;
                Magazine = magazine;
                Ammo = ammo;
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
            gunsDict.Add(1, new Gun("Scar", "Gold", 30, 5, 20, 20, (Image)Properties.Resources.scarIcon));
            gunsDict.Add(2, new Gun("Bolt", "Blue", 100, 10, 1, 1, (Image)Properties.Resources.boltIcon));
            gunsDict.Add(3, new Gun("Pistol", "Gray", 15, 5, 15, 15, (Image)Properties.Resources.pistolIcon));
            gunsDict.Add(4, new Gun("Pump", "Blue", 120, 3, 3, 3, (Image)Properties.Resources.pumpIcon));

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
                    slotslist[i].BackgroundImage = null;
                }
            }
        }

    }

    public class Player
    {
       
        public int Health { get; set; }
        public int Shield { get; set; }
        public int Ammo { get; set; }
        public int Materials { get; set; }
        public Player Target { get; set; }
        public PictureBox PlayerBox { get; set; }
        public bool Alive { get; set;}
        public bool CanWin { get; set; }
        public bool isClient { get; set; } 
        public ProgressBar healthBar { get; set; }
        public ProgressBar shieldBar { get; set; }
        public bool Reloading { get; set; }
        public bool Healing { get; set; }

        public Player(int health, int shield,  int ammo, Player Target , bool Alive, PictureBox playerBox, int materials, bool isClient, bool canWin, ProgressBar healthBar, ProgressBar shieldBar, bool Reloading, bool Healing)
        {
            Health = health;
            Shield = shield;
            Ammo = ammo;
            this.Alive = Alive;
            this.Target = Target;
            PlayerBox = playerBox;
            Materials = materials;
            this.isClient = isClient;
            this.CanWin = canWin;
            this.healthBar = healthBar;
            this.shieldBar = shieldBar;
            this.Reloading = Reloading;
            this.Healing = Healing;
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
            playersLanding = rand.Next(1, 11);
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
        public Player playerShooter { get; set; }
        public List<Player> enemyList { get; set; }
        public PictureBox gameBoxPicture { get; set; }
        public PictureBox player { get; set; }

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

            foreach (Player player in enemyList)
            {

                if (player.Alive && player.PlayerBox.Bounds.IntersectsWith(bullet.Bounds) && player.PlayerBox != playerShooter.PlayerBox && playerShooter.isClient == false)
                {

                    bulletTimer.Stop();
                    bulletTimer.Dispose();
                    bullet.Dispose();
                    if (player.Shield >= 10)
                    {
                        player.Shield = player.Shield - 10;
                        player.shieldBar.Value = player.Shield;
                    }
                    else if (player.Shield < 10 && player.Shield != 0)
                    {
                        player.Health = player.Health + player.Shield;
                        player.Health = player.Health - 10;
                        player.shieldBar.Value = 0;
                        player.Shield = 0;

                        player.healthBar.Value = player.Health;
                    }
                    else if (player.Health > 10)
                    { 
                        player.Health = player.Health - 10;
                        player.healthBar.Value = player.Health;
                    }
                    else if (player.Health + player.Shield <= 10)
                    {
                        player.Alive = false;
                        player.shieldBar.Visible = false;
                        player.healthBar.Visible = false;

                        player.shieldBar.Value = 0;
                        player.Shield = 0;

                        player.healthBar.Value = 0;
                        player.Health = 0;

                        int cat = 0;

                        System.Windows.Forms.Timer explosion = new System.Windows.Forms.Timer();
                        explosion.Interval = 50;
                        explosion.Tick += new EventHandler(ShootExplosionTimerEvent);
                        explosion.Start();


                        void ShootExplosionTimerEvent(object sender, EventArgs e)
                        {
                            if (cat == 0)
                            {
                                player.PlayerBox.Size = new Size(11, 11);
                            }
                            if (cat == 1)
                            {
                                player.PlayerBox.Size = new Size(12, 12);
                            }
                            if (cat == 2)
                            {
                                player.PlayerBox.Size = new Size(13, 13);
                            }

                            if (cat == 3)
                            {
                                player.PlayerBox.Size = new Size(14, 14);
                            }
                            if (cat == 4)
                            {
                                player.PlayerBox.Size = new Size(15, 15);
                            }
                            if (cat == 5)
                            {
                                player.PlayerBox.Size = new Size(15, 15);
                            }
                            if (cat == 6)
                            {
                                player.PlayerBox.Size = new Size(16, 16);
                            }
                            if (cat == 7)
                            {
                                player.PlayerBox.Size = new Size(17, 17);
                            }
                            if (cat == 8)
                            {
                                player.PlayerBox.Size = new Size(18, 18);
                            }
                            if (cat == 9)
                            {
                                player.PlayerBox.Visible = false;
                                
                            }
                            cat++;
                        }
                    }
                }
                else if (player.Alive && player.PlayerBox.Bounds.IntersectsWith(bullet.Bounds) && player.PlayerBox != playerShooter.PlayerBox && playerShooter.isClient)
                {
                    bulletTimer.Stop();
                    bulletTimer.Dispose();
                    bullet.Dispose();

                    player.healthBar.Value = player.Health;
                    player.shieldBar.Value = player.Shield;

                    Console.WriteLine(damage);
                    if (player.Shield >= damage)
                    {
                        player.Shield = player.Shield - damage;
                        player.shieldBar.Value = player.Shield;
                    }
                    else if (player.Shield < damage && player.Shield != 0)
                    {
                        player.Health = player.Health + player.Shield;
                        player.Health = player.Health - damage;
                        player.Shield = 0;

                        player.shieldBar.Value = player.Shield;
                        player.healthBar.Value = player.Health;
                        Console.WriteLine(player.shieldBar.Value);
                        Console.WriteLine(player.Health);
                    }
                    else if (player.Health > damage && player.Shield == 0)
                    {
                        player.Health = player.Health - damage;
                        player.healthBar.Value = player.Health;
                    }
                    else if (player.Health + player.Shield <= damage)
                    {

                        player.Alive = false;                        
                        player.healthBar.Visible = false;
                        player.shieldBar.Visible = false;

                        player.shieldBar.Value = 0;
                        player.Shield = 0;

                        player.healthBar.Value = 0;
                        player.Health = 0;
                        int cat = 0;

                        System.Windows.Forms.Timer explosion = new System.Windows.Forms.Timer();
                        explosion.Interval = 50;
                        explosion.Tick += new EventHandler(ReloadingTimerEvent);
                        explosion.Start();


                        void ReloadingTimerEvent(object sender, EventArgs e)
                        { 
                            if (cat == 0)
                            {
                                player.PlayerBox.Size = new Size(11, 11);
                            }
                            if (cat == 1)
                            {
                                player.PlayerBox.Size = new Size(12, 12);
                            }
                            if (cat == 2)
                            {
                                player.PlayerBox.Size = new Size(13, 13);
                            }

                            if (cat == 3)
                            {
                                player.PlayerBox.Size = new Size(14, 14);
                            }
                            if (cat == 4)
                            {
                                player.PlayerBox.Size = new Size(15, 15);
                            }
                            if (cat == 5)
                            {
                                player.PlayerBox.Size = new Size(15, 15);
                            }
                            if (cat == 6)
                            {
                                player.PlayerBox.Size = new Size(16, 16);
                            }
                            if (cat == 7)
                            {
                                player.PlayerBox.Size = new Size(17, 17);
                            }
                            if (cat == 8)
                            {
                                player.PlayerBox.Size = new Size(18, 18);
                            }
                            if (cat == 9)
                            {
                                player.PlayerBox.Visible = false;

                            }
                            cat++;
                        }

                    }
                }

            }


            if (bullet.Location.Y >= gameBoxPicture.Location.Y + gameBoxPicture.Height - bullet.Height - 1 || bullet.Location.Y <= gameBoxPicture.Location.Y + 1 || bullet.Location.X <= gameBoxPicture.Location.X + 1 || bullet.Location.X >= gameBoxPicture.Location.X + gameBoxPicture.Width - bullet.Width - 1)
            {
                
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                
            }
            

        }
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }

}
