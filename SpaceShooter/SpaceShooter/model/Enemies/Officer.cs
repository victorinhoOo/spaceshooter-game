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
        private List<string> explosionSprites;
        private int currentExplosionIndex;
        private bool isExploding;
        public bool IsExploding { get => isExploding; set => isExploding = value; }

        private TheGame g;
        public Officer(double x, double y, Game g, string name = "Ship_3.png") : base(x, y, g, name, -100)
        {
            Random random = new Random();
            double randomAngle = random.NextDouble() * 40 - 20; // Génère un angle aléatoire entre -20 et 20
            base.Angle = randomAngle;
            base.Speed = 400;
            this.g = (TheGame) g;

            explosionSprites = new List<string>()
            {
                "explosion1.png",
                "explosion2.png",
                "explosion3.png",
                "explosion4.png",
                "explosion5.png"
            };
            currentExplosionIndex = 0;
            isExploding = false;
        }

        /// <summary>
        /// Tire un laser
        /// </summary>
        /// <author>Victor Duboz</author>
        public void ShootLaser()
        {
            Laser laser = new Laser(this.Left, this.Bottom - 10, this.TheGame);
            TheGame.AddItem(laser);
        }

        private Random random = new Random();


        /// <summary>
        /// Effectue l'animation de l'officer
        /// </summary>
        /// <param name="dt">durée écoulée depuis la dernière animation</param>
        /// <author>Victor Duboz</author>
        public override void Animate(TimeSpan dt)
        {
            if (isExploding)
            {
                if (currentExplosionIndex < explosionSprites.Count)
                {
                    this.ChangeSprite(explosionSprites[currentExplosionIndex]);
                    currentExplosionIndex++;
                    if (currentExplosionIndex >= explosionSprites.Count)
                    {
                        TheGame.RemoveItem(this);
                        this.GenerateBonus();
                        g.Score += 2;
                        --Amount;
                    }
                }
                return;
            }

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

            if (timeSinceLastShot >= shootInterval)
            {
                ShootLaser();               
                double delay = random.NextDouble() * 2 + 1; // délai aléatoire entre les tirs (entre 1 et 3 secondes)
                shootInterval = TimeSpan.FromSeconds(delay);
                timeSinceLastShot = TimeSpan.Zero; // Réinitialise le temps écoulé depuis le dernier tir
            }

            MoveDA(Speed * dt.TotalSeconds, Angle);
            timeSinceLastShot += dt;
        }

        /// <summary>
        /// Gère les collisions de l'officier avec les autres items du jeu
        /// </summary>
        /// <param name="other">autre item</param>
        /// <author>Victor Duboz</author>
        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "PlayerBullet")
            {

                if (!isExploding)
                {
                    isExploding = true;
                    currentExplosionIndex = 0;
                    TheGame.RemoveItem(other);
                    return;
                }


            }
            if (other.TypeName == "Enemy")
            {
                Angle = (360 + 180 - Angle) % 360;
            }
        }
    }
}
