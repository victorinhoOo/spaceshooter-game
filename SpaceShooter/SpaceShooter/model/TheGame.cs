using IUTGame;
using SpaceShooter.model.Ennemies;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SpaceShooter.model
{
    public class TheGame : IUTGame.Game
    {
        public TheGame(IScreen screen) : base(screen, "Sprites", "Sounds")
        {

        }

        protected override void InitItems()
        {
            double y = this.Screen.Height / 2;
            double x = this.Screen.Width / 2;
            Player player = new Player(x, y, this);
            AddItem(player);
            AddItem(new GeneratorEnemy(this));

            //PlayBackgroundMusic("backGroundMusic.mp3");

        }

        protected override void RunWhenLoose()
        {
            throw new NotImplementedException();
        }

        protected override void RunWhenWin()
        {
            throw new NotImplementedException();
        }
    }
}