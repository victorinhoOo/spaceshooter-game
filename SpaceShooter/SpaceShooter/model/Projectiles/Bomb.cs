using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Projectiles
{
    public class Bomb : Projectile
    {
        public Bomb(double x, double y, Game g, string name = "", int zindex = 0) : base(x, y, g, name, zindex)
        {
        }

        public void Explode()
        {
            
        }

        public override void Animate(TimeSpan dt)
        {
            throw new NotImplementedException();
        }

        public override void CollideEffect(GameItem other)
        {
            throw new NotImplementedException();
        }
    }
}
