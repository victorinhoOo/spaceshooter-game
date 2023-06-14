using IUTGame;
using SpaceShooter.model;
using SpaceShooter.model.Ennemies;
using Xunit;
using SpaceShooter.model.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Windows.Media.Media3D;

namespace Tests_Unitaires.TestGeneratorEnemy
{
    /// <summary>
    /// Test unitaire de la générations des ennemis
    /// </summary>
    /// <author>Victor Duboz</author>
    public class TestGeneratorEnemy
    {
        private FakeScreen s;
        private FakeWindow w;
        private TheGame g;
        private GeneratorEnemy ge;

        [Fact]
        public void TestEnemyGeneration()
        {
            s = new FakeScreen();
            w = new FakeWindow();
            g = new TheGame(s, w);
            ge = new GeneratorEnemy(g);

            ge.TimeToCreateAsteroid = new TimeSpan(0);
            ge.TimeToCreateSoldier = new TimeSpan(0);
            ge.TimeToCreateOfficer = new TimeSpan(0);

            // Vérifie que des ennemis ont été créés

            Assert.True(GeneratorEnemy.Amount > 0);
        }
    }
}
