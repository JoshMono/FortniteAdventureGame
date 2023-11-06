using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace AdventureGame
{
    public class InventoryModel
    {

        public int Health { get; set; }
        public int ZBucks { get; set; }
        public Image Skin { get; set; }



        public InventoryModel(int Health, int ZBucks, Image Skin)
        {
            this.Health = Health;
            this.ZBucks = ZBucks;
            this.Skin = Skin;
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

        public class InventorySlot
        {
            public int slot { get; set; }
            public Gun? gun { get; set; }

            public InventorySlot(int slot, Gun? gun)
            {
                this.slot = slot;
                this.gun = gun;
            }

            public bool hasGun()
            {
                if (gun == null) return false; return true;
            }

        }

        public Gun GetGun()
        {
            Dictionary<int, Gun> gunsDict = new Dictionary<int, Gun>();
            gunsDict.Add(1, new Gun("Scar", "Gold", 40, 5, (Image)Properties.Resources.scar));
            gunsDict.Add(2, new Gun("Bolt", "Blue", 50, 10, (Image)Properties.Resources.bolt));
            gunsDict.Add(3, new Gun("Pistol", "Gray", 10, 5, (Image)Properties.Resources.pistol));
            gunsDict.Add(4, new Gun("Pump", "Blue", 80, 3,(Image)Properties.Resources.pump));

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
                else
                {
                    slotslist[i].BackColor = Color.White;
                }
            }
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
        public bool hitWall { get; set; }
        public PictureBox gameBoxPicture { get; set; }
        public PictureBox player { get; set; }
        public PictureBox topGap { get; set; }
        public PictureBox sideGap { get; set; }

        public Wall[,] horizontalWall { get; set; }

        public Wall[,] verticalWall { get; set; }


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

            
        }

        public void BulletStop(Form form)
        {
            bulletTimer.Stop();
            bulletTimer.Dispose();
            bullet.Dispose();
            bulletTimer = null;
            bullet = null;


        }

        public bool hitWallReturn ()
        {

            return true;

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
                            horizontalWall[k, c].formWall.Visible = false;
                            horizontalWall[k, c].Alive = false;
                            bulletTimer.Stop();
                            bulletTimer.Dispose();
                            bullet.Dispose();
                            

                        }
                    }
                
                            
                }
            }

            if (bullet.Left < gameBoxPicture.Location.X || bullet.Left > sideGap.Width + gameBoxPicture.Width || bullet.Top < gameBoxPicture.Location.Y || bullet.Top > topGap.Height + gameBoxPicture.Height || hitWall)
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
