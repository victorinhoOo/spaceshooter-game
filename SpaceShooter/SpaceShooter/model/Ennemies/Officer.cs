using IUTGame;
using SpaceShooter.model.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Ennemies
{
    public class Officer : Enemy
    {

        private TimeSpan shootInterval = TimeSpan.FromSeconds(2); // Intervalle de 2 secondes entre les tirs
        private TimeSpan timeSinceLastShot = TimeSpan.Zero; // Temps écoulé depuis le dernier tir
        public Officer(double x, double y, Game g, string name = "Ship_3.png") : base(x, y, g, name, -100)
        {
            Random random = new Random();
            double randomAngle = random.NextDouble() * 40 - 20; // Génère un angle aléatoire entre -20 et 20
            base.Angle = randomAngle;
            base.Speed = 400;
        }
        public override string TypeName => "Officer";
        public void ShootLaser()
        {
            Laser laser = new Laser(this.Left, this.Bottom - 10, this.TheGame);
            TheGame.AddItem(laser);
        }

        /// <summary>
        /// Effectue l'animation de l'officer
        /// </summary>
        /// <param name="dt">durée écoulée depuis la dernière animation</param>
        /// <author>Victor Duboz</author>
        public override void Animate(TimeSpan dt)
        {
            if (this.Top < 0)
            {
                Top = 0;
                Angle = 360 - Angle;
            }
            else if (Bottom > GameHeight - 100)
            {
                Bottom = GameHeight - 100;
                Angle = 360 - Angle;
            }
            else if (Left < 0)
            {
                Angle = (360 + 180 - Angle) % 360;
                Left = 0;
            }
            else if (Right > GameWidth)
            {
                Angle = (360 + 180 - Angle) % 360;
                Right = GameWidth;
            }

            MoveDA(Speed * dt.TotalSeconds, Angle);
            timeSinceLastShot += dt;

            if (timeSinceLastShot >= shootInterval)
            {
                ShootLaser();
                timeSinceLastShot = TimeSpan.Zero; // Réinitialise le temps écoulé depuis le dernier tir
            }

            TimeSpan test = new TimeSpan(0, 0, 0, 0, 0);
            if (Waiting >= test) { Waiting -= dt; }
        }

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "Player")
            {
                TheGame.RemoveItem(this);
            }
            if (other.TypeName == "PlayerBullet")
            {

                //this.ChangeSprite("explosion.png");
                TheGame.RemoveItem(this);
                this.GenerateBonus();
                TheGame.RemoveItem(other);
                Player.Score += 1;
                --Amount;
            }
            if (other.TypeName == "Enemy")
            {
                Angle = (360 + 180 - Angle) % 360;
            }

        }

    }
}
