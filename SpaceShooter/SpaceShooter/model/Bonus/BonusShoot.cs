using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Bonus
{
    /// <summary>
    /// 
    /// </summary>
    /// <author>Clément Boutet</author>
    public class BonusShoot : Bonus
    {

        public BonusShoot(double x, double y, Game game, string spriteName = "shoot.png", int zindex = 0) : base(x, y, game, spriteName, zindex)
        {
            base.ChangeSprite(spriteName);
        }

        public override string TypeName => "Shoot";
    }
}
