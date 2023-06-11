using System;
using System.Diagnostics;
using System.Windows.Input;
using IUTGame;
using PetitJeu;
using SpaceShooter.model.Projectiles;

namespace SpaceShooter.model.Space
{
    class Player : GameItem, IAnimable, IKeyboardInteract
    {
        private bool compte = false;
        private double time = 0;
        private ObjScore objScore;
        private int life = 3;
        private Game game;
        private double speed = 10;

        public int Life { get => life; set => life = value; }

        private TimeSpan timeSinceLastShot = TimeSpan.Zero;
        private TimeSpan shootRecoveryTime = TimeSpan.FromSeconds(0.5); // Temps de récupération entre les tirs

        public Player(double x, double y, Game g) : base(x, y, g, "Ship_1.png")
        {
            /*objScore = new ObjScore(0, 10, 10, g);
            TheGame.AddItem(objScore);*/

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
            /*if (!compte)
            {
                // Score à changer ainsi que la limite 
                objScore.Score++;
                if (objScore.Score >= 10)
                    TheGame.Win();
                compte = true;
                time = 0;
                /*PlaySound("music.mp3");
            }
            if (other.GetType() == typeof(Shoot))
            {

            }
            */

            if(other.TypeName == "Speed")
            {
                this.speed *= 1.1;
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
