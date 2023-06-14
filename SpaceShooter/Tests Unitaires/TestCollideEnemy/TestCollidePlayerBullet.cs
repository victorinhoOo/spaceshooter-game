using IUTGame;
using SpaceShooter.model.Ennemies;
using SpaceShooter.model.Projectiles;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Tests_Unitaires.TestCollideEnemy
{
    /// <summary>
    /// Test unitaires des collisions entre les balles du joueur et les ennemis
    /// </summary>
    /// <author>Victor Duboz</author>
    public class TestCollidePlayerBullet
    {
        private Game game;
        private Soldier soldier;
        private Officer officer;

        private FakeScreen s;
        private FakeWindow w;
        private Projectile projectile;

        [Fact]
        public void TestCollideSoldier()
        {

            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            soldier = new Soldier(100, 100, game);
            projectile = new PlayerBullet(100, 100, game);

            Assert.True(soldier.IsCollide(projectile));

            soldier.CollideEffect(projectile);

            Assert.True(soldier.IsExploding);
        }


        [Fact]
        public void TestCollideOfficer()
        {

            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            officer = new Officer(100, 100, game);
            projectile = new PlayerBullet(100, 100, game);

            Assert.True(officer.IsCollide(projectile));

            officer.CollideEffect(projectile);

            Assert.True(officer.IsExploding);
        }
    }
}
