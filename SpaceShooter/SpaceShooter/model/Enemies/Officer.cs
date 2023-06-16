using IUTGame;
using SpaceShooter.model.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Ennemies
{
    /// <summary>
    /// Classe qui représente les officiers avec toutes ses méthodes 
    /// </summary>
    /// <author>Victor Duboz</author>
    /// <author>Théo Cornu</author>
    public class Officer : Enemy
    {

        private TimeSpan shootInterval = TimeSpan.FromSeconds(2); // Intervalle de 2 secondes entre les tirs
        private TimeSpan timeSinceLastShot = TimeSpan.Zero; // Temps écoulé depuis le dernier tir
        private List<string> explosionSprites;
        private int currentExplosionIndex;
        private bool isExploding;
        public bool IsExploding { get => isExploding; set => isExploding = value; }

        private TheGame g;

        /// <summary>
        /// Construit un officier, le fait apparaître avec un angle aléatoire parmi un interval
        /// </summary>
        /// <param name="x">Coordonnées d'apparition</param>
        /// <param name="y">Coordonnées d'apparition</param>
        /// <param name="g">Jeu auquel il appartient</param>
        /// <param name="name">sprite du soldat</param>
        public Officer(double x, double y, Game g, string name = "Ship_3.png") : base(x, y, g, name, -100)
        {
            Random random = new Random();
            double randomAngle;

            if (random.NextDouble() < 0.5)
            {
                randomAngle = random.NextDouble() * 50 - 25; // apparaît entre -25 et 25
            }
            else
            {
                randomAngle = random.NextDouble() * 50 - 25 + 180; // apparaît avec un angle opposé
            }
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
            if (isExploding) // si l'officier est en train d'exploser
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
                        --GeneratorEnemy.Amount;
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
