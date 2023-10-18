using System;
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
    public partial class Locker : Form
    {

        public int skin;

        public Locker()
        {
            InitializeComponent();
        }

        private void renegaterBTN_Click(object sender, EventArgs e)
        {
            skin = 1;
        }

        private void skullTrooperBTN_Click(object sender, EventArgs e)
        {
            skin = 2;
        }
    }
}
