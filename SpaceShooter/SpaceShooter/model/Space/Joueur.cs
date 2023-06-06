using System;
using System.Windows.Input;
using IUTGame;
namespace PetitJeu
{
    class Player : GameItem, IAnimable, IKeyboardInteract
    {        
        private bool compte = false;
        private double time = 0;
        private ObjScore objScore;

        public Joueur(double x, double y, Game g)
            :base(x,y,g,"Player.png")
        {
            objScore = new ObjScore(0, 10, 10, g);
            TheGame.AddItem(objScore);
        }
        public override string TypeName => "Player";

        public void Animate(TimeSpan dt)
        {
            if(compte)
            {
                time += dt.TotalMilliseconds;
                if (time > 500)
                    compte = false;
            }
        }

        public override void CollideEffect(GameItem other)
        {
            if(!compte)
            {
                objScore.Score++;
                if (objScore.Score >= 10)
                    TheGame.Win();
                compte = true;
                time = 0;
                PlaySound("blop.mp3");
            }
            if (other.TypeName == "SuperBalle")
            {
                TheGame.Win();
            }
            

        }

        public void KeyDown(Key key)
        {
            switch(key)
            {
                case Key.Left:
                    MoveXY(-10, 0);break;
                case Key.Right:
                    MoveXY(10, 0);break;
            }
        }

        public void KeyUp(Key key)
        {
            
        }
    }
}
