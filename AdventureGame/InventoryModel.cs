using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class InventoryModel
    {

        public int Health { get; set; }
        public int ZBucks { get; set; }

        public InventoryModel(int Health, int ZBucks)
        {
            this.Health = Health;
            this.ZBucks = ZBucks;
        }

        public class Gun
        {
            public string Name { get; set; }
            public string Rarity { get; set; }
            public int Damage { get; set; }

            public Image? Icon { get; set; }

            public Gun(string name, string rarity, int damage, Image? icon)
            {
                Name = name;
                Rarity = rarity;
                Damage = damage;
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

            //Test

            public bool hasGun()
            {
                if (gun == null) return false; return true;
            }

        }

        public Gun GetGun()
        {
            Dictionary<int, Gun> gunsDict = new Dictionary<int, Gun>();
            gunsDict.Add(1, new Gun("Scar", "Gold", 40, (Image)Properties.Resources.scar));
            gunsDict.Add(2, new Gun("Bolt", "Blue", 50, (Image)Properties.Resources.bolt));
            gunsDict.Add(3, new Gun("Pistol", "Gray", 10, (Image)Properties.Resources.pistol));
            gunsDict.Add(4, new Gun("Pump", "Blue", 80, (Image)Properties.Resources.pump));

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

}
