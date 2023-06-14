using IUTGame;
using SpaceShooter.model;
using SpaceShooter.model.Bonus;
using SpaceShooter.model.Ennemies;
using SpaceShooter.model.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tests_Unitaires.TestAnimateBonus
{
    /// <author>Alexandre Hugot</author>
    public class TestMoovementBonus
    {
        private Game game;
        private Bonus bonus;
        private FakeScreen s;
        private FakeWindow w;


        [Fact]
        public void TestMoovementBonusSpeed()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            bonus = new BonusSpeed(100, 100, game);
            double initialTop = bonus.Top;

            TimeSpan dt = new TimeSpan(0, 0, 10);
            bonus.Animate(dt);


            Assert.Equal(initialTop + 100 * dt.TotalSeconds, bonus.Top);
        }

        [Fact]
        public void TestMoovementBonusShoot()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            bonus = new BonusShoot(100, 100, game);
            double initialTop = bonus.Top;

            TimeSpan dt = new TimeSpan(0, 0, 10);
            bonus.Animate(dt);


            Assert.Equal(initialTop + 100 * dt.TotalSeconds, bonus.Top);
        }
    }
}
