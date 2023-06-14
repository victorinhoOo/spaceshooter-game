using IUTGame;
using SpaceShooter.model.Bonus;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceShooter.model.Projectiles;

namespace Tests_Unitaires.TestAnimateProjectiles
{
    /// <author>Alexandre Hugot</author>
    public class TestMoovementProjectiles
    {
        private Game game;
        private Projectile projectile;
        private FakeScreen s;
        private FakeWindow w;

        [Fact]
        public void TestMoovementBullet()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            projectile = new Bullet(100, 100, game);
            double initialTop = projectile.Top;
            double initialLeft = projectile.Left;
            TimeSpan dt = new TimeSpan(0, 0, 3);
            projectile.Animate(dt);

            double speed = projectile.Speed;
            double angleInRadians = 10 * Math.PI / 180; // Convert degrees to radians
            double expectedX = initialTop + speed * Math.Cos(angleInRadians) * dt.TotalSeconds;
            double expectedY = initialLeft - speed * Math.Sin(angleInRadians) * dt.TotalSeconds;

            // Assert
            Assert.Equal(expectedX, projectile.Top, 3); // Adjust the precision (3 decimal places) as needed
            Assert.Equal(expectedY, projectile.Left, 3); // Adjust the precision (3 decimal places) as needed
        }

        [Fact]
        public void TestMoovementLaser()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            projectile = new Laser(100, 100, game);
            double initialTop = projectile.Top;
            double initialLeft = projectile.Left;
            TimeSpan dt = new TimeSpan(0, 0, 3);
            projectile.Animate(dt);

            double speed = projectile.Speed;
            double angleInRadians = 10 * Math.PI / 180; // Convertion en radians
            double expectedX = initialTop + speed * Math.Cos(angleInRadians) * dt.TotalSeconds;
            double expectedY = initialLeft - speed * Math.Sin(angleInRadians) * dt.TotalSeconds;

            // Assert
            Assert.Equal(expectedX, projectile.Top, 3); // Ajuste la précision (à 3 déciamales prêt)
            Assert.Equal(expectedY, projectile.Left, 3); // Ajuste la précision (à 3 déciamales prêt)
        }

        [Fact]
        public void TestMoovementPlayerBullet()
        {
            w = new FakeWindow();
            s = new FakeScreen();


            game = new TheGame(s, w);
            projectile = new PlayerBullet(100, 100, game);
            double initialTop = projectile.Top;
            double initialLeft = projectile.Left;
            TimeSpan dt = new TimeSpan(0, 0, 3);
            projectile.Animate(dt);


            // Assert
            Assert.Equal(initialTop - projectile.Speed * dt.TotalSeconds, projectile.Top, 3); // Ajuste la précision (à 3 déciamales prêt)
            Assert.Equal(initialLeft, projectile.Left, 3); 
        }
    }
}
