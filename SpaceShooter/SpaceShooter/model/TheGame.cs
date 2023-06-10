using IUTGame;
using SpaceShooter.model.Space;
using SpaceShooter.model.Vaisseaux.Enemi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model
{
    public class TheGame : IUTGame.Game
    {
        public TheGame(IScreen screen) : base(screen, "Sprites", "Sounds")
        {
            
        }

        protected override void InitItems()
        {
            double x = this.Screen.Width / 2;
            double y = this.Screen.Height / 2;
            Player player = new Player(x, y, this);
            AddItem(player);
            AddItem(new GeneratorEnemy(this));
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
