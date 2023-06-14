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
        private TimeSpan timeToCreateAsteroid;
        private TimeSpan timeToCreateSoldier;
        private TimeSpan timeToCreateOfficer;
        private TimeSpan soldierInterval;
        private TimeSpan officerInterval;
        private TimeSpan soldierIntervalMin;
        private TimeSpan officerIntervalMin;
        private Random random;

        private static int amount = 0;
        public static int Amount { get => amount; set => amount = value; }

        /// <summary>
        /// Constructeur de la fabrique d'ennemis
        /// </summary>
        /// <param name="g">Le jeu</param>
        /// <author>Victor Duboz</author>
        public GeneratorEnemy(Game g) : base(0, 0, g)
        {
            random = new Random();
            timeToCreateAsteroid = GetRandomTimeToCreate();
            timeToCreateSoldier = TimeSpan.FromSeconds(3); // Temps initial pour la création de soldats
            timeToCreateOfficer = TimeSpan.FromSeconds(5); // Temps initial pour la création d'officiers
            soldierInterval = TimeSpan.FromSeconds(5); // Intervalle entre les apparitions de soldats
            officerInterval = TimeSpan.FromSeconds(10); // Intervalle entre les apparitions d'officiers
            soldierIntervalMin = TimeSpan.FromSeconds(1); // Intervalle minimum entre les apparitions de soldats
            officerIntervalMin = TimeSpan.FromSeconds(3); // Intervalle minimum entre les apparitions d'officiers
        }

        /// <summary>
        /// Propriété qui renvoie le type de la fabrique d'ennemis
        /// </summary>
        public override string TypeName => "generator";

        public TimeSpan TimeToCreateAsteroid { get => timeToCreateAsteroid; set => timeToCreateAsteroid = value; }
        public TimeSpan TimeToCreateSoldier { get => timeToCreateSoldier; set => timeToCreateSoldier = value; }
        public TimeSpan TimeToCreateOfficer { get => timeToCreateOfficer; set => timeToCreateOfficer = value; }

        /// <summary>
        /// Effectue la génération d'ennemis
        /// </summary>
        /// <param name="dt">Durée écoulée depuis la dernière génération</param>
        /// <author>Victor Duboz</author>
        public void Animate(TimeSpan dt)
        {
            timeToCreateAsteroid -= dt;
            timeToCreateSoldier -= dt;
            timeToCreateOfficer -= dt;

            if (timeToCreateAsteroid.TotalMilliseconds < 0)
            {
                CreateAsteroid();
                timeToCreateAsteroid = GetRandomTimeToCreate();
            }

            if (timeToCreateSoldier.TotalMilliseconds < 0)
            {
                CreateSoldier();
                timeToCreateSoldier = AdjustSoldierInterval();
            }

            if (timeToCreateOfficer.TotalMilliseconds < 0)
            {
                CreateOfficer();
                timeToCreateOfficer = AdjustOfficerInterval();
            }
        }

        private TimeSpan GetRandomTimeToCreate()
        {
            int alea = random.Next(4) + 1;
            return TimeSpan.FromSeconds(alea);
        }

        private void CreateAsteroid()
        {
            double x = random.NextDouble() * GameWidth;
            double y = 0; // Position en haut de l'écran

            Asteroid asteroid = new Asteroid(x, y, TheGame);
            TheGame.AddItem(asteroid);
        }

        private void CreateSoldier()
        {
            double x = random.NextDouble() * GameWidth;
            double y = random.NextDouble() * (GameHeight / 2); // Position aléatoire en haut de l'écran
            Soldier soldier = new Soldier(x, y, TheGame);
            TheGame.AddItem(soldier);
        }

        private void CreateOfficer()
        {
            double x = random.NextDouble() * GameWidth;
            double y = random.NextDouble() * (GameHeight / 2); // Position aléatoire en haut de l'écran
            Officer officer = new Officer(x, y, TheGame);
            TheGame.AddItem(officer);
        }

        /// <summary>
        /// Diminue l'intervalle entre les apparitions de soldats au fil du temps
        /// </summary>
        private TimeSpan AdjustSoldierInterval()
        {
            double intervalReduction = random.NextDouble() * 0.8 + 0.4; // Réduction aléatoire de l'intervalle à chaque génération 

            soldierInterval -= TimeSpan.FromSeconds(intervalReduction);

            if (soldierInterval < soldierIntervalMin)
            {
                soldierInterval = soldierIntervalMin;
            }

            return soldierInterval;
        }


        // Diminue l'intervalle entre les apparitions d'officiers au fil du temps
        private TimeSpan AdjustOfficerInterval()
        {
            double intervalReduction = random.NextDouble() * 0.6 + 0.2; // Réduction aléatoire de l'intervalle à chaque génération 

            officerInterval -= TimeSpan.FromSeconds(intervalReduction);

            if (officerInterval < officerIntervalMin)
            {
                officerInterval = officerIntervalMin;
            }

            return officerInterval;
        }

        public override void CollideEffect(GameItem other)
        {
        }
    }
}
