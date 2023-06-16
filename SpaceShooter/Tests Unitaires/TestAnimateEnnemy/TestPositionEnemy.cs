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
    /// <summary>
    /// Tests pour le déplacement des ennemis
    /// </summary>
    /// <author>Clément Boutet</author>
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


        [Fact]
        public void TestPositionOfficer()
        {

            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            enemy = new Officer(100, 100, game);
            enemy.Animate(new TimeSpan(0, 0, 10));

            Assert.True(enemy.Left != 100);
            Assert.True(enemy.Top != 100);
        }


        [Fact]
        public void TestPositionGeneral()
        {

            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            enemy = new General(100, 100, game);
            enemy.Animate(new TimeSpan(0, 0, 10));

            Assert.True(enemy.Left != 100);
            Assert.True(enemy.Top != 100);
        }

    }
}
             

