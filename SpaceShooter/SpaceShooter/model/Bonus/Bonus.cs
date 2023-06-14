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
    /// <summary>
    /// 
    /// </summary>
    /// <author>Clément Boutet</author>
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
            MoveDA(100 * dt.TotalSeconds, 90);
        }


        public override void CollideEffect(GameItem other)
        {
        }



    }
}
