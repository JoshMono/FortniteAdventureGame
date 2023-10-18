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
            InventoryModel character = new InventoryModel(100, 100);
            Lobby lobby = new Lobby(character);
            this.Hide();
            lobby.Show();
        }

        private void SaveWorldBTN_Click(object sender, EventArgs e)
        {
            FightingMinigame comingSoon = new FightingMinigame(null);
            this.Hide();
            comingSoon.Show();
        }
    }
}