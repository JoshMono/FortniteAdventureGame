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
using static AdventureGame.InventoryModel;

namespace AdventureGame
{
    

    public class InventoryModel
    {

        // Makes a new Inventory Model
        public int ZBucks { get; set; }
        public int Wins { get; set; }
        public Image Skin { get; set; }
        public Player Player { get; set; }
        




        public InventoryModel(int zBucks, int wins ,Image skin, Player player)
        {
            ZBucks = zBucks;
            Wins = wins;
            Skin = skin;
            Player = player;
        }

        // Makes a new Gun Model
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

        // Makes a new Item model
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

        // Makes an new Inventory slot
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

            // Checks if the slot has a gun
            public bool hasGun()
            {
                if (gun == null) return false; return true;
            }

            // Checks if the slot has a item
            public bool hasItem()
            {
                if (item == null) return false; return true;
            }

        }   

        // Gets a random Item
        public Item GetItem()
        {
            Dictionary<int, Item> itemDict = new Dictionary<int, Item>();
            itemDict.Add(1, new Item("Mini", 0, 25, 3, (Image)Properties.Resources.miniIcon));
            Random rand = new Random();
            int itemId = rand.Next(1, 2);
            return itemDict[itemId];
        }

        // Gets a random Gun
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

        // Refreshes the slot icons
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

    // Makes a new Player Model
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
        public bool Pickaxing { get; set; }

