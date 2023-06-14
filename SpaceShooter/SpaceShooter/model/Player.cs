using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using IUTGame;
using SpaceShooter.model.Projectiles;

namespace SpaceShooter.model
{
    /// <summary>
    /// Classe qui représente le joueur avec toutes ses méthodes
    /// </summary>
    /// <author>Théo Cornu</author>
    public class Player : GameItem, IAnimable, IKeyboardInteract
    {


        private Game game;

        private double speed = 10;

        public double Speed { get => speed; }

        private TimeSpan timeSinceLastShot = TimeSpan.Zero;

        private TimeSpan shootRecoveryTime = TimeSpan.FromSeconds(0.5);
        public TimeSpan ShootRecoveryTime { get => shootRecoveryTime; set => shootRecoveryTime = value; }


        private List<string> explosionSprites; // Liste des sprites d'explosion
        private int currentExplosionIndex; // index de l'explosion du joueur

        private bool isExploding; // joueur en train d'exploser ou non
        public bool IsExploding { get => isExploding; set => isExploding = value; }

        public Player(double x, double y, Game g) : base(x, y, g, "Ship_1.png")
        {
            this.game = g;
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

        public override string TypeName => "Player";




        /// <author>Clément Boutet</author>
        /// <author>Victor Duboz</author>
        public void Animate(TimeSpan dt)
        {
            if (isExploding)
            {
                if (currentExplosionIndex < explosionSprites.Count)
                {
                    this.ChangeSprite(explosionSprites[currentExplosionIndex]);
                    currentExplosionIndex++;
                    if (currentExplosionIndex >= explosionSprites.Count)
                    {
                        TheGame.Loose();
                    }
                }
                return;
            }
            if (this.Top <= 0)
            {
                this.Top = 0;
            }
            if (this.Left <= 0)
            {
                this.Left = 0;
            }
            if (this.Left > this.GameWidth - 30)
            {
                this.Left = this.GameWidth - 30;
            }
            if (this.Top > this.game.Screen.Height - 30)
            {
                this.Top = this.game.Screen.Height - 30;
            }

            // Met à jour le temps écoulé depuis le dernier tir
            timeSinceLastShot += dt;
        }

        ///<author>Victor Duboz</author>
        /// <author>Clément Boutet</author>
        public override void CollideEffect(GameItem other)
        {

            if(other is Bonus.Bonus)
            {
                PlaySound("bonusSound.mp3");
                if (other.TypeName == "Speed")
                {
                    this.speed *= 1.1;
                }

                if (other.TypeName == "Shoot")
                {
                    this.shootRecoveryTime -= TimeSpan.FromSeconds(0.1);
                }
                TheGame.RemoveItem(other);
            }          

            if ((other.TypeName == "Enemy")||(other.TypeName == "Projectile")||(other.TypeName=="Asteroid"))
            {
                if (!isExploding)
                {
                    isExploding = true;
                    currentExplosionIndex = 0;
                    TheGame.RemoveItem(other);
                }
            }
        }

        public void Shoot()
        {
            PlayerBullet bullet = new PlayerBullet(this.Left, this.Top - 30, this.TheGame);
            TheGame.AddItem(bullet);
        }

        /// <author>Clément Boutet</author>
        /// <author>Théo Cornu</author>
        public void KeyDown(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    MoveXY(-this.Speed, 0);
                    break;
                case Key.Right:
                    MoveXY(this.Speed, 0);
                    break;
                case Key.Up:
                    MoveXY(0, -this.Speed) ;
                    break;
                case Key.Down:
                    MoveXY(0, this.Speed);
                    break;
                case Key.S:
                    if (timeSinceLastShot >= ShootRecoveryTime)
                    {
                        Shoot();
                        timeSinceLastShot = TimeSpan.Zero; // Réinitialise le temps écoulé depuis le dernier tir
                    }
                    break;
            }
        }

        public void KeyUp(Key key)
        {
            KeyDown(key);
        }
    }
}
