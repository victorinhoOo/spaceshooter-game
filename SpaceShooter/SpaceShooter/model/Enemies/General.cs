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
    /// Classe qui représente les généraux avec toutes ses méthodes
    /// </summary>
    /// <author>Alexandre Hugot</author>
    public class General : Enemy
    {

        private TimeSpan shootInterval = TimeSpan.FromSeconds(0.5); // Intervalle entre les tirs
        private TimeSpan timeSinceLastShot = TimeSpan.Zero; // Temps écoulé depuis le dernier tir
        private List<string> explosionSprites;
        private int currentExplosionIndex;
        private bool isExploding;
        public bool IsExploding { get => isExploding; set => isExploding = value; }

        private TheGame g;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="x">coordonnee d'apparition</param>
        /// <param name="y">coordonnee d'apparition</param>
        /// <param name="g">le jeu dans lequel il apparait</param>
        /// <param name="name">sprite</param>
        public General(double x, double y, Game g, string name = "general.png") : base(x, y, g, name, -100)
        {
            base.Speed = 100;
            Random random = new Random();
            double randomAngle = random.NextDouble() * 40 - 20; // Génère un angle aléatoire entre -20 et 20
            base.Angle = randomAngle;
            this.g = (TheGame)g;

            explosionSprites = new List<string>()
            {
                "explosion1.png",
                "explosion2.png",
                "explosion3.png",
                "explosion4.png",
                "explosion5.png"
            };
            currentExplosionIndex = 0;
            IsExploding = false;
        }

        /// <summary>
        /// Tire un laser
        /// </summary>
        public void ShootLaser()
        {
            Laser laser = new Laser(this.Left, this.Bottom - 10, this.TheGame);
            TheGame.AddItem(laser);
        }

        private Random random = new Random();



        /// <summary>
        /// Effectue l'animation du général
        /// </summary>
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
                timeSinceLastShot = TimeSpan.Zero; // Réinitialise le temps écoulé depuis le dernier tir
            }

            MoveDA(Speed * dt.TotalSeconds, Angle);
            timeSinceLastShot += dt;
        }

        /// <summary>
        /// Gère les collisions du général avec les autres items du jeu
        /// </summary>
        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "PlayerBullet")
            {

                if (!IsExploding)
                {
                    IsExploding = true;
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
