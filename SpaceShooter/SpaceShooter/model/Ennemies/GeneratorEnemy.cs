using System;
using IUTGame;

namespace SpaceShooter.model.Ennemies
{
    /// <summary>
    /// Gère la fabrique d'ennemis.
    /// </summary>
    /// <author>Victor Duboz</author>
    /// <author>Théo Cornu</author>
    public class GeneratorEnemy : GameItem, IAnimable
    {
        private TimeSpan timeToCreate;
        private TimeSpan soldierInterval;
        private Random random;

        /// <summary>
        /// Constructeur de la fabrique d'ennemis
        /// </summary>
        /// <param name="g">Le jeu</param>
        /// <author>Victor Duboz</author>
        public GeneratorEnemy(Game g) : base(0, 0, g)
        {
            random = new Random();
            timeToCreate = GetRandomTimeToCreate();
            soldierInterval = TimeSpan.FromSeconds(10); // Intervalle entre les apparitions de soldats
        }

        /// <summary>
        /// Propriété qui renvoi le type de la fabrique d'ennemi.
        /// </summary>
        public override string TypeName => "generator";

        /// <summary>
        /// Effectue la génération d'ennemis
        /// </summary>
        /// <param name="dt">durée écoulée depuis la dernière génération</param>
        /// <author>Victor Duboz</author>
        public void Animate(TimeSpan dt)
        {
            timeToCreate -= dt;

            if (timeToCreate.TotalMilliseconds < 0)
            {
                CreateAsteroid();
                timeToCreate = GetRandomTimeToCreate();
            }

            // Vérifie s'il est temps de faire apparaître un soldat
            soldierInterval -= dt;
            if (soldierInterval.TotalMilliseconds < 0)
            {
                CreateSoldier();
                soldierInterval = AdjustSoldierInterval();
            }
        }

        private TimeSpan GetRandomTimeToCreate()
        {
            int alea = random.Next(10) + 2;
            return TimeSpan.FromSeconds(alea);
        }

        private void CreateAsteroid()
        {
            double x = random.NextDouble() * GameWidth;
            double y = random.NextDouble() * GameHeight / 2;

            Asteroid b = new Asteroid(x, y, TheGame);
            TheGame.AddItem(b);
        }

        private void CreateSoldier()
        {
            double x = GameWidth / 2;
            double y = GameHeight / 2;
            Soldier soldier = new Soldier(x, y, TheGame);
            TheGame.AddItem(soldier);
        }

        private TimeSpan AdjustSoldierInterval()
        {
            // Augmente l'intervalle entre les apparitions de soldats au fil du temps
            soldierInterval += TimeSpan.FromSeconds(2);
            return soldierInterval;
        }

        public override void CollideEffect(GameItem other)
        {
   
        }
    }
}
