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
            InventoryModel Player = new InventoryModel(100, 100, Properties.Resources.defaultSkin);
            Lobby lobby = new Lobby(Player);
            this.Hide();
            lobby.Show();
        }

        bool Host = false;

        private void SaveWorldBTN_Click(object sender, EventArgs e)
        {
            TestGame comingSoon = new TestGame(Host);
            this.Hide();
            comingSoon.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Host = true;
        }
    }
}