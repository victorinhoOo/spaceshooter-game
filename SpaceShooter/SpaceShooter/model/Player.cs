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

        public int Life { get => life; set => life = value; }

        public Player(double x, double y, Game g) : base(x, y, g, "Ship_1.png")
        {
            /*objScore = new ObjScore(0, 10, 10, g);
            TheGame.AddItem(objScore);*/

            this.game = g;
        }
        public override string TypeName => "Player";

        

        public void Animate(TimeSpan dt)
        {
            if(this.Top <= 0)
            {
                this.Top = 0;
            }
            if(this.Left <= 0)
            {
                this.Left = 0;
            }
            if(this.Left > this.GameWidth-30) 
            {
                this.Left = this.GameWidth-30;
            }
            if(this.Top > this.game.Screen.Height-30)
            {
                this.Top = this.game.Screen.Height-30;
            }
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
            PlayerBullet bullet = new PlayerBullet(this.Left, this.Top -30, this.TheGame);
            TheGame.AddItem(bullet);
        }

        public void KeyDown(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    MoveXY(-10, 0); break;
                case Key.Right:
                    MoveXY(10, 0); break;
                case Key.Up:
                    MoveXY(0, -10); break;
                case Key.Down :
                    MoveXY(0, 10); break;
                case Key.S: 
                    Shoot(); break;
                

            }
        }

        public void KeyUp(Key key)
        {
            KeyDown( key);
        }
    }
}
