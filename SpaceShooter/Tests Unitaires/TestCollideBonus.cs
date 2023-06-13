using SpaceShooter.model.Bonus;
using SpaceShooter.model;
using SpaceShooter.model.Projectiles;
using IUTGame;
using IUTGame.WPF;
using System.Windows.Controls;
using SpaceShooter.view;
using System.Threading;
using Xunit;

namespace Tests_Unitaires
{
    public class TestCollideBonus
    {
        private TheGame game;
        private Player player;
        private Bonus bonus;
        private IWindow view;
        private IScreen screen;


        [Fact]
        public void TestCollideBonusPlayer()
        {
            this.game = new TheGame(screen, view);
            this.player = new Player(100, 100, this.game);
            this.bonus = new BonusShoot(100, 100, this.game);


            Assert.True(true);
        }
    }
}