﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame
{
    public partial class Map : Form
    {
        // Makes a 2d array for the map spots
        MapLocation[,] map = new MapLocation[3, 3];

        // Making all the map spots
        MapLocation pos0x0 = new MapLocation("Pleasent Park");
        MapLocation pos1x0 = new MapLocation("Lazy Links");
        MapLocation pos2x0 = new MapLocation("Wailing Woods");
        MapLocation pos0x1 = new MapLocation("Tilted Towers");
        MapLocation pos1x1 = new MapLocation("Dusty Divot");
        MapLocation pos2x1 = new MapLocation("Retail Row");
        MapLocation pos0x2 = new MapLocation("Frosty Flights");
        MapLocation pos1x2 = new MapLocation("Fatal Fields");
        MapLocation pos2x2 = new MapLocation("Paradise Palms");

        
        // Making inventory slots
        InventoryModel.InventorySlot inventory1 = new InventoryModel.InventorySlot(1, null, null);
        InventoryModel.InventorySlot inventory2 = new InventoryModel.InventorySlot(2, null, null);
        InventoryModel.InventorySlot inventory3 = new InventoryModel.InventorySlot(3, null, null);
        InventoryModel.InventorySlot inventory4 = new InventoryModel.InventorySlot(4, null, null);
        InventoryModel.InventorySlot inventory5 = new InventoryModel.InventorySlot(5, null, null);
        InventoryModel.InventorySlot inventory6 = new InventoryModel.InventorySlot(6, null, null);


        // Lists of the picture box slots and the model inventory slots
        public List<PictureBox> slotsList = new List<PictureBox>();
        public List<InventoryModel.InventorySlot> inventorySlots = new List<InventoryModel.InventorySlot>();

        // Adds all the slots and inventoryslots to their lists
        public void AddSlots()
        {

            slotsList.Add(slot1);
            slotsList.Add(slot2);
            slotsList.Add(slot3);
            slotsList.Add(slot4);
            slotsList.Add(slot5);
            slotsList.Add(slot6);

            inventorySlots.Add(inventory1);
            inventorySlots.Add(inventory2);
            inventorySlots.Add(inventory3);
            inventorySlots.Add(inventory4);
            inventorySlots.Add(inventory5);
            inventorySlots.Add(inventory6);
        }

        // Checks if a slot has an item or gun in it
        public InventoryModel.InventorySlot CheckIfHasSomthingInSlot()
        {


            if (inventory1.hasGun() == false && inventory1.hasItem() == false)
            {
                return inventory1;
            }
            else if (inventory2.hasGun() == false && inventory2.hasItem() == false)
            {
                return inventory2;
            }
            else if (inventory3.hasGun() == false || inventory3.hasItem() == false)
            {
                return inventory3;
            }
            else if (inventory4.hasGun() == false || inventory4.hasItem() == false)
            {
                return inventory4;
            }
            else if (inventory5.hasGun() == false || inventory5.hasItem() == false)
            {
                return inventory5;
            }
            else
            {
                return inventory6;
            }

        }

        Settings settings;
        public InventoryModel Player;

        public Map(InventoryModel player)
        {
            InitializeComponent();
            Player = player;

            healthBar.Value = Player.Player.Health;

            // Makes the settings pannel
            settings = new Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            settings.FormBorderStyle = FormBorderStyle.None;
            this.settingsPannel.Controls.Add(settings);

            // Setting all the map spots into the 2d array
            map[0, 0] = pos0x0;
            map[1, 0] = pos1x0;
            map[2, 0] = pos2x0;
            map[0, 1] = pos0x1;
            map[1, 1] = pos1x1;
            map[2, 1] = pos2x1;
            map[0, 2] = pos0x2;
            map[1, 2] = pos1x2;
            map[2, 2] = pos2x2;

            btn0x0.Text = map[0, 0].locationName + "\n" + "\n" + "Players: " + map[0, 0].playersLanding.ToString();
            btn1x0.Text = map[1, 0].locationName + "\n" + "\n" + "Players: " + map[1, 0].playersLanding.ToString();
            btn2x0.Text = map[2, 0].locationName + "\n" + "\n" + "Players: " + map[2, 0].playersLanding.ToString();
            btn0x1.Text = map[0, 1].locationName + "\n" + "\n" + "Players: " + map[0, 1].playersLanding.ToString();
            btn1x1.Text = map[1, 1].locationName + "\n" + "\n" + "Players: " + map[1, 1].playersLanding.ToString();
            btn2x1.Text = map[2, 1].locationName + "\n" + "\n" + "Players: " + map[2, 1].playersLanding.ToString();
            btn0x2.Text = map[0, 2].locationName + "\n" + "\n" + "Players: " + map[0, 2].playersLanding.ToString();
            btn1x2.Text = map[1, 2].locationName + "\n" + "\n" + "Players: " + map[1, 2].playersLanding.ToString();
            btn2x2.Text = map[2, 2].locationName + "\n" + "\n" + "Players: " + map[2, 2].playersLanding.ToString();

            /* InventoryModel.Gun gun = inventory.GetGun();
             inventory1.gun = gun*/

            AddSlots();

            // Refreshes the slot icons
            InventoryModel.RefreshInventory(slotsList, inventorySlots);


        }

        Random random = new Random();

        // It sets a new gun to the next avaliable slot and a new item then adds a random amount of materials and ammo to the player then opens a new FightingMinigame Form
        private void RunNewMinigame()
        {
            InventoryModel.InventorySlot available = CheckIfHasSomthingInSlot();
            InventoryModel.Gun gun = Player.GetGun();
            available.gun = gun;
            InventoryModel.InventorySlot available2 = CheckIfHasSomthingInSlot();
            InventoryModel.Item item = Player.GetItem();
            available2.item = item;
            Player.Player.Materials = Player.Player.Materials + random.Next(30, 100);
            Player.Player.Ammo = Player.Player.Ammo + random.Next(10, 50);
            InventoryModel.RefreshInventory(slotsList, inventorySlots);
            FightingMinigame miniGame = new FightingMinigame(inventorySlots, Player, map[0, 0].playersLanding);
            this.Hide();
            miniGame.Show();
        }


        // Runs RunNewMinigame on click
        private void btn0x0_Click(object sender, EventArgs e)
        {

            RunNewMinigame();


        }

        // Runs RunNewMinigame on click
        private void btn1x0_Click(object sender, EventArgs e)
        {

            RunNewMinigame();
        }

        // Runs RunNewMinigame on click
        private void btn2x0_Click(object sender, EventArgs e)
        {

            RunNewMinigame();
        }

        // Runs RunNewMinigame on click
        private void btn0x1_Click(object sender, EventArgs e)
        {

            RunNewMinigame();
        }

        // Runs RunNewMinigame on click
        private void btn1x1_Click(object sender, EventArgs e)
        {
            RunNewMinigame();
        }

        // Runs RunNewMinigame on click
        private void btn2x1_Click(object sender, EventArgs e)
        {
            RunNewMinigame();
        }

        // Runs RunNewMinigame on click
        private void btn0x2_Click(object sender, EventArgs e)
        {
            RunNewMinigame();
        }

        // Runs RunNewMinigame on click
        private void btn1x2_Click(object sender, EventArgs e)
        {

            RunNewMinigame();

        }

        // Runs RunNewMinigame on click
        private void btn2x2_Click(object sender, EventArgs e)
        {
            RunNewMinigame();

        }

        bool settingsOn = false;
       
        // Makes the settings pannel visible and not on click
        private void settingsBTN_Click(object sender, EventArgs e)
        {
            if (settingsOn == false)
            {

                settings.Show();
                settingsPannel.Show();
                settingsOn = true;
            }
            else
            {
                settingsPannel.Hide();
                settingsOn = false;
            }
        }
    }
}
