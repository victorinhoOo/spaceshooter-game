using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Bonus
{
    public class BonusSpeed : Bonus
    {
        public BonusSpeed(double x, double y, Game game, string spriteName = "speed.png", int zindex = 0) : base(x, y, game, spriteName, zindex)
        {
            base.ChangeSprite(spriteName);
        }

        public override string TypeName => "Speed";
    }
}
