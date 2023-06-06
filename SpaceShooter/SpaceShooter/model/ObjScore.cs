using IUTGame;
using System;


namespace PetitJeu
{
    class ObjScore : IUTGame.GameItem
    {
        private int score;
        public ObjScore(int score, double x, double y, Game g)
            :base(x,y,g)
        {
            this.score = score;
        }

        public int Score
        {
            get { return score; }
            set
            {
                score = Math.Min(10,value);
                ChangeSprite(string.Format("{0}.png", score));
            }
        }
        
        public override string TypeName => "score";

        public override bool IsCollide(GameItem other)
        {
            return false;
        }
        public override void CollideEffect(GameItem other)
        {
            
        }

        
    }
}
