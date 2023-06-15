using IUTGame;
using SpaceShooter.model;
using System.Windows.Input;
using SpaceShooter.model.Ennemies;
using SpaceShooter.model.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Windows.Media.Media3D;

namespace Tests_Unitaires.TestMoovePlayer
{
    /// <summary>
    /// test unitaire des mouvements du joueur
    /// </summary>
    /// <author>Théo Cornu</author>
    public class TestPlayerMovement
    {
        [Fact]
        public void TestPlayerMoveLeft()
        {
            FakeScreen s = new FakeScreen();
            FakeWindow w = new FakeWindow();
            Game game = new TheGame(s, w);
            Player player = new Player(100, 100, game);
            double initialLeft = player.Left;

            player.KeyDown(Key.Left);

            Assert.Equal(initialLeft - player.Speed, player.Left);
        }

        [Fact]
        public void TestPlayerMoveRight()
        {
            FakeScreen s = new FakeScreen();
            FakeWindow w = new FakeWindow();
            Game game = new TheGame(s, w);
            Player player = new Player(100, 100, game);
            double initialLeft = player.Left;

            player.KeyDown(Key.Right);

            Assert.Equal(initialLeft + player.Speed, player.Left);
        }

        [Fact]
        public void TestPlayerMoveUp()
        {
            FakeScreen s = new FakeScreen();
            FakeWindow w = new FakeWindow();
            Game game = new TheGame(s, w);
            Player player = new Player(100, 100, game);
            double initialTop = player.Top;

            player.KeyDown(Key.Up);

            Assert.Equal(initialTop - player.Speed, player.Top);
        }

        [Fact]
        public void TestPlayerMoveDown()
        {
            FakeScreen s = new FakeScreen();
            FakeWindow w = new FakeWindow();
            Game game = new TheGame(s, w);
            Player player = new Player(100, 100, game);
            double initialTop = player.Top;

            player.KeyDown(Key.Down);

            Assert.Equal(initialTop + player.Speed, player.Top);
        }
    }
}