using IUTGame;
using SpaceShooter.model.Ennemies;
using SpaceShooter.model.Projectiles;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_Unitaires.TestAnimateEnnemy
{
    public class TestPositionEnemy
    {

        private Game game;
        private Enemy enemy;
        private FakeScreen s;
        private FakeWindow w;
        private Projectile projectile;



        [Fact]
        public void TestPositionSoldier()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            enemy = new Soldier(100, 100, game);
            enemy.Animate(new TimeSpan(0,0,10));

            Assert.True(enemy.Left != 100);
            Assert.True(enemy.Top != 100);
        }
    }
}
             

