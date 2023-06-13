using SpaceShooter.model.Bonus;
using SpaceShooter.model;
using SpaceShooter.model.Projectiles;
using IUTGame;
using IUTGame.WPF;
using System.Windows.Controls;
using SpaceShooter.view;
using System.Threading;
using Xunit;
using System.Runtime.CompilerServices;

namespace Tests_Unitaires.TestCollidePlayer
{
    public class TestCollideBonus
    {
        private Game game;
        private Player player;
        private Bonus bonus;
        private FakeScreen s;
        private FakeWindow w;


        [Fact]
        public void TestCollide()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            player = new Player(100, 100, game);
            bonus = new BonusSpeed(100, 100, game);

            Assert.True(player.IsCollide(bonus));
        }

        [Fact]
        public void TestBonusSpeed()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            bonus = new BonusSpeed(100, 100, game);
            player = new Player(100, 100, game);
            player.CollideEffect(bonus);

            Assert.Equal(11, player.Speed);
        }

        [Fact]
        public void TestBonusShoot()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            bonus = new BonusShoot(100, 100, game);
            player = new Player(100, 100, game);
            TimeSpan initial = player.ShootRecoveryTime;
            player.CollideEffect(bonus);

            Assert.True(player.ShootRecoveryTime < initial);
        }


    }
}