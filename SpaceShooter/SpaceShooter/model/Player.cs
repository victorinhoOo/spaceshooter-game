using System;
using System.Diagnostics;
using System.Windows.Input;
using IUTGame;
using SpaceShooter.model.Projectiles;

namespace SpaceShooter.model
{
    class Player : GameItem, IAnimable, IKeyboardInteract
    {


        private Game game;



        private int life = 3;
        public int Life { get => life; set => life = value; }

        private double speed = 10;

        private TimeSpan timeSinceLastShot = TimeSpan.Zero;

        private TimeSpan shootRecoveryTime = TimeSpan.FromSeconds(0.5); 

        /// <summary>
        /// Propriété qui permet l'accès et la modification du délai de récupération entre les tirs du joueur
        /// </summary>
        /// <author>Victor Duboz</author>
        public TimeSpan ShootRecoveryTime { get => shootRecoveryTime; set => shootRecoveryTime = value; }

        public Player(double x, double y, Game g) : base(x, y, g, "Ship_1.png")
        {
            this.game = g;
        }

        public override string TypeName => "Player";

        public void Animate(TimeSpan dt)
        {
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
            }

            

            

            if (other is Ennemies.Enemy)
            {
                Life -= 1;
                if (Life == 0)
                {
                    TheGame.Loose();
                }
            }
        }

        public void Shoot()
        {
            PlayerBullet bullet = new PlayerBullet(this.Left, this.Top - 30, this.TheGame);
            TheGame.AddItem(bullet);
        }

        public void KeyDown(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    MoveXY(-this.speed, 0);
                    break;
                case Key.Right:
                    MoveXY(this.speed, 0);
                    break;
                case Key.Up:
                    MoveXY(0, -this.speed) ;
                    break;
                case Key.Down:
                    MoveXY(0, this.speed);
                    break;
                case Key.S:
                    if (timeSinceLastShot >= shootRecoveryTime)
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
