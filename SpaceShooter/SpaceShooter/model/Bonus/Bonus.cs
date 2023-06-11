using IUTGame;
using SpaceShooter.model.Ennemies;
using SpaceShooter.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Bonus
{
    public abstract class Bonus : GameItem, IAnimable
    {
        public Bonus(double x, double y, Game game, string spriteName, int zindex = 0) : base(x, y, game, spriteName, zindex)
        {
        }

        public override string TypeName => "Bonus";

        public void Animate(TimeSpan dt)
        {
           
        }

        public override void CollideEffect(GameItem other)
        {
            if(other.TypeName == "Player")
            {
                TheGame.RemoveItem(this);
            }
        }



    }
}
