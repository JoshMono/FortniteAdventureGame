namespace AdventureGame
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void BattleRoyalBTN_Click(object sender, EventArgs e)
        {
            // Makes a new Player model
            Player clientPlayer = new Player(100, 0, 0, null, false, null, 0, true, true, null, null, false, false, false);

            // Makes a new Inventory model
            InventoryModel Player = new InventoryModel(100, 0, Properties.Resources.defaultSkin, clientPlayer);

            // Loads lobby
            Lobby lobby = new Lobby(Player);
            this.Hide();
            lobby.Show();
        }

        bool Host = false;

        private void SaveWorldBTN_Click(object sender, EventArgs e)
        {
            /*TestGame comingSoon = new TestGame(Host, ipAdress.Text);
            this.Hide();
            comingSoon.Show();*/
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Host = true;
        }
    }
}