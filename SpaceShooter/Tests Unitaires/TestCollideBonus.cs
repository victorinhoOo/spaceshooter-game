using SpaceShooter.model.Bonus;
using SpaceShooter.model;
using SpaceShooter.model.Projectiles;
using IUTGame;
using IUTGame.WPF;
using System.Windows.Controls;
using SpaceShooter.view;

namespace Tests_Unitaires
{
    public class TestCollideBonus
    {
        private TheGame game;
        private Player player;
        private Bonus bonus;


        [STAThread]
        [Fact]
        public bool TestCollideBonusPlayer()
        {
            this.game = new TheGame(new WPFScreen(new Canvas()), new GameWindow());
            this.player = new Player(100, 100, this.game);
            this.bonus = new BonusShoot(100, 100, this.game);

            return true;
        }
    }
}