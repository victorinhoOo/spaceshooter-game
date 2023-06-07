using System;
using System.Reflection.Metadata;
using System.Windows;
using IUTGame;
using SpaceShooter.model.Space.Enemy;

namespace SpaceShooter.model.Vaisseaux.Enemi
{
    public class GeneratorEnemy : GameItem, IAnimable
    {
        private TimeSpan timeToCreate;
        public GeneratorEnemy(Game g) : base(0, 0, g)
        {
            timeToCreate = new TimeSpan(0, 0, 2);
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

                Soldier b = new Soldier(x, y, TheGame);
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
                Officer officer = new Officer(x, y, TheGame, "Shi^p_5.png");
                TheGame.AddItem(officer);


            }
        }

        public override void CollideEffect(GameItem other)
        {

        }
    }
}
