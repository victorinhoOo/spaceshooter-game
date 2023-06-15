using System;
using IUTGame;

namespace SpaceShooter.model.Ennemies
{
    /// <summary>
    /// Gère la fabrique d'ennemis.
    /// </summary>
    /// <author>Victor Duboz</author>
    /// <author>Théo Cornu</author>
    /// <author>Alexandre Hugot</author>
    public class GeneratorEnemy : GameItem, IAnimable
    {
        private TimeSpan timeToCreateAsteroid;
        private TimeSpan timeToCreateSoldier;
        private TimeSpan timeToCreateOfficer;
        private TimeSpan timeToCreateGeneral;
        private TimeSpan soldierInterval;
        private TimeSpan officerInterval;
        private TimeSpan generalInterval;
        private TimeSpan soldierIntervalMin;
        private TimeSpan officerIntervalMin;
        private TimeSpan generalIntervalMin;
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
            timeToCreateGeneral = TimeSpan.FromSeconds(10); // Temps initial pour la création de généraux
            soldierInterval = TimeSpan.FromSeconds(5); // Intervalle entre les apparitions de soldats
            officerInterval = TimeSpan.FromSeconds(10); // Intervalle entre les apparitions d'officiers
            generalInterval = TimeSpan.FromSeconds(20); // Intervalle entre les apparitions de généraux
            soldierIntervalMin = TimeSpan.FromSeconds(2); // Intervalle minimum entre les apparitions de soldats
            officerIntervalMin = TimeSpan.FromSeconds(3); // Intervalle minimum entre les apparitions d'officiers
            generalIntervalMin = TimeSpan.FromSeconds(7); // Intervalle minimum entre les apparitions de généraux
        }

        /// <summary>
        /// Propriété qui renvoie le type de la fabrique d'ennemis
        /// </summary>
        public override string TypeName => "generator";

        public TimeSpan TimeToCreateAsteroid { get => timeToCreateAsteroid; set => timeToCreateAsteroid = value; }
        public TimeSpan TimeToCreateSoldier { get => timeToCreateSoldier; set => timeToCreateSoldier = value; }
        public TimeSpan TimeToCreateOfficer { get => timeToCreateOfficer; set => timeToCreateOfficer = value; }
        public TimeSpan TimeToCreateGeneral { get => timeToCreateGeneral; set => timeToCreateGeneral = value; }

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
            timeToCreateGeneral -= dt;

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

            if (timeToCreateGeneral.TotalMilliseconds < 0)
            {
                CreateGeneral();
                timeToCreateGeneral = AdjustGeneralInterval();
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

        private void CreateGeneral()
        {
            double x = random.NextDouble() * GameWidth;
            double y = random.NextDouble() * (GameHeight / 2); // Position aléatoire en haut de l'écran
            General general = new General(x, y, TheGame);
            TheGame.AddItem(general);
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

        // Diminue l'intervalle entre les apparitions de generaux au fil du temps
        private TimeSpan AdjustGeneralInterval()
        {
            double intervalReduction = random.NextDouble() * 0.5 + 0.2; // Réduction aléatoire de l'intervalle à chaque génération 

            generalInterval -= TimeSpan.FromSeconds(intervalReduction);

            if (generalInterval < generalIntervalMin)
            {
                generalInterval = generalIntervalMin;
            }

            return generalInterval;
        }

        public override void CollideEffect(GameItem other)
        {
        }
    }
}
