using IUTGame;
using SpaceShooter.model.Ennemies;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SpaceShooter.view;
namespace SpaceShooter.model
{
    public class TheGame : IUTGame.Game
    {
        public TheGame(IScreen screen) : base(screen, "Sprites", "Sounds")
        {

        }

        protected override void InitItems()
        {
            double y = 350;
            double x = this.Screen.Width / 2 -10;
            Player player = new Player(x, y, this);
            AddItem(player);
            AddItem(new GeneratorEnemy(this));

            //PlayBackgroundMusic("mainMusic.mp3");

        }

        protected override void RunWhenLoose()
        {
            
            LooseWindow loose = new LooseWindow();
            loose.Show();
            
        }

        protected override void RunWhenWin()
        {
            throw new NotImplementedException();
        }
    }
}