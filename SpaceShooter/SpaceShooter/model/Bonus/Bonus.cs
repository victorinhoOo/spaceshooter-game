using IUTGame;
using SpaceShooter.model.Ennemies;
using SpaceShooter.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpaceShooter.model.Bonus
{
    public abstract class Bonus : GameItem, IAnimable
    {

        private TimeSpan delay;
        public Bonus(double x, double y, Game game, string name="", int zindex = 0) : base(x, y, game, name, zindex)
        {
            this.delay = new TimeSpan(0,0,3);
        }

        public override string TypeName => "Bonus";

        public void Animate(TimeSpan dt)
        {
            this.delay -= dt;
           if(this.delay <= TimeSpan.Zero)
            {
                TheGame.RemoveItem(this);
            }
        }


        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "Player")
            {
                TheGame.RemoveItem(this);
            }
        }



    }
}
