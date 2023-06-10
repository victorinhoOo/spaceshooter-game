using System;
using System.Reflection.Metadata;
using System.Windows;
using IUTGame;

namespace SpaceShooter.model.Ennemies
{
    public class GeneratorEnemy : GameItem, IAnimable
    {
        private TimeSpan timeToCreate;
        public GeneratorEnemy(Game g) : base(0, 0, g)
        {
            Random random = new Random();
            int alea = random.Next(10) + 2;
            timeToCreate = new TimeSpan(0, 0, alea);
        }
        public override string TypeName => "generator";

        public void Animate(TimeSpan dt)
        {
            timeToCreate = timeToCreate - dt;



            if (timeToCreate.TotalMilliseconds < 0)
            {
                Random r = new Random();
                double x = r.NextDouble() * GameWidth;
                double y = r.NextDouble() * GameHeight / 2;

                Asteroid b = new Asteroid(x, y, TheGame);
                TheGame.AddItem(b);
                double ms = r.NextDouble() * 5000 + 1000;
                timeToCreate = new TimeSpan(0, 0, 0, 0, (int)ms);



            }
            Random Z = new Random();//systeme de chance plus augmente la range plus c rare 
            //d'avoir une apparition 
            double random = Z.Next(1, 500);
            if (random == 99)
            {

                double x = GameWidth / 2;
                double y = GameHeight / 2;
                Soldier soldier = new Soldier(x, y, TheGame);
                TheGame.AddItem(soldier);


            }
        }

        public override void CollideEffect(GameItem other)
        {

        }
    }
}
