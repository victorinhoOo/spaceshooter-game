using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Ennemies
{
    /// <summary>
    /// Classe qui représente les généraux avec toutes ses méthodes
    /// </summary>
    /// <author>Théo Cornu</author>
    public class General : Enemy
    {
        public General(double x, double y, Game g, string name = "Ship_5.png") : base(x, y, g, name, -100)
        {



        }
        public override string TypeName => "General";

        public void Shoot()
        {

        }

        public void ShootMissile()
        {

        }
        public override void Animate(TimeSpan dt)
        {

        }
    }
}
