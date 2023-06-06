using System;
using System.Reflection.Metadata;
using System.Windows;
using IUTGame;

namespace SpaceShooter.model.Vaisseaux.Enemi
{
    public class GenerateurBalle : GameItem, IAnimable
    {
        private TimeSpan timeToCreate;
        public GenerateurBalle(Game g) : base(0, 0, g)
        {
            timeToCreate = new TimeSpan(0, 0, 2);
        }
        public override string TypeName => "generateur";

        public void Animate(TimeSpan dt)
        {
            timeToCreate = timeToCreate - dt;



            if (timeToCreate.TotalMilliseconds < 0)
            {
                Random r = new Random();
                double x = r.NextDouble() * GameWidth;
                double y = r.NextDouble() * GameHeight / 2;

                Balle b = new Balle(x, y, TheGame);
                TheGame.AddItem(b);
                double ms = r.NextDouble() * 5000 + 1000;
                timeToCreate = new TimeSpan(0, 0, 0, 0, (int)ms);



            }
            Random Z = new Random();
            double random = Z.Next(1, 500);
            if (random == 99)
            {

                double x = GameWidth / 2;
                double y = GameHeight / 2;
                SuperBalle superBalle = new SuperBalle(x, y, TheGame);
                superBalle.Vitesse = 1000;
                superBalle.Angle = Z.Next(180, 361);
                TheGame.AddItem(superBalle);


            }
        }

        public override void CollideEffect(GameItem other)
        {

        }
    }
}
