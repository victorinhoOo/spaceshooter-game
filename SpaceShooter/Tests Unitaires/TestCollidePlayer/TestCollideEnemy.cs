using IUTGame;
using SpaceShooter.model.Bonus;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceShooter.model.Ennemies;
using SpaceShooter.model.Projectiles;

namespace Tests_Unitaires.TestCollidePlayer
{
    public class TestCollideEnemy
    {
        private Game game;
        private Player player;
        private Enemy enemy;
        private FakeScreen s;
        private FakeWindow w;
        private Projectile projectile;

        [Fact]
        public void TestCollideSoldier()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            player = new Player(100, 100, game);
            enemy = new Soldier(100, 100, game);

            Assert.True(player.IsCollide(enemy));

            player.CollideEffect(enemy);

            Assert.True(player.IsExploding);
        }

        [Fact]
        public void TestCollideOfficer()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            player = new Player(100, 100, game);
            enemy = new Officer(100, 100, game);

            Assert.True(player.IsCollide(enemy));

            player.CollideEffect(enemy);

            Assert.True(player.IsExploding);
        }


        [Fact]
        public void TestCollideBullet()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            player = new Player(100, 100, game);
            projectile = new Bullet(100, 100, game);

            Assert.True(player.IsCollide(projectile));

            player.CollideEffect(projectile);

            Assert.True(player.IsExploding);
        }

        [Fact]
        public void TestCollideLaser()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            player = new Player(100, 100, game);
            projectile = new Laser(100, 100, game);

            Assert.True(player.IsCollide(projectile));

            player.CollideEffect(projectile);

            Assert.True(player.IsExploding);
        }


    }
}
