﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame
{
    public partial class ComingSoon : Form
    {
        public ComingSoon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu NewMainMenu = new MainMenu();
            this.Hide();
            NewMainMenu.Show();
        }
    }
}