        public Player(int health, int shield,  int ammo, Player Target , bool Alive, PictureBox playerBox, int materials, bool isClient, bool canWin, ProgressBar healthBar, ProgressBar shieldBar, bool Reloading, bool Healing, bool Pickaxing)
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
            this.Pickaxing = Pickaxing;
        }
    }

    // Makes a new Wall Model
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

    // Makes a new Map Location
    public class MapLocation
    {
        public string locationName { get; set; }
        public int playersLanding;
        public bool hasChest;

        public MapLocation(string locationName)
        {
            this.locationName = locationName;
            playersLanding = PlayersLandingChance();
        }

        // Randomises how many players are landing at a location
        public int PlayersLandingChance()
        {
            Random rand = new Random();
            playersLanding = rand.Next(1, 6);
            return playersLanding;
        }


    }

    // Makes a new bullet
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
        public InventoryModel inventoryModel { get; set; }
        public List<InventoryModel.InventorySlot> InventorySlotsList { get; set; }
        public List<PictureBox> slotsList { get; set; } 

        public Wall[,] horizontalWall { get; set; }

        public Wall[,] verticalWall { get; set; }

        public Color colour = Color.FromArgb(138, 95, 43);
        public int colourG;
        public int colourB;

        
        // Creates the bullet and timer
        public PictureBox bullet = new PictureBox();
        private System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();

        // Makes the picturebox on the form then starts the bulletTimer
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
        }      

        private void BulletTimerEvent(object sender, EventArgs e)
        {
            // If the players facing direction is left it will travel left
            if (facingDirection == "left")
            {
                bullet.Left -= speed;
            }

            // If the players facing direction is right it will travel right
            if (facingDirection == "right")
            {
                bullet.Left += speed;
            }

            // If the players facing direction is up it will travel up
            if (facingDirection == "up")
            {
                bullet.Top -= speed;
            }

            // If the players facing direction is down it will travel down
            if (facingDirection == "down")
            {
                bullet.Top += speed;
            }

            // If the players facing direction is Up and Right it will travel Up and Right
            if (facingDirection == "WD")
            {
                bullet.Top -= speed;
                bullet.Left += speed;
            }

            // If the players facing direction is Up and Left it will travel Up and Left
            if (facingDirection == "WA")
            {
                bullet.Top -= speed;
                bullet.Left -= speed;
            }

            // If the players facing direction is Down and Right it will travel Down and Right
            if (facingDirection == "SD")
            {
                bullet.Top += speed;
                bullet.Left += speed;
            }

            // If the players facing direction is Down and Left it will travel Down and Left
            if (facingDirection == "SA")
            {
                bullet.Top += speed;
                bullet.Left -= speed;
            }

            // Checks all the horizontal walls to see if the bullet has hit one of them and if it has it will take some of its health off
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

                            // Kills the bullet and stops the timer
                            bulletTimer.Stop();
                            bulletTimer.Dispose();
                            bullet.Dispose();
                            

                        }
                    }
                
                            
                }
            }

            // Checks all the vertical walls to see if the bullet has hit one of them and if it has it will take some of its health off
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

                            // Kills the bullet and stops the timer
                            bulletTimer.Stop();
                            bulletTimer.Dispose();
                            bullet.Dispose();


                        }
                    }


                }
            }

            // Loops through all the enemys too see if the bullet has hit one
            foreach (Player player in enemyList)
            {
                // Runs when the enemy who had shot the bullet isnt the user
                if (player.Alive && player.PlayerBox.Bounds.IntersectsWith(bullet.Bounds) && player.PlayerBox != playerShooter.PlayerBox && playerShooter.isClient == false)
                {
                    // Kills the bullet and stops the timer
                    bulletTimer.Stop();
                    bulletTimer.Dispose();
                    bullet.Dispose();

                    // Decides if the enemy is dead or how much to take off their shield and health
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
                        // Kills the enemy
                        player.Alive = false;
                        player.shieldBar.Visible = false;
                        player.healthBar.Visible = false;

                        player.shieldBar.Value = 0;
                        player.Shield = 0;

                        player.healthBar.Value = 0;
                        player.Health = 0;

                        int number = 0;

                        System.Windows.Forms.Timer explosion = new System.Windows.Forms.Timer();
                        explosion.Interval = 50;
                        explosion.Tick += new EventHandler(ShootExplosionTimerEvent);
                        explosion.Start();

                        // Does a sort of animation when the enemy dies
                        void ShootExplosionTimerEvent(object sender, EventArgs e)
                        {
                            if (number == 0)
                            {
                                player.PlayerBox.Size = new Size(21, 21);
                            }
                            if (number == 1)
                            {
                                player.PlayerBox.Size = new Size(22, 22);
                            }
                            if (number == 2)
                            {
                                player.PlayerBox.Size = new Size(23, 23);
                            }

                            if (number == 3)
                            {
                                player.PlayerBox.Size = new Size(24, 24);
                            }
                            if (number == 4)
                            {
                                player.PlayerBox.Size = new Size(25, 25);
                            }
                            if (number == 5)
                            {
                                player.PlayerBox.Size = new Size(25, 25);
                            }
                            if (number == 6)
                            {
                                player.PlayerBox.Size = new Size(26, 26);
                            }
                            if (number == 7)
                            {
                                player.PlayerBox.Size = new Size(27, 27);
                            }
                            if (number == 8)
                            {
                                player.PlayerBox.Size = new Size(28, 28);
                            }
                            if (number == 9)
                            {
                                player.PlayerBox.Visible = false;
                                
                            }
                            number++;
                        }
                    }
                }

                // Runs when the enemy who had shot the bullet is the user
                else if (player.Alive && player.PlayerBox.Bounds.IntersectsWith(bullet.Bounds) && player.PlayerBox != playerShooter.PlayerBox && playerShooter.isClient)
                {
                    // Kills the bullet and stops the timer
                    bulletTimer.Stop();
                    bulletTimer.Dispose();
                    bullet.Dispose();

                    // Sets the players health and shield progress bar to their health and shield
                    player.healthBar.Value = player.Health;
                    player.shieldBar.Value = player.Shield;

                    // Decides if the enemy is dead or how much to take off their shield and health
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
                    }

                    else if (player.Health > damage && player.Shield == 0)
                    {
                        player.Health = player.Health - damage;
                        player.healthBar.Value = player.Health;
                    }
                    else if (player.Health + player.Shield <= damage)
                    {
                        // Kills the enemy
                        player.Alive = false;                        
                        player.healthBar.Visible = false;
                        player.shieldBar.Visible = false;

                        player.shieldBar.Value = 0;
                        player.Shield = 0;

                        player.healthBar.Value = 0;
                        player.Health = 0;
                        int number = 0;

                        System.Windows.Forms.Timer explosion = new System.Windows.Forms.Timer();
                        explosion.Interval = 50;
                        explosion.Tick += new EventHandler(ReloadingTimerEvent);
                        explosion.Start();

                        // Does a sort of animation when the enemy dies
                        void ReloadingTimerEvent(object sender, EventArgs e)
                        {
                            if (number == 0)
                            {
                                player.PlayerBox.Size = new Size(21, 21);
                            }
                            if (number == 1)
                            {
                                player.PlayerBox.Size = new Size(22, 22);
                            }
                            if (number == 2)
                            {
                                player.PlayerBox.Size = new Size(23, 23);
                            }

                            if (number == 3)
                            {
                                player.PlayerBox.Size = new Size(24, 24);
                            }
                            if (number == 4)
                            {
                                player.PlayerBox.Size = new Size(25, 25);
                            }
                            if (number == 5)
                            {
                                player.PlayerBox.Size = new Size(25, 25);
                            }
                            if (number == 6)
                            {
                                player.PlayerBox.Size = new Size(26, 26);
                            }
                            if (number == 7)
                            {
                                player.PlayerBox.Size = new Size(27, 27);
                            }
                            if (number == 8)
                            {
                                player.PlayerBox.Size = new Size(28, 28);
                            }
                            if (number == 9)
                            {
                                player.PlayerBox.Visible = false;

                                // Gives the player a new gun and a new item and more ammo and materials

                                InventorySlot avaliable = CheckIfHasSomthingInSlot();
                                InventoryModel.Gun gun = inventoryModel.GetGun();
                                avaliable.gun = gun;

                                Random random = new Random();

                                InventoryModel.RefreshInventory(slotsList, InventorySlotsList);

                                InventoryModel.InventorySlot available2 = CheckIfHasSomthingInSlot();
                                InventoryModel.Item item = inventoryModel.GetItem();
                                available2.item = item;
                                player.Ammo = player.Ammo + random.Next(10, 50);
                                player.Materials = player.Materials + random.Next(30, 100);
                                InventoryModel.RefreshInventory(slotsList, InventorySlotsList);

                            }
                            number++;
                        }

                    }
                }

            }

            // Checks if a slot has an item or gun in it
            InventoryModel.InventorySlot CheckIfHasSomthingInSlot()
            {


                if (InventorySlotsList[0].hasGun() == false && InventorySlotsList[0].hasItem() == false)
                {
                    return InventorySlotsList[0];
                }
                else if (InventorySlotsList[1].hasGun() == false && InventorySlotsList[1].hasItem() == false)
                {
                    return InventorySlotsList[1];
                }
                else if (InventorySlotsList[2].hasGun() == false && InventorySlotsList[2].hasItem() == false)
                {
                    return InventorySlotsList[2];
                }
                else if (InventorySlotsList[3].hasGun() == false && InventorySlotsList[3].hasItem() == false)
                {
                    return InventorySlotsList[3];
                }
                else if (InventorySlotsList[4].hasGun() == false && InventorySlotsList[4].hasItem() == false)
                {
                    return InventorySlotsList[4];
                }
                else
                {
                    return InventorySlotsList[5];
                }
            }

            // Kills the bullet and timer if it goes outside the gamebox
            if (bullet.Location.Y >= gameBoxPicture.Location.Y + gameBoxPicture.Height - bullet.Height - 1 || bullet.Location.Y <= gameBoxPicture.Location.Y + 1 || bullet.Location.X <= gameBoxPicture.Location.X + 1 || bullet.Location.X >= gameBoxPicture.Location.X + gameBoxPicture.Width - bullet.Width - 1)
            {

                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();

            }
            
            

        }
    }

}
